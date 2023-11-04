using System;
using System.Collections.Generic;
using System.Linq;

namespace AuthentiKitTuningApp.Common.Model
{
    public class DiagnosticDTO
    {
        public DiagnosticDTO()
        {
            Healthy = false;
            Message = "";
        }

        public bool Healthy { get; set; }
        public string Message { get; set; }

    }
}