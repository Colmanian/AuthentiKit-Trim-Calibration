using AuthentiKitTrimCalibration.ViewModel;
using System;
using System.Windows.Forms;

namespace ATC_Windows_Forms_App.Controls
{
    public partial class AxisToAxisControl : UserControl
    {
        private BindingSource MappingBindingSource;
        public AxisToAxisControl()
        {
            InitializeComponent();
        }
        public void LoadFormData(ref MainViewModel viewModel, ref BindingSource mappingBindingSource)
        {
            MappingBindingSource = mappingBindingSource;

            // Input A
            cbInputAxis.DataSource = viewModel.InputButtonsA;
            cbInputAxis.DisplayMember = "Name";
            cbInputAxis.ValueMember = "Hash";
            cbInputAxis.DataBindings.Add("SelectedValue", MappingBindingSource, "InputButtonAxisHash");

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
