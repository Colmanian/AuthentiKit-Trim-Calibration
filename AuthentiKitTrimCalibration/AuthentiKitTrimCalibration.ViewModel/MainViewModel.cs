using AuthentiKitTrimCalibration.DataAccess;
using MappingManager.Common.DataProvider;
using MappingManager.Common.Model;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace AuthentiKitTrimCalibration.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private readonly int MAX_MAPPINGS = 20;
        private IMainDataHandler _mainDataHandler;
        private MappingViewModel _selectedMapping;
        public ObservableCollection<string> InputStrings;
        public ObservableCollection<string> OutputStrings;
        private IEnumerable<InputChannel> _inputChannels;
        private IEnumerable<OutputChannel> _outputChannels;

        public ObservableCollection<MappingType> MappingTypes = MappingType.GetMappingTypes();
        public ObservableCollection<MappingViewModel> Mappings { get; set; } = new();
        public bool IsAnyMappingSelected => _selectedMapping != null;
        public bool CanAddMapping { get; private set; }

        public MainViewModel()
        {
            _mainDataHandler = new MainDataHandler();
            CanAddMapping = true;

            // Get the input list once on startup
            InputStrings = new();
            _inputChannels = HardwareInfo.GetInputChannels();
            foreach (var channel in _inputChannels)
            {
                InputStrings.Add(channel.ToString());
            }

            // Get the output list once on startup
            OutputStrings = new();
            _outputChannels = HardwareInfo.GetOutputChannels();
            foreach (var channel in _outputChannels)
            {
                OutputStrings.Add(channel.ToString());
            }
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
                Mappings.Add(new MappingViewModel(mapping, _inputChannels, _outputChannels));
            }
        }
        public void NewMapping()
        {
            if (Mappings.Count < MAX_MAPPINGS)
            {
                Mappings.Add(new MappingViewModel(_mainDataHandler.GetDefaultMapping(), _inputChannels, _outputChannels));
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
    }
}
