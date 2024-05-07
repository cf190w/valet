namespace Valet_UI
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panel1 = new Panel();
            panel2 = new Panel();
            button_Dashboard = new Button();
            button_Settings = new Button();
            button_Dictionary = new Button();
            button1 = new Button();
            button_Minimize = new Button();
            dashboard1 = new Dashboard();
            dictionary1 = new Dictionary();
            settings1 = new Settings();
            button2 = new Button();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.Black;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(56, 724);
            panel1.TabIndex = 0;
            // 
            // panel2
            // 
            panel2.BackColor = Color.Black;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(462, 23);
            panel2.TabIndex = 1;
            // 
            // button_Dashboard
            // 
            button_Dashboard.BackColor = Color.Black;
            button_Dashboard.FlatStyle = FlatStyle.Flat;
            button_Dashboard.Image = Properties.Resources.dashboard;
            button_Dashboard.Location = new Point(5, 12);
            button_Dashboard.Name = "button_Dashboard";
            button_Dashboard.Size = new Size(48, 48);
            button_Dashboard.TabIndex = 2;
            button_Dashboard.UseVisualStyleBackColor = false;
            button_Dashboard.Click += button_Dashboard_Click;
            // 
            // button_Settings
            // 
            button_Settings.BackColor = Color.Black;
            button_Settings.FlatStyle = FlatStyle.Flat;
            button_Settings.Image = Properties.Resources.settings;
            button_Settings.Location = new Point(5, 120);
            button_Settings.Name = "button_Settings";
            button_Settings.Size = new Size(48, 48);
            button_Settings.TabIndex = 3;
            button_Settings.UseVisualStyleBackColor = false;
            button_Settings.Click += button_Settings_Click;
            // 
            // button_Dictionary
            // 
            button_Dictionary.BackColor = Color.Black;
            button_Dictionary.FlatStyle = FlatStyle.Flat;
            button_Dictionary.Image = Properties.Resources.dictionary;
            button_Dictionary.Location = new Point(5, 66);
            button_Dictionary.Name = "button_Dictionary";
            button_Dictionary.Size = new Size(48, 48);
            button_Dictionary.TabIndex = 4;
            button_Dictionary.UseVisualStyleBackColor = false;
            button_Dictionary.Click += button_Dictionary_Click;
            // 
            // button1
            // 
            button1.BackColor = Color.Black;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Image = Properties.Resources.close_small;
            button1.Location = new Point(428, -1);
            button1.Name = "button1";
            button1.Size = new Size(24, 24);
            button1.TabIndex = 5;
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // button_Minimize
            // 
            button_Minimize.BackColor = Color.Black;
            button_Minimize.FlatStyle = FlatStyle.Flat;
            button_Minimize.Image = Properties.Resources.minimize;
            button_Minimize.Location = new Point(398, -1);
            button_Minimize.Name = "button_Minimize";
            button_Minimize.Size = new Size(24, 24);
            button_Minimize.TabIndex = 6;
            button_Minimize.UseVisualStyleBackColor = false;
            button_Minimize.Click += button_Minimize_Click;
            // 
            // dashboard1
            // 
            dashboard1.Location = new Point(63, 29);
            dashboard1.Name = "dashboard1";
            dashboard1.Size = new Size(389, 554);
            dashboard1.TabIndex = 7;
            // 
            // dictionary1
            // 
            dictionary1.Location = new Point(63, 29);
            dictionary1.Name = "dictionary1";
            dictionary1.Size = new Size(389, 554);
            dictionary1.TabIndex = 8;
            // 
            // settings1
            // 
            settings1.Location = new Point(63, 29);
            settings1.Name = "settings1";
            settings1.Size = new Size(389, 554);
            settings1.TabIndex = 9;
            // 
            // button2
            // 
            button2.BackColor = Color.FromArgb(112, 51, 190);
            button2.FlatStyle = FlatStyle.Flat;
            button2.Font = new Font("Microsoft Sans Serif", 15.75F, FontStyle.Bold);
            button2.ForeColor = SystemColors.ButtonFace;
            button2.Location = new Point(63, 614);
            button2.Name = "button2";
            button2.Size = new Size(387, 59);
            button2.TabIndex = 10;
            button2.Text = "Launch";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(462, 685);
            ControlBox = false;
            Controls.Add(button2);
            Controls.Add(settings1);
            Controls.Add(dictionary1);
            Controls.Add(dashboard1);
            Controls.Add(button_Minimize);
            Controls.Add(button1);
            Controls.Add(button_Dictionary);
            Controls.Add(button_Settings);
            Controls.Add(button_Dashboard);
            Controls.Add(panel2);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private Button button_Dashboard;
        private Button button_Settings;
        private Button button_Dictionary;
        private Button button1;
        private Button button_Minimize;
        private Dashboard dashboard1;
        private Dictionary dictionary1;
        private Settings settings1;
        private Button button2;
    }
}
