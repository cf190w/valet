namespace Valet_UI
{
    partial class Dictionary
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
            label2 = new Label();
            label3 = new Label();
            panel2 = new Panel();
            label1 = new Label();
            label4 = new Label();
            pictureBox1 = new PictureBox();
            label_Dictionary = new Label();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(234, 234, 234);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label3);
            panel1.Location = new Point(3, 73);
            panel1.Name = "panel1";
            panel1.Size = new Size(383, 74);
            panel1.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(14, 42);
            label2.Name = "label2";
            label2.Size = new Size(166, 20);
            label2.TabIndex = 3;
            label2.Text = "A list of all commands.";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft Sans Serif", 15.75F, FontStyle.Bold);
            label3.Location = new Point(14, 17);
            label3.Name = "label3";
            label3.Size = new Size(128, 25);
            label3.TabIndex = 4;
            label3.Text = "Commands";
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(234, 234, 234);
            panel2.Controls.Add(label1);
            panel2.Controls.Add(label4);
            panel2.Location = new Point(3, 153);
            panel2.Name = "panel2";
            panel2.Size = new Size(383, 74);
            panel2.TabIndex = 5;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(14, 42);
            label1.Name = "label1";
            label1.Size = new Size(195, 20);
            label1.TabIndex = 3;
            label1.Text = "Copys the highligthed text.";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Microsoft Sans Serif", 15.75F, FontStyle.Bold);
            label4.Location = new Point(14, 17);
            label4.Name = "label4";
            label4.Size = new Size(66, 25);
            label4.TabIndex = 4;
            label4.Text = "Copy";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.Subtract;
            pictureBox1.Location = new Point(343, 23);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(24, 24);
            pictureBox1.TabIndex = 4;
            pictureBox1.TabStop = false;
            // 
            // label_Dictionary
            // 
            label_Dictionary.AutoSize = true;
            label_Dictionary.Font = new Font("Microsoft Sans Serif", 20.25F, FontStyle.Bold);
            label_Dictionary.Location = new Point(28, 23);
            label_Dictionary.Name = "label_Dictionary";
            label_Dictionary.Size = new Size(146, 31);
            label_Dictionary.TabIndex = 5;
            label_Dictionary.Text = "Dictionary";
            // 
            // Dictionary
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panel2);
            Controls.Add(label_Dictionary);
            Controls.Add(pictureBox1);
            Controls.Add(panel1);
            Name = "Dictionary";
            Size = new Size(389, 554);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private Label label1;
        private Label label4;
        private Label label2;
        private Label label3;
        private PictureBox pictureBox1;
        private Label label_Dictionary;
    }
}
