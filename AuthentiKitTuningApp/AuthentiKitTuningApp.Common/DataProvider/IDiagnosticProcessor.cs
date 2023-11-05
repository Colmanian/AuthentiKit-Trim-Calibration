using AuthentiKitTuningApp.Common.Model;

namespace AuthentiKitTuningApp.Common.DataProvider
{
    public interface IDiagnosticProcessor
    {
        public DiagnosticDTO RunDiagnostics();
    }
}
