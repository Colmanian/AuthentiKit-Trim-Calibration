using MappingManager.Common.Model;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace MappingManager.Common.DataProvider
{
    public interface IMainDataHandler
    {
        IEnumerable<MappingDTO> LoadMappings(ObservableCollection<InputChannel> inputChannelsA, ObservableCollection<InputChannel> inputChannelsB, ObservableCollection<OutputChannel> outputAxes, ObservableCollection<OutputChannel> outputButtons);
        void SaveMappings(IEnumerable<MappingDTO> mappings);
        MappingDTO GetBlankMapping();
        IEnumerable<MappingDTO> GetDefaultMappings(Aircraft aircraft, ObservableCollection<InputChannel> inputChannelsA, ObservableCollection<InputChannel> inputChannelsB, ObservableCollection<OutputChannel> outputAxes, ObservableCollection<OutputChannel> outputButtons);
    }
}
