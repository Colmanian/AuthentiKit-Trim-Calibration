
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
            cbOutputButtonA = new ComboBox();
            cbOutputButtonB = new ComboBox();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            numericUpDown1 = new NumericUpDown();
            checkBox1 = new CheckBox();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
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
            DetectButton2.Location = new Point(330, 84);
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
            DetectButton1.Location = new Point(330, 31);
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
            label2.Location = new Point(18, 66);
            label2.Name = "label2";
            label2.Size = new Size(82, 15);
            label2.TabIndex = 21;
            label2.Text = "Input Button -";
            // 
            // label1
            // 
            label1.AutoEllipsis = true;
            label1.AutoSize = true;
            label1.Location = new Point(18, 13);
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
            cbInputB.Location = new Point(18, 84);
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
            cbInputA.Location = new Point(18, 31);
            cbInputA.Name = "cbInputA";
            cbInputA.Size = new Size(306, 23);
            cbInputA.TabIndex = 18;
            cbInputA.SelectedIndexChanged += cbInputA_SelectedIndexChanged;
            // 
            // cbOutputButtonA
            // 
            cbOutputButtonA.FormattingEnabled = true;
            cbOutputButtonA.Location = new Point(17, 151);
            cbOutputButtonA.Name = "cbOutputButtonA";
            cbOutputButtonA.Size = new Size(232, 23);
            cbOutputButtonA.TabIndex = 25;
            cbOutputButtonA.SelectedIndexChanged += cbOutputButtonA_SelectedIndexChanged;
            // 
            // cbOutputButtonB
            // 
            cbOutputButtonB.FormattingEnabled = true;
            cbOutputButtonB.Location = new Point(17, 202);
            cbOutputButtonB.Name = "cbOutputButtonB";
            cbOutputButtonB.Size = new Size(232, 23);
            cbOutputButtonB.TabIndex = 26;
            cbOutputButtonB.SelectedIndexChanged += cbOutputButtonB_SelectedIndexChanged;
            // 
            // label3
            // 
            label3.AutoEllipsis = true;
            label3.AutoSize = true;
            label3.Location = new Point(17, 133);
            label3.Name = "label3";
            label3.Size = new Size(108, 15);
            label3.TabIndex = 27;
            label3.Text = "Output Range Start";
            // 
            // label4
            // 
            label4.AutoEllipsis = true;
            label4.AutoSize = true;
            label4.Location = new Point(17, 184);
            label4.Name = "label4";
            label4.Size = new Size(162, 15);
            label4.TabIndex = 28;
            label4.Text = "Inital / Default Output Button";
            // 
            // label5
            // 
            label5.AutoEllipsis = true;
            label5.AutoSize = true;
            label5.Location = new Point(269, 133);
            label5.Name = "label5";
            label5.Size = new Size(97, 15);
            label5.TabIndex = 29;
            label5.Text = "Num. of Outputs";
            // 
            // numericUpDown1
            // 
            numericUpDown1.Location = new Point(269, 152);
            numericUpDown1.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            numericUpDown1.Minimum = new decimal(new int[] { 3, 0, 0, 0 });
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(120, 23);
            numericUpDown1.TabIndex = 30;
            numericUpDown1.Value = new decimal(new int[] { 3, 0, 0, 0 });
            numericUpDown1.ValueChanged += numericUpDown1_ValueChanged;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(269, 202);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(127, 19);
            checkBox1.TabIndex = 31;
            checkBox1.Text = "Loop Over Outputs";
            checkBox1.UseVisualStyleBackColor = true;
            checkBox1.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // RotaryControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(checkBox1);
            Controls.Add(numericUpDown1);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(cbOutputButtonB);
            Controls.Add(cbOutputButtonA);
            Controls.Add(DetectButton2);
            Controls.Add(DetectButton1);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(cbInputB);
            Controls.Add(cbInputA);
            Name = "RotaryControl";
            Size = new Size(407, 256);
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
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
        private ComboBox cbOutputButtonA;
        private ComboBox cbOutputButtonB;
        private Label label3;
        private Label label4;
        private Label label5;
        private NumericUpDown numericUpDown1;
        private CheckBox checkBox1;
    }
}
