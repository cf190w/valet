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
                        ||currentOutput.Contains("haste")
                        ||currentOutput.Contains("insert"))
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
                    /*
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
                    else if (doc.Value.Contains("start"))
                    {
                        // If it does, call the start function 
                        start(doc);
                    }
                    */
                    else if (doc.Value.Contains("cut")
                        ||doc.Value.Contains("remove")
                        ||doc.Value.Contains("trim")
                        ||doc.Value.Contains("delete"))
                    {
                        cutNLP(doc);
                    }
                    else if (doc.Value.Contains("select")
                        ||doc.Value.Contains("highlight")
                        ||doc.Value.Contains("save")
                        ||doc.Value.Contains("store")
                        ||doc.Value.Contains("hold"))
                    {
                        selectAllNLP(doc);
                    }
                    else if (doc.Value.Contains("minimize")
                        ||doc.Value.Contains("minimise")
                        ||doc.Value.Contains("smaller")
                        ||doc.Value.Contains("downsize")
                        ||doc.Value.Contains("shrink"))
                    {
                        shrinkNLP(doc);
                    }
                    else if (doc.Value.Contains("reopen")
                        ||doc.Value.Contains("back")
                        ||doc.Value.Contains("revive")
                        ||doc.Value.Contains("bring")
                        ||doc.Value.Contains("come")
                        ||doc.Value.Contains("meant")
                        ||doc.Value.Contains("done")
                        ||doc.Value.Contains("no"))
                    {
                        // If it does, call the reopen function
                        reopenNLP(doc);
                    }
                    else if (doc.Value.Contains("maximize")
                        ||doc.Value.Contains("maximise")
                        ||doc.Value.Contains("full")
                        ||doc.Value.Contains("expand")
                        ||doc.Value.Contains("enlarge"))
                    {
                        // If it does, call the maximize function
                        maxCurrentNLP(doc);
                    }
                    else if (doc.Value.Contains("split")
                        ||doc.Value.Contains("separate")
                        ||doc.Value.Contains("divide")
                        ||doc.Value.Contains("snap")
                        ||doc.Value.Contains("right")
                        ||doc.Value.Contains("write"))
                    {
                        // If it does, call the split function
                        rightNLP(doc);
                    }
                    else if (doc.Value.Contains("left"))
                    {
                        // If it does, call the left function
                        leftNLP(doc);
                    }
                    else if (doc.Value.Contains("stop")
                        ||doc.Value.Contains("stop"))
                    {
                        if (doc.Value.Contains("firefox")
                        ||doc.Value.Contains("fire fox"))
                        {
                            nlpFirefox(doc);
                        }
                        else if (doc.Value.Contains("chrome"))
                        {
                            chromeNLP(doc);
                        }
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
                        tokenText == "haste" ||
                        tokenText == "insert"
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
                    if(tokenText == "cut" || tokenText == "remove" || tokenText == "trim" || tokenText == "delete" && token.Tag == PartOfSpeech.VERB)
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
                    if(tokenText == "select" || tokenText == "highlight" || tokenText == "save" || tokenText == "store" || tokenText == "hold" && token.Tag == PartOfSpeech.VERB)
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
        private static void reopenNLP(Document doc)
        {
            foreach (var tokenList in doc.TokensData)
            {
                foreach (var token in tokenList)
                {
                    int start = token.Bounds[0];
                    int end = token.Bounds[1];
                    string tokenText = doc.Value.Substring(start, end - start + 1);
                    if(tokenText == "reopen"
                        || tokenText == "back"
                        || tokenText == "smaller"
                        || tokenText == "revive"
                        || tokenText == "bring"
                        || tokenText == "come"
                        || tokenText == "meant"
                        || tokenText == "done"
                        || tokenText == "no" && token.Tag == PartOfSpeech.VERB)
                    {
                        ShortCuts.WindowReopen();
                    }
                }
            }
        }
        private static void maxCurrentNLP(Document doc)
        {
            foreach (var tokenList in doc.TokensData)
            {
                foreach (var token in tokenList)
                {
                    int start = token.Bounds[0];
                    int end = token.Bounds[1];
                    string tokenText = doc.Value.Substring(start, end - start + 1);
                    if(tokenText == "maximize"
                        || tokenText == "maximise"
                        || tokenText == "full"
                        || tokenText == "expand"
                        || tokenText == "enlarge" && token.Tag == PartOfSpeech.VERB)
                    {
                        ShortCuts.WindowReopen();
                    }
                }
            }
        }
        private static void rightNLP(Document doc)
        {
            foreach (var tokenList in doc.TokensData)
            {
                foreach (var token in tokenList)
                {
                    int start = token.Bounds[0];
                    int end = token.Bounds[1];
                    string tokenText = doc.Value.Substring(start, end - start + 1);
                    if(tokenText == "split"
                        || tokenText == "separate"
                        || tokenText == "divide"
                        || tokenText == "snap"
                        || tokenText == "right"
                        || tokenText == "write"
                        && token.Tag == PartOfSpeech.VERB)
                    {
                        ShortCuts.WindowReopen();
                    }
                }
            }
        }
        private static void leftNLP(Document doc)
        {
            foreach (var tokenList in doc.TokensData)
            {
                foreach (var token in tokenList)
                {
                    int start = token.Bounds[0];
                    int end = token.Bounds[1];
                    string tokenText = doc.Value.Substring(start, end - start + 1);
                    if(tokenText == "left"
                        && token.Tag == PartOfSpeech.VERB)
                    {
                        ShortCuts.WindowReopen();
                    }
                }
            }
        }
        private static void nlpFirefox(Document doc)
        {
            foreach (var tokenList in doc.TokensData)
            {
                foreach (var token in tokenList)
                {
                    int start = token.Bounds[0];
                    int end = token.Bounds[1];
                    string tokenText = doc.Value.Substring(start, end - start + 1);
                    if(tokenText == "close"
                        && token.Tag == PartOfSpeech.VERB)
                    {
                        ShortCuts.StopExact("firefox");
                        ShortCuts.StopExact("Firefox");
                    }
                }
            }
        }
        private static void chromeNLP(Document doc)
        {
            foreach (var tokenList in doc.TokensData)
            {
                foreach (var token in tokenList)
                {
                    int start = token.Bounds[0];
                    int end = token.Bounds[1];
                    string tokenText = doc.Value.Substring(start, end - start + 1);
                    if(tokenText == "close"
                        && token.Tag == PartOfSpeech.VERB)
                    {
                        ShortCuts.StopExact("Google Chrome");
                        ShortCuts.StopExact("chrome");
                    }
                }
            }
        }
    }
}
