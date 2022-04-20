
namespace ATC_Windows_Forms_App.Controls
{
    partial class EncoderAxisControl
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
            this.pnlEncoderAxisConfig = new System.Windows.Forms.Panel();
            this.DetectButton2 = new System.Windows.Forms.Button();
            this.DetectButton1 = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tbRevsInPerRevsOut = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbEncoderPPR = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.cbOutputAxis = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbInputB = new System.Windows.Forms.ComboBox();
            this.cbInputA = new System.Windows.Forms.ComboBox();
            this.lblMultiplier = new System.Windows.Forms.Label();
            this.pnlEncoderAxisConfig.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbEncoderPPR)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlEncoderAxisConfig
            // 
            this.pnlEncoderAxisConfig.AutoSize = true;
            this.pnlEncoderAxisConfig.BackColor = System.Drawing.SystemColors.Control;
            this.pnlEncoderAxisConfig.Controls.Add(this.DetectButton2);
            this.pnlEncoderAxisConfig.Controls.Add(this.DetectButton1);
            this.pnlEncoderAxisConfig.Controls.Add(this.label6);
            this.pnlEncoderAxisConfig.Controls.Add(this.label5);
            this.pnlEncoderAxisConfig.Controls.Add(this.tbRevsInPerRevsOut);
            this.pnlEncoderAxisConfig.Controls.Add(this.label4);
            this.pnlEncoderAxisConfig.Controls.Add(this.tbEncoderPPR);
            this.pnlEncoderAxisConfig.Controls.Add(this.label3);
            this.pnlEncoderAxisConfig.Controls.Add(this.cbOutputAxis);
            this.pnlEncoderAxisConfig.Controls.Add(this.label2);
            this.pnlEncoderAxisConfig.Controls.Add(this.label1);
            this.pnlEncoderAxisConfig.Controls.Add(this.cbInputB);
            this.pnlEncoderAxisConfig.Controls.Add(this.cbInputA);
            this.pnlEncoderAxisConfig.Controls.Add(this.lblMultiplier);
            this.pnlEncoderAxisConfig.Location = new System.Drawing.Point(0, 0);
            this.pnlEncoderAxisConfig.Name = "pnlEncoderAxisConfig";
            this.pnlEncoderAxisConfig.Size = new System.Drawing.Size(476, 256);
            this.pnlEncoderAxisConfig.TabIndex = 4;
            // 
            // DetectButton2
            // 
            this.DetectButton2.AutoSize = true;
            this.DetectButton2.Location = new System.Drawing.Point(305, 88);
            this.DetectButton2.Name = "DetectButton2";
            this.DetectButton2.Size = new System.Drawing.Size(73, 25);
            this.DetectButton2.TabIndex = 21;
            this.DetectButton2.Text = "Detect";
            this.DetectButton2.UseVisualStyleBackColor = true;
            this.DetectButton2.Click += new System.EventHandler(this.DetectButton2_Click);
            // 
            // DetectButton1
            // 
            this.DetectButton1.AutoSize = true;
            this.DetectButton1.Location = new System.Drawing.Point(305, 37);
            this.DetectButton1.Name = "DetectButton1";
            this.DetectButton1.Size = new System.Drawing.Size(73, 25);
            this.DetectButton1.TabIndex = 20;
            this.DetectButton1.Text = "Detect";
            this.DetectButton1.UseVisualStyleBackColor = true;
            this.DetectButton1.Click += new System.EventHandler(this.DetectButton_Click);
            // 
            // label6
            // 
            this.label6.AutoEllipsis = true;
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(18, 192);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(99, 15);
            this.label6.TabIndex = 19;
            this.label6.Text = "(min=6, max=24)";
            // 
            // label5
            // 
            this.label5.AutoEllipsis = true;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(235, 190);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(108, 15);
            this.label5.TabIndex = 18;
            this.label5.Text = "(min=0.2, max=16)";
            // 
            // tbRevsInPerRevsOut
            // 
            this.tbRevsInPerRevsOut.Location = new System.Drawing.Point(236, 210);
            this.tbRevsInPerRevsOut.Name = "tbRevsInPerRevsOut";
            this.tbRevsInPerRevsOut.Size = new System.Drawing.Size(145, 23);
            this.tbRevsInPerRevsOut.TabIndex = 17;
            this.tbRevsInPerRevsOut.TextChanged += new System.EventHandler(this.tbRevsInPerRevsOut_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoEllipsis = true;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(235, 175);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(110, 15);
            this.label4.TabIndex = 16;
            this.label4.Text = "Rev. In per Rev. Out";
            // 
            // tbEncoderPPR
            // 
            this.tbEncoderPPR.Location = new System.Drawing.Point(20, 210);
            this.tbEncoderPPR.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.tbEncoderPPR.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.tbEncoderPPR.Name = "tbEncoderPPR";
            this.tbEncoderPPR.Size = new System.Drawing.Size(163, 23);
            this.tbEncoderPPR.TabIndex = 14;
            this.tbEncoderPPR.Value = new decimal(new int[] {
            6,
            0,
            0,
            0});
            this.tbEncoderPPR.Click += new System.EventHandler(this.tbEncoderPPR_Click);
            this.tbEncoderPPR.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tbEncoderPPR_KeyUp);
            // 
            // label3
            // 
            this.label3.AutoEllipsis = true;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 122);
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
            this.cbOutputAxis.Location = new System.Drawing.Point(20, 140);
            this.cbOutputAxis.Name = "cbOutputAxis";
            this.cbOutputAxis.Size = new System.Drawing.Size(358, 23);
            this.cbOutputAxis.TabIndex = 12;
            this.cbOutputAxis.SelectedIndexChanged += new System.EventHandler(this.cbOutput_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoEllipsis = true;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 15);
            this.label2.TabIndex = 11;
            this.label2.Text = "Encoder Input B";
            // 
            // label1
            // 
            this.label1.AutoEllipsis = true;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 18);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(2, 1, 0, 0);
            this.label1.Size = new System.Drawing.Size(94, 16);
            this.label1.TabIndex = 10;
            this.label1.Text = "Encoder Input A";
            // 
            // cbInputB
            // 
            this.cbInputB.AccessibleRole = System.Windows.Forms.AccessibleRole.ComboBox;
            this.cbInputB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbInputB.DropDownWidth = 512;
            this.cbInputB.FormattingEnabled = true;
            this.cbInputB.Location = new System.Drawing.Point(20, 88);
            this.cbInputB.MaxDropDownItems = 16;
            this.cbInputB.Name = "cbInputB";
            this.cbInputB.Size = new System.Drawing.Size(255, 23);
            this.cbInputB.TabIndex = 9;
            this.cbInputB.SelectedIndexChanged += new System.EventHandler(this.cbInputB_SelectedIndexChanged);
            // 
            // cbInputA
            // 
            this.cbInputA.AccessibleRole = System.Windows.Forms.AccessibleRole.ComboBox;
            this.cbInputA.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbInputA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbInputA.DropDownWidth = 512;
            this.cbInputA.FormattingEnabled = true;
            this.cbInputA.Location = new System.Drawing.Point(20, 37);
            this.cbInputA.MaxDropDownItems = 16;
            this.cbInputA.Name = "cbInputA";
            this.cbInputA.Size = new System.Drawing.Size(255, 23);
            this.cbInputA.TabIndex = 8;
            this.cbInputA.SelectedIndexChanged += new System.EventHandler(this.cbInputA_SelectedIndexChanged);
            // 
            // lblMultiplier
            // 
            this.lblMultiplier.AutoEllipsis = true;
            this.lblMultiplier.AutoSize = true;
            this.lblMultiplier.Location = new System.Drawing.Point(18, 175);
            this.lblMultiplier.Name = "lblMultiplier";
            this.lblMultiplier.Padding = new System.Windows.Forms.Padding(0, 1, 0, 0);
            this.lblMultiplier.Size = new System.Drawing.Size(131, 16);
            this.lblMultiplier.TabIndex = 2;
            this.lblMultiplier.Text = "Encoder Pulses per Rev.";
            // 
            // EncoderAxisControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlEncoderAxisConfig);
            this.Name = "EncoderAxisControl";
            this.Size = new System.Drawing.Size(407, 256);
            this.pnlEncoderAxisConfig.ResumeLayout(false);
            this.pnlEncoderAxisConfig.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbEncoderPPR)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlEncoderAxisConfig;
        private System.Windows.Forms.NumericUpDown tbEncoderPPR;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbOutputAxis;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbInputB;
        private System.Windows.Forms.ComboBox cbInputA;
        private System.Windows.Forms.Label lblMultiplier;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbRevsInPerRevsOut;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button DetectButton1;
        private System.Windows.Forms.Button DetectButton2;
    }
}
