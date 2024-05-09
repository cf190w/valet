using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Catalyst;
using Catalyst.Models;
using Mosaik.Core;
using Newtonsoft.Json;

namespace Valet_UI
{
    public partial class Form1 : Form
    {
        private bool isFirstTime = false;
        public Form1()
        {
            InitializeComponent();

            //displays the dashboard panel when intialized
            dashboard1.Visible = true;
            dictionary1.Visible = false;
            settings1.Visible = false;
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
            dashboard1.Visible = true;

        }

        /// <summary>
        /// When clicked will hide all panels except the dictionary panel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_Dictionary_Click(object sender, EventArgs e)
        {
            dictionary1.Visible = true;
            dashboard1.Visible = false;
            settings1.Visible = false;
        }

        /// <summary>
        /// When clicked will hide all panels except the settings panel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_Settings_Click(object sender, EventArgs e)
        {
            settings1.Visible = true;
            dashboard1.Visible = false;
            dictionary1.Visible = false;
        }

        /// <summary>
        /// Minimizes the form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_Minimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// When clicked will hide the dsahboard form and display the floating menu in the right hand corner
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {

            this.Hide();
            FloatingWindow floatingWindow = new FloatingWindow();
            //gets the working area of the users screen
            System.Drawing.Rectangle workingArea = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea;

            //calculates the x and y postion at the bottom right screen
            int xPosition = workingArea.Right - floatingWindow.Width - 30;
            int yPosition = workingArea.Bottom - floatingWindow.Height - 30;

            //sets the forms loaction
            floatingWindow.Location = new System.Drawing.Point(xPosition, yPosition);
            floatingWindow.changeText("Loading...");
            floatingWindow.Show();


            if (!isFirstTime)
            {
                isFirstTime = true;
                //toggle so this runs once, spawning the python subprocess which will run in the background/foreground
                Console.WriteLine("Starting Python Speech to text");
                Process pythonProcess = new Process();
                pythonProcess.StartInfo.FileName = "python";
                pythonProcess.StartInfo.Arguments = @"C:\Users\cd\valet\Valet_UI\stt\vosk_stt.py";
                pythonProcess.StartInfo.UseShellExecute = false;
                pythonProcess.StartInfo.RedirectStandardOutput = true;
                pythonProcess.Start();
                /*
                pythonProcess.OutputDataReceived += (sender, e) =>
                {
                    if (e.Data != null && string.IsNullOrWhiteSpace(e.Data)) // Replace "your_string" with the desired string
                    {
                        Console.WriteLine(e.Data);
                        // String received, resume execution
                    }
                };
                */
                while (!pythonProcess.StandardOutput.EndOfStream) { 
                    string currentOutput = pythonProcess.StandardOutput.ReadLine();
                    floatingWindow.changeText("listening...");
                    if (currentOutput.Contains("listening"))
                    {
                        floatingWindow.changeText(currentOutput);

                    }
                    Console.WriteLine(currentOutput);
                }

            }
        }
    }
}
