using AuthentiKitTuningApp.Common.Model;
using System.Collections.Generic;

namespace AuthentiKitTuningApp.Common.DataProvider
{
    public interface IMappingProcessor
    {        
        void Activate(MappingDTO mapping);
        void Deactivate();
        bool IsErrored();
        bool IsRunning();
        public void Centre();
    }
}
