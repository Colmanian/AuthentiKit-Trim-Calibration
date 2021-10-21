﻿using AuthentiKitTrimCalibration.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ATC_Windows_Forms_App.Controls
{
    public partial class AxisConfigControl : UserControl
    {
        public AxisConfigControl()
        {
            InitializeComponent();
        }
        public void LoadFormData(ref MainViewModel viewModel, ref BindingSource mappingBindingSource)
        {
            var dataBindingsInitalised = (tbName.DataBindings.Count > 0) ||
                (cbMappingType.DataBindings.Count > 0) ||
                (cbMappingType.DataBindings.Count > 0);
            if (dataBindingsInitalised)
            {
                mappingBindingSource.ResetBindings(false);
            }
            else
            {
                // Mapping Name
                tbName.DataBindings.Add("Text", mappingBindingSource, "Name");

                // Mapping Type
                cbMappingType.DataSource = viewModel.MappingTypes;
                cbMappingType.DisplayMember = "Name";
                cbMappingType.ValueMember = "Id";
                cbMappingType.DataBindings.Add("SelectedValue", mappingBindingSource, "TypeId");

                // Input A
                cbInputA.DataSource = viewModel.InputChannelsA;
                cbInputA.DisplayMember = "Name";
                cbInputA.ValueMember = "Hash";
                cbInputA.DataBindings.Add("SelectedValue", mappingBindingSource, "InputChannelAHash");

                // Input B
                cbInputB.DataSource = viewModel.InputChannelsB;
                cbInputB.DisplayMember = "Name";
                cbInputB.ValueMember = "Hash";
                cbInputB.DataBindings.Add("SelectedValue", mappingBindingSource, "InputChannelBHash");

                // Output
                cbOutput.DataSource = viewModel.OutputChannels;
                cbOutput.DisplayMember = "Name";
                cbOutput.ValueMember = "Hash";
                cbOutput.DataBindings.Add("SelectedValue", mappingBindingSource, "OutputChannelHash");

                // Multiplier
                tbMultiplier.DataBindings.Add("Text", mappingBindingSource, "Multiplier");

                // Panel Activation
                pnlAxisConfig.DataBindings.Add("Enabled", mappingBindingSource, "Deactivated");
            }
        }
    }
}
