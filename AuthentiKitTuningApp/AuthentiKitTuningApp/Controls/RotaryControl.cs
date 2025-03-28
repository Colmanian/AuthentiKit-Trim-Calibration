using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AuthentiKitTuningApp.ViewModel;

namespace AuthentiKitTuningApp.Controls
{
    public partial class RotaryControl : UserControl
    {
        private BindingSource MappingBindingSource;
        public RotaryControl()
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

            // Output
            cbOutputButtonA.DataSource = viewModel.OutputButtonsA;
            cbOutputButtonA.DisplayMember = "Name";
            cbOutputButtonA.ValueMember = "Hash";
            cbOutputButtonA.DataBindings.Add("SelectedValue", MappingBindingSource, "OutputButtonAHash");

            cbOutputButtonB.DataSource = viewModel.OutputButtonsB;
            cbOutputButtonB.DisplayMember = "Name";
            cbOutputButtonB.ValueMember = "Hash";
            cbOutputButtonB.DataBindings.Add("SelectedValue", MappingBindingSource, "OutputButtonBHash");

            // Tech Debt. I'm rushed for time so comandeering the GatewayEnabled1 and Gateway1 fields for the rotary control
            checkBox1.DataBindings.Add("Checked", MappingBindingSource, "GatewayEnabled1");
            numericUpDown1.DataBindings.Add("Value", MappingBindingSource, "Gateway1");

            // Panel Activation
            panel1.DataBindings.Add("Enabled", MappingBindingSource, "Deactivated");

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

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Focused)
            {
                foreach (Binding b in checkBox1.DataBindings)
                {
                    b.WriteValue();
                }
            }
        }

        private void cbOutputButtonA_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbOutputButtonA.Focused)
            {
                foreach (Binding b in cbOutputButtonA.DataBindings)
                {
                    b.WriteValue();
                }
            }
        }

        private void cbOutputButtonB_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbOutputButtonB.Focused)
            {
                foreach (Binding b in cbOutputButtonB.DataBindings)
                {
                    b.WriteValue();
                }
            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            if (numericUpDown1.Focused)
            {
                foreach (Binding b in numericUpDown1.DataBindings)
                {
                    b.WriteValue();
                }
            }
        }

        private void DetectButton1_Click(object sender, EventArgs e)
        {
            try
            {
                DetectButton1.Text = "Listening...";
                cbInputA.Enabled = false;
                panel1.Refresh();
                if (MappingBindingSource.Current is MappingViewModel mappingViewModel
                    && mappingViewModel.Deactivated)
                {
                    mappingViewModel.DetectButtonInputA();
                }
                DetectButton1.Text = "Detect";
                cbInputA.Enabled = true;
                panel1.Refresh();
            }
            catch (Exception ex)
            {
                DetectButton1.Text = "Detect";
                cbInputA.Enabled = true;
                panel1.Refresh();
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
                panel1.Refresh();
                if (MappingBindingSource.Current is MappingViewModel mappingViewModel
                    && mappingViewModel.Deactivated)
                {
                    mappingViewModel.DetectButtonInputB();
                }
                DetectButton2.Text = "Detect";
                cbInputB.Enabled = true;
                panel1.Refresh();
            }
            catch (Exception ex)
            {
                DetectButton2.Text = "Detect";
                cbInputB.Enabled = true;
                panel1.Refresh();
                MessageBox.Show(ex.Message, "Error detecting input",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
