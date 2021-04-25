using MappingManager.Common.DataProvider;
using MappingManager.Common.Model;
using System;
using System.ComponentModel;

namespace AuthentiKitTrimCalibration.ViewModel
{
    public class MappingViewModel : ViewModelBase
    {
        private readonly Mapping _mapping;
        private readonly IMappingDataProvider _mappingDataProvider;

        public MappingViewModel(Mapping mapping, IMappingDataProvider mappingDataProvider)
        {
            _mapping = mapping;
            this._mappingDataProvider = mappingDataProvider;
        }

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


        public string Input
        {
            get { return _mapping.Input; }
            set
            {
                if (_mapping.Input != value)
                {
                    _mapping.Input = value;
                    RaisePropertyChanged();
                }
            }
        }

        public string Output
        {
            get { return _mapping.Output; }
            set
            {
                if (_mapping.Output != value)
                {
                    _mapping.Output = value;
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

        public bool CanApply => !string.IsNullOrEmpty(Name);
        public void Apply()
        {
            _mappingDataProvider.ApplyMapping(_mapping);
        }
    }
}
