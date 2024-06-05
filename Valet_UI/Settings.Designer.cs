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
            button_ConfirmChange = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // label_Dictionary
            // 
            label_Dictionary.AutoSize = true;
            label_Dictionary.Font = new Font("Microsoft Sans Serif", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label_Dictionary.Location = new Point(12, 23);
            label_Dictionary.Name = "label_Dictionary";
            label_Dictionary.Size = new Size(108, 29);
            label_Dictionary.TabIndex = 6;
            label_Dictionary.Text = "Settings";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.Subtract;
            pictureBox1.Location = new Point(351, 23);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(24, 24);
            pictureBox1.TabIndex = 7;
            pictureBox1.TabStop = false;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(234, 234, 234);
            panel1.Controls.Add(button_ConfirmChange);
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
            label2.ForeColor = Color.FromArgb(64, 64, 64);
            label2.Location = new Point(3, 33);
            label2.Name = "label2";
            label2.Size = new Size(213, 40);
            label2.TabIndex = 3;
            label2.Text = "Notifies the user when a \r\nprocess has been completed";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(0, 9);
            label3.Name = "label3";
            label3.Size = new Size(113, 24);
            label3.TabIndex = 4;
            label3.Text = "Notification";
            // 
            // button_ConfirmChange
            // 
            button_ConfirmChange.FlatStyle = FlatStyle.Flat;
            button_ConfirmChange.ForeColor = Color.Red;
            button_ConfirmChange.Location = new Point(292, 18);
            button_ConfirmChange.Name = "button_ConfirmChange";
            button_ConfirmChange.Size = new Size(80, 32);
            button_ConfirmChange.TabIndex = 9;
            button_ConfirmChange.Text = "Turn Off";
            button_ConfirmChange.UseVisualStyleBackColor = false;
            button_ConfirmChange.Click += button_ConfirmChange_Click;
            // 
            // Settings
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panel1);
            Controls.Add(pictureBox1);
            Controls.Add(label_Dictionary);
            Name = "Settings";
            Size = new Size(389, 554);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label_Dictionary;
        private PictureBox pictureBox1;
        private Panel panel1;
        private Label label2;
        private Label label3;
        private Button button_ConfirmChange;
    }
}
