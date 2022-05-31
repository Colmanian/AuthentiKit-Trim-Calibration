namespace ATC_Windows_Forms_App.Controls
{
    partial class AxisToAxisControl
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
            this.label1 = new System.Windows.Forms.Label();
            this.DetectButton = new System.Windows.Forms.Button();
            this.cbInputAxis = new System.Windows.Forms.ComboBox();
            this.pnlAxisToAxisConfig = new System.Windows.Forms.Panel();
            this.pnlAxisToAxisConfig.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Input Axis";
            // 
            // DetectButton
            // 
            this.DetectButton.AutoSize = true;
            this.DetectButton.Location = new System.Drawing.Point(304, 66);
            this.DetectButton.Name = "DetectButton";
            this.DetectButton.Size = new System.Drawing.Size(73, 25);
            this.DetectButton.TabIndex = 17;
            this.DetectButton.Text = "Detect";
            this.DetectButton.UseVisualStyleBackColor = true;
            this.DetectButton.Click += new System.EventHandler(this.DetectButton_Click);
            // 
            // cbInputAxis
            // 
            this.cbInputAxis.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbInputAxis.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbInputAxis.DropDownWidth = 512;
            this.cbInputAxis.FormattingEnabled = true;
            this.cbInputAxis.Location = new System.Drawing.Point(20, 37);
            this.cbInputAxis.Name = "cbInputAxis";
            this.cbInputAxis.Size = new System.Drawing.Size(357, 23);
            this.cbInputAxis.TabIndex = 18;
            this.cbInputAxis.SelectedIndexChanged += new System.EventHandler(this.cbInputAxis_SelectedIndexChanged);
            // 
            // pnlAxisToAxisConfig
            // 
            this.pnlAxisToAxisConfig.Controls.Add(this.cbInputAxis);
            this.pnlAxisToAxisConfig.Controls.Add(this.label1);
            this.pnlAxisToAxisConfig.Controls.Add(this.DetectButton);
            this.pnlAxisToAxisConfig.Location = new System.Drawing.Point(0, 0);
            this.pnlAxisToAxisConfig.Name = "pnlAxisToAxisConfig";
            this.pnlAxisToAxisConfig.Size = new System.Drawing.Size(407, 256);
            this.pnlAxisToAxisConfig.TabIndex = 19;
            // 
            // AxisToAxisControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlAxisToAxisConfig);
            this.Name = "AxisToAxisControl";
            this.Size = new System.Drawing.Size(407, 256);
            this.pnlAxisToAxisConfig.ResumeLayout(false);
            this.pnlAxisToAxisConfig.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button DetectButton;
        private System.Windows.Forms.ComboBox cbInputAxis;
        private System.Windows.Forms.Panel pnlAxisToAxisConfig;
    }
}
