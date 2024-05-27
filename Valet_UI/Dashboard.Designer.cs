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
            panel_KeywordActivation = new Panel();
            button_ChangeActivationName = new Button();
            label_Keyword = new Label();
            panel_ChangeKeyword = new Panel();
            button_Discard = new Button();
            textBox_Keyword = new TextBox();
            button_ConfirmChange = new Button();
            label4 = new Label();
            panel_ErrorMessage = new Panel();
            panel3 = new Panel();
            label5 = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel1.SuspendLayout();
            panel_KeywordActivation.SuspendLayout();
            panel_ChangeKeyword.SuspendLayout();
            panel_ErrorMessage.SuspendLayout();
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
            // panel_KeywordActivation
            // 
            panel_KeywordActivation.BackColor = Color.FromArgb(250, 250, 250);
            panel_KeywordActivation.Controls.Add(button_ChangeActivationName);
            panel_KeywordActivation.Controls.Add(label_Keyword);
            panel_KeywordActivation.Location = new Point(3, 153);
            panel_KeywordActivation.Name = "panel_KeywordActivation";
            panel_KeywordActivation.Size = new Size(383, 74);
            panel_KeywordActivation.TabIndex = 5;
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
            button_ChangeActivationName.Click += button_ChangeActivationName_Click;
            // 
            // label_Keyword
            // 
            label_Keyword.AutoSize = true;
            label_Keyword.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold);
            label_Keyword.Location = new Point(14, 30);
            label_Keyword.Name = "label_Keyword";
            label_Keyword.Size = new Size(51, 20);
            label_Keyword.TabIndex = 4;
            label_Keyword.Text = "Valet";
            // 
            // panel_ChangeKeyword
            // 
            panel_ChangeKeyword.BackColor = Color.FromArgb(250, 250, 250);
            panel_ChangeKeyword.Controls.Add(button_Discard);
            panel_ChangeKeyword.Controls.Add(textBox_Keyword);
            panel_ChangeKeyword.Controls.Add(button_ConfirmChange);
            panel_ChangeKeyword.Controls.Add(label4);
            panel_ChangeKeyword.Location = new Point(3, 153);
            panel_ChangeKeyword.Name = "panel_ChangeKeyword";
            panel_ChangeKeyword.Size = new Size(383, 74);
            panel_ChangeKeyword.TabIndex = 6;
            // 
            // button_Discard
            // 
            button_Discard.FlatStyle = FlatStyle.Flat;
            button_Discard.ForeColor = Color.FromArgb(192, 0, 0);
            button_Discard.Location = new Point(198, 25);
            button_Discard.Name = "button_Discard";
            button_Discard.Size = new Size(80, 32);
            button_Discard.TabIndex = 5;
            button_Discard.Text = "Discard";
            button_Discard.UseVisualStyleBackColor = false;
            button_Discard.Click += button_Discard_Click;
            // 
            // textBox_Keyword
            // 
            textBox_Keyword.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            textBox_Keyword.Location = new Point(14, 27);
            textBox_Keyword.Name = "textBox_Keyword";
            textBox_Keyword.Size = new Size(151, 26);
            textBox_Keyword.TabIndex = 5;
            // 
            // button_ConfirmChange
            // 
            button_ConfirmChange.FlatStyle = FlatStyle.Flat;
            button_ConfirmChange.ForeColor = Color.FromArgb(0, 64, 0);
            button_ConfirmChange.Location = new Point(284, 25);
            button_ConfirmChange.Name = "button_ConfirmChange";
            button_ConfirmChange.Size = new Size(80, 32);
            button_ConfirmChange.TabIndex = 1;
            button_ConfirmChange.Text = "Change";
            button_ConfirmChange.UseVisualStyleBackColor = false;
            button_ConfirmChange.Click += button_ConfirmChange_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold);
            label4.Location = new Point(14, 30);
            label4.Name = "label4";
            label4.Size = new Size(51, 20);
            label4.TabIndex = 4;
            label4.Text = "Valet";
            // 
            // panel_ErrorMessage
            // 
            panel_ErrorMessage.BackColor = Color.Red;
            panel_ErrorMessage.Controls.Add(panel3);
            panel_ErrorMessage.ForeColor = Color.FromArgb(192, 0, 0);
            panel_ErrorMessage.Location = new Point(0, 233);
            panel_ErrorMessage.Name = "panel_ErrorMessage";
            panel_ErrorMessage.Size = new Size(383, 51);
            panel_ErrorMessage.TabIndex = 7;
            // 
            // panel3
            // 
            panel3.BackColor = Color.White;
            panel3.Controls.Add(label5);
            panel3.ForeColor = Color.FromArgb(192, 0, 0);
            panel3.Location = new Point(3, 3);
            panel3.Name = "panel3";
            panel3.Size = new Size(377, 44);
            panel3.TabIndex = 8;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.DarkRed;
            label5.Location = new Point(53, 0);
            label5.Name = "label5";
            label5.Size = new Size(263, 40);
            label5.TabIndex = 0;
            label5.Text = "Keyword can only contain lower \r\nand upper case characters.";
            // 
            // Dashboard
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panel_ErrorMessage);
            Controls.Add(panel1);
            Controls.Add(pictureBox1);
            Controls.Add(label1);
            Controls.Add(panel_ChangeKeyword);
            Controls.Add(panel_KeywordActivation);
            Name = "Dashboard";
            Size = new Size(389, 554);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel_KeywordActivation.ResumeLayout(false);
            panel_KeywordActivation.PerformLayout();
            panel_ChangeKeyword.ResumeLayout(false);
            panel_ChangeKeyword.PerformLayout();
            panel_ErrorMessage.ResumeLayout(false);
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
        private Panel panel_KeywordActivation;
        private Button button_ChangeActivationName;
        private Label label_Keyword;
        private Panel panel_ChangeKeyword;
        private TextBox textBox_Keyword;
        private Button button_ConfirmChange;
        private Label label4;
        private Button button_Discard;
        private Panel panel_ErrorMessage;
        private Panel panel3;
        private Label label5;
    }
}
