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
            // Mapping selection on the Left
            _viewModel.LoadMappings();
            mappingBindingSource.DataSource = _viewModel.Mappings;
            lsbMappings.DataSource = mappingBindingSource;
            lsbMappings.DisplayMember = "Name";

            // Mapping Name
            tbName.DataBindings.Add("Text", mappingBindingSource, "Name",
                false, DataSourceUpdateMode.OnPropertyChanged);

            // Mapping Type
            cbMappingType.DataSource = _viewModel.MappingTypes;
            cbMappingType.ValueMember = "Name";
            cbMappingType.ValueMember = "Id";
            cbMappingType.DataBindings.Add("SelectedValue", mappingBindingSource, "TypeId");

            // Activate Button
            btnActivate.DataBindings.Add("Enabled", mappingBindingSource, "CanApply");
        }
    }
}
