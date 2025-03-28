
using System.Drawing;
using System.Windows.Forms;

namespace AuthentiKitTuningApp.Controls
{
    partial class RotaryControl : UserControl
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
            panel1 = new Panel();
            DetectButton2 = new Button();
            DetectButton1 = new Button();
            label2 = new Label();
            label1 = new Label();
            cbInputB = new ComboBox();
            cbInputA = new ComboBox();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.AutoSize = true;
            panel1.BackColor = SystemColors.Control;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(407, 256);
            panel1.TabIndex = 3;
            // 
            // DetectButton2
            // 
            DetectButton2.AutoSize = true;
            DetectButton2.Location = new Point(330, 69);
            DetectButton2.Name = "DetectButton2";
            DetectButton2.Size = new Size(59, 25);
            DetectButton2.TabIndex = 23;
            DetectButton2.Text = "Detect";
            DetectButton2.UseVisualStyleBackColor = true;
            DetectButton2.Click += DetectButton2_Click;
            // 
            // DetectButton1
            // 
            DetectButton1.AutoSize = true;
            DetectButton1.Location = new Point(330, 25);
            DetectButton1.Name = "DetectButton1";
            DetectButton1.Size = new Size(59, 25);
            DetectButton1.TabIndex = 22;
            DetectButton1.Text = "Detect";
            DetectButton1.UseVisualStyleBackColor = true;
            DetectButton1.Click += DetectButton1_Click;
            // 
            // label2
            // 
            label2.AutoEllipsis = true;
            label2.AutoSize = true;
            label2.Location = new Point(18, 51);
            label2.Name = "label2";
            label2.Size = new Size(82, 15);
            label2.TabIndex = 21;
            label2.Text = "Input Button -";
            // 
            // label1
            // 
            label1.AutoEllipsis = true;
            label1.AutoSize = true;
            label1.Location = new Point(18, 7);
            label1.Name = "label1";
            label1.Size = new Size(85, 15);
            label1.TabIndex = 20;
            label1.Text = "Input Button +";
            // 
            // cbInputB
            // 
            cbInputB.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            cbInputB.DropDownStyle = ComboBoxStyle.DropDownList;
            cbInputB.DropDownWidth = 800;
            cbInputB.FormattingEnabled = true;
            cbInputB.Location = new Point(18, 69);
            cbInputB.Name = "cbInputB";
            cbInputB.Size = new Size(306, 23);
            cbInputB.TabIndex = 19;
            cbInputB.SelectedIndexChanged += cbInputB_SelectedIndexChanged;
            // 
            // cbInputA
            // 
            cbInputA.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            cbInputA.DropDownStyle = ComboBoxStyle.DropDownList;
            cbInputA.DropDownWidth = 800;
            cbInputA.FormattingEnabled = true;
            cbInputA.Location = new Point(18, 25);
            cbInputA.Name = "cbInputA";
            cbInputA.Size = new Size(306, 23);
            cbInputA.TabIndex = 18;
            cbInputA.SelectedIndexChanged += cbInputA_SelectedIndexChanged;
            // 
            // RotaryControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(DetectButton2);
            Controls.Add(DetectButton1);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(cbInputB);
            Controls.Add(cbInputA);
            Name = "RotaryControl";
            Size = new Size(407, 256);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button DetectButton2;
        private Button DetectButton1;
        private Label label2;
        private Label label1;
        private ComboBox cbInputB;
        private ComboBox cbInputA;
        private Panel panel1;
    }
}
