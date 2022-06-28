using AuthentiKitTuningApp.ViewModel;
using System;
using System.Windows.Forms;

namespace AuthentiKitTuningApp.Controls
{
    public partial class ButtonToAxisControl : UserControl
    {
        private BindingSource MappingBindingSource;
        public ButtonToAxisControl()
        {
            InitializeComponent();
        }
        public void LoadFormData(ref MainViewModel viewModel, ref BindingSource mappingBindingSource)
        {
            MappingBindingSource = mappingBindingSource;

            // Input A
            cbInputA.DataSource = viewModel.InputButtonsA;
            cbInputA.DisplayMember = "Name";
            cbInputA.ValueMember = "Hash";
            cbInputA.DataBindings.Add("SelectedValue", MappingBindingSource, "InputButtonAHash");

            // Input B
            cbInputB.DataSource = viewModel.InputButtonsB;
            cbInputB.DisplayMember = "Name";
            cbInputB.ValueMember = "Hash";
            cbInputB.DataBindings.Add("SelectedValue", MappingBindingSource, "InputButtonBHash");

            // Output Axis
            cbOutputAxis.DataSource = viewModel.OutputAxes;
            cbOutputAxis.DisplayMember = "Name";
            cbOutputAxis.ValueMember = "Hash";
            cbOutputAxis.DataBindings.Add("SelectedValue", MappingBindingSource, "OutputAxisHash");

            // Axis Sensitivity
            tbAxisSensitivity.DataBindings.Add("Text", MappingBindingSource, "AxisSensitivity");
            tBarAxisSensitivity.DataBindings.Add("Value", MappingBindingSource, "AxisSensitivity");

            // Panel Activation
            pnlAxisConfig.DataBindings.Add("Enabled", MappingBindingSource, "Deactivated");

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
            }
            if (tbAxisSensitivity.Focused)
            {
                foreach (Binding b in tbAxisSensitivity.DataBindings)
                {
                    b.WriteValue();
                }
                tbAxisSensitivity.Select(Right, 0);
            }
        }

        private void RefreshSensitivityBindings(object sender, KeyEventArgs e)
        {

        }

        private void DetectButton1_Click(object sender, EventArgs e)
        {
            try
            {
                DetectButton1.Text = "Listening...";
                cbInputA.Enabled = false;
                pnlAxisConfig.Refresh();
                if (MappingBindingSource.Current is MappingViewModel mappingViewModel
                    && mappingViewModel.Deactivated)
                {
                    mappingViewModel.DetectButtonInputA();
                }
                DetectButton1.Text = "Detect";
                cbInputA.Enabled = true;
                pnlAxisConfig.Refresh();
            }
            catch (Exception ex)
            {
                DetectButton1.Text = "Detect";
                cbInputA.Enabled = true;
                pnlAxisConfig.Refresh();
                MessageBox.Show(ex.Message, "Error detecting input",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DetectButton2_Click(object sender, EventArgs e)
        {
            try
            {
                DetectButton2.Text = "Listening...";
                cbInputB.Enabled = false;
                pnlAxisConfig.Refresh();
                if (MappingBindingSource.Current is MappingViewModel mappingViewModel
                    && mappingViewModel.Deactivated)
                {
                    mappingViewModel.DetectButtonInputB();
                }
                DetectButton2.Text = "Detect";
                cbInputB.Enabled = true;
                pnlAxisConfig.Refresh();
            }
            catch (Exception ex)
            {
                DetectButton2.Text = "Detect";
                cbInputB.Enabled = true;
                pnlAxisConfig.Refresh();
                MessageBox.Show(ex.Message, "Error detecting input",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}