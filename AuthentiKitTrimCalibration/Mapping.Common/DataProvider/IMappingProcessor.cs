using MappingManager.Common.Model;
using System.Collections.Generic;

namespace MappingManager.Common.DataProvider
{
    public interface IMappingProcessor
    {        
        void ApplyMapping(MappingDTO mapping);
        void Stop();
    }
}
