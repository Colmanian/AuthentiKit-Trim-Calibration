
namespace AuthentiKitTuningApp.Controls
{
    partial class ButtonChangeToPulseControl
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
            pnlButtonConfig = new System.Windows.Forms.Panel();
            cbOutputButtonB = new System.Windows.Forms.ComboBox();
            label2 = new System.Windows.Forms.Label();
            DetectButton = new System.Windows.Forms.Button();
            label3 = new System.Windows.Forms.Label();
            cbOutputButtonA = new System.Windows.Forms.ComboBox();
            label1 = new System.Windows.Forms.Label();
            cbInputA = new System.Windows.Forms.ComboBox();
            label4 = new System.Windows.Forms.Label();
            tbPulseDuration = new System.Windows.Forms.NumericUpDown();
            pnlButtonConfig.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)tbPulseDuration).BeginInit();
            SuspendLayout();
            // 
            // pnlButtonConfig
            // 
            pnlButtonConfig.BackColor = System.Drawing.SystemColors.Control;
            pnlButtonConfig.Controls.Add(label4);
            pnlButtonConfig.Controls.Add(tbPulseDuration);
            pnlButtonConfig.Controls.Add(cbOutputButtonB);
            pnlButtonConfig.Controls.Add(label2);
            pnlButtonConfig.Controls.Add(DetectButton);
            pnlButtonConfig.Controls.Add(label3);
            pnlButtonConfig.Controls.Add(cbOutputButtonA);
            pnlButtonConfig.Controls.Add(label1);
            pnlButtonConfig.Controls.Add(cbInputA);
            pnlButtonConfig.Location = new System.Drawing.Point(0, 0);
            pnlButtonConfig.Name = "pnlButtonConfig";
            pnlButtonConfig.Size = new System.Drawing.Size(407, 256);
            pnlButtonConfig.TabIndex = 4;
            // 
            // cbOutputButtonB
            // 
            cbOutputButtonB.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            cbOutputButtonB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbOutputButtonB.FormattingEnabled = true;
            cbOutputButtonB.Location = new System.Drawing.Point(19, 146);
            cbOutputButtonB.Name = "cbOutputButtonB";
            cbOutputButtonB.Size = new System.Drawing.Size(371, 23);
            cbOutputButtonB.TabIndex = 21;
            cbOutputButtonB.SelectedIndexChanged += cbOutputB_SelectedIndexChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(19, 128);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(354, 15);
            label2.TabIndex = 20;
            label2.Text = "Virtual Output Button B (Pulses when input goes from OFF to ON)";
            // 
            // DetectButton
            // 
            DetectButton.Location = new System.Drawing.Point(331, 33);
            DetectButton.Name = "DetectButton";
            DetectButton.Size = new System.Drawing.Size(59, 25);
            DetectButton.TabIndex = 19;
            DetectButton.Text = "Detect";
            DetectButton.UseVisualStyleBackColor = true;
            DetectButton.Click += DetectButton_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(19, 78);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(355, 15);
            label3.TabIndex = 13;
            label3.Text = "Virtual Output Button A (Pulses when input goes from ON to OFF)";
            // 
            // cbOutputButtonA
            // 
            cbOutputButtonA.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            cbOutputButtonA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbOutputButtonA.FormattingEnabled = true;
            cbOutputButtonA.Location = new System.Drawing.Point(19, 96);
            cbOutputButtonA.Name = "cbOutputButtonA";
            cbOutputButtonA.Size = new System.Drawing.Size(371, 23);
            cbOutputButtonA.TabIndex = 12;
            cbOutputButtonA.SelectedIndexChanged += cbOutputA_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(19, 15);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(74, 15);
            label1.TabIndex = 10;
            label1.Text = "Input Button";
            // 
            // cbInputA
            // 
            cbInputA.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            cbInputA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbInputA.DropDownWidth = 800;
            cbInputA.FormattingEnabled = true;
            cbInputA.Location = new System.Drawing.Point(19, 33);
            cbInputA.Name = "cbInputA";
            cbInputA.Size = new System.Drawing.Size(306, 23);
            cbInputA.TabIndex = 8;
            cbInputA.SelectedIndexChanged += cbInputA_SelectedIndexChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            label4.Location = new System.Drawing.Point(18, 188);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(111, 15);
            label4.TabIndex = 23;
            label4.Text = "Pulse Duration (ms)";
            // 
            // tbPulseDuration
            // 
            tbPulseDuration.Location = new System.Drawing.Point(19, 206);
            tbPulseDuration.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            tbPulseDuration.Name = "tbPulseDuration";
            tbPulseDuration.Size = new System.Drawing.Size(157, 23);
            tbPulseDuration.TabIndex = 22;
            // 
            // ButtonChangeToPulseControl
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(pnlButtonConfig);
            Name = "ButtonChangeToPulseControl";
            Size = new System.Drawing.Size(407, 256);
            pnlButtonConfig.ResumeLayout(false);
            pnlButtonConfig.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)tbPulseDuration).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pnlButtonConfig;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbOutputButtonA;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbInputA;
        private System.Windows.Forms.Button DetectButton;
        private System.Windows.Forms.ComboBox cbOutputButtonB;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown tbPulseDuration;
    }
}
