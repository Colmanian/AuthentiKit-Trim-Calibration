using AuthentiKitTrimCalibration.ViewModel;
using MappingManager.Common.Model;
using System;
using System.Diagnostics;
using System.Reflection;
using System.Windows.Forms;

namespace ATC_Windows_Forms_App
{
    public partial class MainForm : Form
    {
        private MainViewModel _viewModel;

        private readonly string VERSION =
            Assembly.GetExecutingAssembly().GetName().Version.Major + "."
            + Assembly.GetExecutingAssembly().GetName().Version.Minor + "."
            + Assembly.GetExecutingAssembly().GetName().Version.Build;
        private readonly string DOCS_URL = "https://authentikit.org/tuning";
        private readonly string DEVELOPER_URL = "https://collotech.net";



        public MainForm()
        {
            try
            {
                InitializeComponent();
                _viewModel = new MainViewModel();
                InitalSetup();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error on Startup",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                _viewModel.Stop();
            }
            Debug.WriteLine(SaveFileName);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            try
            {
                _viewModel.LoadMappings();
                LoadFormData();
                if (_viewModel.StartAllOnOpen)
                {
                    _viewModel.Start();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error loading app",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                _viewModel.Stop();
            }

            lblVersion.Text = VERSION;
        }


        private void btnAddMapping_Click(object sender, EventArgs e)
        {
            try
            {
                Debug.WriteLine("Adding New mapping");
                _viewModel.NewMapping();
                LoadFormData();
                lsbMappings.SelectedIndex = lsbMappings.Items.Count - 1;
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
                if (mappingBindingSource.Current is MappingViewModel mappingViewModel)
                {
                    _viewModel.RemoveMapping(mappingViewModel);
                }
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

        private void LoadFormData()
        {
            // Initialise the BindingSource
            mappingBindingSource.DataSource = _viewModel.Mappings;

            // Mapping selection on the Left
            lsbMappings.DataSource = mappingBindingSource;
            lsbMappings.DisplayMember = "Name";

            // Save File Name
            lblSaveFileName.Text = SaveFileName;

            var dataBindingsInitalised = (btnActivate.DataBindings.Count > 0) ||
                (btnDeactivate.DataBindings.Count > 0) ||
                (buttonToAxisControl.DataBindings.Count > 0) ||
                (tbName.DataBindings.Count > 0) ||
                (cbMappingType.DataBindings.Count > 0) ||
                (buttonToButtonControl.DataBindings.Count > 0);
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
                cbMappingType.DataBindings.Add("Enabled", mappingBindingSource, "Deactivated");

                // Remove Mapping Button
                btnRemoveMapping.DataBindings.Add("Enabled", mappingBindingSource, "Exists");

                // Activate and Deactivate Buttons
                btnActivate.DataBindings.Add("Enabled", mappingBindingSource, "CanApply");
                btnDeactivate.DataBindings.Add("Enabled", mappingBindingSource, "Activated");

                // Panel Visibility
                buttonToAxisControl.Visible = true;
                buttonToButtonControl.Visible = true;
                encoderToAxisControl.Visible = true;
                axisToAxisControl.Visible = true;
                buttonToAxisControl.DataBindings.Add("Visible", mappingBindingSource, "IsButtonToAxisMapping");
                buttonToButtonControl.DataBindings.Add("Visible", mappingBindingSource, "IsButtonToButtonMapping");
                encoderToAxisControl.DataBindings.Add("Visible", mappingBindingSource, "IsEncoderToAxisMapping");
                axisToAxisControl.DataBindings.Add("Visible", mappingBindingSource, "IsAxisToAxisMapping");

                // buttonToAxisControl
                buttonToAxisControl.LoadFormData(ref _viewModel, ref mappingBindingSource);

                // buttonToButtonControl
                buttonToButtonControl.LoadFormData(ref _viewModel, ref mappingBindingSource);

                // encoderToAxisControl
                encoderToAxisControl.LoadFormData(ref _viewModel, ref mappingBindingSource);

                // axisToAxisControl
                axisToAxisControl.LoadFormData(ref _viewModel, ref mappingBindingSource);

                // axisToButtonControl
                axisToButtonControl1.LoadFormData(ref _viewModel, ref mappingBindingSource);

                // Form Activation
                tbName.DataBindings.Add("Enabled", mappingBindingSource, "Deactivated");
            }

            // Update Selected Mapping
            if (mappingBindingSource.Current is MappingViewModel mappingViewModel)
            {
                mappingViewModel.Name = tbName.Text;
                tbName.SelectionStart = tbName.Text.Length;
                tbName.SelectionLength = 0;
            }

        }
        private void configMenuItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            fileMenuItem.DropDown.Close();
            if (e.ClickedItem.Name.Equals("saveAsMenuItem") || ((e.ClickedItem.Name.Equals("saveMenuItem")) && (!_viewModel.SaveFileExists())))
            {
                try
                {
                    SaveFileDialog saveFileDialog = new();
                    saveFileDialog.Filter = "XML Files (*.xml)|*.xml";
                    saveFileDialog.FilterIndex = 0;
                    saveFileDialog.DefaultExt = "xml";
                    saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
                    saveFileDialog.RestoreDirectory = true;

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        _viewModel.SaveMappings(saveFileDialog.FileName);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error while saving",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    _viewModel.Stop();
                }

            }
            else if (e.ClickedItem.Name.Equals("saveMenuItem"))
            {
                try
                {
                    _viewModel.SaveMappings();
                    MessageBox.Show("Your config has been saved to " + _viewModel.GetSaveFilePath(), "Saved",
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
                    OpenFileDialog openFileDialog = new();
                    openFileDialog.Filter = "XML Files (*.xml)|*.xml";
                    openFileDialog.FilterIndex = 0;
                    openFileDialog.DefaultExt = "xml";
                    openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
                    openFileDialog.RestoreDirectory = true;

                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        _viewModel.LoadMappings(openFileDialog.FileName);
                        LoadFormData();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error while loading",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    _viewModel.Stop();
                }
            }
        }

        private void presetsMenuItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            try
            {
                if (e.ClickedItem.Name.Equals("clearMenuItem"))
                {
                    _viewModel.Reset(Preset.NONE);
                }
                else if (e.ClickedItem.Name.Equals("spitfireMkIXMenuItem"))
                {
                    _viewModel.Reset(Preset.SPITFIRE_MKIX);
                }
                else if (e.ClickedItem.Name.Equals("honeycombBravoMenuItem"))
                {
                    _viewModel.Reset(Preset.HONEYCOMB_BRAVO);
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
        private void settingsMenuItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            try
            {
                if (e.ClickedItem.Name.Equals("startupMenuItem"))
                {
                    string message = "Would you like to run this application on Windows Start Up ?";
                    DialogResult dialogResult = MessageBox.Show(message, "Start Up Options", MessageBoxButtons.YesNo);
                    bool runOnStartup = false;
                    if (dialogResult == DialogResult.Yes)
                    {
                        runOnStartup = true;
                    }
                    _viewModel.SetRunOnStartup(runOnStartup);
                    MessageBox.Show("Run on Windows Startup set to " + runOnStartup, "Setting Updated",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (e.ClickedItem.Name.Equals("calibrationMenuItem"))
                {
                    string message = "Would you like persist axis calibrations along with your mappings?";
                    DialogResult dialogResult = MessageBox.Show(message, "Axis Calibration  Options", MessageBoxButtons.YesNo);
                    bool persist = false;
                    if (dialogResult == DialogResult.Yes)
                    {
                        persist = true;
                    }
                    _viewModel.PersistCalibration = persist;
                    MessageBox.Show("Persist calibrations set to " + _viewModel.PersistCalibration, "Setting Updated",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (e.ClickedItem.Name.Equals("startAllMappingsMenuItem"))
                {
                    string message = "Would you like start all mappings whenever the app starts?";
                    DialogResult dialogResult = MessageBox.Show(message, "Start All on Open", MessageBoxButtons.YesNo);
                    bool startAllOnOpen = false;
                    if (dialogResult == DialogResult.Yes)
                    {
                        startAllOnOpen = true;
                    }
                    _viewModel.StartAllOnOpen = startAllOnOpen;
                    MessageBox.Show("Start All Mappigns is set to " + _viewModel.StartAllOnOpen, "Setting Updated",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error changing settings",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                _viewModel.Stop();
            }
        }

        private void helpMenuItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            try
            {
                if (e.ClickedItem.Name.Equals("userGuideMenuItem"))
                {
                    ProcessStartInfo sInfo = new(DOCS_URL)
                    {
                        UseShellExecute = true
                    };
                    Process.Start(sInfo);
                }
                else if (e.ClickedItem.Name.Equals("bugReportMenuItem"))
                {
                    ProcessStartInfo sInfo = new(DOCS_URL)
                    {
                        UseShellExecute = true
                    };
                    Process.Start(sInfo);
                }
                else if (e.ClickedItem.Name.Equals("aboutToolStripMenuItem"))
                {
                    string message = String.Format("AuthentiKit Tuning App ({0})\n\n" +
                        "Authored by Ian Colman and licensed under CC BY NC ND 4.0.\n\n" +
                        "You can find more details at the developer's home page. Would you like to go there now?",
                        VERSION);
                    string title = "About";
                    MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
                    DialogResult result = MessageBox.Show(message, title, buttons);
                    if (result == DialogResult.OK)
                    {
                        ProcessStartInfo sInfo = new(DEVELOPER_URL)
                        {
                            UseShellExecute = true
                        };
                        Process.Start(sInfo);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error displaying help windows",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                _viewModel.Stop();
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

        /*
         * The following methods only exist to trigger an update of the data binding without having to
         * select another control. The main way that data is updated in the mapping is via the databindings
         * specified in the LoadFormData above.
         */
        private void cbMappingType_SelectedValueChanged(object sender, EventArgs e)
        {
            if ((mappingBindingSource.Current is MappingViewModel mappingViewModel) && (_viewModel.Mappings.Count > 0))
            {
                if (cbMappingType.SelectedValue != null)
                {
                    string selected = cbMappingType.SelectedValue.ToString();
                    if (selected.Equals("0") ||
                        selected.Equals("1") ||
                        selected.Equals("2") ||
                        selected.Equals("3") ||
                        selected.Equals("4") ||
                        selected.Equals("5"))
                        mappingViewModel.TypeId = int.Parse(selected);
                }
            }
        }

        private void tbName_TextChanged(object sender, EventArgs e)
        {
            if ((mappingBindingSource.Current is MappingViewModel mappingViewModel) && (_viewModel.Mappings.Count > 0))
            {
                mappingViewModel.Name = tbName.Text;
                tbName.SelectionStart = tbName.Text.Length;
                tbName.SelectionLength = 0;
            }
        }

        private void InitalSetup()
        {
            if (!_viewModel.AtLeastOneMapping)
            {
                try
                {
                    _viewModel.NewMapping();
                    LoadFormData();
                    lsbMappings.SelectedIndex = lsbMappings.Items.Count - 1;
                    if (mappingBindingSource.Current is MappingViewModel mappingViewModel)
                    {
                        _viewModel.RemoveMapping(mappingViewModel);
                    }
                    LoadFormData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error starting up",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    _viewModel.Stop();
                }
            }
        }

        private void btnStartAll_Click(object sender, EventArgs e)
        {
            _viewModel.Start();
        }

        private void btnStopAll_Click(object sender, EventArgs e)
        {
            _viewModel.Stop();
        }

        private void exitMenuItem_Click(object sender, EventArgs e)
        {
            _viewModel.Stop();
            Application.Exit();
        }

        private void toolStripMenuItemExit_Click(object sender, EventArgs e)
        {
            _viewModel.Stop();
            Application.Exit();
        }

        private string SaveFileName { get { return _viewModel.SaveFileName; } }
    }
}
