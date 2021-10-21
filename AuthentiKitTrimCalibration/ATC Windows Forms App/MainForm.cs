using AuthentiKitTrimCalibration.ViewModel;
using MappingManager.Common.Model;
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
                Debug.WriteLine("Adding New mapping");
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

        private void btnRemoveMapping_Click(object sender, EventArgs e)
        {
            try
            {
                Debug.WriteLine("Removing selected mapping");
                _viewModel.RemoveSelectedMapping();
                LoadFormData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error removing mapping",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                _viewModel.Stop();
            }
        }



        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _viewModel.Stop();
        }

        private void headerControl2_Load(object sender, EventArgs e)
        {

        }

        private void LoadFormData()
        {
            // Mapping selection on the Left
            mappingBindingSource.DataSource = _viewModel.Mappings;
            lsbMappings.DataSource = mappingBindingSource;
            lsbMappings.DisplayMember = "Name";

            // AxisConfigControl
            axisConfigControl.LoadFormData(ref _viewModel, ref mappingBindingSource);

            var dataBindingsInitalised = (btnActivate.DataBindings.Count > 0) ||
                (btnDeactivate.DataBindings.Count > 0);
            if (dataBindingsInitalised)
            {
                mappingBindingSource.ResetBindings(false);
            }
            else
            {
                // Activate Button
                btnActivate.DataBindings.Add("Enabled", mappingBindingSource, "CanApply");

                // Deactivate Button
                btnDeactivate.DataBindings.Add("Enabled", mappingBindingSource, "Activated");
            }

        }
        private void configMenuItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem.Name.Equals("saveMenuItem"))
            {
                try
                {
                    _viewModel.SaveMappings();
                    MessageBox.Show("Your config has been saved", "Saved",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error while saving",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    _viewModel.Stop();
                }

            }
            else if (e.ClickedItem.Name.Equals("loadMenuItem"))
            {
                try
                {
                    _viewModel.LoadMappings();
                    LoadFormData();
                    MessageBox.Show("Your config has been loaded", "Loaded",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error while loading",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    _viewModel.Stop();
                }
            }
        }

        private void resetMenuItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            try
            {
                if (e.ClickedItem.Name.Equals("clearMenuItem"))
                {
                    _viewModel.Reset(Aircraft.NONE);
                }
                else if (e.ClickedItem.Name.Equals("spitfireMkIXMenuItem"))
                {
                    _viewModel.Reset(Aircraft.SPITFIRE_MKIX);
                    MessageBox.Show("Loaded recommended tuning for the MSFS FlyingIron Spitfire MK.IX", "Reset",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                LoadFormData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error while resetting",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                _viewModel.Stop();
            }
        }

        private void helpMenuItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            string msg = String.Format("Item clicked: {0}", e.ClickedItem.Text);
            MessageBox.Show(msg, "Clicked", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
    }
}
