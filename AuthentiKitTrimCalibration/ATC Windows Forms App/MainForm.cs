using AuthentiKitTrimCalibration.ViewModel;
using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace ATC_Windows_Forms_App
{
    public partial class MainForm : Form
    {
        private MainViewModel _viewModel;

        public MainForm()
        {
            try
            {
                InitializeComponent();
                _viewModel = new MainViewModel();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error on Startup",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                _viewModel.Stop();
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            try
            {
                _viewModel.LoadMappings();
                LoadFormData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error loading app",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                _viewModel.Stop();
            }
        }


        private void btnAddMapping_Click(object sender, EventArgs e)
        {
            try
            {
                Debug.WriteLine("Adding New mapping"); /// You're trying to get this function working
                _viewModel.NewMapping();
                LoadFormData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error adding new mapping",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                _viewModel.Stop();
            }
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
                cbMappingType.DisplayMember = "Name";
                cbMappingType.ValueMember = "Id";
                cbMappingType.DataBindings.Add("SelectedValue", mappingBindingSource, "TypeId");

                // Input A
                cbInputA.DataSource = _viewModel.InputChannelsA;
                cbInputA.DisplayMember = "Name";
                cbInputA.ValueMember = "Id";
                cbInputA.DataBindings.Add("SelectedValue", mappingBindingSource, "InputChannelAId");

                // Input B
                cbInputB.DataSource = _viewModel.InputChannelsB;
                cbInputB.DisplayMember = "Name";
                cbInputB.ValueMember = "Id";
                cbInputB.DataBindings.Add("SelectedValue", mappingBindingSource, "InputChannelBId");

                // Output
                cbOutput.DataSource = _viewModel.OutputChannels;
                cbOutput.DisplayMember = "Name";
                cbOutput.ValueMember = "Id";
                cbOutput.DataBindings.Add("SelectedValue", mappingBindingSource, "OutputChannelId");

                // Multiplier
                tbMultiplier.DataBindings.Add("Text", mappingBindingSource, "Multiplier");

                // Activate Button
                btnActivate.DataBindings.Add("Enabled", mappingBindingSource, "CanApply");

                // Deactivate Button
                btnDeactivate.DataBindings.Add("Enabled", mappingBindingSource, "Activated");

                // Panel Activation
                pnlMainArea.DataBindings.Add("Enabled", mappingBindingSource, "Deactivated");
            }
        }

        private void btnActivate_Click(object sender, EventArgs e)
        {
            try
            {
                if (mappingBindingSource.Current is MappingViewModel mappingViewModel
                    && mappingViewModel.Deactivated)
                {
                    mappingViewModel.Activate();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error activating mapping",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                _viewModel.Stop();
            }
        }

        private void btnDeactivate_Click(object sender, EventArgs e)
        {
            try
            {
                if (mappingBindingSource.Current is MappingViewModel mappingViewModel
                    && mappingViewModel.Activated)
                {
                    mappingViewModel.Deactivate();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error deactivating mapping",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                _viewModel.Stop();
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _viewModel.Stop();
        }
    }
}
