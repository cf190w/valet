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
                //Start new thread to read asynchronously from stdout
                Thread outputThread = new Thread(() => readOutput(floatingWindow));
                outputThread.Start();
                Debug.WriteLine("started");
            }
        }

        private async void readOutput(FloatingWindow floatingWindow)
        {
            Catalyst.Models.English.Register();
            Storage.Current = new DiskStorage("cataylst-models");
            var nlp = await Pipeline.ForAsync(Language.English);
            while (!pythonProcess.StandardOutput.EndOfStream)
            {
                string currentOutput = pythonProcess.StandardOutput.ReadLine();
                if (currentOutput == null || String.IsNullOrEmpty(currentOutput))
                {

                }
                else
                {
                    var doc = new Document(currentOutput, Language.English);
                    // Update the UI using the main thread
                    Invoke((MethodInvoker)delegate
                    {
                        floatingWindow.changeText(currentOutput);
                    });
                    processNLP(doc);
                    /*
                    if (currentOutput.Contains("copy"))
                    {
                       copyNLP(doc);

                    }
                    else if (currentOutput.Contains("paste"))
                    {
                        ShortCuts.paste();

                    }
                    else if (currentOutput.Contains("undo"))
                    {
                        ShortCuts.undo();

                    }
                    else if (currentOutput.Contains("refresh"))
                    {
                        ShortCuts.refresh();
                    }
                    else if (currentOutput.Contains("redo"))
                    {
                        ShortCuts.redo();
                    }

                    if(doc.Value.Contains("copy"))
                    {
                        
                    }
                    */
                }
            }
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
        private static void processNLP(Document doc)
        {
            // Loop through each token list in the document
            foreach (var tokenList in doc.TokensData)
            {
                // Loop through each token in the token list
                foreach (var token in tokenList)
                {
                    // Get the start and end indices of the token in the original text
                    int start = token.Bounds[0];
                    int end = token.Bounds[1];
                    // Extract the token text from the original text
                    string tokenText = doc.Value.Substring(start, end - start + 1);

                    if (tokenText == "copy" && token.Tag == PartOfSpeech.VERB)
                    {
                        ShortCuts.copy();
                    }
                    else if (tokenText == "refresh" && token.Tag == PartOfSpeech.VERB)
                    {
                        
                    }

                }
            }
        }
     
        
        private static void refreshNLP(Document doc)
        {
            foreach (var tokenList in doc.TokensData)
            {
                foreach (var token in tokenList)
                {
                    int start = token.Bounds[0];
                    int end = token.Bounds[1];
                    string tokenText = doc.Value.Substring(start, end - start + 1);
                }
            }
        }
    }
}
