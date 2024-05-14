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
        /*
        Console.WriteLine("Running C# Program");
        Process pythonProcess = new Process();
        pythonProcess.StartInfo.FileName = "python";
        pythonProcess.StartInfo.Arguments = @"C:\Users\cd\valet\nlp\stt\vosk_stt.py";
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
        */

        //Register the English language model
        Catalyst.Models.English.Register(); //You need to pre-register each language (and install the respective NuGet Packages)
        // Configure storage
        Storage.Current = new DiskStorage("catalyst-models");
        // Create a Catalyst NLP pipeline for English
        var nlp = await Pipeline.ForAsync(Language.English);
        // Input text and create a document
        var doc = new Document("Hey Valet. Can you stop the browser Opera from running", Language.English);
        // Process the document
        nlp.ProcessSingle(doc);

        //Formatting
        // Convert the 'doc' object to a JSON string and print it to the console
        Console.WriteLine(doc.ToJson());
        // Convert the 'doc' object to a pretty (indented) JSON string
        string prettyJson = JsonConvert.SerializeObject(doc, Formatting.Indented);
        // Print the pretty JSON string to the console
        Console.WriteLine(prettyJson);

       //Checking the input for specific words
        // Check if the 'input' string contains the word "copy" 
        if (doc.Value.Contains("copy"))
        {
            // If it does, call the copy function
            copy(doc);
        }
        // Check if the 'input' string contains the word "paste"
        else if (doc.Value.Contains("paste"))
        {
            // If it does, call the paste function 
            paste(doc);
        }
        // Check if the 'input' string contains the word "close"
        else if (doc.Value.Contains("close"))
        {
            // If it does, call the close function 
            close(doc);
        }
        // Check if the 'input' string contains the word "undo"
        else if (doc.Value.Contains("undo"))
        {
            // If it does, call the undo function 
            undo(doc);
        }
        // Check if the 'input' string contains the word "start"
        else if(doc.Value.Contains("start"))
        {
            // If it does, call the start function 
            start(doc);
        }
        // Check if the 'input' string contains the word "redo"
        else if(doc.Value.Contains("redo"))
        {
            // If it does, call the redo function 
            redo(doc);
        }
        // Check if the 'input' string contains the word "refresh"
        else if(doc.Value.Contains("refresh"))
        {
            // If it does, call the refresh function
            refresh(doc);
        }
        // Check if the 'input' string contains the word "stop" and "chrome"
        else if(doc.Value.Contains("stop"))
        {
            // Check if the 'input' string contains the word "chrome"
            if(doc.Value.Contains("chrome"))
            {
                // If it does, call the stopChrome function 
            }
            // Check if the 'input' string contains the word "opera"
            else if (doc.Value.Contains("opera"))
            {
                // If it does, call the stopOpera function 
            }
            // Check if the 'input' string contains the word "edge"
            else if (doc.Value.Contains("edge"))
            {
                // If it does, call the stopEdge function 
            }
            // Check if the 'input' string contains the word "firefox"
            else if (doc.Value.Contains("firefox"))
            {
                // If it does, call the stopFirefox function 
            }
            // Check if the 'input' string contains the word "explorer"
            else if (doc.Value.Contains("explorer"))
            {
                // If it does, call the stopExplorer function 
            }
            else 
            {
                // If the 'input' string doesn't contain any of the above words, call the stopActive function 
            }
        }
        else
        {
            // If the 'input' string doesn't contain any of the above words, print an error message
            Console.WriteLine("Invalid input. Please try again.");
        }
    }

    /// <summary>
    /// Write a program that implements part of speech tagging for the word copy. 
    /// If it is a noun, then call the shortcut copy funtion and write copy on to the screen
    /// </summary>
    public static void copy(Document doc)
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

                // If the token is the word "copy" and it is a verb
                if (tokenText == "copy" && token.Tag == PartOfSpeech.VERB)
                {
                    // Call the copy function from ShortCuts class
                    //ShortCuts.copy();
                    // Print "Copy" to the console
                    Console.WriteLine("Copy");
                }
            }
        }
    }

    /// <summary>
    /// Write a program that implements part of speech tagging for the word paste.
    /// If it is a verb, then call the shortcut paste funtion and write paste on to the screen
    /// </summary>
    public static void paste(Document doc)
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

                // If the token is the word "paste" and it is a verb
                if (tokenText == "paste" && token.Tag == PartOfSpeech.VERB)
                {
                    // Call the paste function from ShortCuts class
                    //ShortCuts.paste();
                    // Print "Paste" to the console
                    Console.WriteLine("Paste");
                }
            }
        }
    }

    /// <summary>
    /// Write a program that implements part of speech tagging for the word close.
    /// If it is a verb, then call the shortcut close funtion and write close on to the screen
    /// </summary>
    public static void close(Document doc)
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

                // If the token is the word "close" and it is a verb
                if (tokenText == "close" && token.Tag == PartOfSpeech.VERB)
                {
                    // Call the close function from ShortCuts class
                    //ShortCuts.close();
                    // Print "Close" to the console
                    Console.WriteLine("Close");
                }
            }
        }
    }

    /// <summary>
    /// Write a program that implements part of speech tagging for the word undo.
    /// If it is a verb, then call the shortcut undo funtion and write undo on to the screen
    /// </summary>
    public static void undo(Document doc)
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

                // If the token is the word "undo" and it is a verb
                if (tokenText == "undo" && token.Tag == PartOfSpeech.VERB)
                {
                    // Call the undo function from ShortCuts class
                    //ShortCuts.undo();
                    // Print "Undo" to the console
                    Console.WriteLine("Undo");
                }
            }
        }
    }

    /// <summary>
    /// Write a program that implements part of speech tagging for the word start.
    /// If it is a verb, then call the shortcut start funtion and write start on to the screen
    /// </summary>
    public static void start(Document doc)
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

                // If the token is the word "start" and it is a verb
                if (tokenText == "start" && token.Tag == PartOfSpeech.VERB)
                {
                    // Call the start function from ShortCuts class
                    //ShortCuts.start();
                    // Print "Start" to the console
                    Console.WriteLine("Start");
                }
            }
        }
    }

    /// <summary>
    /// Write a program that implements part of speech tagging for the word redo.
    /// If it is a verb, then call the shortcut redo funtion and write redo on to the screen
    /// </summary>
    public static void redo(Document doc)
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

                // If the token is the word "redo" and it is a verb
                if (tokenText == "redo" && token.Tag == PartOfSpeech.VERB)
                {
                    // Call the redo function from ShortCuts class
                    //ShortCuts.redo();
                    // Print "Redo" to the console
                    Console.WriteLine("Redo");
                }
            }
        }
    }

    /// <summary>
    /// Write a program that implements part of speech tagging for the word refresh.
    /// If it is a verb, then call the shortcut refresh funtion and write refresh on to the screen
    /// </summary>
    public static void refresh(Document doc)
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

                // If the token is the word "refresh" and it is a verb
                if (tokenText == "refresh" && token.Tag == PartOfSpeech.VERB)
                {
                    // Call the refresh function from ShortCuts class
                    //ShortCuts.refresh();
                    // Print "Refresh" to the console
                    Console.WriteLine("Refresh");
                }
            }
        }
    }
}
