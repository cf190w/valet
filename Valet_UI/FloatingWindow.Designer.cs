namespace Valet_UI
{
    partial class FloatingWindow
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FloatingWindow));
            label_Listening = new Label();
            pictureBox1 = new PictureBox();
            button1 = new Button();
            label_userSpeach = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // label_Listening
            // 
            label_Listening.AutoSize = true;
            label_Listening.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            label_Listening.Location = new Point(57, 9);
            label_Listening.Name = "label_Listening";
            label_Listening.Size = new Size(118, 24);
            label_Listening.TabIndex = 0;
            label_Listening.Text = "Listening ...";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.Subtract;
            pictureBox1.Location = new Point(12, 9);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(24, 24);
            pictureBox1.TabIndex = 8;
            pictureBox1.TabStop = false;
            // 
            // button1
            // 
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Image = Properties.Resources.stop_circle;
            button1.Location = new Point(199, 7);
            button1.Name = "button1";
            button1.Size = new Size(26, 26);
            button1.TabIndex = 9;
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label_userSpeach
            // 
            label_userSpeach.AutoSize = true;
            label_userSpeach.Location = new Point(23, 45);
            label_userSpeach.Name = "label_userSpeach";
            label_userSpeach.Size = new Size(150, 15);
            label_userSpeach.TabIndex = 10;
            label_userSpeach.Text = "Example .. Please Copy this";
            // 
            // FloatingWindow
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(237, 128);
            ControlBox = false;
            Controls.Add(label_userSpeach);
            Controls.Add(button1);
            Controls.Add(pictureBox1);
            Controls.Add(label_Listening);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FloatingWindow";
            StartPosition = FormStartPosition.Manual;
            Text = "FloatingWindow";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label_Listening;
        private PictureBox pictureBox1;
        private Button button1;
        private Label label_userSpeach;
    }
}