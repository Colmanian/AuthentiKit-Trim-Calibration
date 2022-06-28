
namespace AuthentiKitTuningApp.Controls
{
    partial class ButtonToButtonControl
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
            this.pnlButtonConfig = new System.Windows.Forms.Panel();
            this.DetectButton = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.tbHoldThresholdStop = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.tbHoldThresholdStart = new System.Windows.Forms.NumericUpDown();
            this.tbButtonMultiplier = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.cbOutputButton = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbInputA = new System.Windows.Forms.ComboBox();
            this.lblMultiplier = new System.Windows.Forms.Label();
            this.pnlButtonConfig.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbHoldThresholdStop)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbHoldThresholdStart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbButtonMultiplier)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlButtonConfig
            // 
            this.pnlButtonConfig.BackColor = System.Drawing.SystemColors.Control;
            this.pnlButtonConfig.Controls.Add(this.DetectButton);
            this.pnlButtonConfig.Controls.Add(this.label4);
            this.pnlButtonConfig.Controls.Add(this.tbHoldThresholdStop);
            this.pnlButtonConfig.Controls.Add(this.label2);
            this.pnlButtonConfig.Controls.Add(this.tbHoldThresholdStart);
            this.pnlButtonConfig.Controls.Add(this.tbButtonMultiplier);
            this.pnlButtonConfig.Controls.Add(this.label3);
            this.pnlButtonConfig.Controls.Add(this.cbOutputButton);
            this.pnlButtonConfig.Controls.Add(this.label1);
            this.pnlButtonConfig.Controls.Add(this.cbInputA);
            this.pnlButtonConfig.Controls.Add(this.lblMultiplier);
            this.pnlButtonConfig.Location = new System.Drawing.Point(0, 0);
            this.pnlButtonConfig.Name = "pnlButtonConfig";
            this.pnlButtonConfig.Size = new System.Drawing.Size(407, 256);
            this.pnlButtonConfig.TabIndex = 4;
            // 
            // DetectButton
            // 
            this.DetectButton.Location = new System.Drawing.Point(309, 33);
            this.DetectButton.Name = "DetectButton";
            this.DetectButton.Size = new System.Drawing.Size(68, 23);
            this.DetectButton.TabIndex = 19;
            this.DetectButton.Text = "Detect";
            this.DetectButton.UseVisualStyleBackColor = true;
            this.DetectButton.Click += new System.EventHandler(this.DetectButton_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(222, 195);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(142, 15);
            this.label4.TabIndex = 18;
            this.label4.Text = "Stop Holding After... (ms)";
            // 
            // tbHoldThresholdStop
            // 
            this.tbHoldThresholdStop.Location = new System.Drawing.Point(222, 213);
            this.tbHoldThresholdStop.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.tbHoldThresholdStop.Name = "tbHoldThresholdStop";
            this.tbHoldThresholdStop.Size = new System.Drawing.Size(155, 23);
            this.tbHoldThresholdStop.TabIndex = 17;
            this.tbHoldThresholdStop.Click += new System.EventHandler(this.tbHoldThresholdStop_click);
            this.tbHoldThresholdStop.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tbHoldThresholdStop_keyUp);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label2.Location = new System.Drawing.Point(18, 195);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(158, 15);
            this.label2.TabIndex = 16;
            this.label2.Text = "Hold Output On After... (ms)";
            // 
            // tbHoldThresholdStart
            // 
            this.tbHoldThresholdStart.Location = new System.Drawing.Point(19, 213);
            this.tbHoldThresholdStart.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.tbHoldThresholdStart.Name = "tbHoldThresholdStart";
            this.tbHoldThresholdStart.Size = new System.Drawing.Size(157, 23);
            this.tbHoldThresholdStart.TabIndex = 15;
            this.tbHoldThresholdStart.Click += new System.EventHandler(this.tbHoldThresholdStart_click);
            this.tbHoldThresholdStart.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tbHoldThresholdStart_keyUp);
            // 
            // tbButtonMultiplier
            // 
            this.tbButtonMultiplier.Location = new System.Drawing.Point(19, 154);
            this.tbButtonMultiplier.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.tbButtonMultiplier.Name = "tbButtonMultiplier";
            this.tbButtonMultiplier.Size = new System.Drawing.Size(358, 23);
            this.tbButtonMultiplier.TabIndex = 14;
            this.tbButtonMultiplier.Click += new System.EventHandler(this.tbButtonMultiplier_Click);
            this.tbButtonMultiplier.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tbButtonMultiplier_KeyUp);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(121, 15);
            this.label3.TabIndex = 13;
            this.label3.Text = "Virtual Output Button";
            // 
            // cbOutputButton
            // 
            this.cbOutputButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbOutputButton.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbOutputButton.FormattingEnabled = true;
            this.cbOutputButton.Location = new System.Drawing.Point(19, 91);
            this.cbOutputButton.Name = "cbOutputButton";
            this.cbOutputButton.Size = new System.Drawing.Size(358, 23);
            this.cbOutputButton.TabIndex = 12;
            this.cbOutputButton.SelectedIndexChanged += new System.EventHandler(this.cbOutput_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 15);
            this.label1.TabIndex = 10;
            this.label1.Text = "Input Button";
            // 
            // cbInputA
            // 
            this.cbInputA.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbInputA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbInputA.DropDownWidth = 512;
            this.cbInputA.FormattingEnabled = true;
            this.cbInputA.Location = new System.Drawing.Point(19, 33);
            this.cbInputA.Name = "cbInputA";
            this.cbInputA.Size = new System.Drawing.Size(264, 23);
            this.cbInputA.TabIndex = 8;
            this.cbInputA.SelectedIndexChanged += new System.EventHandler(this.cbInputA_SelectedIndexChanged);
            // 
            // lblMultiplier
            // 
            this.lblMultiplier.AutoSize = true;
            this.lblMultiplier.Location = new System.Drawing.Point(18, 135);
            this.lblMultiplier.Name = "lblMultiplier";
            this.lblMultiplier.Size = new System.Drawing.Size(209, 15);
            this.lblMultiplier.TabIndex = 2;
            this.lblMultiplier.Text = "Multipler (pulses out per button press)";
            // 
            // ButtonConfigControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlButtonConfig);
            this.Name = "ButtonConfigControl";
            this.Size = new System.Drawing.Size(407, 256);
            this.pnlButtonConfig.ResumeLayout(false);
            this.pnlButtonConfig.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbHoldThresholdStop)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbHoldThresholdStart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbButtonMultiplier)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlButtonConfig;
        private System.Windows.Forms.NumericUpDown tbButtonMultiplier;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbOutputButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbInputA;
        private System.Windows.Forms.Label lblMultiplier;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown tbHoldThresholdStart;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown tbHoldThresholdStop;
        private System.Windows.Forms.Button DetectButton;
    }
}
