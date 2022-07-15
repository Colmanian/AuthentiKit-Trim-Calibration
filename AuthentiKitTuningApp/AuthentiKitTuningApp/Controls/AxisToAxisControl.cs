using AuthentiKitTuningApp.ViewModel;
using System;
using System.Windows.Forms;

namespace AuthentiKitTuningApp.Controls
{
    public partial class AxisToAxisControl : UserControl
    {
        private BindingSource MappingBindingSource;
        public AxisToAxisControl()
        {
            InitializeComponent();
        }
        public void LoadFormData(ref MainViewModel viewModel, ref BindingSource mappingBindingSource)
        {
            MappingBindingSource = mappingBindingSource;

            // Input A
            cbInputAxis.DataSource = viewModel.InputAxes;
            cbInputAxis.DisplayMember = "Name";
            cbInputAxis.ValueMember = "Hash";
            cbInputAxis.DataBindings.Add("SelectedValue", MappingBindingSource, "InputAxisHash");

            // Output Axis
            cbOutputAxis.DataSource = viewModel.OutputAxes;
            cbOutputAxis.DisplayMember = "Name";
            cbOutputAxis.ValueMember = "Hash";
            cbOutputAxis.DataBindings.Add("SelectedValue", MappingBindingSource, "OutputAxisHash");

            // Flipped
            chbFlip.DataBindings.Add("Checked", MappingBindingSource, "Flipped");

            // Calibration Label
            lblCalibration.DataBindings.Add("Text", MappingBindingSource, "CalibrationString");

            // Panel Activation
            pnlAxisToAxisConfig.DataBindings.Add("Enabled", MappingBindingSource, "Deactivated");
        }

        private void cbInputAxis_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbInputAxis.Focused)
            {
                foreach (Binding b in cbInputAxis.DataBindings)
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

        private void chbFlip_CheckedChanged(object sender, EventArgs e)
        {
            if (chbFlip.Focused)
            {
                foreach (Binding b in chbFlip.DataBindings)
                {
                    b.WriteValue();
                }
            }
        }

        private void GetCalibrationButtonClick(object sender, EventArgs e)
        {
            lblCalibration.DataBindings.Clear();
            lblCalibration.DataBindings.Add("Text", MappingBindingSource, "CalibrationString");
        }
    }
}
