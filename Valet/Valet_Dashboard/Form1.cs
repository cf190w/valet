using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Valet_Dashboard
{
    public partial class Form1 : Form
    {     
        public Form1()
        {
            InitializeComponent();

            //only displays the dashboard panel when intialized
            dictionary1.Visible = false;
            settings1.Visible = false;
            dashBoard1.Visible = true;

            
        }


      
        /// <summary>
        /// When clicked will hide all panels except the dashboard panel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_Dashboard_Click(object sender, EventArgs e)
        {
            dictionary1.Visible = false;
            settings1.Visible = false;
            dashBoard1.Visible = true;
        }        

        /// <summary>
        /// When clicked will hide all panels except the dictionary panel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_Dictionary_Click(object sender, EventArgs e)
        {
            dictionary1.Visible = true;
            settings1.Visible = false;
            dashBoard1.Visible = false;

        }

        /// <summary>
        /// When clicked will hide all panels except the settings panel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_Settings_Click(object sender, EventArgs e)
        {
            dictionary1.Visible = false;
            settings1.Visible = true;
            dashBoard1.Visible = false;
        }

        /// <summary>
        /// When clicked will hide the dsahboard form and display the floating menu in the right hand corner
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_Launch_Click(object sender, EventArgs e)
        {
            this.Hide();
            
            Floating_Menu floating_Menu = new Floating_Menu();
            //gets the working area of the users screen
            System.Drawing.Rectangle workingArea = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea;

            //calculates the x and y postion at the bottom right screen
            int xPosition = workingArea.Right - floating_Menu.Width - 30;
            int yPosition = workingArea.Bottom - floating_Menu.Height - 30;

            //sets the forms loaction
            floating_Menu.Location = new System.Drawing.Point(xPosition, yPosition);

            //Displays the floating menu
            floating_Menu.Show();
        }

        /// <summary>
        /// Closes the application
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        /// <summary>
        /// Minimizes the Form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_Minimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
