using MappingManager.Common.Model;
using System.Collections.Generic;

namespace MappingManager.Common.DataProvider
{
    public interface IMainDataHandler
    {
        IEnumerable<MappingDTO> LoadMappings();
        void SaveMappings(IEnumerable<MappingDTO> mappings);
        MappingDTO GetBlankMapping();
        IEnumerable<MappingDTO> GetDefaultMappings();
    }
}
