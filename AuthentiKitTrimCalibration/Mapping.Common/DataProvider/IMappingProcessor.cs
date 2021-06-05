using MappingManager.Common.Model;
using System.Collections.Generic;

namespace MappingManager.Common.DataProvider
{
    public interface IMappingProcessor
    {
        IEnumerable<Mapping> LoadMappings();

        void Run();

        void ApplyMapping(Mapping mapping);
        void KillMapping(Mapping mapping);

        IEnumerable<InputChannel> GetInputChannels();

        IEnumerable<OutputChannel> GetOutputChannels();
        Mapping GetDefaultMapping();
    }
}
