using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Catalyst;
using Catalyst.Models;
using Mosaik.Core;
using Newtonsoft.Json;

namespace NLP;

public class Program 
{
    //test
    public static async Task Main() 
    {
        Console.WriteLine("Running C# Program");
        Process pythonProcess = new Process();
        pythonProcess.StartInfo.FileName = "python";
        pythonProcess.StartInfo.Arguments = "vosk_stt.py";
        pythonProcess.StartInfo.UseShellExecute = false;
        pythonProcess.StartInfo.RedirectStandardOutput = true;

        pythonProcess.Start();
        string previousOutput = string.Empty;

        while (!pythonProcess.HasExited)
        {
            string currentOutput = pythonProcess.StandardOutput.ReadToEnd();
            
            if (!string.IsNullOrEmpty(currentOutput))
            {
                if (currentOutput.EndsWith('\n'))
                {
                    Console.Write(currentOutput);
                }
                else
                {
                    previousOutput += currentOutput;
                }
            }
        }

        //Register the English language model
        Catalyst.Models.English.Register(); //You need to pre-register each language (and install the respective NuGet Packages)
        // Configure storage
        Storage.Current = new DiskStorage("catalyst-models");
        // Create a Catalyst NLP pipeline for English
        var nlp = await Pipeline.ForAsync(Language.English);
        // Input text and create a document
        var doc = new Document("Hey Valet. Can you refresh the tab", Language.English);
        // Process the document
        nlp.ProcessSingle(doc);

        //Formatting
        // Convert the 'doc' object to a JSON string and print it to the console
        Console.WriteLine(doc.ToJson());
        // Convert the 'doc' object to a pretty (indented) JSON string
        string prettyJson = JsonConvert.SerializeObject(doc, Formatting.Indented);
        // Print the pretty JSON string to the console
        Console.WriteLine(prettyJson);

        //Counting the amount of verbs and nouns in the sentence
        // Count the number of verbs in the 'doc' object and print the count to the console
        int numVerbs = verbCount(doc);
        Console.WriteLine($"The document contains {numVerbs} verbs.");
        // Count the number of nouns in the 'doc' object and print the count to the console
        int numNouns = nounCount(doc);
        Console.WriteLine($"The document contains {numNouns} nouns.");

        //Checking the input for specific words
        // Check if the 'input' string contains the word "copy" 
        if (doc.Value.Contains("copy"))
        {
            // If it does, call the 'wordCopyFunction' function
            wordCopyFunction();
        }
        // Check if the 'input' string contains the word "paste"
        else if (doc.Value.Contains("paste"))
        {
            // If it does, call the 'wordPasteFunction' function
            wordPasteFunction();
        }
        // Check if the 'input' string contains the word "close"
        else if (doc.Value.Contains("close"))
        {
            // If it does, call the 'closeApplicationFunction' function
            closeApplicationFunction();
        }
        else if (doc.Value.Contains("open"))
        {
            // If it does, call the 'openApplicationFunction' function
            openApplicationFunction();
        }
        else if(doc.Value.Contains("start"))
        {
            // If it does, call the 'startProcessFunction' function
            startProcessFunction();
        }
        else if(doc.Value.Contains("stop"))
        {
            // If it does, call the 'stopProcessFunction' function
            stopProcessFunction();
        }
        else if(doc.Value.Contains("kill"))
        {
            // If it does, call the 'killProcessFunction' function
            killProcessFunction();
        }
        else if(doc.Value.Contains("refresh"))
        {
            // If it does, call the 'refreshPageFunction' function
            refreshPageFunction();
        }
        else if(doc.Value.Contains("editor"))
        {
            // If it does, call the 'copyFromEditorFunction' function
            copyFromEditorFunction();
        }
        else if (doc.Value.Contains("focused") && doc.Value.Contains("control"))
        {
            // If it does, call the 'getFocusedControlFunction' function
            getFocusedControlFunction();
        }
        else if (doc.Value.Contains("get") && doc.Value.Contains("text"))
        {
            // If it does, call the 'getTextFunction' function
            getTextFunction();
        }
        else
        {
            // If the 'input' string doesn't contain any of the above words, print an error message
            Console.WriteLine("Invalid input. Please try again.");
        }
    }

    /// <summary>
    /// Counts how many verbs are in the sentence. Also stores all the verbs in the sentence 
    /// </summary>
    public static int verbCount (Document doc)
    {
        // Initialize a counter for the verbs
        int verbCount = 0;

        // Loop through each token list in the document
        foreach (var tokenList in doc.TokensData)
        {
            // Loop through each token in the token list
            foreach (var token in tokenList)
            {
                // If the part of speech of the token is a verb
                if (token.Tag == PartOfSpeech.VERB)
                {
                    // Increment the verb counter
                    verbCount++;
                }
            }
        }
        // Return the count of verbs
        return verbCount;
    }

    /// <summary>
    /// Counts how many nouns are in the sentence. Also stores all the nouns in the sentence
    /// </summary>
    public static int nounCount (Document doc)
    {
        // Initialize a counter for the nouns
        int nounCount = 0;

        // Loop through each token list in the document
        foreach (var tokenList in doc.TokensData)
        {
            // Loop through each token in the token list
            foreach (var token in tokenList)
            {
                // If the part of speech of the token is a noun
                if (token.Tag == PartOfSpeech.NOUN)
                {
                    // Increment the noun counter
                    nounCount++;
                }
            }
        }
        // Return the count of nouns
        return nounCount;
    }

    /// <summary>
    /// Function for the word copy to be called and copies highlighted text
    /// </summary>
    public static void wordCopyFunction()
    {
        Console.WriteLine("Copy");
    }

    /// <summary>
    /// Function for the word paste to be called 
    /// </summary>
    public static void wordPasteFunction ()
    {
        Console.WriteLine("Paste");
    }

    /// <summary>
    /// Function for the word close to be called 
    /// </summary>
    public static void closeApplicationFunction ()
    {
        Console.WriteLine("Close");
    }

    /// <summary>
    /// Function for the word open to be called
    /// </summary>
    public static void openApplicationFunction ()
    {
        Console.WriteLine("Open");
    }

    /// <summary>
    /// Function to be called to start any given process using the name of the name of the process
    /// </summary>
    public static void startProcessFunction ()
    {
        Console.WriteLine("Start");
    }

    /// <summary>
    /// Function to be called to stop all process with this name
    /// e.g if you had 5 instances of chrome open it would delete them all
    /// </summary>
    public static void stopProcessFunction ()
    {
        Console.WriteLine("Stop");
    }

    /// <summary>
    /// Function to be called to stop or kill the currently active or foreground process on your system
    /// </summary>
    public static void killProcessFunction ()
    {
        Console.WriteLine("Kill");
    }

    /// <summary>
    /// Function to be called to refresh a page
    /// </summary>
    public static void refreshPageFunction ()
    {
        Console.WriteLine("Refresh");
    }

    /// <summary>
    /// Function to be called to copy from editor
    /// </summary>
    public static void copyFromEditorFunction ()
    {
        Console.WriteLine("Copy from Editor");
    }

    /// <summary>
    /// Function to be called to get focused control
    /// </summary>
    public static void getFocusedControlFunction ()
    {
        Console.WriteLine("Get Focused Control");
    }

    /// <summary>
    /// Function to be called to get text
    /// </summary>
    public static void getTextFunction ()
    {
        Console.WriteLine("Get Text");
    }
}
