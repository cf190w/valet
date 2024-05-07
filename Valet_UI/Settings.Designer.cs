namespace Valet_UI
{
    partial class Settings
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
            label_Dictionary = new Label();
            pictureBox1 = new PictureBox();
            panel1 = new Panel();
            label2 = new Label();
            label3 = new Label();
            panel2 = new Panel();
            label1 = new Label();
            label4 = new Label();
            panel3 = new Panel();
            label5 = new Label();
            label6 = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // label_Dictionary
            // 
            label_Dictionary.AutoSize = true;
            label_Dictionary.Font = new Font("Microsoft Sans Serif", 20.25F, FontStyle.Bold);
            label_Dictionary.Location = new Point(28, 23);
            label_Dictionary.Name = "label_Dictionary";
            label_Dictionary.Size = new Size(121, 31);
            label_Dictionary.TabIndex = 6;
            label_Dictionary.Text = "Settings";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.Subtract;
            pictureBox1.Location = new Point(343, 23);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(24, 24);
            pictureBox1.TabIndex = 7;
            pictureBox1.TabStop = false;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(234, 234, 234);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label3);
            panel1.Location = new Point(3, 73);
            panel1.Name = "panel1";
            panel1.Size = new Size(383, 74);
            panel1.TabIndex = 8;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(14, 42);
            label2.Name = "label2";
            label2.Size = new Size(141, 20);
            label2.TabIndex = 3;
            label2.Text = "Setting description";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft Sans Serif", 15.75F, FontStyle.Bold);
            label3.Location = new Point(14, 17);
            label3.Name = "label3";
            label3.Size = new Size(150, 25);
            label3.TabIndex = 4;
            label3.Text = "Setting name";
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(234, 234, 234);
            panel2.Controls.Add(label1);
            panel2.Controls.Add(label4);
            panel2.Location = new Point(3, 153);
            panel2.Name = "panel2";
            panel2.Size = new Size(383, 74);
            panel2.TabIndex = 9;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(14, 42);
            label1.Name = "label1";
            label1.Size = new Size(141, 20);
            label1.TabIndex = 3;
            label1.Text = "Setting description";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Microsoft Sans Serif", 15.75F, FontStyle.Bold);
            label4.Location = new Point(14, 17);
            label4.Name = "label4";
            label4.Size = new Size(150, 25);
            label4.TabIndex = 4;
            label4.Text = "Setting name";
            // 
            // panel3
            // 
            panel3.BackColor = Color.FromArgb(234, 234, 234);
            panel3.Controls.Add(label5);
            panel3.Controls.Add(label6);
            panel3.Location = new Point(3, 233);
            panel3.Name = "panel3";
            panel3.Size = new Size(383, 74);
            panel3.TabIndex = 9;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(14, 42);
            label5.Name = "label5";
            label5.Size = new Size(141, 20);
            label5.TabIndex = 3;
            label5.Text = "Setting description";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Microsoft Sans Serif", 15.75F, FontStyle.Bold);
            label6.Location = new Point(14, 17);
            label6.Name = "label6";
            label6.Size = new Size(150, 25);
            label6.TabIndex = 4;
            label6.Text = "Setting name";
            // 
            // Settings
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panel2);
            Controls.Add(panel3);
            Controls.Add(panel1);
            Controls.Add(pictureBox1);
            Controls.Add(label_Dictionary);
            Name = "Settings";
            Size = new Size(389, 554);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label_Dictionary;
        private PictureBox pictureBox1;
        private Panel panel1;
        private Label label2;
        private Label label3;
        private Panel panel2;
        private Label label1;
        private Label label4;
        private Panel panel3;
        private Label label5;
        private Label label6;
    }
}
