using AuthentiKitTrimCalibration.DataAccess;
using MappingManager.Common.DataProvider;
using MappingManager.Common.Model;
using System;
using System.Collections.ObjectModel;

namespace AuthentiKitTrimCalibration.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private readonly int MAX_MAPPINGS = 20;
        private IMainDataHandler _mainDataHandler;
        public ObservableCollection<MappingViewModel> Mappings { get; set; } = new();
        public ObservableCollection<MappingType> MappingTypes = MappingType.GetMappingTypes();
        public ObservableCollection<InputChannel> InputChannelsA = HardwareInfo.GetInputChannels();
        public ObservableCollection<InputChannel> InputChannelsB = HardwareInfo.GetInputChannels();
        public ObservableCollection<OutputChannel> OutputChannels = HardwareInfo.GetOutputChannels();

        private MappingViewModel _selectedMapping;
        public bool IsAnyMappingSelected => _selectedMapping != null;
        public bool CanAddMapping { get; private set; }

        public MainViewModel()
        {
            _mainDataHandler = new MainDataHandler();
            CanAddMapping = true;
        }
        public MappingViewModel SelectedMapping
        {
            get => _selectedMapping;
            set
            {
                if (_selectedMapping != value)
                {
                    _selectedMapping = value;
                    RaisePropertyChanged();
                    RaisePropertyChanged(nameof(IsAnyMappingSelected));
                }
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
            Stop();
            Mappings.Clear();
            var mappings = _mainDataHandler.LoadMappings();
            foreach (var mapping in mappings)
            {
                Mappings.Add(new MappingViewModel(mapping, InputChannelsA, OutputChannels));
            }
        }
        public void NewMapping()
        {
            if (Mappings.Count < MAX_MAPPINGS)
            {
                Mappings.Add(new MappingViewModel(_mainDataHandler.GetDefaultMapping(), InputChannelsA, OutputChannels));
            }

            if (Mappings.Count >= MAX_MAPPINGS)
            {
                CanAddMapping = false;
            }
        }
        public void RemoveMapping()
        {
            _selectedMapping.Deactivate();
            Mappings.Remove(_selectedMapping);
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
    }
}
