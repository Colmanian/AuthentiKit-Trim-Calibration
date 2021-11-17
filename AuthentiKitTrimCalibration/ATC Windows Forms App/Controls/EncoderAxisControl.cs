using AuthentiKitTrimCalibration.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ATC_Windows_Forms_App.Controls
{
    public partial class EncoderAxisControl : UserControl
    {
        public EncoderAxisControl()
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

            // Input B
            cbInputB.DataSource = viewModel.InputChannelsB;
            cbInputB.DisplayMember = "Name";
            cbInputB.ValueMember = "Hash";
            cbInputB.DataBindings.Add("SelectedValue", mappingBindingSource, "InputChannelBHash");

            // Output
            cbOutputAxis.DataSource = viewModel.OutputAxes;
            cbOutputAxis.DisplayMember = "Name";
            cbOutputAxis.ValueMember = "Hash";
            cbOutputAxis.DataBindings.Add("SelectedValue", mappingBindingSource, "OutputAxisHash");

            // Encoder Pulses per Revolution
            tbEncoderPPR.DataBindings.Add("Text", mappingBindingSource, "EncoderPPR");
                
            // Encoder Pulses per Revolution
            tbRevsInPerRevsOut.DataBindings.Add("Text", mappingBindingSource, "RevsInPerRevsOut");

            // Panel Activation
            pnlEncoderAxisConfig.DataBindings.Add("Enabled", mappingBindingSource, "Deactivated");

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
        private void tbEncoderPPR_KeyUp(object sender, KeyEventArgs e)
        {
            if (tbEncoderPPR.Focused)
            {
                foreach (Binding b in tbEncoderPPR.DataBindings)
                {
                    b.WriteValue();
                }
                tbEncoderPPR.Select(Right, 0);
            }
        }

        private void tbEncoderPPR_Click(object sender, EventArgs e)
        {
            if (tbEncoderPPR.Focused)
            {
                foreach (Binding b in tbEncoderPPR.DataBindings)
                {
                    b.WriteValue();
                }
            }
        }

        private void tbRevsInPerRevsOut_TextChanged(object sender, EventArgs e)
        {
            if (tbRevsInPerRevsOut.Focused)
            {
                foreach (Binding b in tbRevsInPerRevsOut.DataBindings)
                {
                    b.WriteValue();
                }
                tbRevsInPerRevsOut.SelectionStart = tbRevsInPerRevsOut.Text.Length;
                tbRevsInPerRevsOut.SelectionLength = 0;
            }
        }
    }
}
