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
            var dataBindingsInitalised = (cbInputA.DataBindings.Count > 0) ||
                (cbOutput.DataBindings.Count > 0) ||
                (tbButtonMultiplier.DataBindings.Count > 0);
            if (dataBindingsInitalised)
            {
                mappingBindingSource.ResetBindings(false);
            }
            else
            {

                // Input A
                cbInputA.DataSource = viewModel.InputChannelsA;
                cbInputA.DisplayMember = "Name";
                cbInputA.ValueMember = "Hash";
                cbInputA.DataBindings.Add("SelectedValue", mappingBindingSource, "InputChannelAHash");

                // Output
                cbOutput.DataSource = viewModel.OutputChannels;
                cbOutput.DisplayMember = "Name";
                cbOutput.ValueMember = "Hash";
                cbOutput.DataBindings.Add("SelectedValue", mappingBindingSource, "OutputChannelHash");

                // Multiplier
                tbButtonMultiplier.DataBindings.Add("Value", mappingBindingSource, "ButtonMultiplier");

                // Panel Activation
                pnlButtonConfig.DataBindings.Add("Enabled", mappingBindingSource, "Deactivated");
            }
        }

        /*
         * The following methods only exist to trigger an update of the data binding without having to
         * select another control. The main way that data is updated in the mapping is via the databindings
         * specified in the LoadFormData above.
         */
        private void tbButtonMultiplier_Click(object sender, EventArgs e)
        {
            foreach (Binding b in tbButtonMultiplier.DataBindings)
            {
                b.WriteValue();
            }
        }

        private void tbButtonMultiplier_KeyUp(object sender, KeyEventArgs e)
        {
            foreach (Binding b in tbButtonMultiplier.DataBindings)
            {
                b.WriteValue();
            }
            tbButtonMultiplier.Select(Right, 0);
        }

        private void cbInputA_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (Binding b in cbInputA.DataBindings)
            {
                b.WriteValue();
            }
        }

        private void cbOutput_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (Binding b in cbOutput.DataBindings)
            {
                b.WriteValue();
            }
        }
    }
}
