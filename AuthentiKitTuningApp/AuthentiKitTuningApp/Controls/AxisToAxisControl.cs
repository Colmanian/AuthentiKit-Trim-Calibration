using AuthentiKitTrimCalibration.ViewModel;
using System;
using System.Windows.Forms;

namespace ATC_Windows_Forms_App.Controls
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

        private void DetectButton_Click(object sender, EventArgs e)
        {
            try
            {
                DetectButton.Text = "Listening...";
                cbInputAxis.Enabled = false;
                pnlAxisToAxisConfig.Refresh();
                if (MappingBindingSource.Current is MappingViewModel mappingViewModel
                    && mappingViewModel.Deactivated)
                {
                    mappingViewModel.DetectButtonInputA();
                }
                DetectButton.Text = "Detect";
                cbInputAxis.Enabled = true;
                pnlAxisToAxisConfig.Refresh();
            }
            catch (Exception ex)
            {
                DetectButton.Text = "Detect";
                cbInputAxis.Enabled = true;
                pnlAxisToAxisConfig.Refresh();
                MessageBox.Show(ex.Message, "Error detecting input",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
