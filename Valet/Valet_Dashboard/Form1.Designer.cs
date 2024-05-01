namespace Valet_Dashboard
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.panel1 = new System.Windows.Forms.Panel();
            this.button_Dictionary = new System.Windows.Forms.Button();
            this.button_Settings = new System.Windows.Forms.Button();
            this.button_Dashboard = new System.Windows.Forms.Button();
            this.dictionary1 = new Valet_Dashboard.Dictionary();
            this.settings1 = new Valet_Dashboard.Settings();
            this.dashBoard1 = new Valet_Dashboard.DashBoard();
            this.button_Launch = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button_Minimize = new System.Windows.Forms.Button();
            this.buttonExit = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.Controls.Add(this.button_Dictionary);
            this.panel1.Controls.Add(this.button_Settings);
            this.panel1.Controls.Add(this.button_Dashboard);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(56, 724);
            this.panel1.TabIndex = 0;
            // 
            // button_Dictionary
            // 
            this.button_Dictionary.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_Dictionary.Image = global::Valet_Dashboard.Properties.Resources.dictionary;
            this.button_Dictionary.Location = new System.Drawing.Point(5, 66);
            this.button_Dictionary.Name = "button_Dictionary";
            this.button_Dictionary.Size = new System.Drawing.Size(48, 48);
            this.button_Dictionary.TabIndex = 1;
            this.button_Dictionary.UseVisualStyleBackColor = true;
            this.button_Dictionary.Click += new System.EventHandler(this.button_Dictionary_Click);
            // 
            // button_Settings
            // 
            this.button_Settings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_Settings.Image = global::Valet_Dashboard.Properties.Resources.settings;
            this.button_Settings.Location = new System.Drawing.Point(5, 120);
            this.button_Settings.Name = "button_Settings";
            this.button_Settings.Size = new System.Drawing.Size(48, 48);
            this.button_Settings.TabIndex = 3;
            this.button_Settings.UseVisualStyleBackColor = true;
            this.button_Settings.Click += new System.EventHandler(this.button_Settings_Click);
            // 
            // button_Dashboard
            // 
            this.button_Dashboard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_Dashboard.Image = global::Valet_Dashboard.Properties.Resources.dashboard;
            this.button_Dashboard.Location = new System.Drawing.Point(5, 12);
            this.button_Dashboard.Name = "button_Dashboard";
            this.button_Dashboard.Size = new System.Drawing.Size(48, 48);
            this.button_Dashboard.TabIndex = 2;
            this.button_Dashboard.UseVisualStyleBackColor = true;
            this.button_Dashboard.Click += new System.EventHandler(this.button_Dashboard_Click);
            // 
            // dictionary1
            // 
            this.dictionary1.Location = new System.Drawing.Point(63, 29);
            this.dictionary1.Name = "dictionary1";
            this.dictionary1.Size = new System.Drawing.Size(389, 554);
            this.dictionary1.TabIndex = 3;
            // 
            // settings1
            // 
            this.settings1.Location = new System.Drawing.Point(63, 29);
            this.settings1.Name = "settings1";
            this.settings1.Size = new System.Drawing.Size(389, 554);
            this.settings1.TabIndex = 2;
            // 
            // dashBoard1
            // 
            this.dashBoard1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.dashBoard1.Location = new System.Drawing.Point(63, 29);
            this.dashBoard1.Name = "dashBoard1";
            this.dashBoard1.Size = new System.Drawing.Size(389, 554);
            this.dashBoard1.TabIndex = 1;
            // 
            // button_Launch
            // 
            this.button_Launch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(51)))), ((int)(((byte)(190)))));
            this.button_Launch.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Launch.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.button_Launch.Location = new System.Drawing.Point(63, 614);
            this.button_Launch.Name = "button_Launch";
            this.button_Launch.Size = new System.Drawing.Size(387, 59);
            this.button_Launch.TabIndex = 4;
            this.button_Launch.Text = "Launch";
            this.button_Launch.UseVisualStyleBackColor = false;
            this.button_Launch.Click += new System.EventHandler(this.button_Launch_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Black;
            this.panel2.Controls.Add(this.buttonExit);
            this.panel2.Controls.Add(this.button_Minimize);
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(462, 23);
            this.panel2.TabIndex = 5;
            // 
            // button_Minimize
            // 
            this.button_Minimize.BackColor = System.Drawing.Color.Black;
            this.button_Minimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_Minimize.Image = global::Valet_Dashboard.Properties.Resources.minimize;
            this.button_Minimize.Location = new System.Drawing.Point(398, -1);
            this.button_Minimize.Name = "button_Minimize";
            this.button_Minimize.Size = new System.Drawing.Size(24, 24);
            this.button_Minimize.TabIndex = 6;
            this.button_Minimize.UseVisualStyleBackColor = false;
            this.button_Minimize.Click += new System.EventHandler(this.button_Minimize_Click);
            // 
            // buttonExit
            // 
            this.buttonExit.BackColor = System.Drawing.Color.Black;
            this.buttonExit.Cursor = System.Windows.Forms.Cursors.UpArrow;
            this.buttonExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonExit.Image = global::Valet_Dashboard.Properties.Resources.close_small;
            this.buttonExit.Location = new System.Drawing.Point(428, -1);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(24, 24);
            this.buttonExit.TabIndex = 7;
            this.buttonExit.UseVisualStyleBackColor = false;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(462, 685);
            this.ControlBox = false;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.button_Launch);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dictionary1);
            this.Controls.Add(this.settings1);
            this.Controls.Add(this.dashBoard1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button_Dictionary;
        private System.Windows.Forms.Button button_Dashboard;
        private System.Windows.Forms.Button button_Settings;
        private DashBoard dashBoard1;
        private Settings settings1;
        private Dictionary dictionary1;
        private System.Windows.Forms.Button button_Launch;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button_Minimize;
        private System.Windows.Forms.Button buttonExit;
    }
}

