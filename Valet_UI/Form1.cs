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
        private bool keywordBool = false;
        private bool changedState = false;
        private Process pythonProcess;
        string keyword = "";

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
            keyword = GlobalSettings.Keyword;

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

        private void readOutput(FloatingWindow floatingWindow)
        {
            Invoke((MethodInvoker)delegate
            {
                floatingWindow.changeText("Listening for keyword");
            });
            English.Register();
            Storage.Current = new DiskStorage("cataylst-models");
            while (!pythonProcess.StandardOutput.EndOfStream)
            {
                string currentOutput = pythonProcess.StandardOutput.ReadLine();
                if (currentOutput == null || String.IsNullOrEmpty(currentOutput))
                {

                }
                else if (currentOutput.Contains(keyword))
                {
                    keywordBool = true;
                }
                else if(keywordBool) 
                {
                    if (!changedState)
                    {
                        changedState = true;    
                    Invoke((MethodInvoker)delegate
                    {
                        floatingWindow.changeText("keyword heard, valet now actively listening");
                    });
                        Thread.Sleep(5000);
                    }
                    var doc = new Document(currentOutput, Language.English);
                    // Update the UI using the main thread
                    Invoke((MethodInvoker)delegate
                    {
                        floatingWindow.changeText(currentOutput);
                    });
                    
                    if (currentOutput.Contains("copy")
                        ||currentOutput.Contains("take")
                        ||doc.Value.Contains("grab"))
                    {
                       copyNLP(doc);
                    }
                    else if (currentOutput.Contains("paste")
                        ||currentOutput.Contains("taste")
                        ||currentOutput.Contains("post")
                        ||currentOutput.Contains("haste"))
                    {
                        pasteNLP(doc);  
                    }
                    else if (currentOutput.Contains("undo"))
                    {
                        undoNLP(doc);
                    }
                    else if (currentOutput.Contains("refresh"))
                    {
                        refreshNLP(doc);
                    }
                    else if (currentOutput.Contains("redo"))
                    {
                        redoNLP(doc);
                    }
                    else if (doc.Value.Contains("insert"))
                    {
                        // If it does, call the insert function 
                        insert(doc);
                    }
                    // Check if the 'input' string contains the word "close"
                    else if (doc.Value.Contains("close"))
                    {
                        // If it does, call the close function 
                        close(doc);
                    }
                    else if (doc.Value.Contains("shut"))
                    {
                        // If it does, call the shut function 
                        shut(doc);
                    }
                    // Check if the 'input' string contains the word "undo"
                    else if (doc.Value.Contains("undo"))
                    {
                        // If it does, call the undo function 
                        undo(doc);
                    }
                    // Check if the 'input' string contains the word "start"
                    else if (doc.Value.Contains("start"))
                    {
                        // If it does, call the start function 
                        start(doc);
                    }
                    else if (doc.Value.Contains("cut")
                        ||doc.Value.Contains("remove")
                        ||doc.Value.Contains("trim"))
                    {
                        cutNLP(doc);
                    }
                    else if (doc.Value.Contains("delete"))
                    {
                        // If it does, call the delete function
                        delete(doc);
                    }
                    else if (doc.Value.Contains("select")
                        ||doc.Value.Contains("highlight"))
                    {
                        // If it does, call the select function
                        selectAllNLP(doc);
                    }
                    else if (doc.Value.Contains("save"))
                    {
                        // If it does, call the save function
                        save(doc);
                    }
                    else if (doc.Value.Contains("store"))
                    {
                        // If it does, call the store function
                        store(doc);
                    }
                    else if (doc.Value.Contains("hold"))
                    {
                        // If it does, call the hold function
                        hold(doc);
                    }
                    else if (doc.Value.Contains("minimize")
                        ||doc.Value.Contains("minimise")
                        ||doc.Value.Contains("smaller")
                        ||doc.Value.Contains("downsize")
                        ||doc.Value.Contains("shrink"))
                    {
                        shrinkNLP(doc);
                    }
                    else if (doc.Value.Contains("minimise"))
                    {
                        // If it does, call the minimise function
                        minimise(doc);
                    }
                    else if (doc.Value.Contains("smaller"))
                    {
                        // If it does, call the minimise function
                        smaller(doc);
                    }
                    else if (doc.Value.Contains("downsize"))
                    {
                        // If it does, call the downsize function
                        downsize(doc);
                    }
                    else if (doc.Value.Contains("shrink"))
                    {
                        // If it does, call the shrink function
                        shrink(doc);
                    }
                    else if (doc.Value.Contains("reopen"))
                    {
                        // If it does, call the reopen function
                        reopen(doc);
                    }
                    else if (doc.Value.Contains("back"))
                    {
                        // If it does, call the shrink function
                        back(doc);
                    }
                    else if (doc.Value.Contains("revive"))
                    {
                        // If it does, call the revive function
                        revive(doc);
                    }
                    else if (doc.Value.Contains("bring"))
                    {
                        // If it does, call the bring function
                        bring(doc);
                    }
                    else if (doc.Value.Contains("come"))
                    {
                        // If it does, call the come function
                        come(doc);
                    }
                    else if (doc.Value.Contains("meant"))
                    {
                        // If it does, call the meant function
                        meant(doc);
                    }
                    else if (doc.Value.Contains("done"))
                    {
                        // If it does, call the done function
                        done(doc);
                    }
                    else if (doc.Value.Contains("no"))
                    {
                        // If it does, call the no function
                        no(doc);
                    }
                    else if (doc.Value.Contains("maximize"))
                    {
                        // If it does, call the maximize function
                        maximize(doc);
                    }
                    else if (doc.Value.Contains("maximise"))
                    {
                        // If it does, call the maximise function
                        maximise(doc);
                    }
                    else if (doc.Value.Contains("full"))
                    {
                        // If it does, call the full function
                        full(doc);
                    }
                    else if (doc.Value.Contains("enlarge"))
                    {
                        // If it does, call the enlarge function
                        enlarge(doc);
                    }
                    else if (doc.Value.Contains("expand"))
                    {
                        // If it does, call the expand function
                        expand(doc);
                    }
                    else if (doc.Value.Contains("split"))
                    {
                        // If it does, call the split function
                        split(doc);
                    }
                    else if (doc.Value.Contains("left"))
                    {
                        // If it does, call the left function
                        left(doc);
                    }
                    else if (doc.Value.Contains("right"))
                    {
                        // If it does, call the right function
                        right(doc);
                    }
                    else if (doc.Value.Contains("seperate"))
                    {
                        // If it does, call the seperate function
                        seperate(doc);
                    }
                    else if (doc.Value.Contains("divide"))
                    {
                        // If it does, call the divide function
                        divide(doc);
                    }
                    else if (doc.Value.Contains("snap"))
                    {
                        // If it does, call the snap function
                        snap(doc);
                    }
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
        private static void copyNLP(Document doc)
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

                    if (tokenText == "copy" || tokenText == "take" || tokenText == "grab" && token.Tag == PartOfSpeech.VERB)
                    {
                        ShortCuts.copy();

                    }
                }
            }
        }

        private static void pasteNLP(Document doc)
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

                    if (tokenText == "paste" ||
                        tokenText == "post" ||
                        tokenText == "taste" ||
                        tokenText == "haste"
                        && token.Tag == PartOfSpeech.VERB)
                    {
                        ShortCuts.paste();                       
                    }
                }
            }
        }

        private static void undoNLP(Document doc)
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

                    if (tokenText == "undo" && token.Tag == PartOfSpeech.VERB)
                    {
                        ShortCuts.undo();
                        
                        
                    }
                }
            }
        }

        private static void redo(Document doc)
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

                    if (tokenText == "redo" && token.Tag == PartOfSpeech.VERB)
                    {
                        ShortCuts.redo();
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
                    if(tokenText == "refresh" && token.Tag == PartOfSpeech.VERB)
                    {
                        ShortCuts.refresh();

                        
                    }
                }
            }
        }
        private static void redoNLP(Document doc)
        {
            foreach (var tokenList in doc.TokensData)
            {
                foreach (var token in tokenList)
                {
                    int start = token.Bounds[0];
                    int end = token.Bounds[1];
                    string tokenText = doc.Value.Substring(start, end - start + 1);
                    if(tokenText == "redo" && token.Tag == PartOfSpeech.VERB)
                    {
                        ShortCuts.redo();
                        //Sets notification text and spawns a notification window
                    }
                }
            }
        }
        private static void cutNLP(Document doc)
        {
            foreach (var tokenList in doc.TokensData)
            {
                foreach (var token in tokenList)
                {
                    int start = token.Bounds[0];
                    int end = token.Bounds[1];
                    string tokenText = doc.Value.Substring(start, end - start + 1);
                    if(tokenText == "cut" || tokenText == "remove" || tokenText == "trim" && token.Tag == PartOfSpeech.VERB)
                    {
                        ShortCuts.cut();
                    }
                }
            }
        }
        private static void selectAllNLP(Document doc)
        {
            foreach (var tokenList in doc.TokensData)
            {
                foreach (var token in tokenList)
                {
                    int start = token.Bounds[0];
                    int end = token.Bounds[1];
                    string tokenText = doc.Value.Substring(start, end - start + 1);
                    if(tokenText == "select" || tokenText == "highlight" && token.Tag == PartOfSpeech.VERB)
                    {
                        ShortCuts.selectAll();
                    }
                }
            }
        }
        private static void shrinkNLP(Document doc)
        {
            foreach (var tokenList in doc.TokensData)
            {
                foreach (var token in tokenList)
                {
                    int start = token.Bounds[0];
                    int end = token.Bounds[1];
                    string tokenText = doc.Value.Substring(start, end - start + 1);
                    if(tokenText == "minimize" || tokenText == "minimise" || tokenText == "smaller" || tokenText == "downsize" || tokenText == "shrink" && token.Tag == PartOfSpeech.VERB)
                    {
                        ShortCuts.WindowMinimize();
                    }
                }
            }
        }
    }
}
