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

            // Output Axis
            cbOutputAxis.DataSource = viewModel.OutputAxes;
            cbOutputAxis.DisplayMember = "Name";
            cbOutputAxis.ValueMember = "Hash";
            cbOutputAxis.DataBindings.Add("SelectedValue", mappingBindingSource, "OutputAxisHash");

            // Axis Sensitivity
            tbAxisSensitivity.DataBindings.Add("Text", mappingBindingSource, "AxisSensitivity");
            tBarAxisSensitivity.DataBindings.Add("Value", mappingBindingSource, "AxisSensitivity");

            // Panel Activation
            pnlAxisConfig.DataBindings.Add("Enabled", mappingBindingSource, "Deactivated");

        }


        /*
         * The following methods only exist to trigger an update of the data binding without having to
         * select another control. The main way that data is updated in the mapping is via the databindings
         * specified in the LoadFormData above.
         */

        private void cbInputA_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbInputA.Focused)
            {
                foreach (Binding b in cbInputA.DataBindings)
                {
                    b.WriteValue();
                }
            }
        }

        private void cbInputB_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbInputB.Focused)
            {
                foreach (Binding b in cbInputB.DataBindings)
                {
                    b.WriteValue();
                }
            }
        }

        private void cbOutput_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbOutputAxis.Focused)
            {
                foreach (Binding b in cbOutputAxis.DataBindings)
                {
                    b.WriteValue();
                }
            }
        }

        private void RefreshSensitivityBindings(object sender, EventArgs e)
        {
            if (tBarAxisSensitivity.Focused)
            {
                foreach (Binding b in tBarAxisSensitivity.DataBindings)
                {
                    b.WriteValue();
                }
                foreach (Binding b in tbAxisSensitivity.DataBindings)
                {
                    b.WriteValue();
                }
                tbAxisSensitivity.Select(Right, 0);
            }
        }
    }
}