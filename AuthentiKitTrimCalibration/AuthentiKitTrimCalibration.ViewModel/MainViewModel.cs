using MappingManager.Common.DataProvider;
using System.Collections.ObjectModel;

namespace AuthentiKitTrimCalibration.ViewModel
{
    public class MainViewModel : ViewModelBase
    {

        public IMappingProcessor _mappingDataProvider { get; }
        private MappingViewModel _selectedMapping;

        public MainViewModel(IMappingProcessor mappingDataProvider)
        {
            _mappingDataProvider = mappingDataProvider;
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
                    RaisePropertyChanged(nameof(IsMappingSelected));
                }
            }
        }

        public bool IsMappingSelected => _selectedMapping != null;

        public void Run()
        {
            _mappingDataProvider.Run();
        }

        public void Load()
        {
            var mappings = _mappingDataProvider.LoadMappings();

            Mappings.Clear();
            foreach (var mapping in mappings)
            {
                Mappings.Add(new MappingViewModel(mapping, _mappingDataProvider));
            }
        }
    }
}
