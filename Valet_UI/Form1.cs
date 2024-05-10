using System;
using System.Diagnostics;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Threading;
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
        private Process pythonProcess;

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
                pythonProcess = new Process();
                // Specify the working directory for the Python process
                string baseDirectory = (AppDomain.CurrentDomain.BaseDirectory);
                string workingDirectory = Path.Combine(baseDirectory);
                pythonProcess.StartInfo.WorkingDirectory = workingDirectory;
                // Set the Python script file path relative to the working directory
                string scriptPath = Path.Combine(workingDirectory, "vosk_stt.py");
                // Set the arguments for the Python process
                pythonProcess.StartInfo.FileName = "python";
                pythonProcess.StartInfo.Arguments = scriptPath;
                // Rest of your code...
                pythonProcess.StartInfo.UseShellExecute = false;
                pythonProcess.StartInfo.RedirectStandardOutput = true;
                pythonProcess.StartInfo.CreateNoWindow = true;
                pythonProcess.Start();
                Thread outputThread = new Thread(() => readOutput(floatingWindow));
                outputThread.Start();
                Debug.WriteLine("started");
            }
        }

        private void readOutput(FloatingWindow floatingWindow)
        {
            bool isReadingOutput = true;
            while (!pythonProcess.StandardOutput.EndOfStream)
            {
                string currentOutput = pythonProcess.StandardOutput.ReadLine();

                // Update the UI using the main thread
                Invoke((MethodInvoker)delegate
                {
                    floatingWindow.changeText(currentOutput);
                });
                if (currentOutput.Contains("copy"))
                {
                    Console.WriteLine("copy was said (hello from c#)");
                    ShortCuts.copy();
                }
                else if (currentOutput.Contains("paste"))
                {
                    Console.WriteLine("paste was said (hello from c#)");
                }
                else if (currentOutput.Contains("refresh"))
                {
                    Console.WriteLine("refresh was said (hello from c#)");
                }
                else if (currentOutput.Contains("close"))
                {
                    Console.WriteLine("close was said (hello from c#)");
                }   
            }
            isReadingOutput = false;

        }

        /// <summary>
        /// Upon closing the main form, kill the subprocess otherwise cannot build the project again
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Terminate the subprcess if it still running
            if (pythonProcess != null && !pythonProcess.HasExited)
            {
                pythonProcess.Kill();
            }
        }
    }
}
