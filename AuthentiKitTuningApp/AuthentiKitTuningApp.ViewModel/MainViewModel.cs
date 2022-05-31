using AuthentiKitTrimCalibration.DataAccess;
using MappingManager.Common.DataProvider;
using MappingManager.Common.Model;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Threading;

namespace AuthentiKitTrimCalibration.ViewModel
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
        public ObservableCollection<OutputChannel> OutputButtons = HardwareInfo.GetOutputButtons();
        public bool CanAddMapping { get; private set; }

        public bool AtLeastOneMapping { get => Mappings.Count > 0; }

        public MainViewModel()
        {
            _mainDataHandler = new DataHandler();
            CanAddMapping = true;
        }
        public void Start()
        {
            foreach (var mapping in Mappings)
            {
                mapping.Activate();
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
            var mappings = _mainDataHandler.LoadMappings(InputButtonsA, InputButtonsB, InputAxes, OutputAxes, OutputButtons);
            foreach (var mapping in mappings)
            {
                Mappings.Add(new MappingViewModel(mapping, InputButtonsA, InputButtonsB, InputAxes, OutputAxes, OutputButtons));
            }
        }
        public void NewMapping()
        {
            if (Mappings.Count < MAX_MAPPINGS)
            {
                Mappings.Add(new MappingViewModel(_mainDataHandler.GetBlankMapping(), InputButtonsA, InputButtonsB, InputAxes, OutputAxes, OutputButtons));
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
            _mainDataHandler.SaveMappings(mappings);
        }
        public void SaveMappings(string filePath)
        {
            Debug.WriteLine("Saving to " + filePath);
            ObservableCollection<MappingDTO> mappings = new();
            foreach (var m in Mappings)
            {
                mappings.Add(m.getMappingDTO());
            }
            _mainDataHandler.SaveMappings(mappings, filePath);
        }

        public void Reset(Preset aircraft)
        {
            Debug.WriteLine(String.Format("{0}", aircraft));
            Stop();
            Mappings.Clear();
            if (aircraft != Preset.NONE)
            {
                var mappings = _mainDataHandler.GetDefaultMappings(aircraft, InputButtonsA, InputButtonsB, OutputAxes, OutputButtons);
                foreach (var mapping in mappings)
                {
                    Mappings.Add(new MappingViewModel(mapping, InputButtonsA, InputButtonsB, InputAxes, OutputAxes, OutputButtons));
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

        public void SetRunOnStartup(bool runOnStartup)
        {
            _mainDataHandler.SetRunOnStartup(runOnStartup);
        }
    }
}
