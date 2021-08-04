
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
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.headerControl1 = new ATC_Windows_Forms_App.Controls.HeaderControl();
            this.pnlNavigation = new System.Windows.Forms.Panel();
            this.lsbMappings = new System.Windows.Forms.ListBox();
            this.pnlAddMapping = new System.Windows.Forms.Panel();
            this.btnAddMapping = new System.Windows.Forms.Button();
            this.pnlMainArea = new System.Windows.Forms.Panel();
            this.btnActivate = new System.Windows.Forms.Button();
            this.tbMultipler = new System.Windows.Forms.TextBox();
            this.cbMappingType = new System.Windows.Forms.ComboBox();
            this.tbName = new System.Windows.Forms.TextBox();
            this.lblMultiplier = new System.Windows.Forms.Label();
            this.lblMappingType = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.mappingBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.pnlHeader.SuspendLayout();
            this.pnlNavigation.SuspendLayout();
            this.pnlAddMapping.SuspendLayout();
            this.pnlMainArea.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mappingBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.Controls.Add(this.headerControl1);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1157, 100);
            this.pnlHeader.TabIndex = 0;
            // 
            // headerControl1
            // 
            this.headerControl1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(138)))), ((int)(((byte)(0)))));
            this.headerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.headerControl1.Location = new System.Drawing.Point(0, 0);
            this.headerControl1.Name = "headerControl1";
            this.headerControl1.Size = new System.Drawing.Size(1157, 100);
            this.headerControl1.TabIndex = 0;
            // 
            // pnlNavigation
            // 
            this.pnlNavigation.Controls.Add(this.lsbMappings);
            this.pnlNavigation.Controls.Add(this.pnlAddMapping);
            this.pnlNavigation.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlNavigation.Location = new System.Drawing.Point(0, 100);
            this.pnlNavigation.Name = "pnlNavigation";
            this.pnlNavigation.Size = new System.Drawing.Size(242, 350);
            this.pnlNavigation.TabIndex = 1;
            // 
            // lsbMappings
            // 
            this.lsbMappings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lsbMappings.FormattingEnabled = true;
            this.lsbMappings.ItemHeight = 15;
            this.lsbMappings.Location = new System.Drawing.Point(0, 0);
            this.lsbMappings.Name = "lsbMappings";
            this.lsbMappings.Size = new System.Drawing.Size(242, 287);
            this.lsbMappings.TabIndex = 1;
            // 
            // pnlAddMapping
            // 
            this.pnlAddMapping.Controls.Add(this.btnAddMapping);
            this.pnlAddMapping.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlAddMapping.Location = new System.Drawing.Point(0, 287);
            this.pnlAddMapping.Name = "pnlAddMapping";
            this.pnlAddMapping.Size = new System.Drawing.Size(242, 63);
            this.pnlAddMapping.TabIndex = 0;
            // 
            // btnAddMapping
            // 
            this.btnAddMapping.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddMapping.Location = new System.Drawing.Point(12, 16);
            this.btnAddMapping.Name = "btnAddMapping";
            this.btnAddMapping.Size = new System.Drawing.Size(217, 30);
            this.btnAddMapping.TabIndex = 0;
            this.btnAddMapping.Text = "Add Mapping";
            this.btnAddMapping.UseVisualStyleBackColor = true;
            // 
            // pnlMainArea
            // 
            this.pnlMainArea.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlMainArea.Controls.Add(this.btnActivate);
            this.pnlMainArea.Controls.Add(this.tbMultipler);
            this.pnlMainArea.Controls.Add(this.cbMappingType);
            this.pnlMainArea.Controls.Add(this.tbName);
            this.pnlMainArea.Controls.Add(this.lblMultiplier);
            this.pnlMainArea.Controls.Add(this.lblMappingType);
            this.pnlMainArea.Controls.Add(this.lblName);
            this.pnlMainArea.Location = new System.Drawing.Point(242, 100);
            this.pnlMainArea.Name = "pnlMainArea";
            this.pnlMainArea.Size = new System.Drawing.Size(915, 350);
            this.pnlMainArea.TabIndex = 2;
            // 
            // btnActivate
            // 
            this.btnActivate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnActivate.Location = new System.Drawing.Point(26, 303);
            this.btnActivate.Name = "btnActivate";
            this.btnActivate.Size = new System.Drawing.Size(861, 30);
            this.btnActivate.TabIndex = 6;
            this.btnActivate.Text = "Activate";
            this.btnActivate.UseVisualStyleBackColor = true;
            // 
            // tbMultipler
            // 
            this.tbMultipler.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbMultipler.Location = new System.Drawing.Point(19, 147);
            this.tbMultipler.Name = "tbMultipler";
            this.tbMultipler.Size = new System.Drawing.Size(868, 23);
            this.tbMultipler.TabIndex = 5;
            // 
            // cbMappingType
            // 
            this.cbMappingType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbMappingType.FormattingEnabled = true;
            this.cbMappingType.Location = new System.Drawing.Point(19, 92);
            this.cbMappingType.Name = "cbMappingType";
            this.cbMappingType.Size = new System.Drawing.Size(868, 23);
            this.cbMappingType.TabIndex = 4;
            // 
            // tbName
            // 
            this.tbName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbName.Location = new System.Drawing.Point(19, 37);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(868, 23);
            this.tbName.TabIndex = 3;
            // 
            // lblMultiplier
            // 
            this.lblMultiplier.AutoSize = true;
            this.lblMultiplier.Location = new System.Drawing.Point(19, 128);
            this.lblMultiplier.Name = "lblMultiplier";
            this.lblMultiplier.Size = new System.Drawing.Size(58, 15);
            this.lblMultiplier.TabIndex = 2;
            this.lblMultiplier.Text = "Multiplier";
            // 
            // lblMappingType
            // 
            this.lblMappingType.AutoSize = true;
            this.lblMappingType.Location = new System.Drawing.Point(19, 74);
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
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1157, 450);
            this.Controls.Add(this.pnlMainArea);
            this.Controls.Add(this.pnlNavigation);
            this.Controls.Add(this.pnlHeader);
            this.Name = "MainForm";
            this.Text = "Authentikit Trim Calibration";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.pnlHeader.ResumeLayout(false);
            this.pnlNavigation.ResumeLayout(false);
            this.pnlAddMapping.ResumeLayout(false);
            this.pnlMainArea.ResumeLayout(false);
            this.pnlMainArea.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mappingBindingSource)).EndInit();
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
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.TextBox tbMultipler;
        private System.Windows.Forms.Button btnActivate;
        private Controls.HeaderControl headerControl1;
        private System.Windows.Forms.BindingSource mappingBindingSource;
    }
}

