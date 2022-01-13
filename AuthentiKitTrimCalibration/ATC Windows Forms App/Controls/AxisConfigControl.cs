using AuthentiKitTrimCalibration.ViewModel;
using System;
using System.Windows.Forms;

namespace ATC_Windows_Forms_App.Controls
{
    public partial class AxisConfigControl : UserControl
    {
        private BindingSource MappingBindingSource;
        public AxisConfigControl()
        {
            InitializeComponent();
        }
        public void LoadFormData(ref MainViewModel viewModel, ref BindingSource mappingBindingSource)
        {
            MappingBindingSource = mappingBindingSource;

            // Input A
            cbInputA.DataSource = viewModel.InputChannelsA;
            cbInputA.DisplayMember = "Name";
            cbInputA.ValueMember = "Hash";
            cbInputA.DataBindings.Add("SelectedValue", MappingBindingSource, "InputChannelAHash");

            // Input B
            cbInputB.DataSource = viewModel.InputChannelsB;
            cbInputB.DisplayMember = "Name";
            cbInputB.ValueMember = "Hash";
            cbInputB.DataBindings.Add("SelectedValue", MappingBindingSource, "InputChannelBHash");

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
                    mappingViewModel.DetectInputA();
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

    }
}