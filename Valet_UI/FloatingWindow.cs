using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Valet_UI
{
    public partial class FloatingWindow : Form
    {

        private System.Windows.Forms.Timer timerLoading;
        private int dotCounter = 0;

        public FloatingWindow()
        {
            InitializeComponent();


            timerLoading = new System.Windows.Forms.Timer();
            timerLoading.Interval = 500;
            timerLoading.Tick += timerLoading_Tick;

            timerLoading.Start();
        }

        private void timerLoading_Tick(object sender, EventArgs e)
        {
            //Cycles between 0, 1, 2, 3 dots
            dotCounter = (dotCounter + 1) % 4;
            //Prints to the listening label
            label_Listening.Text = "Listening" + new string('.', dotCounter);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Cloases the floating Menu
            this.Close();

            //Creates a new instance of the main form and displays it
            Form1 form1 = new Form1();
            form1.ShowDialog();

        }
        public void changeText(string newText)
        {
            label_userSpeach.Text = newText;
        }
    }
}
