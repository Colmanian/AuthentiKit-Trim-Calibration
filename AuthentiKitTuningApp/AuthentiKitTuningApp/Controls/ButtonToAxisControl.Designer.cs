
using System.Windows.Forms;

namespace AuthentiKitTuningApp.Controls
{
    partial class ButtonToAxisControl
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
            pnlAxisConfig = new Panel();
            DetectButton2 = new Button();
            DetectButton1 = new Button();
            tbAxisSensitivity = new NumericUpDown();
            label3 = new Label();
            cbOutputAxis = new ComboBox();
            label2 = new Label();
            label1 = new Label();
            cbInputB = new ComboBox();
            cbInputA = new ComboBox();
            lblMultiplier = new Label();
            pnlAxisConfig.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)tbAxisSensitivity).BeginInit();
            SuspendLayout();
            // 
            // pnlAxisConfig
            // 
            pnlAxisConfig.AutoSize = true;
            pnlAxisConfig.BackColor = System.Drawing.SystemColors.Control;
            pnlAxisConfig.Controls.Add(DetectButton2);
            pnlAxisConfig.Controls.Add(DetectButton1);
            pnlAxisConfig.Controls.Add(tbAxisSensitivity);
            pnlAxisConfig.Controls.Add(label3);
            pnlAxisConfig.Controls.Add(cbOutputAxis);
            pnlAxisConfig.Controls.Add(label2);
            pnlAxisConfig.Controls.Add(label1);
            pnlAxisConfig.Controls.Add(cbInputB);
            pnlAxisConfig.Controls.Add(cbInputA);
            pnlAxisConfig.Controls.Add(lblMultiplier);
            pnlAxisConfig.Location = new System.Drawing.Point(0, 0);
            pnlAxisConfig.Name = "pnlAxisConfig";
            pnlAxisConfig.Size = new System.Drawing.Size(407, 256);
            pnlAxisConfig.TabIndex = 3;
            // 
            // DetectButton2
            // 
            DetectButton2.AutoSize = true;
            DetectButton2.Location = new System.Drawing.Point(332, 89);
            DetectButton2.Name = "DetectButton2";
            DetectButton2.Size = new System.Drawing.Size(59, 25);
            DetectButton2.TabIndex = 17;
            DetectButton2.Text = "Detect";
            DetectButton2.UseVisualStyleBackColor = true;
            DetectButton2.Click += DetectButton2_Click;
            // 
            // DetectButton1
            // 
            DetectButton1.AutoSize = true;
            DetectButton1.Location = new System.Drawing.Point(332, 37);
            DetectButton1.Name = "DetectButton1";
            DetectButton1.Size = new System.Drawing.Size(59, 25);
            DetectButton1.TabIndex = 16;
            DetectButton1.Text = "Detect";
            DetectButton1.UseVisualStyleBackColor = true;
            DetectButton1.Click += DetectButton1_Click;
            // 
            // tbAxisSensitivity
            // 
            tbAxisSensitivity.AutoSize = true;
            tbAxisSensitivity.Location = new System.Drawing.Point(23, 204);
            tbAxisSensitivity.Maximum = new decimal(new int[] { 999999, 0, 0, 0 });
            tbAxisSensitivity.Name = "tbAxisSensitivity";
            tbAxisSensitivity.Size = new System.Drawing.Size(80, 23);
            tbAxisSensitivity.TabIndex = 14;
            tbAxisSensitivity.Value = new decimal(new int[] { 1000, 0, 0, 0 });
            // 
            // label3
            // 
            label3.AutoEllipsis = true;
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(20, 125);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(107, 15);
            label3.TabIndex = 13;
            label3.Text = "Virtual Output Axis";
            // 
            // cbOutputAxis
            // 
            cbOutputAxis.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            cbOutputAxis.DropDownStyle = ComboBoxStyle.DropDownList;
            cbOutputAxis.FormattingEnabled = true;
            cbOutputAxis.Location = new System.Drawing.Point(20, 143);
            cbOutputAxis.Name = "cbOutputAxis";
            cbOutputAxis.Size = new System.Drawing.Size(371, 23);
            cbOutputAxis.TabIndex = 12;
            cbOutputAxis.SelectedIndexChanged += cbOutput_SelectedIndexChanged;
            // 
            // label2
            // 
            label2.AutoEllipsis = true;
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(20, 71);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(82, 15);
            label2.TabIndex = 11;
            label2.Text = "Input Button -";
            // 
            // label1
            // 
            label1.AutoEllipsis = true;
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(20, 19);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(85, 15);
            label1.TabIndex = 10;
            label1.Text = "Input Button +";
            // 
            // cbInputB
            // 
            cbInputB.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            cbInputB.DropDownStyle = ComboBoxStyle.DropDownList;
            cbInputB.DropDownWidth = 800;
            cbInputB.FormattingEnabled = true;
            cbInputB.Location = new System.Drawing.Point(20, 89);
            cbInputB.Name = "cbInputB";
            cbInputB.Size = new System.Drawing.Size(306, 23);
            cbInputB.TabIndex = 9;
            cbInputB.SelectedIndexChanged += cbInputB_SelectedIndexChanged;
            // 
            // cbInputA
            // 
            cbInputA.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            cbInputA.DropDownStyle = ComboBoxStyle.DropDownList;
            cbInputA.DropDownWidth = 800;
            cbInputA.FormattingEnabled = true;
            cbInputA.Location = new System.Drawing.Point(20, 37);
            cbInputA.Name = "cbInputA";
            cbInputA.Size = new System.Drawing.Size(306, 23);
            cbInputA.TabIndex = 8;
            cbInputA.SelectedIndexChanged += cbInputA_SelectedIndexChanged;
            // 
            // lblMultiplier
            // 
            lblMultiplier.AutoEllipsis = true;
            lblMultiplier.AutoSize = true;
            lblMultiplier.Location = new System.Drawing.Point(20, 186);
            lblMultiplier.Name = "lblMultiplier";
            lblMultiplier.Size = new System.Drawing.Size(60, 15);
            lblMultiplier.TabIndex = 2;
            lblMultiplier.Text = "Sensitivity";
            // 
            // ButtonToAxisControl
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(pnlAxisConfig);
            Name = "ButtonToAxisControl";
            Size = new System.Drawing.Size(407, 256);
            pnlAxisConfig.ResumeLayout(false);
            pnlAxisConfig.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)tbAxisSensitivity).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel pnlAxisConfig;
        private NumericUpDown tbAxisSensitivity;
        private Label label3;
        private ComboBox cbOutputAxis;
        private Label label2;
        private Label label1;
        private ComboBox cbInputB;
        private ComboBox cbInputA;
        private Label lblMultiplier;
        private BindingSource mappingBindingSource;
        private Button DetectButton1;
        private Button DetectButton2;
    }
}
