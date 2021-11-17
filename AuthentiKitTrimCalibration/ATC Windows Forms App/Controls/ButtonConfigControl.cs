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
