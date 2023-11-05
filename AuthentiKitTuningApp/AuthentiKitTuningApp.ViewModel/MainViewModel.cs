using AuthentiKitTuningApp.Processor;
using AuthentiKitTuningApp.Common.DataProvider;
using AuthentiKitTuningApp.Common.Model;
using AuthentiKitTuningApp.Processor.Hardware;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Threading;
using AuthentiKitTuningApp.Processor.Data;
using System.Collections.Generic;

namespace AuthentiKitTuningApp.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private readonly int MAX_MAPPINGS = 20;
        private IDataHandler _mainDataHandler;
        public ObservableCollection<MappingViewModel> Mappings { get; set; } = new();
        public ObservableCollection<MappingType> MappingTypes = MappingType.GetMappingTypes();
        public ObservableCollection<InputButton> InputButtonsA = HardwareInfo.GetInputButtons();
        public ObservableCollection<InputButton> InputButtonsB = HardwareInfo.GetInputButtons();
        public ObservableCollection<InputAxis> InputAxes = HardwareInfo.GetInputAxes();
        public ObservableCollection<OutputChannel> OutputAxes = HardwareInfo.GetOutputAxes();
        public ObservableCollection<OutputChannel> OutputButtonsA = HardwareInfo.GetOutputButtons();
        public ObservableCollection<OutputChannel> OutputButtonsB = HardwareInfo.GetOutputButtons();
        public bool CanAddMapping { get; private set; }

        public bool AtLeastOneMapping { get => Mappings.Count > 0; }

        public MainViewModel()
        {
            _mainDataHandler = new DataHandler();
            CanAddMapping = true;
        }
        public void StartAll()
        {
            foreach (var mapping in Mappings)
            {
                mapping.Activate();
                Thread.Sleep(60);
            }
        }
        public void Stop()
        {
            foreach (var mapping in Mappings)
            {
                mapping.Deactivate();
            }
        }

        public void LoadMappings()
        {
            if (SaveFileExists())
                LoadMappings(GetSaveFilePath());
        }
        public void LoadMappings(string filePath)
        {
            Stop();
            Mappings.Clear();
            _mainDataHandler.SetSaveFilePath(filePath);
            var mappings = _mainDataHandler.LoadMappings(InputButtonsA, InputButtonsB, InputAxes, OutputAxes, OutputButtonsA, OutputButtonsB);
            foreach (var mapping in mappings)
            {
                Mappings.Add(new MappingViewModel(mapping, InputButtonsA, InputButtonsB, InputAxes, OutputAxes, OutputButtonsA, OutputButtonsB));
            }
        }
        public void NewMapping()
        {
            if (Mappings.Count < MAX_MAPPINGS)
            {
                Mappings.Add(new MappingViewModel(_mainDataHandler.GetBlankMapping(), InputButtonsA, InputButtonsB, InputAxes, OutputAxes, OutputButtonsA, OutputButtonsB));
            }

            if (Mappings.Count >= MAX_MAPPINGS)
            {
                CanAddMapping = false;
            }
        }
        public void RemoveMapping(MappingViewModel mappingToDelete)
        {
            foreach (var m in Mappings)
            {
                if (m.Equals(mappingToDelete))
                {
                    m.Deactivate();
                    Mappings.Remove(m);
                    return;
                }
            }
        }

        public void SaveMappings()
        {
            ObservableCollection<MappingDTO> mappings = new();
            foreach (var m in Mappings)
            {
                mappings.Add(m.getMappingDTO());
            }
            _mainDataHandler.SaveMappings(mappings, InputAxes);
            foreach (var m in Mappings)
            {
                m.UpdateStatus();
            }
        }
        public void SaveMappings(string filePath)
        {
            Debug.WriteLine("Saving to " + filePath);
            ObservableCollection<MappingDTO> mappings = new();
            foreach (var m in Mappings)
            {
                mappings.Add(m.getMappingDTO());
            }
            _mainDataHandler.SaveMappings(mappings, filePath, InputAxes);
            foreach (var m in Mappings)
            {
                m.UpdateStatus();
            }

        }

        public void Reset(Preset aircraft)
        {
            Debug.WriteLine(String.Format("{0}", aircraft));
            Stop();
            Mappings.Clear();
            _mainDataHandler.SetSaveFilePath("");
            if (aircraft != Preset.NONE)
            {
                var mappings = _mainDataHandler.GetDefaultMappings(aircraft, InputButtonsA, InputButtonsB, InputAxes, OutputAxes, OutputButtonsA, OutputButtonsB);
                foreach (var mapping in mappings)
                {
                    Mappings.Add(new MappingViewModel(mapping, InputButtonsA, InputButtonsB, InputAxes, OutputAxes, OutputButtonsA, OutputButtonsB));
                }
            }
        }

        public bool SaveFileExists()
        {
            bool saveFileExists = File.Exists(_mainDataHandler.GetSaveFilePath());
            return saveFileExists;
        }

        public string GetSaveFilePath()
        {
            return _mainDataHandler.GetSaveFilePath();
        }

        public string GetLoadDirectory()
        {
            return _mainDataHandler.GetLoadDirectory();
        }
        public string SaveFileName
        {
            get
            {
                if (SaveFileExists())
                    return Path.GetFileName(GetSaveFilePath())[0..^4];
                else
                    return "Mapping List";
            }
        }

        public bool RunOnStartup
        {
            get
            {
                return _mainDataHandler.GetRunOnStartup();
            }
            set
            {
                _mainDataHandler.SetRunOnStartup(value);
            }
        }

        public bool PersistCalibration
        {
            get
            {
                return _mainDataHandler.GetPersistCalibration();
            }
            set
            {
                _mainDataHandler.SetPersistCalibration(value);
            }
        }
        public bool StartAllOnOpen
        {
            get
            {
                return _mainDataHandler.GetStartAllOnOpen();
            }
            set
            {
                _mainDataHandler.SetStartAllOnOpen(value);
            }
        }
        public bool MinimiseToSystemTray
        {
            get
            {
                return _mainDataHandler.GetMinimiseToSystemTray();
            }
            set
            {
                _mainDataHandler.SetMinimiseToSystemTray(value);
            }
        }

        public bool AnyFormDirty
        {
            get
            {
                foreach (var mapping in Mappings)
                {
                    if (mapping.IsDirty) { return true; }
                }
                return false;
            }
        }

        public static string GetAxisRegistryPathsDebugString()
        {
            return DataHandler.GetRegistryPathsDebugDisplay(HardwareInfo.GetInputAxes());
        }

        public static DiagnosticDTO RunDiagnostics()
        {
            var results = new DiagnosticDTO();
            var diagnosticProcessor = new DiagnosticProcessor();
            if (diagnosticProcessor != null)
            {
                results = diagnosticProcessor.RunDiagnostics();
            }
            else
            {
                results.Message = "Failed to create diagnostic processor";
            }
            return results;
        }
    }
}
