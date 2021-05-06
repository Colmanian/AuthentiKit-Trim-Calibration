using MappingManager.Common.DataProvider;
using MappingManager.Common.Model;
using System;
using System.ComponentModel;

namespace AuthentiKitTrimCalibration.ViewModel
{
    public class MappingViewModel : ViewModelBase
    {
        private readonly Mapping _mapping;
        private readonly IMappingProcessor _mappingDataProvider;

        public bool CanApply => !string.IsNullOrEmpty(Name);

        public MappingViewModel(Mapping mapping, IMappingProcessor mappingDataProvider)
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


        public int InputId
        {
            get { return _mapping.InputId; }
            set
            {
                if (_mapping.InputId != value)
                {
                    _mapping.InputId = value;
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
        public void Apply()
        {
            _mappingDataProvider.ApplyMapping(_mapping);
        }
    }
}
