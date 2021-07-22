using AuthentiKitTrimCalibration.DataAccess;
using MappingManager.Common.DataProvider;
using MappingManager.Common.Model;
using System.Collections.ObjectModel;

namespace AuthentiKitTrimCalibration.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private IMainDataHandler _mainDataHandler;
        private MappingViewModel _selectedMapping;
        private readonly int MAX_MAPPINGS = 20;
        public MainViewModel()
        {
            _mainDataHandler = new MainDataHandler();
            CanAddMapping = true;
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
                Mappings.Add(new MappingViewModel(mapping));
            }
        }
        public void NewMapping()
        {
            if (Mappings.Count < MAX_MAPPINGS)
            {
                Mappings.Add(new MappingViewModel(_mainDataHandler.GetDefaultMapping()));
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

        public ObservableCollection<MappingViewModel> Mappings { get; set; } = new();
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
        public bool IsAnyMappingSelected => _selectedMapping != null;
        public bool CanAddMapping { get; private set; }

        public ObservableCollection<string> Inputs
        {
            get
            {
                ObservableCollection<string> inputs = new();
                var channels = HardwareInfo.GetInputChannels();
                foreach (var channel in channels)
                {
                    inputs.Add(channel.ToString());
                }
                return inputs;
            }
        }
        public ObservableCollection<string> Outputs
        {
            get
            {
                ObservableCollection<string> outputs = new();
                var channels = HardwareInfo.GetOutputChannels();
                foreach (var channel in channels)
                {
                    outputs.Add(channel.ToString());
                }
                return outputs;
            }
        }

        public ObservableCollection<string> MappingTypes
        {
            get
            {
                ObservableCollection<string> mappingTypes = new();
                mappingTypes.Add(MappingDTO.MappingType.Axis.ToString());
                mappingTypes.Add(MappingDTO.MappingType.Button.ToString());
                return mappingTypes;
            }
        }
    }
}
