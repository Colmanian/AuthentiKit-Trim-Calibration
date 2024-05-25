using AuthentiKitTuningApp.ViewModel;
using System;
using System.Diagnostics;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace AuthentiKitTuningApp.Controls
{
    public partial class AdvancedButtonToButtonControl : UserControl
    {
        private BindingSource MappingBindingSource;
        public AdvancedButtonToButtonControl()
        {
            InitializeComponent();
        }

        public void LoadFormData(ref MainViewModel viewModel, ref BindingSource mappingBindingSource)
        {
            MappingBindingSource = mappingBindingSource;

            // Input
            cbInputA.DataSource = viewModel.InputButtonsA;
            cbInputA.DisplayMember = "Name";
            cbInputA.ValueMember = "Hash";
            cbInputA.DataBindings.Add("SelectedValue", MappingBindingSource, "InputButtonAHash");

            cbLatched.DataBindings.Add("Checked", MappingBindingSource, "Latched");

            // Output
            cbOutputButtonA.DataSource = viewModel.OutputButtonsA;
            cbOutputButtonA.DisplayMember = "Name";
            cbOutputButtonA.ValueMember = "Hash";
            cbOutputButtonA.DataBindings.Add("SelectedValue", MappingBindingSource, "OutputButtonAHash");

            cbOutputButtonB.DataSource = viewModel.OutputButtonsB;
            cbOutputButtonB.DisplayMember = "Name";
            cbOutputButtonB.ValueMember = "Hash";
            cbOutputButtonB.DataBindings.Add("SelectedValue", MappingBindingSource, "OutputButtonBHash");

            // Panel Activation
            pnlButtonConfig.DataBindings.Add("Enabled", MappingBindingSource, "Deactivated");
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
        private void cbOutputA_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbOutputButtonA.Focused)
            {
                foreach (Binding b in cbOutputButtonA.DataBindings)
                {
                    b.WriteValue();
                }
            }
        }
        private void cbOutputB_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbOutputButtonB.Focused)
            {
                foreach (Binding b in cbOutputButtonB.DataBindings)
                {
                    b.WriteValue();
                }
            }
        }

        private void LatchedChanged(object sender, EventArgs e)
        {
            if (cbLatched.Focused)
            {
                foreach (Binding b in cbLatched.DataBindings)
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
                cbInputA.Enabled = false;
                pnlButtonConfig.Refresh();
                if (MappingBindingSource.Current is MappingViewModel mappingViewModel
                    && mappingViewModel.Deactivated)
                {
                    mappingViewModel.DetectButtonInputA();
                }
                DetectButton.Text = "Detect";
                cbInputA.Enabled = true;
                pnlButtonConfig.Refresh();
            }
            catch (Exception ex)
            {
                DetectButton.Text = "Detect";
                cbInputA.Enabled = true;
                pnlButtonConfig.Refresh();
                MessageBox.Show(ex.Message, "Error detecting input",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
