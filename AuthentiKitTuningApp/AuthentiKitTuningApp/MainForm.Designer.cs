
namespace AuthentiKitTuningApp
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            pnlHeader = new System.Windows.Forms.Panel();
            lblVersion = new System.Windows.Forms.Label();
            headerControl2 = new Controls.HeaderControl();
            menuStrip = new System.Windows.Forms.MenuStrip();
            fileMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            saveMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            saveAsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            loadMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            exitMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            settingsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            startupMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            calibrationMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            startAllMappingsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            minimiseToSystemTrayMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            presetsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            spitfireMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            honeycombBravoMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            p40BMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            bf109MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            clearMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            helpMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            userGuideMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            bugReportMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            diagnosticsToolStripItem = new System.Windows.Forms.ToolStripMenuItem();
            toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            advancedButtonToButtonControl = new Controls.AdvancedButtonToButtonControl();
            pnlNavigation = new System.Windows.Forms.Panel();
            lblSaveFileName = new System.Windows.Forms.Label();
            axisToButtonControl = new Controls.AxisToButtonControl();
            btnAddMapping = new System.Windows.Forms.Button();
            lsbMappings = new System.Windows.Forms.ListBox();
            pnlAddMapping = new System.Windows.Forms.Panel();
            btnActivate = new System.Windows.Forms.Button();
            btnDeactivate = new System.Windows.Forms.Button();
            btnStopAll = new System.Windows.Forms.Button();
            btnRemoveMapping = new System.Windows.Forms.Button();
            btnStartAll = new System.Windows.Forms.Button();
            lblName = new System.Windows.Forms.Label();
            mappingBindingSource = new System.Windows.Forms.BindingSource(components);
            newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            printToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            printPreviewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            redoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            cutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            pasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            selectAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            customizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            searchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            tbName = new System.Windows.Forms.TextBox();
            cbMappingType = new System.Windows.Forms.ComboBox();
            lblMappingType = new System.Windows.Forms.Label();
            notifyIconTray = new System.Windows.Forms.NotifyIcon(components);
            contextMenuStripTray = new System.Windows.Forms.ContextMenuStrip(components);
            toolStripMenuItemShow = new System.Windows.Forms.ToolStripMenuItem();
            toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            toolStripMenuItemStartAll = new System.Windows.Forms.ToolStripMenuItem();
            toolStripMenuItemStopAll = new System.Windows.Forms.ToolStripMenuItem();
            toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            toolStripMenuItemExit = new System.Windows.Forms.ToolStripMenuItem();
            buttonToAxisControl = new Controls.ButtonToAxisControl();
            buttonToButtonControl = new Controls.ButtonToButtonControl();
            encoderToAxisControl = new Controls.EncoderToAxisControl();
            axisToAxisControl = new Controls.AxisToAxisControl();
            buttonChangeToPulseControl1 = new Controls.ButtonChangeToPulseControl();
            pnlHeader.SuspendLayout();
            menuStrip.SuspendLayout();
            pnlNavigation.SuspendLayout();
            pnlAddMapping.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)mappingBindingSource).BeginInit();
            contextMenuStripTray.SuspendLayout();
            SuspendLayout();
            // 
            // pnlHeader
            // 
            pnlHeader.Controls.Add(lblVersion);
            pnlHeader.Controls.Add(headerControl2);
            pnlHeader.Controls.Add(menuStrip);
            pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            pnlHeader.Location = new System.Drawing.Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new System.Drawing.Size(649, 100);
            pnlHeader.TabIndex = 0;
            // 
            // lblVersion
            // 
            lblVersion.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            lblVersion.AutoSize = true;
            lblVersion.BackColor = System.Drawing.SystemColors.Desktop;
            lblVersion.ForeColor = System.Drawing.SystemColors.GrayText;
            lblVersion.Location = new System.Drawing.Point(601, 82);
            lblVersion.Name = "lblVersion";
            lblVersion.Size = new System.Drawing.Size(45, 15);
            lblVersion.TabIndex = 2;
            lblVersion.Text = "version";
            lblVersion.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // headerControl2
            // 
            headerControl2.BackColor = System.Drawing.Color.FromArgb(8, 8, 9);
            headerControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            headerControl2.Location = new System.Drawing.Point(0, 24);
            headerControl2.Name = "headerControl2";
            headerControl2.Size = new System.Drawing.Size(649, 76);
            headerControl2.TabIndex = 0;
            // 
            // menuStrip
            // 
            menuStrip.BackColor = System.Drawing.SystemColors.ControlLight;
            menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { fileMenuItem, settingsMenuItem, presetsMenuItem, helpMenuItem });
            menuStrip.Location = new System.Drawing.Point(0, 0);
            menuStrip.Name = "menuStrip";
            menuStrip.ShowItemToolTips = true;
            menuStrip.Size = new System.Drawing.Size(649, 24);
            menuStrip.TabIndex = 1;
            menuStrip.Text = "menuStrip";
            // 
            // fileMenuItem
            // 
            fileMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { saveMenuItem, saveAsMenuItem, loadMenuItem, toolStripSeparator6, exitMenuItem });
            fileMenuItem.Name = "fileMenuItem";
            fileMenuItem.Size = new System.Drawing.Size(37, 20);
            fileMenuItem.Text = "&File";
            fileMenuItem.DropDownItemClicked += configMenuItemClicked;
            // 
            // saveMenuItem
            // 
            saveMenuItem.Image = (System.Drawing.Image)resources.GetObject("saveMenuItem.Image");
            saveMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            saveMenuItem.Name = "saveMenuItem";
            saveMenuItem.ShortcutKeys = System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S;
            saveMenuItem.Size = new System.Drawing.Size(171, 22);
            saveMenuItem.Text = "&Save";
            // 
            // saveAsMenuItem
            // 
            saveAsMenuItem.Image = (System.Drawing.Image)resources.GetObject("saveAsMenuItem.Image");
            saveAsMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            saveAsMenuItem.Name = "saveAsMenuItem";
            saveAsMenuItem.ShortcutKeys = System.Windows.Forms.Keys.Shift | System.Windows.Forms.Keys.F12;
            saveAsMenuItem.Size = new System.Drawing.Size(171, 22);
            saveAsMenuItem.Text = "&Save As";
            // 
            // loadMenuItem
            // 
            loadMenuItem.Image = (System.Drawing.Image)resources.GetObject("loadMenuItem.Image");
            loadMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            loadMenuItem.Name = "loadMenuItem";
            loadMenuItem.ShortcutKeys = System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.L;
            loadMenuItem.Size = new System.Drawing.Size(171, 22);
            loadMenuItem.Text = "&Load";
            // 
            // toolStripSeparator6
            // 
            toolStripSeparator6.Name = "toolStripSeparator6";
            toolStripSeparator6.Size = new System.Drawing.Size(168, 6);
            // 
            // exitMenuItem
            // 
            exitMenuItem.Name = "exitMenuItem";
            exitMenuItem.ShortcutKeys = System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4;
            exitMenuItem.Size = new System.Drawing.Size(171, 22);
            exitMenuItem.Text = "Exit";
            exitMenuItem.Click += exitMenuItem_Click;
            // 
            // settingsMenuItem
            // 
            settingsMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { startupMenuItem, calibrationMenuItem, startAllMappingsMenuItem, minimiseToSystemTrayMenuItem });
            settingsMenuItem.Name = "settingsMenuItem";
            settingsMenuItem.Size = new System.Drawing.Size(61, 20);
            settingsMenuItem.Text = "&Settings";
            settingsMenuItem.DropDownItemClicked += settingsMenuItemClicked;
            // 
            // startupMenuItem
            // 
            startupMenuItem.Image = (System.Drawing.Image)resources.GetObject("startupMenuItem.Image");
            startupMenuItem.Name = "startupMenuItem";
            startupMenuItem.Size = new System.Drawing.Size(241, 22);
            startupMenuItem.Text = "&Run on Windows Start";
            // 
            // calibrationMenuItem
            // 
            calibrationMenuItem.Image = (System.Drawing.Image)resources.GetObject("calibrationMenuItem.Image");
            calibrationMenuItem.Name = "calibrationMenuItem";
            calibrationMenuItem.Size = new System.Drawing.Size(241, 22);
            calibrationMenuItem.Text = "&Save and Load Axis Calibrations";
            // 
            // startAllMappingsMenuItem
            // 
            startAllMappingsMenuItem.Image = (System.Drawing.Image)resources.GetObject("startAllMappingsMenuItem.Image");
            startAllMappingsMenuItem.Name = "startAllMappingsMenuItem";
            startAllMappingsMenuItem.Size = new System.Drawing.Size(241, 22);
            startAllMappingsMenuItem.Text = "Start All Mappings on App Start";
            // 
            // minimiseToSystemTrayMenuItem
            // 
            minimiseToSystemTrayMenuItem.Image = (System.Drawing.Image)resources.GetObject("minimiseToSystemTrayMenuItem.Image");
            minimiseToSystemTrayMenuItem.Name = "minimiseToSystemTrayMenuItem";
            minimiseToSystemTrayMenuItem.Size = new System.Drawing.Size(241, 22);
            minimiseToSystemTrayMenuItem.Text = "&Minimise to System Tray";
            // 
            // presetsMenuItem
            // 
            presetsMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { spitfireMenuItem, honeycombBravoMenuItem, p40BMenuItem, bf109MenuItem, toolStripSeparator4, clearMenuItem });
            presetsMenuItem.Name = "presetsMenuItem";
            presetsMenuItem.Size = new System.Drawing.Size(56, 20);
            presetsMenuItem.Text = "&Presets";
            presetsMenuItem.DropDownItemClicked += presetsMenuItemClicked;
            // 
            // spitfireMenuItem
            // 
            spitfireMenuItem.Name = "spitfireMenuItem";
            spitfireMenuItem.Size = new System.Drawing.Size(236, 22);
            spitfireMenuItem.Text = "&Spitfire Mk.I / Mk.IX (for MSFS)";
            // 
            // honeycombBravoMenuItem
            // 
            honeycombBravoMenuItem.Name = "honeycombBravoMenuItem";
            honeycombBravoMenuItem.Size = new System.Drawing.Size(236, 22);
            honeycombBravoMenuItem.Text = "&Honeycomb Bravo (for MSFS)";
            // 
            // p40BMenuItem
            // 
            p40BMenuItem.Name = "p40BMenuItem";
            p40BMenuItem.Size = new System.Drawing.Size(236, 22);
            p40BMenuItem.Text = "&P-40B (for MSFS)";
            // 
            // bf109MenuItem
            // 
            bf109MenuItem.Name = "bf109MenuItem";
            bf109MenuItem.Size = new System.Drawing.Size(236, 22);
            bf109MenuItem.Text = "&Bf 109 (for DCS)";
            // 
            // toolStripSeparator4
            // 
            toolStripSeparator4.Name = "toolStripSeparator4";
            toolStripSeparator4.Size = new System.Drawing.Size(233, 6);
            // 
            // clearMenuItem
            // 
            clearMenuItem.Name = "clearMenuItem";
            clearMenuItem.Size = new System.Drawing.Size(236, 22);
            clearMenuItem.Text = "&Clear All";
            // 
            // helpMenuItem
            // 
            helpMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { userGuideMenuItem, bugReportMenuItem, diagnosticsToolStripItem, toolStripSeparator5, aboutToolStripMenuItem });
            helpMenuItem.Name = "helpMenuItem";
            helpMenuItem.Size = new System.Drawing.Size(44, 20);
            helpMenuItem.Text = "&Help";
            helpMenuItem.DropDownItemClicked += helpMenuItemClicked;
            // 
            // userGuideMenuItem
            // 
            userGuideMenuItem.Name = "userGuideMenuItem";
            userGuideMenuItem.Size = new System.Drawing.Size(159, 22);
            userGuideMenuItem.Text = "&User Guide";
            // 
            // bugReportMenuItem
            // 
            bugReportMenuItem.Name = "bugReportMenuItem";
            bugReportMenuItem.Size = new System.Drawing.Size(159, 22);
            bugReportMenuItem.Text = "&Report a Bug";
            // 
            // diagnosticsToolStripItem
            // 
            diagnosticsToolStripItem.Name = "diagnosticsToolStripItem";
            diagnosticsToolStripItem.Size = new System.Drawing.Size(159, 22);
            diagnosticsToolStripItem.Text = "Run &Diagnostics";
            // 
            // toolStripSeparator5
            // 
            toolStripSeparator5.Name = "toolStripSeparator5";
            toolStripSeparator5.Size = new System.Drawing.Size(156, 6);
            // 
            // aboutToolStripMenuItem
            // 
            aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            aboutToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            aboutToolStripMenuItem.Text = "&About...";
            // 
            // advancedButtonToButtonControl
            // 
            advancedButtonToButtonControl.Location = new System.Drawing.Point(242, 114);
            advancedButtonToButtonControl.Name = "advancedButtonToButtonControl";
            advancedButtonToButtonControl.Size = new System.Drawing.Size(407, 256);
            advancedButtonToButtonControl.TabIndex = 3;
            // 
            // pnlNavigation
            // 
            pnlNavigation.AutoSize = true;
            pnlNavigation.BackColor = System.Drawing.SystemColors.Control;
            pnlNavigation.Controls.Add(buttonChangeToPulseControl1);
            pnlNavigation.Controls.Add(advancedButtonToButtonControl);
            pnlNavigation.Controls.Add(lblSaveFileName);
            pnlNavigation.Controls.Add(axisToButtonControl);
            pnlNavigation.Controls.Add(btnAddMapping);
            pnlNavigation.Controls.Add(lsbMappings);
            pnlNavigation.Controls.Add(pnlAddMapping);
            pnlNavigation.Controls.Add(lblName);
            pnlNavigation.Dock = System.Windows.Forms.DockStyle.Left;
            pnlNavigation.Location = new System.Drawing.Point(0, 100);
            pnlNavigation.Name = "pnlNavigation";
            pnlNavigation.Size = new System.Drawing.Size(654, 435);
            pnlNavigation.TabIndex = 1;
            // 
            // lblSaveFileName
            // 
            lblSaveFileName.AutoSize = true;
            lblSaveFileName.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            lblSaveFileName.Location = new System.Drawing.Point(3, 3);
            lblSaveFileName.Name = "lblSaveFileName";
            lblSaveFileName.Padding = new System.Windows.Forms.Padding(5);
            lblSaveFileName.Size = new System.Drawing.Size(60, 25);
            lblSaveFileName.TabIndex = 21;
            lblSaveFileName.Text = "SaveFile";
            // 
            // axisToButtonControl
            // 
            axisToButtonControl.Location = new System.Drawing.Point(242, 121);
            axisToButtonControl.Name = "axisToButtonControl";
            axisToButtonControl.Size = new System.Drawing.Size(407, 256);
            axisToButtonControl.TabIndex = 2;
            // 
            // btnAddMapping
            // 
            btnAddMapping.Location = new System.Drawing.Point(7, 344);
            btnAddMapping.Name = "btnAddMapping";
            btnAddMapping.Size = new System.Drawing.Size(229, 26);
            btnAddMapping.TabIndex = 0;
            btnAddMapping.Text = "Add Mapping";
            btnAddMapping.UseVisualStyleBackColor = true;
            btnAddMapping.Click += btnAddMapping_Click;
            // 
            // lsbMappings
            // 
            lsbMappings.BackColor = System.Drawing.SystemColors.ControlLightLight;
            lsbMappings.FormattingEnabled = true;
            lsbMappings.ItemHeight = 15;
            lsbMappings.Location = new System.Drawing.Point(7, 31);
            lsbMappings.Name = "lsbMappings";
            lsbMappings.Size = new System.Drawing.Size(229, 304);
            lsbMappings.TabIndex = 1;
            // 
            // pnlAddMapping
            // 
            pnlAddMapping.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            pnlAddMapping.AutoSize = true;
            pnlAddMapping.BackColor = System.Drawing.SystemColors.Control;
            pnlAddMapping.Controls.Add(btnActivate);
            pnlAddMapping.Controls.Add(btnDeactivate);
            pnlAddMapping.Controls.Add(btnStopAll);
            pnlAddMapping.Controls.Add(btnRemoveMapping);
            pnlAddMapping.Controls.Add(btnStartAll);
            pnlAddMapping.Location = new System.Drawing.Point(0, 376);
            pnlAddMapping.Name = "pnlAddMapping";
            pnlAddMapping.Size = new System.Drawing.Size(637, 56);
            pnlAddMapping.TabIndex = 0;
            // 
            // btnActivate
            // 
            btnActivate.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            btnActivate.AutoSize = true;
            btnActivate.Location = new System.Drawing.Point(252, 25);
            btnActivate.Name = "btnActivate";
            btnActivate.Size = new System.Drawing.Size(91, 28);
            btnActivate.TabIndex = 17;
            btnActivate.Text = "Start";
            btnActivate.UseVisualStyleBackColor = true;
            btnActivate.Click += btnActivate_Click;
            // 
            // btnDeactivate
            // 
            btnDeactivate.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            btnDeactivate.AutoSize = true;
            btnDeactivate.Enabled = false;
            btnDeactivate.Location = new System.Drawing.Point(349, 25);
            btnDeactivate.Name = "btnDeactivate";
            btnDeactivate.Size = new System.Drawing.Size(91, 28);
            btnDeactivate.TabIndex = 18;
            btnDeactivate.Text = "Stop";
            btnDeactivate.UseVisualStyleBackColor = true;
            btnDeactivate.Click += btnDeactivate_Click;
            // 
            // btnStopAll
            // 
            btnStopAll.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            btnStopAll.Location = new System.Drawing.Point(126, 25);
            btnStopAll.Name = "btnStopAll";
            btnStopAll.Size = new System.Drawing.Size(110, 28);
            btnStopAll.TabIndex = 1;
            btnStopAll.Text = "Stop All";
            btnStopAll.UseVisualStyleBackColor = true;
            btnStopAll.Click += btnStopAll_Click;
            // 
            // btnRemoveMapping
            // 
            btnRemoveMapping.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            btnRemoveMapping.Location = new System.Drawing.Point(554, 25);
            btnRemoveMapping.Name = "btnRemoveMapping";
            btnRemoveMapping.Size = new System.Drawing.Size(80, 28);
            btnRemoveMapping.TabIndex = 1;
            btnRemoveMapping.Text = "Delete";
            btnRemoveMapping.UseVisualStyleBackColor = true;
            btnRemoveMapping.Click += btnRemoveMapping_Click;
            // 
            // btnStartAll
            // 
            btnStartAll.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            btnStartAll.Location = new System.Drawing.Point(7, 25);
            btnStartAll.Name = "btnStartAll";
            btnStartAll.Size = new System.Drawing.Size(113, 28);
            btnStartAll.TabIndex = 0;
            btnStartAll.Text = "Start All";
            btnStartAll.UseVisualStyleBackColor = true;
            btnStartAll.Click += btnStartAll_Click;
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Location = new System.Drawing.Point(261, 19);
            lblName.Name = "lblName";
            lblName.Size = new System.Drawing.Size(39, 15);
            lblName.TabIndex = 20;
            lblName.Text = "Name";
            // 
            // newToolStripMenuItem
            // 
            newToolStripMenuItem.Name = "newToolStripMenuItem";
            newToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // toolStripSeparator
            // 
            toolStripSeparator.Name = "toolStripSeparator";
            toolStripSeparator.Size = new System.Drawing.Size(6, 6);
            // 
            // saveAsToolStripMenuItem
            // 
            saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            saveAsToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new System.Drawing.Size(6, 6);
            // 
            // printToolStripMenuItem
            // 
            printToolStripMenuItem.Name = "printToolStripMenuItem";
            printToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // printPreviewToolStripMenuItem
            // 
            printPreviewToolStripMenuItem.Name = "printPreviewToolStripMenuItem";
            printPreviewToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new System.Drawing.Size(6, 6);
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // redoToolStripMenuItem
            // 
            redoToolStripMenuItem.Name = "redoToolStripMenuItem";
            redoToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // toolStripSeparator3
            // 
            toolStripSeparator3.Name = "toolStripSeparator3";
            toolStripSeparator3.Size = new System.Drawing.Size(6, 6);
            // 
            // cutToolStripMenuItem
            // 
            cutToolStripMenuItem.Name = "cutToolStripMenuItem";
            cutToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // copyToolStripMenuItem
            // 
            copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            copyToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // pasteToolStripMenuItem
            // 
            pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
            pasteToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // selectAllToolStripMenuItem
            // 
            selectAllToolStripMenuItem.Name = "selectAllToolStripMenuItem";
            selectAllToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // customizeToolStripMenuItem
            // 
            customizeToolStripMenuItem.Name = "customizeToolStripMenuItem";
            customizeToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // optionsToolStripMenuItem
            // 
            optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            optionsToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // searchToolStripMenuItem
            // 
            searchToolStripMenuItem.Name = "searchToolStripMenuItem";
            searchToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // tbName
            // 
            tbName.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            tbName.Location = new System.Drawing.Point(261, 137);
            tbName.Name = "tbName";
            tbName.Size = new System.Drawing.Size(376, 23);
            tbName.TabIndex = 23;
            tbName.TextChanged += tbName_TextChanged;
            // 
            // cbMappingType
            // 
            cbMappingType.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            cbMappingType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbMappingType.FormattingEnabled = true;
            cbMappingType.Location = new System.Drawing.Point(261, 191);
            cbMappingType.Name = "cbMappingType";
            cbMappingType.Size = new System.Drawing.Size(376, 23);
            cbMappingType.TabIndex = 22;
            cbMappingType.SelectedValueChanged += cbMappingType_SelectedValueChanged;
            // 
            // lblMappingType
            // 
            lblMappingType.AutoSize = true;
            lblMappingType.Location = new System.Drawing.Point(261, 173);
            lblMappingType.Name = "lblMappingType";
            lblMappingType.Size = new System.Drawing.Size(82, 15);
            lblMappingType.TabIndex = 21;
            lblMappingType.Text = "Mapping Type";
            // 
            // notifyIconTray
            // 
            notifyIconTray.ContextMenuStrip = contextMenuStripTray;
            notifyIconTray.Icon = (System.Drawing.Icon)resources.GetObject("notifyIconTray.Icon");
            notifyIconTray.Text = "AuthentiKit Tuning App";
            notifyIconTray.Visible = true;
            notifyIconTray.DoubleClick += notifyIconTray_DoubleClick;
            // 
            // contextMenuStripTray
            // 
            contextMenuStripTray.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { toolStripMenuItemShow, toolStripSeparator8, toolStripMenuItemStartAll, toolStripMenuItemStopAll, toolStripSeparator7, toolStripMenuItemExit });
            contextMenuStripTray.Name = "contextMenuStripTray";
            contextMenuStripTray.Size = new System.Drawing.Size(116, 104);
            // 
            // toolStripMenuItemShow
            // 
            toolStripMenuItemShow.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            toolStripMenuItemShow.Name = "toolStripMenuItemShow";
            toolStripMenuItemShow.Size = new System.Drawing.Size(115, 22);
            toolStripMenuItemShow.Text = "Show";
            toolStripMenuItemShow.Click += btnShow_Click;
            // 
            // toolStripSeparator8
            // 
            toolStripSeparator8.Name = "toolStripSeparator8";
            toolStripSeparator8.Size = new System.Drawing.Size(112, 6);
            // 
            // toolStripMenuItemStartAll
            // 
            toolStripMenuItemStartAll.Name = "toolStripMenuItemStartAll";
            toolStripMenuItemStartAll.Size = new System.Drawing.Size(115, 22);
            toolStripMenuItemStartAll.Text = "Start All";
            toolStripMenuItemStartAll.Click += btnStartAll_Click;
            // 
            // toolStripMenuItemStopAll
            // 
            toolStripMenuItemStopAll.Name = "toolStripMenuItemStopAll";
            toolStripMenuItemStopAll.Size = new System.Drawing.Size(115, 22);
            toolStripMenuItemStopAll.Text = "Stop All";
            toolStripMenuItemStopAll.Click += btnStopAll_Click;
            // 
            // toolStripSeparator7
            // 
            toolStripSeparator7.Name = "toolStripSeparator7";
            toolStripSeparator7.Size = new System.Drawing.Size(112, 6);
            // 
            // toolStripMenuItemExit
            // 
            toolStripMenuItemExit.Name = "toolStripMenuItemExit";
            toolStripMenuItemExit.Size = new System.Drawing.Size(115, 22);
            toolStripMenuItemExit.Text = "Exit";
            toolStripMenuItemExit.Click += toolStripMenuItemExit_Click;
            // 
            // buttonToAxisControl
            // 
            buttonToAxisControl.Location = new System.Drawing.Point(242, 218);
            buttonToAxisControl.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            buttonToAxisControl.Name = "buttonToAxisControl";
            buttonToAxisControl.Size = new System.Drawing.Size(407, 256);
            buttonToAxisControl.TabIndex = 24;
            // 
            // buttonToButtonControl
            // 
            buttonToButtonControl.Location = new System.Drawing.Point(242, 218);
            buttonToButtonControl.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            buttonToButtonControl.Name = "buttonToButtonControl";
            buttonToButtonControl.Size = new System.Drawing.Size(407, 256);
            buttonToButtonControl.TabIndex = 25;
            // 
            // encoderToAxisControl
            // 
            encoderToAxisControl.Location = new System.Drawing.Point(242, 218);
            encoderToAxisControl.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            encoderToAxisControl.Name = "encoderToAxisControl";
            encoderToAxisControl.Size = new System.Drawing.Size(407, 256);
            encoderToAxisControl.TabIndex = 26;
            // 
            // axisToAxisControl
            // 
            axisToAxisControl.AutoSize = true;
            axisToAxisControl.Location = new System.Drawing.Point(242, 218);
            axisToAxisControl.Name = "axisToAxisControl";
            axisToAxisControl.Size = new System.Drawing.Size(410, 259);
            axisToAxisControl.TabIndex = 27;
            // 
            // buttonChangeToPulseControl1
            // 
            buttonChangeToPulseControl1.Location = new System.Drawing.Point(242, 114);
            buttonChangeToPulseControl1.Name = "buttonChangeToPulseControl1";
            buttonChangeToPulseControl1.Size = new System.Drawing.Size(407, 256);
            buttonChangeToPulseControl1.TabIndex = 22;

            // 
            // MainForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            AutoSize = true;
            ClientSize = new System.Drawing.Size(649, 535);
            Controls.Add(axisToAxisControl);
            Controls.Add(encoderToAxisControl);
            Controls.Add(buttonToButtonControl);
            Controls.Add(buttonToAxisControl);
            Controls.Add(tbName);
            Controls.Add(cbMappingType);
            Controls.Add(lblMappingType);
            Controls.Add(pnlNavigation);
            Controls.Add(pnlHeader);
            HelpButton = true;
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            MaximumSize = new System.Drawing.Size(665, 574);
            MinimumSize = new System.Drawing.Size(665, 574);
            Name = "MainForm";
            Text = "AuthentiKit Tuning App";
            FormClosing += MainForm_FormClosing;
            Load += MainForm_Load;
            Resize += MainForm_Resize;
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            menuStrip.ResumeLayout(false);
            menuStrip.PerformLayout();
            pnlNavigation.ResumeLayout(false);
            pnlNavigation.PerformLayout();
            pnlAddMapping.ResumeLayout(false);
            pnlAddMapping.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)mappingBindingSource).EndInit();
            contextMenuStripTray.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Panel pnlNavigation;
        private System.Windows.Forms.ListBox lsbMappings;
        private System.Windows.Forms.Panel pnlAddMapping;
        private System.Windows.Forms.Button btnAddMapping;
        private Controls.HeaderControl headerControl1;
        private System.Windows.Forms.BindingSource mappingBindingSource;
        private Controls.HeaderControl headerControl2;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
        private System.Windows.Forms.ToolStripMenuItem saveMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem printToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem printPreviewToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem presetsMenuItem;
        private System.Windows.Forms.ToolStripMenuItem spitfireMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearMenuItem;
        private System.Windows.Forms.ToolStripMenuItem redoToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem cutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pasteToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem selectAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem customizeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpMenuItem;
        private System.Windows.Forms.ToolStripMenuItem userGuideMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bugReportMenuItem;
        private System.Windows.Forms.ToolStripMenuItem searchToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.Button btnRemoveMapping;
        private System.Windows.Forms.Button btnDeactivate;
        private System.Windows.Forms.Button btnActivate;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.ComboBox cbMappingType;
        private System.Windows.Forms.Label lblMappingType;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.ToolStripMenuItem settingsMenuItem;
        private System.Windows.Forms.ToolStripMenuItem startupMenuItem;
        private System.Windows.Forms.Button btnStopAll;
        private System.Windows.Forms.Button btnStartAll;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripMenuItem exitMenuItem;
        private System.Windows.Forms.NotifyIcon notifyIconTray;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripTray;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemStartAll;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemStopAll;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemExit;
        private System.Windows.Forms.ToolStripMenuItem honeycombBravoMenuItem;
        private Controls.ButtonToAxisControl buttonToAxisControl;
        private Controls.ButtonToButtonControl buttonToButtonControl;
        private Controls.EncoderToAxisControl encoderToAxisControl;
        private Controls.AxisToAxisControl axisToAxisControl;
        private Controls.AxisToButtonControl axisToButtonControl;
        private Controls.AdvancedButtonToButtonControl advancedButtonToButtonControl;
        private System.Windows.Forms.ToolStripMenuItem calibrationMenuItem;
        private System.Windows.Forms.ToolStripMenuItem startAllMappingsMenuItem;
        private System.Windows.Forms.Label lblSaveFileName;
        private System.Windows.Forms.Label lblVersion;
        private System.Windows.Forms.ToolStripMenuItem p40BMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bf109MenuItem;
        private System.Windows.Forms.ToolStripMenuItem minimiseToSystemTrayMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemShow;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.ToolStripMenuItem diagnosticsToolStripItem;
        private Controls.ButtonChangeToPulseControl buttonChangeToPulseControl1;
    }
}

