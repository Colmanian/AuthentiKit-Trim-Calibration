using MappingManager.Common.DataProvider;
using MappingManager.Common.Model;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace AuthentiKitTrimCalibration.ViewModel
{
    public class MainViewModel : ViewModelBase
    {

        public IMappingDataProvider _mappingDataProvider { get; }
        private MappingViewModel _selectedMapping;
        private bool _active;

        public MainViewModel(IMappingDataProvider mappingDataProvider)
        {
            _mappingDataProvider = mappingDataProvider;
        }

        public ObservableCollection<MappingViewModel> Mappings { get; } = new();
        public ObservableCollection<InputDevice> Devices { get; } = new();
        public MappingViewModel SelectedMapping
        {
            get => _selectedMapping;
            set {
                if(_selectedMapping != value)
                {
                    _selectedMapping = value;
                    RaisePropertyChanged();
                    RaisePropertyChanged(nameof(IsMappingSelected));
                }
            }
        }

        public bool IsMappingSelected => _selectedMapping != null;

        public void Run()
        {
            Debug.WriteLine("Run() NOT IMPLMENTED");
        }

        public void Load()
        {
            var mappings = _mappingDataProvider.LoadMappings();
            var devices = _mappingDataProvider.LoadDevices();

            Mappings.Clear();
            foreach (var mapping in mappings)
            {
                Mappings.Add(new MappingViewModel(mapping, _mappingDataProvider));
            }

            Devices.Clear();
            foreach (var device in devices)
            {
                Devices.Add(device);
            }
        }
    }
}
