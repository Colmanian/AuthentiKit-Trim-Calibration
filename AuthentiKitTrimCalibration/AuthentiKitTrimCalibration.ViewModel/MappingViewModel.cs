﻿using MappingManager.Common.DataProvider;
using MappingManager.Common.Model;
using System;
using System.ComponentModel;

namespace AuthentiKitTrimCalibration.ViewModel
{
    public class MappingViewModel : ViewModelBase
    {

        private readonly Mapping _mapping;
        private readonly IMappingProcessor _mappingProcessor;

        public MappingViewModel(Mapping mapping, IMappingProcessor mappingDataProvider)
        {
            _mapping = mapping;
            this._mappingProcessor = mappingDataProvider;
        }
        public void ApplyMapping()
        {
            _mappingProcessor.ApplyMapping(_mapping);
        }
        public void KillMapping()
        {
            _mappingProcessor.KillMapping(_mapping);
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
