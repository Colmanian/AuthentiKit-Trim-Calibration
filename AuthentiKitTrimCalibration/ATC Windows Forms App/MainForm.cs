using AuthentiKitTrimCalibration.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ATC_Windows_Forms_App
{
    public partial class MainForm : Form
    {
        private MainViewModel _viewModel;

        public MainForm()
        {
            InitializeComponent();
            _viewModel = new MainViewModel();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            _viewModel.LoadMappings();
            LoadFormData();
        }


        private void btnAddMapping_Click(object sender, EventArgs e)
        {
            Debug.WriteLine("Adding New mapping"); /// You're trying to get this function working
            _viewModel.NewMapping();
            LoadFormData();
        }

        private void LoadFormData()
        {
            // Mapping selection on the Left
            mappingBindingSource.DataSource = _viewModel.Mappings;
            lsbMappings.DataSource = mappingBindingSource;
            lsbMappings.DisplayMember = "Name";

            var dataBindingsInitalised = (tbName.DataBindings.Count > 0) ||
                (cbMappingType.DataBindings.Count > 0) ||
                (btnActivate.DataBindings.Count > 0);
            if (dataBindingsInitalised)
            {
                mappingBindingSource.ResetBindings(false);
            }
            else
            {
                // Mapping Name
                tbName.DataBindings.Add("Text", mappingBindingSource, "Name");

                // Mapping Type
                cbMappingType.DataSource = _viewModel.MappingTypes;
                cbMappingType.ValueMember = "Name";
                cbMappingType.ValueMember = "Id";
                cbMappingType.DataBindings.Add("SelectedValue", mappingBindingSource, "TypeId");

                // Input A
                cbInputA.DataSource = _viewModel.InputChannelsA;
                cbInputA.ValueMember = "Name";
                cbInputA.ValueMember = "Id";
                cbInputA.DataBindings.Add("SelectedValue", mappingBindingSource, "InputChannelAId");

                // Input B
                cbInputB.DataSource = _viewModel.InputChannelsB;
                cbInputB.ValueMember = "Name";
                cbInputB.ValueMember = "Id";
                cbInputB.DataBindings.Add("SelectedValue", mappingBindingSource, "InputChannelBId");

                // Output
                cbOutput.DataSource = _viewModel.OutputChannels;
                cbOutput.ValueMember = "Name";
                cbOutput.ValueMember = "Id";
                cbOutput.DataBindings.Add("SelectedValue", mappingBindingSource, "OutputChannelId");

                // Multiplier
                tbMultiplier.DataBindings.Add("Text", mappingBindingSource, "Multiplier");

                // Activate Button
                btnActivate.DataBindings.Add("Enabled", mappingBindingSource, "CanApply");

                // Panel Activation
                pnlMainArea.DataBindings.Add("Enabled", mappingBindingSource, "Deactivated");
            }
        }

        private void tbMultipler_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnActivate_Click(object sender, EventArgs e)
        {

        }

        private void btnDeactivate_Click(object sender, EventArgs e)
        {

        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _viewModel.Stop();
        }
    }
}
