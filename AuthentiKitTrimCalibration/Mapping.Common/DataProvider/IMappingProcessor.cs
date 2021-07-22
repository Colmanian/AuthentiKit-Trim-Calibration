using MappingManager.Common.Model;
using System.Collections.Generic;

namespace MappingManager.Common.DataProvider
{
    public interface IMappingProcessor
    {        
        void Activate(MappingDTO mapping);
        void Deactivate();
        bool IsErrored();
        bool IsRunning();
    }
}
