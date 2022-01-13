
using System.Windows.Forms;

namespace ATC_Windows_Forms_App.Controls
{
    partial class AxisConfigControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnlAxisConfig = new System.Windows.Forms.Panel();
            this.tBarAxisSensitivity = new System.Windows.Forms.TrackBar();
            this.tbAxisSensitivity = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.cbOutputAxis = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbInputB = new System.Windows.Forms.ComboBox();
            this.cbInputA = new System.Windows.Forms.ComboBox();
            this.lblMultiplier = new System.Windows.Forms.Label();
            this.DetectButton1 = new System.Windows.Forms.Button();
            this.pnlAxisConfig.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tBarAxisSensitivity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbAxisSensitivity)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlAxisConfig
            // 
            this.pnlAxisConfig.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlAxisConfig.BackColor = System.Drawing.SystemColors.Control;
            this.pnlAxisConfig.Controls.Add(this.DetectButton1);
            this.pnlAxisConfig.Controls.Add(this.tBarAxisSensitivity);
            this.pnlAxisConfig.Controls.Add(this.tbAxisSensitivity);
            this.pnlAxisConfig.Controls.Add(this.label3);
            this.pnlAxisConfig.Controls.Add(this.cbOutputAxis);
            this.pnlAxisConfig.Controls.Add(this.label2);
            this.pnlAxisConfig.Controls.Add(this.label1);
            this.pnlAxisConfig.Controls.Add(this.cbInputB);
            this.pnlAxisConfig.Controls.Add(this.cbInputA);
            this.pnlAxisConfig.Controls.Add(this.lblMultiplier);
            this.pnlAxisConfig.Location = new System.Drawing.Point(0, 0);
            this.pnlAxisConfig.Name = "pnlAxisConfig";
            this.pnlAxisConfig.Size = new System.Drawing.Size(407, 256);
            this.pnlAxisConfig.TabIndex = 3;
            // 
            // tBarAxisSensitivity
            // 
            this.tBarAxisSensitivity.Location = new System.Drawing.Point(19, 204);
            this.tBarAxisSensitivity.Maximum = 1000;
            this.tBarAxisSensitivity.Name = "tBarAxisSensitivity";
            this.tBarAxisSensitivity.Size = new System.Drawing.Size(305, 45);
            this.tBarAxisSensitivity.TabIndex = 15;
            this.tBarAxisSensitivity.TickFrequency = 50;
            this.tBarAxisSensitivity.Value = 1;
            this.tBarAxisSensitivity.Click += new System.EventHandler(this.RefreshSensitivityBindings);
            this.tBarAxisSensitivity.ValueChanged += new System.EventHandler(this.RefreshSensitivityBindings);
            this.tBarAxisSensitivity.KeyUp += new System.Windows.Forms.KeyEventHandler(this.RefreshSensitivityBindings);
            // 
            // tbAxisSensitivity
            // 
            this.tbAxisSensitivity.Enabled = false;
            this.tbAxisSensitivity.Location = new System.Drawing.Point(330, 204);
            this.tbAxisSensitivity.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.tbAxisSensitivity.Name = "tbAxisSensitivity";
            this.tbAxisSensitivity.ReadOnly = true;
            this.tbAxisSensitivity.Size = new System.Drawing.Size(49, 23);
            this.tbAxisSensitivity.TabIndex = 14;
            this.tbAxisSensitivity.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 126);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 15);
            this.label3.TabIndex = 13;
            this.label3.Text = "Virtual Output Axis";
            // 
            // cbOutputAxis
            // 
            this.cbOutputAxis.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbOutputAxis.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbOutputAxis.FormattingEnabled = true;
            this.cbOutputAxis.Location = new System.Drawing.Point(19, 144);
            this.cbOutputAxis.Name = "cbOutputAxis";
            this.cbOutputAxis.Size = new System.Drawing.Size(360, 23);
            this.cbOutputAxis.TabIndex = 12;
            this.cbOutputAxis.SelectedIndexChanged += new System.EventHandler(this.cbOutput_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 15);
            this.label2.TabIndex = 11;
            this.label2.Text = "Input Button -";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 15);
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
            this.cbInputB.Location = new System.Drawing.Point(19, 90);
            this.cbInputB.Name = "cbInputB";
            this.cbInputB.Size = new System.Drawing.Size(295, 23);
            this.cbInputB.TabIndex = 9;
            this.cbInputB.SelectedIndexChanged += new System.EventHandler(this.cbInputB_SelectedIndexChanged);
            // 
            // cbInputA
            // 
            this.cbInputA.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbInputA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbInputA.FormattingEnabled = true;
            this.cbInputA.Location = new System.Drawing.Point(19, 33);
            this.cbInputA.Name = "cbInputA";
            this.cbInputA.Size = new System.Drawing.Size(295, 23);
            this.cbInputA.TabIndex = 8;
            this.cbInputA.SelectedIndexChanged += new System.EventHandler(this.cbInputA_SelectedIndexChanged);
            // 
            // lblMultiplier
            // 
            this.lblMultiplier.AutoSize = true;
            this.lblMultiplier.Location = new System.Drawing.Point(18, 182);
            this.lblMultiplier.Name = "lblMultiplier";
            this.lblMultiplier.Size = new System.Drawing.Size(60, 15);
            this.lblMultiplier.TabIndex = 2;
            this.lblMultiplier.Text = "Sensitivity";
            // 
            // DetectButton1
            // 
            this.DetectButton1.Location = new System.Drawing.Point(321, 33);
            this.DetectButton1.Name = "DetectButton1";
            this.DetectButton1.Size = new System.Drawing.Size(75, 23);
            this.DetectButton1.TabIndex = 16;
            this.DetectButton1.Text = "Detect";
            this.DetectButton1.UseVisualStyleBackColor = true;
            this.DetectButton1.Click += new System.EventHandler(this.DetectButton1_Click);
            // 
            // AxisConfigControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlAxisConfig);
            this.Name = "AxisConfigControl";
            this.Size = new System.Drawing.Size(407, 256);
            this.pnlAxisConfig.ResumeLayout(false);
            this.pnlAxisConfig.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tBarAxisSensitivity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbAxisSensitivity)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlAxisConfig;
        private System.Windows.Forms.NumericUpDown tbAxisSensitivity;
        private System.Windows.Forms.TrackBar tBarAxisSensitivity;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbOutputAxis;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbInputB;
        private System.Windows.Forms.ComboBox cbInputA;
        private System.Windows.Forms.Label lblMultiplier;
        private System.Windows.Forms.BindingSource mappingBindingSource;
        private Button DetectButton1;
    }
}
