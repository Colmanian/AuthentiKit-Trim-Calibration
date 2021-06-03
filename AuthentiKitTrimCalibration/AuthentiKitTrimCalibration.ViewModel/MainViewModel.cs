using MappingManager.Common.DataProvider;
using System.Collections.ObjectModel;

namespace AuthentiKitTrimCalibration.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        public bool IsAnyMappingSelected => _selectedMapping != null;

        private IMappingProcessor _mappingProcessor { get; }
        private MappingViewModel _selectedMapping;
        private readonly int MAX_MAPPINGS = 20;

        public MainViewModel(IMappingProcessor mappingDataProvider)
        {
            _mappingProcessor = mappingDataProvider;
            CanAddMapping = true;
        }

        public ObservableCollection<MappingViewModel> Mappings { get; } = new();
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

        public ObservableCollection<string> Inputs
        {
            get
            {
                ObservableCollection<string> inputs = new();
                var channels = _mappingProcessor.GetInputChannels();
                foreach (var channel in channels)
                {
                    inputs.Add(channel.DisplayText);
                }
                return inputs;
            }
        }
        public ObservableCollection<string> Outputs
        {
            get
            {
                ObservableCollection<string> outputs = new();
                var channels = _mappingProcessor.GetOutputChannels();
                foreach (var channel in channels)
                {
                    outputs.Add(channel.DisplayText);
                }
                return outputs;
            }
        }

        public bool CanAddMapping { get; private set; }

        public void Run()
        {
            _mappingProcessor.Run();
        }

        public void Load()
        {
            var mappings = _mappingProcessor.LoadMappings();

            Mappings.Clear();
            foreach (var mapping in mappings)
            {
                Mappings.Add(new MappingViewModel(mapping, _mappingProcessor));
            }
        }
        public void NewMapping()
        {
            if (Mappings.Count < MAX_MAPPINGS)
            {
                Mappings.Add(new MappingViewModel(_mappingProcessor.GetDefaultMapping(), _mappingProcessor));
            }

            if (Mappings.Count >= MAX_MAPPINGS)
            {
                CanAddMapping = false;
            }
        }
        public void RemoveMapping()
        {
            //TODO Kill mapping process
            Mappings.Remove(_selectedMapping);
        }
    }
}
