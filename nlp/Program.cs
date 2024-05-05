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
        while (!pythonProcess.StandardOutput.EndOfStream)
        {
            string currentOutput = pythonProcess.StandardOutput.ReadLine();
            Console.WriteLine(currentOutput);

            // Process the current output

            // Check if the 'currentOutput' string contains the word "copy" 
            if (currentOutput.Contains("copy"))
            {
              Console.WriteLine("copy was said (hello from c#)");
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
            // If it does, call the 'wordCopy' function
            wordCopy();
        }
        // Check if the 'input' string contains the word "paste"
        else if (doc.Value.Contains("paste"))
        {
            // If it does, call the 'wordPaste' function
            wordPaste();
        }
        // Check if the 'input' string contains the word "close"
        else if (doc.Value.Contains("close"))
        {
            // If it does, call the 'wordCloseTab' function
            wordCloseTab();
        }
        // Check if the 'input' string contains the word "undo"
        else if (doc.Value.Contains("undo"))
        {
            // If it does, call the 'wordUndo' function
            wordUndo();
        }
        // Check if the 'input' string contains the word "start"
        else if(doc.Value.Contains("start"))
        {
            // If it does, call the 'wordStart' function
            wordStart();
        }
        // Check if the 'input' string contains the word "redo"
        else if(doc.Value.Contains("redo"))
        {
            // If it does, call the 'wordRedo' function
            wordRedo();
        }
        // Check if the 'input' string contains the word "refresh"
        else if(doc.Value.Contains("refresh"))
        {
            // If it does, call the 'wordRefreshBrowser' function
            wordRefreshBrowser();
        }
// Check if the 'input' string contains the word "stop"
        else if(doc.Value.Contains("close"))
        {
            // Check if the 'input' string contains the word "chrome"
            if(doc.Value.Contains("chrome"))
            {
                // If it does, call the 'wordStopExact' function
                wordCloseExact();
            }
            // Check if the 'input' string contains the word "opera"
            else if (doc.Value.Contains("opera"))
            {
                // If it does, call the 'wordStopActive' function
                wordCloseExact();
            }
            // Check if the 'input' string contains the word "edge"
            else if (doc.Value.Contains("edge"))
            {
                // If it does, call the 'wordStopActive' function
                wordCloseExact();
            }
            // Check if the 'input' string contains the word "firefox"
            else if (doc.Value.Contains("firefox"))
            {
                // If it does, call the 'wordStopActive' function
                wordCloseExact();
            }
            // Check if the 'input' string contains the word "explorer"
            else if (doc.Value.Contains("explorer"))
            {
                // If it does, call the 'wordStopActive' function
                wordCloseExact();
            }
            else 
            {
                // If it only contains "exact", call the 'wordStopActive' function
                wordCloseActive();
            }
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
    public static void wordCopy()
    {
        ShortCuts.copy();
        Console.WriteLine("Copy");
    }

    /// <summary>
    /// Function for the word paste to be called 
    /// </summary>
    public static void wordPaste()
    {
        ShortCuts.paste();
        Console.WriteLine("Paste");
    }

    /// <summary>
    /// Function for the word close to be called 
    /// </summary>
    public static void wordCloseTab()
    {
        ShortCuts.closeTab();
        Console.WriteLine("Close");
    }

    /// <summary>
    /// Function for the word Undo to be called
    /// </summary>
    public static void openApplicationFunction ()
    {
      Console.WriteLine("Open");
    }
    public static void wordUndo()
    {
      ShortCuts.undo();
      Console.WriteLine("Undo");
    }

    /// <summary>
    /// Function to be called to start any given process using the name of the name of the process
    /// </summary>
    public static void wordStart()
    { 
        //ShortCuts.Start()   takes String argument
        Console.WriteLine("Start");
    }

    /// <summary>
    /// Function to be called redo the last change
    /// </summary>
    public static void wordRedo ()
    {
        ShortCuts.redo();
        Console.WriteLine("redo");
    }

    /// <summary>
    /// Function to be called to refresh a browser tab
    /// </summary>
    public static void wordRefreshBrowser ()
    {
        ShortCuts.refreshBrowserTab();
        Console.WriteLine("Refresh");
    }

    /// <summary>
    /// Function to be called to stop a process that is currently running
    /// </summary>
    public static void wordCloseExact ()
    {
        //ShortCuts.StopExact();    takes string argument
        Console.WriteLine("Close Exact");
    }

    /// <summary>
    /// Function to be called to stop the active process
    /// </summary>
    public static void wordCloseActive ()
    {
        ShortCuts.StopActive();
        Console.WriteLine("Close Active");
    }
}
