namespace Valet_Dashboard
{
    partial class Floating_Menu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Floating_Menu));
            this.label_Listening = new System.Windows.Forms.Label();
            this.label_TextToSpeach = new System.Windows.Forms.Label();
            this.button_StopListening = new System.Windows.Forms.Button();
            this.pictureBox_Icon = new System.Windows.Forms.PictureBox();
            this.panel_floating = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Icon)).BeginInit();
            this.panel_floating.SuspendLayout();
            this.SuspendLayout();
            // 
            // label_Listening
            // 
            this.label_Listening.AutoSize = true;
            this.label_Listening.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Listening.Location = new System.Drawing.Point(45, 3);
            this.label_Listening.Name = "label_Listening";
            this.label_Listening.Size = new System.Drawing.Size(118, 24);
            this.label_Listening.TabIndex = 1;
            this.label_Listening.Text = "Listening ...";
            // 
            // label_TextToSpeach
            // 
            this.label_TextToSpeach.AutoSize = true;
            this.label_TextToSpeach.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_TextToSpeach.Location = new System.Drawing.Point(3, 36);
            this.label_TextToSpeach.Name = "label_TextToSpeach";
            this.label_TextToSpeach.Size = new System.Drawing.Size(160, 20);
            this.label_TextToSpeach.TabIndex = 2;
            this.label_TextToSpeach.Text = "Please Copy this Text";
            // 
            // button_StopListening
            // 
            this.button_StopListening.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_StopListening.ForeColor = System.Drawing.Color.Transparent;
            this.button_StopListening.Image = global::Valet_Dashboard.Properties.Resources.stop_circle;
            this.button_StopListening.Location = new System.Drawing.Point(184, 3);
            this.button_StopListening.Name = "button_StopListening";
            this.button_StopListening.Size = new System.Drawing.Size(26, 26);
            this.button_StopListening.TabIndex = 3;
            this.button_StopListening.UseVisualStyleBackColor = true;
            this.button_StopListening.Click += new System.EventHandler(this.button1_Click);
            // 
            // pictureBox_Icon
            // 
            this.pictureBox_Icon.Image = global::Valet_Dashboard.Properties.Resources.Subtract;
            this.pictureBox_Icon.Location = new System.Drawing.Point(3, 3);
            this.pictureBox_Icon.Name = "pictureBox_Icon";
            this.pictureBox_Icon.Size = new System.Drawing.Size(24, 24);
            this.pictureBox_Icon.TabIndex = 0;
            this.pictureBox_Icon.TabStop = false;
            // 
            // panel_floating
            // 
            this.panel_floating.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel_floating.Controls.Add(this.label_TextToSpeach);
            this.panel_floating.Controls.Add(this.button_StopListening);
            this.panel_floating.Controls.Add(this.pictureBox_Icon);
            this.panel_floating.Controls.Add(this.label_Listening);
            this.panel_floating.Location = new System.Drawing.Point(12, 12);
            this.panel_floating.Name = "panel_floating";
            this.panel_floating.Size = new System.Drawing.Size(213, 100);
            this.panel_floating.TabIndex = 4;
            // 
            // Floating_Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(237, 128);
            this.ControlBox = false;
            this.Controls.Add(this.panel_floating);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Floating_Menu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = " ";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Icon)).EndInit();
            this.panel_floating.ResumeLayout(false);
            this.panel_floating.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox_Icon;
        private System.Windows.Forms.Label label_Listening;
        private System.Windows.Forms.Label label_TextToSpeach;
        private System.Windows.Forms.Button button_StopListening;
        private System.Windows.Forms.Panel panel_floating;
    }
}