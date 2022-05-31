using AuthentiKitTrimCalibration.ViewModel;
using System;
using System.Windows.Forms;

namespace ATC_Windows_Forms_App.Controls
{
    public partial class AxisToButtonControl : UserControl
    {
        private BindingSource MappingBindingSource;
        public AxisToButtonControl()
        {
            InitializeComponent();
        }

        public void LoadFormData(ref MainViewModel viewModel, ref BindingSource mappingBindingSource)
        {
            MappingBindingSource = mappingBindingSource;

            // Input
            cbInputAxis.DataSource = viewModel.InputAxes;
            cbInputAxis.DisplayMember = "Name";
            cbInputAxis.ValueMember = "Hash";
            cbInputAxis.DataBindings.Add("SelectedValue", MappingBindingSource, "InputAxisHash");

            // Output A
            cbOutputButton1.DataSource = viewModel.OutputButtonsA;
            cbOutputButton1.DisplayMember = "Name";
            cbOutputButton1.ValueMember = "Hash";
            cbOutputButton1.DataBindings.Add("SelectedValue", MappingBindingSource, "OutputButtonAHash");
            
            // Output B
            cbOutputButton2.DataSource = viewModel.OutputButtonsB;
            cbOutputButton2.DisplayMember = "Name";
            cbOutputButton2.ValueMember = "Hash";
            cbOutputButton2.DataBindings.Add("SelectedValue", MappingBindingSource, "OutputButtonBHash");

            // Gateways
            numericUpDown1.DataBindings.Add("Value", MappingBindingSource, "Gateway1");
            numericUpDown2.DataBindings.Add("Value", MappingBindingSource, "Gateway2");
            numericUpDown3.DataBindings.Add("Value", MappingBindingSource, "Gateway3");
            numericUpDown4.DataBindings.Add("Value", MappingBindingSource, "Gateway4");
            numericUpDown5.DataBindings.Add("Value", MappingBindingSource, "Gateway5");

            checkBox1.DataBindings.Add("Checked", MappingBindingSource, "GatewayEnabled1");
            checkBox2.DataBindings.Add("Checked", MappingBindingSource, "GatewayEnabled2");
            checkBox3.DataBindings.Add("Checked", MappingBindingSource, "GatewayEnabled3");
            checkBox4.DataBindings.Add("Checked", MappingBindingSource, "GatewayEnabled4");
            checkBox5.DataBindings.Add("Checked", MappingBindingSource, "GatewayEnabled5");

            // Panel Activation
            numericUpDown1.DataBindings.Add("Enabled", MappingBindingSource, "GatewayEnabled1");
            numericUpDown2.DataBindings.Add("Enabled", MappingBindingSource, "GatewayEnabled2");
            numericUpDown3.DataBindings.Add("Enabled", MappingBindingSource, "GatewayEnabled3");
            numericUpDown4.DataBindings.Add("Enabled", MappingBindingSource, "GatewayEnabled4");
            numericUpDown5.DataBindings.Add("Enabled", MappingBindingSource, "GatewayEnabled5");
            pnlAxisToButton.DataBindings.Add("Enabled", MappingBindingSource, "Deactivated");
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
        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Focused)
            {
                foreach (Binding b in checkBox2.DataBindings)
                {
                    b.WriteValue();
                }
            }
        }
        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Focused)
            {
                foreach (Binding b in checkBox3.DataBindings)
                {
                    b.WriteValue();
                }
            }
        }
        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox4.Focused)
            {
                foreach (Binding b in checkBox4.DataBindings)
                {
                    b.WriteValue();
                }
            }
        }
        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox5.Focused)
            {
                foreach (Binding b in checkBox5.DataBindings)
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
        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            if (numericUpDown2.Focused)
            {
                foreach (Binding b in numericUpDown2.DataBindings)
                {
                    b.WriteValue();
                }
            }
        }
        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {
            if (numericUpDown3.Focused)
            {
                foreach (Binding b in numericUpDown3.DataBindings)
                {
                    b.WriteValue();
                }
            }
        }
        private void numericUpDown4_ValueChanged(object sender, EventArgs e)
        {
            if (numericUpDown4.Focused)
            {
                foreach (Binding b in numericUpDown4.DataBindings)
                {
                    b.WriteValue();
                }
            }
        }
        private void numericUpDown5_ValueChanged(object sender, EventArgs e)
        {
            if (numericUpDown5.Focused)
            {
                foreach (Binding b in numericUpDown5.DataBindings)
                {
                    b.WriteValue();
                }
            }
        }

        private void cbOutputButton1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbOutputButton1.Focused)
            {
                foreach (Binding b in cbOutputButton1.DataBindings)
                {
                    b.WriteValue();
                }
            }
        }

        private void cbOutputButton2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbOutputButton2.Focused)
            {
                foreach (Binding b in cbOutputButton2.DataBindings)
                {
                    b.WriteValue();
                }
            }
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
    }
}
