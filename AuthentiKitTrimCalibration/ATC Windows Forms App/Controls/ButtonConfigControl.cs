using AuthentiKitTrimCalibration.ViewModel;
using System;
using System.Windows.Forms;

namespace ATC_Windows_Forms_App.Controls
{
    public partial class ButtonConfigControl : UserControl
    {
        public ButtonConfigControl()
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

            // Output
            cbOutputButton.DataSource = viewModel.OutputButtons;
            cbOutputButton.DisplayMember = "Name";
            cbOutputButton.ValueMember = "Hash";
            cbOutputButton.DataBindings.Add("SelectedValue", mappingBindingSource, "OutputButtonHash");

            // Multiplier
            tbButtonMultiplier.DataBindings.Add("Value", mappingBindingSource, "ButtonMultiplier");

            // tbHoldThresholdStart
            tbHoldThresholdStart.DataBindings.Add("Value", mappingBindingSource, "HoldThresholdStart");

            // tbHoldThresholdStop
            tbHoldThresholdStop.DataBindings.Add("Value", mappingBindingSource, "HoldThresholdStop");

            // Panel Activation
            pnlButtonConfig.DataBindings.Add("Enabled", mappingBindingSource, "Deactivated");
        }

        /*
         * The following methods only exist to trigger an update of the data binding without having to
         * select another control. The main way that data is updated in the mapping is via the databindings
         * specified in the LoadFormData above.
         */
        private void tbButtonMultiplier_Click(object sender, EventArgs e)
        {
            if (tbButtonMultiplier.Focused)
            {
                foreach (Binding b in tbButtonMultiplier.DataBindings)
                {
                    b.WriteValue();
                }
            }
        }
        private void tbHoldThresholdStart_click(object sender, EventArgs e)
        {
            if (tbHoldThresholdStart.Focused)
            {
                foreach (Binding b in tbHoldThresholdStart.DataBindings)
                {
                    b.WriteValue();
                }
            }
        }
        private void tbHoldThresholdStop_click(object sender, EventArgs e)
        {
            if (tbHoldThresholdStop.Focused)
            {
                foreach (Binding b in tbHoldThresholdStop.DataBindings)
                {
                    b.WriteValue();
                }
            }
        }
        private void tbHoldThresholdStart_keyUp(object sender, KeyEventArgs e)
        {
            if (tbHoldThresholdStart.Focused)
            {
                foreach (Binding b in tbHoldThresholdStart.DataBindings)
                {
                    b.WriteValue();
                }
                tbHoldThresholdStart.Select(Right, 0);
            }
        }
        private void tbHoldThresholdStop_keyUp(object sender, KeyEventArgs e)
        {
            if (tbHoldThresholdStop.Focused)
            {
                foreach (Binding b in tbHoldThresholdStop.DataBindings)
                {
                    b.WriteValue();
                }
                tbHoldThresholdStop.Select(Right, 0);
            }
        }

        private void tbButtonMultiplier_KeyUp(object sender, KeyEventArgs e)
        {
            if (tbButtonMultiplier.Focused)
            {
                foreach (Binding b in tbButtonMultiplier.DataBindings)
                {
                    b.WriteValue();
                }
                tbButtonMultiplier.Select(Right, 0);
            }
        }

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

        private void cbOutput_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbOutputButton.Focused)
            {
                foreach (Binding b in cbOutputButton.DataBindings)
                {
                    b.WriteValue();
                }
            }
        }
    }
}
