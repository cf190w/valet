namespace Valet_UI
{
    partial class Dashboard
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
            label1 = new Label();
            pictureBox1 = new PictureBox();
            panel1 = new Panel();
            label2 = new Label();
            label3 = new Label();
            panel2 = new Panel();
            label_ActivationName = new Label();
            panel3 = new Panel();
            label6 = new Label();
            label7 = new Label();
            button_ChangeActivationName = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 20.25F, FontStyle.Bold);
            label1.Location = new Point(28, 23);
            label1.Name = "label1";
            label1.Size = new Size(205, 31);
            label1.TabIndex = 0;
            label1.Text = "My DashBoard";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.Subtract;
            pictureBox1.Location = new Point(343, 23);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(24, 24);
            pictureBox1.TabIndex = 1;
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
            panel1.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(14, 42);
            label2.Name = "label2";
            label2.Size = new Size(247, 20);
            label2.TabIndex = 3;
            label2.Text = "A Keyword to activate your helper.";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft Sans Serif", 15.75F, FontStyle.Bold);
            label3.Location = new Point(14, 17);
            label3.Name = "label3";
            label3.Size = new Size(166, 25);
            label3.TabIndex = 4;
            label3.Text = "My DashBoard";
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(250, 250, 250);
            panel2.Controls.Add(button_ChangeActivationName);
            panel2.Controls.Add(label_ActivationName);
            panel2.Location = new Point(3, 153);
            panel2.Name = "panel2";
            panel2.Size = new Size(383, 74);
            panel2.TabIndex = 5;
            // 
            // label_ActivationName
            // 
            label_ActivationName.AutoSize = true;
            label_ActivationName.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold);
            label_ActivationName.Location = new Point(14, 30);
            label_ActivationName.Name = "label_ActivationName";
            label_ActivationName.Size = new Size(51, 20);
            label_ActivationName.TabIndex = 4;
            label_ActivationName.Text = "Valet";
            // 
            // panel3
            // 
            panel3.BackColor = Color.FromArgb(234, 234, 234);
            panel3.Controls.Add(label6);
            panel3.Controls.Add(label7);
            panel3.Location = new Point(3, 233);
            panel3.Name = "panel3";
            panel3.Size = new Size(383, 74);
            panel3.TabIndex = 5;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.Location = new Point(14, 42);
            label6.Name = "label6";
            label6.Size = new Size(247, 20);
            label6.TabIndex = 3;
            label6.Text = "A Keyword to activate your helper.";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Microsoft Sans Serif", 15.75F, FontStyle.Bold);
            label7.Location = new Point(14, 17);
            label7.Name = "label7";
            label7.Size = new Size(166, 25);
            label7.TabIndex = 4;
            label7.Text = "My DashBoard";
            // 
            // button_ChangeActivationName
            // 
            button_ChangeActivationName.FlatStyle = FlatStyle.Flat;
            button_ChangeActivationName.ForeColor = Color.FromArgb(112, 51, 190);
            button_ChangeActivationName.Location = new Point(284, 25);
            button_ChangeActivationName.Name = "button_ChangeActivationName";
            button_ChangeActivationName.Size = new Size(80, 32);
            button_ChangeActivationName.TabIndex = 1;
            button_ChangeActivationName.Text = "Change";
            button_ChangeActivationName.UseVisualStyleBackColor = false;
            // 
            // Dashboard
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panel2);
            Controls.Add(panel3);
            Controls.Add(panel1);
            Controls.Add(pictureBox1);
            Controls.Add(label1);
            Name = "Dashboard";
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

        private Label label1;
        private PictureBox pictureBox1;
        private Panel panel1;
        private Label label2;
        private Label label3;
        private Panel panel2;
        private Button button_ChangeActivationName;
        private Label label_ActivationName;
        private Panel panel3;
        private Label label6;
        private Label label7;
    }
}
