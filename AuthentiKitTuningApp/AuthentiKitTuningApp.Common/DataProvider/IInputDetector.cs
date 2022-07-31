using AuthentiKitTuningApp.Common.Model;
using System;

namespace AuthentiKitTuningApp.Common.DataProvider
{
    public interface IInputDetector
    {
        InputButton DetectButton();
        InputAxis DetectAxis();
    }
}
