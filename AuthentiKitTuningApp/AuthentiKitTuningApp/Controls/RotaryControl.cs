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
