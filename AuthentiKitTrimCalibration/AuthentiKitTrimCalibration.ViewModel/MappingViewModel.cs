using AuthentiKitTrimCalibration.DataAccess;
using MappingManager.Common.DataProvider;
using MappingManager.Common.Model;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;

namespace AuthentiKitTrimCalibration.ViewModel
{
    public class MappingViewModel : ViewModelBase
    {

        private MappingDTO _mapping;
        private IMappingProcessor _mappingProcessor;

        public MappingViewModel(MappingDTO mapping)
        {
            _mapping = mapping;
            _mappingProcessor = new MappingProcessor();
            ApplyMapping();
        }
        public void ApplyMapping()
        {
            _mappingProcessor.ApplyMapping(_mapping);
        }
        public void Stop()
        {
            _mappingProcessor.Stop();
        }
        public bool CanApply => !string.IsNullOrEmpty(Name);

        public string Name
        {
            get { return _mapping.Name; }
            set
            {
                if (_mapping.Name != value)
                {
                    _mapping.Name = value;
                    RaisePropertyChanged();
                    RaisePropertyChanged(nameof(CanApply));
                }
            }
        }

        public static T ParseEnum<T>(string value)
        {
            return (T)Enum.Parse(typeof(T), value, true);
        }
        public string Type
        {
            get {
                Debug.WriteLine("getting enum {0} as string {1}", _mapping.Type, _mapping.Type.ToString());
                return _mapping.Type.ToString();
            }
            set
            {
                MappingDTO.MappingType enumValue = ParseEnum<MappingDTO.MappingType>(value);
                if (_mapping.Type != enumValue)
                {
                    _mapping.Type = enumValue;
                    RaisePropertyChanged();
                }
                Debug.WriteLine("Setting string {0} to enum {1}", value, enumValue);
            }
        }
        public int InputID_A
        {
            get { return _mapping.InputID_A; }
            set
            {
                if (_mapping.InputID_A != value)
                {
                    _mapping.InputID_A = value;
                    RaisePropertyChanged();
                }
            }
        }
        public int InputID_B
        {
            get { return _mapping.InputID_B; }
            set
            {
                if (_mapping.InputID_B != value)
                {
                    _mapping.InputID_B = value;
                    RaisePropertyChanged();
                }
            }
        }
        public int OutputId
        {
            get { return _mapping.OutputId; }
            set
            {
                if (_mapping.OutputId != value)
                {
                    _mapping.OutputId = value;
                    RaisePropertyChanged();
                }
            }
        }

        public int Multiplier
        {
            get { return _mapping.Multiplier; }
            set
            {
                if (_mapping.Multiplier != value)
                {
                    _mapping.Multiplier = value;
                    RaisePropertyChanged();
                }
            }
        }
        public int HoldThresholdStart
        {
            get { return _mapping.HoldThresholdStart; }
            set
            {
                if (_mapping.HoldThresholdStart != value)
                {
                    _mapping.HoldThresholdStart = value;
                    RaisePropertyChanged();
                }
            }
        }
        public int HoldThresholdStop
        {
            get { return _mapping.HoldThresholdStop; }
            set
            {
                if (_mapping.HoldThresholdStop != value)
                {
                    _mapping.HoldThresholdStop = value;
                    RaisePropertyChanged();
                }
            }
        }
        public string ResetCommand
        {
            get { return _mapping.ResetCommand; }
            set
            {
                if (_mapping.ResetCommand != value)
                {
                    _mapping.ResetCommand = value;
                    RaisePropertyChanged();
                }
            }
        }
        
        public bool Enabled
        {
            get { return _mapping.Enabled; }
            set
            {
                if (_mapping.Enabled != value)
                {
                    _mapping.Enabled = value;
                    RaisePropertyChanged();
                    RaisePropertyChanged(nameof(CanApply));
                }
            }
        }

    }
}
