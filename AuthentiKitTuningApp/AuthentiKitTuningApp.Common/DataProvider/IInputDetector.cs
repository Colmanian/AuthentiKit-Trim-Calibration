using MappingManager.Common.Model;
using System;

namespace MappingManager.Common.DataProvider
{
    public interface IInputDetector
    {
        InputButton DetectButton();
        InputAxis DetectAxis();
    }
}
