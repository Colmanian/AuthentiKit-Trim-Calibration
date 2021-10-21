
namespace ATC_Windows_Forms_App
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.headerControl2 = new ATC_Windows_Forms_App.Controls.HeaderControl();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.configMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resetMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.spitfireMkIXMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.userGuideMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bugReportMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlNavigation = new System.Windows.Forms.Panel();
            this.lsbMappings = new System.Windows.Forms.ListBox();
            this.pnlAddMapping = new System.Windows.Forms.Panel();
            this.btnAddMapping = new System.Windows.Forms.Button();
            this.pnlMainArea = new System.Windows.Forms.Panel();
            this.tbMultiplier = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.cbOutput = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbInputB = new System.Windows.Forms.ComboBox();
            this.cbInputA = new System.Windows.Forms.ComboBox();
            this.tbName = new System.Windows.Forms.TextBox();
            this.cbMappingType = new System.Windows.Forms.ComboBox();
            this.lblMultiplier = new System.Windows.Forms.Label();
            this.lblMappingType = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.btnDeactivate = new System.Windows.Forms.Button();
            this.btnActivate = new System.Windows.Forms.Button();
            this.mappingBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.printToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.printPreviewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.redoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.cutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.selectAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.customizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.searchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlHeader.SuspendLayout();
            this.menuStrip.SuspendLayout();
            this.pnlNavigation.SuspendLayout();
            this.pnlAddMapping.SuspendLayout();
            this.pnlMainArea.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbMultiplier)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mappingBindingSource)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.Controls.Add(this.headerControl2);
            this.pnlHeader.Controls.Add(this.menuStrip);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(649, 100);
            this.pnlHeader.TabIndex = 0;
            // 
            // headerControl2
            // 
            this.headerControl2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(8)))), ((int)(((byte)(9)))));
            this.headerControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.headerControl2.Location = new System.Drawing.Point(0, 24);
            this.headerControl2.Name = "headerControl2";
            this.headerControl2.Size = new System.Drawing.Size(649, 76);
            this.headerControl2.TabIndex = 0;
            this.headerControl2.Load += new System.EventHandler(this.headerControl2_Load);
            // 
            // menuStrip
            // 
            this.menuStrip.BackColor = System.Drawing.SystemColors.ControlLight;
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.configMenuItem,
            this.resetMenuItem,
            this.helpMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.ShowItemToolTips = true;
            this.menuStrip.Size = new System.Drawing.Size(649, 24);
            this.menuStrip.TabIndex = 1;
            this.menuStrip.Text = "menuStrip";
            // 
            // configMenuItem
            // 
            this.configMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveMenuItem,
            this.loadMenuItem});
            this.configMenuItem.Name = "configMenuItem";
            this.configMenuItem.Size = new System.Drawing.Size(55, 20);
            this.configMenuItem.Text = "&Config";
            this.configMenuItem.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.configMenuItemClicked);
            // 
            // saveMenuItem
            // 
            this.saveMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("saveMenuItem.Image")));
            this.saveMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveMenuItem.Name = "saveMenuItem";
            this.saveMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveMenuItem.Size = new System.Drawing.Size(140, 22);
            this.saveMenuItem.Text = "&Save";
            // 
            // loadMenuItem
            // 
            this.loadMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("loadMenuItem.Image")));
            this.loadMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.loadMenuItem.Name = "loadMenuItem";
            this.loadMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.L)));
            this.loadMenuItem.Size = new System.Drawing.Size(140, 22);
            this.loadMenuItem.Text = "&Load";
            // 
            // resetMenuItem
            // 
            this.resetMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.spitfireMkIXMenuItem,
            this.toolStripSeparator4,
            this.clearMenuItem});
            this.resetMenuItem.Name = "resetMenuItem";
            this.resetMenuItem.Size = new System.Drawing.Size(47, 20);
            this.resetMenuItem.Text = "&Reset";
            this.resetMenuItem.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.resetMenuItemClicked);
            // 
            // spitfireMkIXMenuItem
            // 
            this.spitfireMkIXMenuItem.Name = "spitfireMkIXMenuItem";
            this.spitfireMkIXMenuItem.Size = new System.Drawing.Size(261, 22);
            this.spitfireMkIXMenuItem.Text = "&Spitfire Mk.IX  (FlyingIron for MSFS)";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(139, 6);
            // 
            // clearMenuItem
            // 
            this.clearMenuItem.Name = "clearMenuItem";
            this.clearMenuItem.Size = new System.Drawing.Size(261, 22);
            this.clearMenuItem.Text = "&Clear All";
            // 
            // helpMenuItem
            // 
            this.helpMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.userGuideMenuItem,
            this.bugReportMenuItem,
            this.toolStripSeparator5,
            this.aboutToolStripMenuItem});
            this.helpMenuItem.Name = "helpMenuItem";
            this.helpMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpMenuItem.Text = "&Help";
            this.helpMenuItem.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.helpMenuItemClicked);
            // 
            // userGuideMenuItem
            // 
            this.userGuideMenuItem.Name = "userGuideMenuItem";
            this.userGuideMenuItem.Size = new System.Drawing.Size(142, 22);
            this.userGuideMenuItem.Text = "&User Guide";
            // 
            // bugReportMenuItem
            // 
            this.bugReportMenuItem.Name = "bugReportMenuItem";
            this.bugReportMenuItem.Size = new System.Drawing.Size(142, 22);
            this.bugReportMenuItem.Text = "&Report a Bug";
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(139, 6);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.aboutToolStripMenuItem.Text = "&About...";
            // 
            // pnlNavigation
            // 
            this.pnlNavigation.BackColor = System.Drawing.SystemColors.Control;
            this.pnlNavigation.Controls.Add(this.lsbMappings);
            this.pnlNavigation.Controls.Add(this.pnlAddMapping);
            this.pnlNavigation.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlNavigation.Location = new System.Drawing.Point(0, 100);
            this.pnlNavigation.Name = "pnlNavigation";
            this.pnlNavigation.Size = new System.Drawing.Size(242, 441);
            this.pnlNavigation.TabIndex = 1;
            // 
            // lsbMappings
            // 
            this.lsbMappings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lsbMappings.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.lsbMappings.FormattingEnabled = true;
            this.lsbMappings.ItemHeight = 15;
            this.lsbMappings.Location = new System.Drawing.Point(7, 6);
            this.lsbMappings.Name = "lsbMappings";
            this.lsbMappings.Size = new System.Drawing.Size(230, 364);
            this.lsbMappings.TabIndex = 1;
            // 
            // pnlAddMapping
            // 
            this.pnlAddMapping.BackColor = System.Drawing.SystemColors.Control;
            this.pnlAddMapping.Controls.Add(this.btnAddMapping);
            this.pnlAddMapping.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlAddMapping.Location = new System.Drawing.Point(0, 378);
            this.pnlAddMapping.Name = "pnlAddMapping";
            this.pnlAddMapping.Size = new System.Drawing.Size(242, 63);
            this.pnlAddMapping.TabIndex = 0;
            // 
            // btnAddMapping
            // 
            this.btnAddMapping.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddMapping.Location = new System.Drawing.Point(12, 4);
            this.btnAddMapping.Name = "btnAddMapping";
            this.btnAddMapping.Size = new System.Drawing.Size(217, 30);
            this.btnAddMapping.TabIndex = 0;
            this.btnAddMapping.Text = "Add Mapping";
            this.btnAddMapping.UseVisualStyleBackColor = true;
            this.btnAddMapping.Click += new System.EventHandler(this.btnAddMapping_Click);
            // 
            // pnlMainArea
            // 
            this.pnlMainArea.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlMainArea.BackColor = System.Drawing.SystemColors.Control;
            this.pnlMainArea.Controls.Add(this.tbMultiplier);
            this.pnlMainArea.Controls.Add(this.label3);
            this.pnlMainArea.Controls.Add(this.cbOutput);
            this.pnlMainArea.Controls.Add(this.label2);
            this.pnlMainArea.Controls.Add(this.label1);
            this.pnlMainArea.Controls.Add(this.cbInputB);
            this.pnlMainArea.Controls.Add(this.cbInputA);
            this.pnlMainArea.Controls.Add(this.tbName);
            this.pnlMainArea.Controls.Add(this.cbMappingType);
            this.pnlMainArea.Controls.Add(this.lblMultiplier);
            this.pnlMainArea.Controls.Add(this.lblMappingType);
            this.pnlMainArea.Controls.Add(this.lblName);
            this.pnlMainArea.Location = new System.Drawing.Point(242, 100);
            this.pnlMainArea.Name = "pnlMainArea";
            this.pnlMainArea.Size = new System.Drawing.Size(407, 378);
            this.pnlMainArea.TabIndex = 2;
            // 
            // tbMultiplier
            // 
            this.tbMultiplier.Location = new System.Drawing.Point(19, 307);
            this.tbMultiplier.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.tbMultiplier.Name = "tbMultiplier";
            this.tbMultiplier.Size = new System.Drawing.Size(360, 23);
            this.tbMultiplier.TabIndex = 14;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 239);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 15);
            this.label3.TabIndex = 13;
            this.label3.Text = "Virtual Output Axis";
            // 
            // cbOutput
            // 
            this.cbOutput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbOutput.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbOutput.FormattingEnabled = true;
            this.cbOutput.Location = new System.Drawing.Point(19, 257);
            this.cbOutput.Name = "cbOutput";
            this.cbOutput.Size = new System.Drawing.Size(360, 23);
            this.cbOutput.TabIndex = 12;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 190);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 15);
            this.label2.TabIndex = 11;
            this.label2.Text = "Input Button -";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 141);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 15);
            this.label1.TabIndex = 10;
            this.label1.Text = "Input Button +";
            // 
            // cbInputB
            // 
            this.cbInputB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbInputB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbInputB.FormattingEnabled = true;
            this.cbInputB.Location = new System.Drawing.Point(19, 208);
            this.cbInputB.Name = "cbInputB";
            this.cbInputB.Size = new System.Drawing.Size(360, 23);
            this.cbInputB.TabIndex = 9;
            // 
            // cbInputA
            // 
            this.cbInputA.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbInputA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbInputA.FormattingEnabled = true;
            this.cbInputA.Location = new System.Drawing.Point(19, 159);
            this.cbInputA.Name = "cbInputA";
            this.cbInputA.Size = new System.Drawing.Size(360, 23);
            this.cbInputA.TabIndex = 8;
            // 
            // tbName
            // 
            this.tbName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbName.Location = new System.Drawing.Point(19, 36);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(360, 23);
            this.tbName.TabIndex = 7;
            // 
            // cbMappingType
            // 
            this.cbMappingType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbMappingType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMappingType.FormattingEnabled = true;
            this.cbMappingType.Location = new System.Drawing.Point(19, 90);
            this.cbMappingType.Name = "cbMappingType";
            this.cbMappingType.Size = new System.Drawing.Size(360, 23);
            this.cbMappingType.TabIndex = 4;
            // 
            // lblMultiplier
            // 
            this.lblMultiplier.AutoSize = true;
            this.lblMultiplier.Location = new System.Drawing.Point(19, 288);
            this.lblMultiplier.Name = "lblMultiplier";
            this.lblMultiplier.Size = new System.Drawing.Size(60, 15);
            this.lblMultiplier.TabIndex = 2;
            this.lblMultiplier.Text = "Sensitivity";
            // 
            // lblMappingType
            // 
            this.lblMappingType.AutoSize = true;
            this.lblMappingType.Location = new System.Drawing.Point(19, 72);
            this.lblMappingType.Name = "lblMappingType";
            this.lblMappingType.Size = new System.Drawing.Size(82, 15);
            this.lblMappingType.TabIndex = 1;
            this.lblMappingType.Text = "Mapping Type";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(19, 18);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(39, 15);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "Name";
            // 
            // btnDeactivate
            // 
            this.btnDeactivate.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnDeactivate.Enabled = false;
            this.btnDeactivate.Location = new System.Drawing.Point(213, 22);
            this.btnDeactivate.Name = "btnDeactivate";
            this.btnDeactivate.Size = new System.Drawing.Size(124, 29);
            this.btnDeactivate.TabIndex = 14;
            this.btnDeactivate.Text = "Deactivate";
            this.btnDeactivate.UseVisualStyleBackColor = true;
            this.btnDeactivate.Click += new System.EventHandler(this.btnDeactivate_Click);
            // 
            // btnActivate
            // 
            this.btnActivate.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnActivate.Location = new System.Drawing.Point(63, 22);
            this.btnActivate.Name = "btnActivate";
            this.btnActivate.Size = new System.Drawing.Size(131, 29);
            this.btnActivate.TabIndex = 6;
            this.btnActivate.Text = "Activate";
            this.btnActivate.UseVisualStyleBackColor = true;
            this.btnActivate.Click += new System.EventHandler(this.btnActivate_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Controls.Add(this.btnDeactivate);
            this.panel1.Controls.Add(this.btnActivate);
            this.panel1.Location = new System.Drawing.Point(242, 478);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(407, 63);
            this.panel1.TabIndex = 3;
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // toolStripSeparator
            // 
            this.toolStripSeparator.Name = "toolStripSeparator";
            this.toolStripSeparator.Size = new System.Drawing.Size(6, 6);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 6);
            // 
            // printToolStripMenuItem
            // 
            this.printToolStripMenuItem.Name = "printToolStripMenuItem";
            this.printToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // printPreviewToolStripMenuItem
            // 
            this.printPreviewToolStripMenuItem.Name = "printPreviewToolStripMenuItem";
            this.printPreviewToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // redoToolStripMenuItem
            // 
            this.redoToolStripMenuItem.Name = "redoToolStripMenuItem";
            this.redoToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 6);
            // 
            // cutToolStripMenuItem
            // 
            this.cutToolStripMenuItem.Name = "cutToolStripMenuItem";
            this.cutToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // pasteToolStripMenuItem
            // 
            this.pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
            this.pasteToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 6);
            // 
            // selectAllToolStripMenuItem
            // 
            this.selectAllToolStripMenuItem.Name = "selectAllToolStripMenuItem";
            this.selectAllToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // customizeToolStripMenuItem
            // 
            this.customizeToolStripMenuItem.Name = "customizeToolStripMenuItem";
            this.customizeToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // searchToolStripMenuItem
            // 
            this.searchToolStripMenuItem.Name = "searchToolStripMenuItem";
            this.searchToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(649, 541);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pnlMainArea);
            this.Controls.Add(this.pnlNavigation);
            this.Controls.Add(this.pnlHeader);
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(665, 580);
            this.MinimumSize = new System.Drawing.Size(665, 580);
            this.Name = "MainForm";
            this.Text = "AuthentiKit Tuning App";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.pnlNavigation.ResumeLayout(false);
            this.pnlAddMapping.ResumeLayout(false);
            this.pnlMainArea.ResumeLayout(false);
            this.pnlMainArea.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbMultiplier)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mappingBindingSource)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Panel pnlNavigation;
        private System.Windows.Forms.Panel pnlMainArea;
        private System.Windows.Forms.ListBox lsbMappings;
        private System.Windows.Forms.Panel pnlAddMapping;
        private System.Windows.Forms.Button btnAddMapping;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblMultiplier;
        private System.Windows.Forms.Label lblMappingType;
        private System.Windows.Forms.ComboBox cbMappingType;
        private System.Windows.Forms.Button btnActivate;
        private Controls.HeaderControl headerControl1;
        private System.Windows.Forms.BindingSource mappingBindingSource;
        private Controls.HeaderControl headerControl2;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbInputB;
        private System.Windows.Forms.ComboBox cbInputA;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbOutput;
        private System.Windows.Forms.Button btnDeactivate;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.NumericUpDown tbMultiplier;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem configMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
        private System.Windows.Forms.ToolStripMenuItem saveMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem printToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem printPreviewToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem resetMenuItem;
        private System.Windows.Forms.ToolStripMenuItem spitfireMkIXMenuItem;
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
    }
}

