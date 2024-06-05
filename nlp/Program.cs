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
        var doc = new Document("stop the chrome window", Language.English);
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
        else if (doc.Value.Contains("grab"))
        {
            // If it does, call the grab function
            grab(doc);
        }
        else if (doc.Value.Contains("take"))
        {
            // If it does, call the take function
            take(doc);
        }
        // Check if the 'input' string contains the word "paste"
        else if (doc.Value.Contains("paste"))
        {
            // If it does, call the paste function 
            paste(doc);
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
        else if(doc.Value.Contains("cut"))
        {
            // If it does, call the cut function
            cut(doc);
        }
        else if(doc.Value.Contains("delete"))
        {
            // If it does, call the delete function
            delete(doc);
        }
        else if(doc.Value.Contains("remove"))
        {
            // If it does, call the remove function
            remove(doc);
        }
        else if(doc.Value.Contains("trim"))
        {
            // If it does, call the trim function
            trim(doc);
        }
        else if(doc.Value.Contains("select"))
        {
            // If it does, call the select function
            select(doc);
        }
        else if(doc.Value.Contains("highlight"))
        {
            // If it does, call the highlight function
            highlight(doc);
        }
        else if(doc.Value.Contains("save"))
        {
            // If it does, call the save function
            save(doc);
        }
        else if(doc.Value.Contains("store"))
        {
            // If it does, call the store function
            store(doc);
        }
        else if(doc.Value.Contains("hold"))
        {
            // If it does, call the hold function
            hold(doc);
        }
        else if(doc.Value.Contains("minimize"))
        {
            // If it does, call the minimize function
            minimize(doc);
        }
        else if(doc.Value.Contains("minimise"))
        {
            // If it does, call the minimise function
            minimise(doc);
        }
        else if(doc.Value.Contains("smaller"))
        {
            // If it does, call the minimise function
            smaller(doc);
        }
        else if(doc.Value.Contains("downsize"))
        {
            // If it does, call the downsize function
            downsize(doc);
        }
        else if(doc.Value.Contains("shrink"))
        {
            // If it does, call the shrink function
            shrink(doc);
        }
        else if(doc.Value.Contains("reopen"))
        {
            // If it does, call the reopen function
            reopen(doc);
        }
        else if(doc.Value.Contains("back"))
        {
            // If it does, call the shrink function
            back(doc);
        }
        else if(doc.Value.Contains("revive"))
        {
            // If it does, call the revive function
            revive(doc);
        }
        else if(doc.Value.Contains("bring"))
        {
            // If it does, call the bring function
            bring(doc);
        }
        else if(doc.Value.Contains("come"))
        {
            // If it does, call the come function
            come(doc);
        }
        else if(doc.Value.Contains("meant"))
        {
            // If it does, call the meant function
            meant(doc);
        }
        else if(doc.Value.Contains("done"))
        {
            // If it does, call the done function
            done(doc);
        }
        else if(doc.Value.Contains("no"))
        {
            // If it does, call the no function
            no(doc);
        }
        else if(doc.Value.Contains("maximize"))
        {
            // If it does, call the maximize function
            maximize(doc);
        }
        else if(doc.Value.Contains("maximise"))
        {
            // If it does, call the maximise function
            maximise(doc);
        }
        else if(doc.Value.Contains("full"))
        {
            // If it does, call the full function
            full(doc);
        }
        else if(doc.Value.Contains("enlarge"))
        {
            // If it does, call the enlarge function
            enlarge(doc);
        }
        else if(doc.Value.Contains("expand"))
        {
            // If it does, call the expand function
            expand(doc);
        }
        else if(doc.Value.Contains("split"))
        {
            // If it does, call the split function
            split(doc);
        }
        else if(doc.Value.Contains("left"))
        {
            // If it does, call the left function
            left(doc);
        }
        else if(doc.Value.Contains("right"))
        {
            // If it does, call the right function
            right(doc);
        }
        else if(doc.Value.Contains("seperate"))
        {
            // If it does, call the seperate function
            seperate(doc);
        }
        else if(doc.Value.Contains("divide"))
        {
            // If it does, call the divide function
            divide(doc);
        }
        else if(doc.Value.Contains("snap"))
        {
            // If it does, call the snap function
            snap(doc);
        }
        // Check if the 'input' string contains the word "stop" and "chrome"
        else if(doc.Value.Contains("stop"))
        {
            // Check if the 'input' string contains the word "chrome"
            if(doc.Value.Contains("chrome"))
            {
                // If it does, call the stopChrome function 
                stopChrome(doc);
            }
            // Check if the 'input' string contains the word "opera"
            else if (doc.Value.Contains("opera"))
            {
                // If it does, call the stopOpera function 
                stopOpera(doc);
            }
            // Check if the 'input' string contains the word "edge"
            else if (doc.Value.Contains("edge"))
            {
                // If it does, call the stopEdge function 
                stopEdge(doc);
            }
            // Check if the 'input' string contains the word "firefox"
            else if (doc.Value.Contains("firefox"))
            {
                // If it does, call the stopFirefox function 
                stopFirefox(doc);
            }
            // Check if the 'input' string contains the word "explorer"
            else if (doc.Value.Contains("explorer"))
            {
                // If it does, call the stopExplorer function 
                stopExplorer(doc);
            }
            else 
            {
                // If the 'input' string doesn't contain any of the above words, call the stopActive function 
                stopActive(doc);
            }
        }
        else
        {
            // If the 'input' string doesn't contain any of the above words, print an error message
            Console.WriteLine("Invalid input. Please try again.");
        }
    }

    /// <summary>
    /// program that implements part of speech tagging for the word right.
    /// If it is a noun, then call the shortcut WindowRight funtion and write split on to the screen
    /// </summary>
    /// 
    public static void right(Document doc)
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

                // If the token is the word "right" and it is a verb
                if (tokenText == "right" && token.Tag == PartOfSpeech.NOUN)
                {
                    // Call the right function from ShortCuts class
                    // ShortCuts.WindowRight();
                    // Print "Right" to the console
                    Console.WriteLine("Right");
                }
            }
        }
    }

    /// <summary>
    /// program that implements part of speech tagging for the word left.
    /// If it is a noun, then call the shortcut WindowLeft funtion and write split on to the screen
    /// </summary>
    /// 
    public static void left(Document doc)
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

                // If the token is the word "left" and it is a verb
                if (tokenText == "left" && token.Tag == PartOfSpeech.NOUN)
                {
                    // Call the left function from ShortCuts class
                    // ShortCuts.WindowLeft();
                    // Print "Left" to the console
                    Console.WriteLine("Left");
                }
            }
        }
    }

    /// <summary>
    /// program that implements part of speech tagging for the word split.
    /// If it is a verb, then call the shortcut WindowRight funtion and write split on to the screen
    /// </summary>
    /// 
    public static void split(Document doc)
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

                // If the token is the word "split" and it is a verb
                if (tokenText == "split" && token.Tag == PartOfSpeech.VERB)
                {
                    // Call the split function from ShortCuts class
                    // ShortCuts.WindowRight();
                    // Print "Split" to the console
                    Console.WriteLine("Right");
                }
            }
        }
    }

    /// <summary>
    /// program that implements part of speech tagging for the word snap.
    /// If it is a verb, then call the shortcut WindowRight funtion and write snap on to the screen
    /// </summary>
    /// 
    public static void snap(Document doc)
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

                // If the token is the word "snap" and it is a verb
                if (tokenText == "snap" && token.Tag == PartOfSpeech.VERB)
                {
                    // Call the snap function from ShortCuts class
                    // ShortCuts.WindowRight();
                    // Print "Snap" to the console
                    Console.WriteLine("Right");
                }
            }
        }
    }

    /// <summary>
    /// program that implements part of speech tagging for the word divide.
    /// If it is a verb, then call the shortcut WindowRight funtion and write divide on to the screen
    /// </summary>
    /// 
    public static void divide(Document doc)
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

                // If the token is the word "divide" and it is a verb
                if (tokenText == "divide" && token.Tag == PartOfSpeech.VERB)
                {
                    // Call the divide function from ShortCuts class
                    // ShortCuts.WindowRight();
                    // Print "Divide" to the console
                    Console.WriteLine("Right");
                }
            }
        }
    }

    /// <summary>
    /// program that implements part of speech tagging for the word seperate.
    /// If it is a verb, then call the shortcut WindowRight funtion and write seperate on to the screen
    /// </summary>
    /// 
    public static void seperate(Document doc)
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

                // If the token is the word "seperate" and it is a verb
                if (tokenText == "seperate" && token.Tag == PartOfSpeech.VERB)
                {
                    // Call the seperate function from ShortCuts class
                    // ShortCuts.WindowRight();
                    // Print "Seperate" to the console
                    Console.WriteLine("Right");
                }
            }
        }
    }

    /// <summary>
    /// program that implements part of speech tagging for the word maximize.
    /// If it is a verb, then call the shortcut WindowMaximizeCurrent funtion and write maximize on to the screen
    /// </summary>
    /// 
    public static void maximize(Document doc)
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

                // If the token is the word "maximize" and it is a verb
                if (tokenText == "maximize" && token.Tag == PartOfSpeech.VERB)
                {
                    // Call the maximize function from ShortCuts class
                    // ShortCuts.WindowMaximizeCurrent();
                    // Print "Maximize" to the console
                    Console.WriteLine("Maximize");
                }
            }
        }
    }

    /// <summary>
    /// program that implements part of speech tagging for the word maximise.
    /// If it is a verb, then call the shortcut WindowMaximizeCurrent funtion and write maximise on to the screen
    /// </summary>
    /// 
    public static void maximise(Document doc)
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

                // If the token is the word "maximise" and it is a verb
                if (tokenText == "maximise" && token.Tag == PartOfSpeech.VERB)
                {
                    // Call the maximize function from ShortCuts class
                    // ShortCuts.WindowMaximizeCurrent();
                    // Print "Maximise" to the console
                    Console.WriteLine("Maximize");
                }
            }
        }
    }

    /// <summary>
    /// program that implements part of speech tagging for the word full.
    /// If it is a adjective, then call the shortcut WindowMaximizeCurrent funtion and write full on to the screen
    /// </summary>
    /// 
    public static void full(Document doc)
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

                // If the token is the word "full" and it is a verb
                if (tokenText == "full" && token.Tag == PartOfSpeech.ADJ)
                {
                    // Call the maximize function from ShortCuts class
                    // ShortCuts.WindowMaximizeCurrent();
                    // Print "Full" to the console
                    Console.WriteLine("Maximize");
                }
            }
        }
    }

    /// <summary>
    /// program that implements part of speech tagging for the word enlarge.
    /// If it is a verb, then call the shortcut WindowMaximizeCurrent funtion and write enlarge on to the screen
    /// </summary>
    /// 
    public static void enlarge(Document doc)
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

                // If the token is the word "enlarge" and it is a verb
                if (tokenText == "enlarge" && token.Tag == PartOfSpeech.VERB)
                {
                    // Call the maximize function from ShortCuts class
                    // ShortCuts.WindowMaximizeCurrent();
                    // Print "Enlarge" to the console
                    Console.WriteLine("Maximize");
                }
            }
        }
    }

    /// <summary>
    /// program that implements part of speech tagging for the word expand.
    /// If it is a verb, then call the shortcut WindowMaximizeCurrent funtion and write expand on to the screen
    /// </summary>
    /// 
    public static void expand(Document doc)
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

                // If the token is the word "expand" and it is a verb
                if (tokenText == "expand" && token.Tag == PartOfSpeech.VERB)
                {
                    // Call the maximize function from ShortCuts class
                    // ShortCuts.WindowMaximizeCurrent();
                    // Print "Expand" to the console
                    Console.WriteLine("Maximize");
                }
            }
        }
    }

    /// <summary>
    /// program that implements part of speech tagging for the word reopen.
    /// If it is a verb, then call the shortcut WindowReopen funtion and write reopen on to the screen
    /// </summary>
    /// 
    public static void reopen(Document doc)
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

                // If the token is the word "reopen" and it is a verb
                if (tokenText == "reopen" && token.Tag == PartOfSpeech.VERB)
                {
                    // Call the reopen function from ShortCuts class
                    // ShortCuts.WindowReopen();
                    // Print "Reopen" to the console
                    Console.WriteLine("Reopen");
                }
            }
        }
    }

    /// <summary>
    /// program that implements part of speech tagging for the word back.
    /// If it is a adverb, then call the shortcut WindowReopen funtion and write reopen on to the screen
    /// </summary>
    /// 
    public static void back(Document doc)
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

                // If the token is the word "back" and it is a verb
                if (tokenText == "back" && token.Tag == PartOfSpeech.ADV)
                {
                    // Call the reopen function from ShortCuts class
                    // ShortCuts.WindowReopen();
                    // Print "Back" to the console
                }
            }
        }
    }

    /// <summary>
    /// program that implements part of speech tagging for the word revive.
    /// If it is a verb, then call the shortcut WindowReopen funtion and write reopen on to the screen
    /// </summary>
    /// 
    public static void revive(Document doc)
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

                // If the token is the word "revive" and it is a verb
                if (tokenText == "revive" && token.Tag == PartOfSpeech.VERB)
                {
                    // Call the reopen function from ShortCuts class
                    // ShortCuts.WindowReopen();
                    // Print "Revive" to the console
                    Console.WriteLine("Reopen");
                }
            }
        }
    }

    /// <summary>
    /// program that implements part of speech tagging for the word bring.
    /// If it is a verb, then call the shortcut WindowReopen funtion and write reopen on to the screen
    /// </summary>
    /// 
    public static void bring(Document doc)
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

                // If the token is the word "bring" and it is a verb
                if (tokenText == "bring" && token.Tag == PartOfSpeech.VERB)
                {
                    // Call the reopen function from ShortCuts class
                    // ShortCuts.WindowReopen();
                    // Print "Bring" to the console
                    Console.WriteLine("Reopen");
                }
            }
        }
    }

    /// <summary>
    /// program that implements part of speech tagging for the word come.
    /// If it is a verb, then call the shortcut WindowReopen funtion and write reopen on to the screen
    /// </summary>
    /// 
    public static void come(Document doc)
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

                // If the token is the word "come" and it is a verb
                if (tokenText == "come" && token.Tag == PartOfSpeech.VERB)
                {
                    // Call the reopen function from ShortCuts class
                    // ShortCuts.WindowReopen();
                    // Print "Come" to the console
                    Console.WriteLine("Reopen");
                }
            }
        }
    }

    /// <summary>
    /// program that implements part of speech tagging for the word meant.
    /// If it is a verb, then call the shortcut WindowReopen funtion and write reopen on to the screen
    /// </summary>
    /// 
    public static void meant(Document doc)
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

                // If the token is the word "meant" and it is a verb
                if (tokenText == "meant" && token.Tag == PartOfSpeech.VERB)
                {
                    // Call the reopen function from ShortCuts class
                    // ShortCuts.WindowReopen();
                    // Print "Meant" to the console
                    Console.WriteLine("Reopen");
                }
            }
        }
    }

    /// <summary>
    /// program that implements part of speech tagging for the word done.
    /// If it is a adjective, then call the shortcut WindowReopen funtion and write reopen on to the screen
    /// </summary>
    /// 
    public static void done(Document doc)
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

                // If the token is the word "done" and it is a verb
                if (tokenText == "done" && token.Tag == PartOfSpeech.ADJ)
                {
                    // Call the reopen function from ShortCuts class
                    // ShortCuts.WindowReopen();
                    // Print "Done" to the console
                    Console.WriteLine("Reopen");
                }
            }
        }
    }

    /// <summary>
    /// program that implements part of speech tagging for the word no.
    /// If it is a adverb, then call the shortcut WindowReopen funtion and write reopen on to the screen
    /// </summary>
    /// 
    public static void no(Document doc)
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

                // If the token is the word "no" and it is a verb
                if (tokenText == "no" && token.Tag == PartOfSpeech.ADV)
                {
                    // Call the reopen function from ShortCuts class
                    // ShortCuts.WindowReopen();
                    // Print "No" to the console
                    Console.WriteLine("Reopen");
                }
            }
        }
    }

    /// <summary>
    /// program that implements part of speech tagging for the word minimize.
    /// If it is a verb, then call the shortcut minimize funtion and write minimize on to the screen
    /// </summary>
    /// 
    public static void minimize(Document doc)
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

                // If the token is the word "minimize" and it is a verb
                if (tokenText == "minimize" && token.Tag == PartOfSpeech.VERB)
                {
                    // Call the minimize function from ShortCuts class
                    // ShortCuts.WindowMinimize();
                    // Print "Minimize" to the console
                    Console.WriteLine("Minimize");
                }
            }
        }
    }

    /// <summary>
    /// program that implements part of speech tagging for the word minimise.
    /// If it is a verb, then call the shortcut minimise funtion and write minimise on to the screen
    /// </summary>
    /// 
    public static void minimise(Document doc)
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

                // If the token is the word "minimise" and it is a verb
                if (tokenText == "minimise" && token.Tag == PartOfSpeech.VERB)
                {
                    // Call the minimise function from ShortCuts class
                    // ShortCuts.WindowMinimize();
                    // Print "Minimise" to the console
                    Console.WriteLine("Minimize");
                }
            }
        }
    }

    /// <summary>
    /// program that implements part of speech tagging for the word smaller.
    /// If it is a adjective, then call the shortcut minimize funtion and write smaller on to the screen
    /// </summary>
    /// 
    public static void smaller(Document doc)
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

                // If the token is the word "smaller" and it is a verb
                if (tokenText == "smaller" && token.Tag == PartOfSpeech.ADJ)
                {
                    // Call the minimize function from ShortCuts class
                    // ShortCuts.WindowMinimize();
                    // Print "Smaller" to the console
                    Console.WriteLine("Minimize");
                }
            }
        }
    }

    /// <summary>
    /// program that implements part of speech tagging for the word downsize.
    /// If it is a verb, then call the shortcut minimize funtion and write minimize on to the screen
    /// </summary>
    /// 
    public static void downsize(Document doc)
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

                // If the token is the word "downsize" and it is a verb
                if (tokenText == "downsize" && token.Tag == PartOfSpeech.VERB)
                {
                    // Call the minimize function from ShortCuts class
                    // ShortCuts.WindowMinimize();
                    // Print "Downsize" to the console
                    Console.WriteLine("Minimize");
                }
            }
        }
    }

    /// <summary>
    /// program that implements part of speech tagging for the word shrink.
    /// If it is a verb, then call the shortcut minimize funtion and write minimize on to the screen
    /// </summary>
    /// 
    public static void shrink(Document doc)
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

                // If the token is the word "shrink" and it is a verb
                if (tokenText == "shrink" && token.Tag == PartOfSpeech.VERB)
                {
                    // Call the minimize function from ShortCuts class
                    // ShortCuts.WindowMinimize();
                    // Print "Shrink" to the console
                    Console.WriteLine("Minimize");
                }
            }
        }
    }

    /// <summary>
    /// program that implements part of speech tagging for the word save.
    /// If it is a verb, then call the shortcut save funtion and write save on to the screen
    /// </summary>
    /// 
    public static void save(Document doc)
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

                // If the token is the word "save" and it is a verb
                if (tokenText == "save" && token.Tag == PartOfSpeech.VERB)
                {
                    // Call the save function from ShortCuts class
                    // ShortCuts.save();
                    // Print "Save" to the console
                    Console.WriteLine("Save");
                }
            }
        }
    }

    /// <summary>
    /// program that implements part of speech tagging for the word store.
    /// If it is a verb, then call the shortcut save funtion and write save on to the screen
    /// </summary>
    /// 
    public static void store(Document doc)
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

                // If the token is the word "store" and it is a verb
                if (tokenText == "store" && token.Tag == PartOfSpeech.VERB)
                {
                    // Call the save function from ShortCuts class
                    // ShortCuts.save();
                    // Print "Save" to the console
                    Console.WriteLine("Save");
                }
            }
        }
    }

    /// <summary>
    /// program that implements part of speech tagging for the word hold.
    /// If it is a verb, then call the shortcut save funtion and write save on to the screen
    /// </summary>
    /// 
    public static void hold(Document doc)
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

                // If the token is the word "hold" and it is a verb
                if (tokenText == "hold" && token.Tag == PartOfSpeech.VERB)
                {
                    // Call the save function from ShortCuts class
                    // ShortCuts.save();
                    // Print "Save" to the console
                    Console.WriteLine("Save");
                }
            }
        }
    }

    /// <summary>
    /// program that implements part of speech tagging for the word select.
    /// If it is a verb, then call the shortcut select funtion and write select on to the screen
    /// </summary>
    /// 
    public static void select(Document doc)
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

                // If the token is the word "select" and it is a verb
                if (tokenText == "select" && token.Tag == PartOfSpeech.VERB)
                {
                    // Call the select function from ShortCuts class
                    // ShortCuts.selectAll();
                    // Print "Select" to the console
                    Console.WriteLine("Select");
                }
            }
        }
    }

    /// <summary>
    /// program that implements part of speech tagging for the word highlight.
    /// If it is a verb, then call the shortcut select funtion and write select on to the screen
    /// </summary>
    /// 
    public static void highlight(Document doc)
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

                // If the token is the word "highlight" and it is a verb
                if (tokenText == "highlight" && token.Tag == PartOfSpeech.VERB)
                {
                    // Call the select function from ShortCuts class
                    // ShortCuts.selectAll();
                    // Print "Highlight" to the console
                    Console.WriteLine("select");
                }
            }
        }
    }

    /// <summary>
    /// program that implements part of speech tagging for the word cut.
    /// If it is a verb, then call the shortcut cut funtion and write cut on to the screen
    /// </summary>
    /// 
    public static void cut(Document doc)
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

                // If the token is the word "cut" and it is a verb
                if (tokenText == "cut" && token.Tag == PartOfSpeech.VERB)
                {
                    // Call the cut function from ShortCuts class
                    // ShortCuts.cut();
                    // Print "Cut" to the console
                    Console.WriteLine("Cut");
                }
            }
        }
    }

    /// <summary>
    /// program that implements part of speech tagging for the word delete.
    /// If it is a verb, then call the shortcut cut funtion and write cut on to the screen
    /// </summary>
    /// 
    public static void delete(Document doc)
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

                // If the token is the word "delete" and it is a verb
                if (tokenText == "delete" && token.Tag == PartOfSpeech.VERB)
                {
                    // Call the cut function from ShortCuts class
                    // ShortCuts.cut();
                    // Print "Delete" to the console
                    Console.WriteLine("cut");
                }
            }
        }
    }

    /// <summary>
    /// program that implements part of speech tagging for the word remove.
    /// If it is a verb, then call the shortcut cut funtion and write cut on to the screen
    /// </summary>
    /// 
    public static void remove(Document doc)
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

                // If the token is the word "remove" and it is a verb
                if (tokenText == "remove" && token.Tag == PartOfSpeech.VERB)
                {
                    // Call the cut function from ShortCuts class
                    // ShortCuts.cut();
                    // Print "Remove" to the console
                    Console.WriteLine("cut");
                }
            }
        }
    }

    /// <summary>
    /// program that implements part of speech tagging for the word trim.
    /// If it is a verb, then call the shortcut cut funtion and write cut on to the screen
    /// </summary>
    /// 
    public static void trim(Document doc)
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

                // If the token is the word "trim" and it is a verb
                if (tokenText == "trim" && token.Tag == PartOfSpeech.VERB)
                {
                    // Call the cut function from ShortCuts class
                    // ShortCuts.cut();
                    // Print "Trim" to the console
                    Console.WriteLine("cut");
                }
            }
        }
    }

    /// <summary>
    /// program that implements part of speech tagging for the word copy. 
    /// If it is a verb, then call the shortcut copy funtion and write copy on to the screen
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
                    // ShortCuts.copy();
                    // Print "Copy" to the console
                    Console.WriteLine("Copy");
                }
            }
        }
    }

    /// <summary>
    /// program that implements part of speech tagging for the word grab.
    /// If it is a verb, then call the shortcut copy funtion and write grab on to the screen
    /// </summary>
    public static void grab(Document doc)
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

                // If the token is the word "grab" and it is a verb
                if (tokenText == "grab" && token.Tag == PartOfSpeech.VERB)
                {
                    // Call the copy function from ShortCuts class
                    // ShortCuts.copy();
                    // Print "Grab" to the console
                    Console.WriteLine("Copy");
                }
            }
        }
    }

    /// <summary>
    /// program that implements part of speech tagging for the word take.
    /// If it is a verb, then call the shortcut copy funtion and write take on to the screen
    /// </summary>
    public static void take(Document doc)
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

                // If the token is the word "take" and it is a verb
                if (tokenText == "take" && token.Tag == PartOfSpeech.VERB)
                {
                    // Call the copy function from ShortCuts class
                    // ShortCuts.copy();
                    // Print "Take" to the console
                    Console.WriteLine("Copy");
                }
            }
        }
    }

    /// <summary>
    /// program that implements part of speech tagging for the word paste.
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
                    // ShortCuts.paste();
                    // Print "Paste" to the console
                    Console.WriteLine("Paste");
                }
            }
        }
    }

    /// <summary>
    /// program that implements part of speech tagging for the word insert.
    /// If it is a verb, then call the shortcut paste funtion and write insert on to the screen
    /// </summary>
    public static void insert(Document doc)
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

                // If the token is the word "insert" and it is a verb
                if (tokenText == "insert" && token.Tag == PartOfSpeech.VERB)
                {
                    // Call the paste function from ShortCuts class
                    // ShortCuts.paste();
                    // Print "Insert" to the console
                    Console.WriteLine("Paste");
                }
            }
        }
    }

    /// <summary>
    /// program that implements part of speech tagging for the word close.
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
                    // ShortCuts.close();
                    // Print "Close" to the console
                    Console.WriteLine("Close");
                }
            }
        }
    }

    /// <summary>
    /// program that implements part of speech tagging for the word shut.
    /// If it is a verb, then call the shortcut close funtion and write shut on to the screen
    /// </summary>
    public static void shut(Document doc)
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

                // If the token is the word "shut" and it is a verb
                if (tokenText == "shut" && token.Tag == PartOfSpeech.VERB)
                {
                    // Call the close function from ShortCuts class
                    //ShortCuts.close();
                    // Print "Shut" to the console
                    Console.WriteLine("Shut");
                }
            }
        }
    }

    /// <summary>
    /// program that implements part of speech tagging for the word undo.
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
                    // ShortCuts.undo();
                    // Print "Undo" to the console
                    Console.WriteLine("Undo");
                }
            }
        }
    }

    /// <summary>
    /// program that implements part of speech tagging for the word start.
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
    /// program that implements part of speech tagging for the word redo.
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
                    // ShortCuts.redo();
                    // Print "Redo" to the console
                    Console.WriteLine("Redo");
                }
            }
        }
    }

    /// <summary>
    /// program that implements part of speech tagging for the word refresh.
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
                    // ShortCuts.refresh();
                    // Print "Refresh" to the console
                    Console.WriteLine("Refresh");
                }
            }
        }
    }

    /// <summary>
    /// program that implements part of speech tagging for the words stop and chrome.
    /// If stop is a verb and chrome is a proper noun (propn) then call the shortcut stop chrome funtion 
    /// and write stop chrome on to the screen
    /// </summary>
    public static void stopChrome(Document doc)
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

                // If the token is the word "stop" and it is a verb
                if (tokenText == "stop" && token.Tag == PartOfSpeech.VERB)
                {
                    // Call the stop function from ShortCuts class
                    //ShortCuts.stopExact();
                    // Print "stop" to the console
                    Console.WriteLine("stop chrome");
                }
            }
        }
    }

    /// <summary>
    /// program that implements part of speech tagging for the words stop and opera.
    /// If stop is a verb and opera is a proper noun (propn) then call the shortcut stop opera funtion
    /// and write stop opera on to the screen
    /// </summary>
    public static void stopOpera(Document doc)
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

                // If the token is the word "stop" and it is a verb
                if (tokenText == "stop" && token.Tag == PartOfSpeech.VERB)
                {
                    // Call the stop function from ShortCuts class
                    //ShortCuts.stopExact();
                    // Print "stop" to the console
                    Console.WriteLine("stop opera");
                }
            }
        }
    }

    /// <summary>
    /// program that implements part of speech tagging for the words stop and edge.
    /// If stop is a verb and edge is a proper noun (propn) then call the shortcut stop edge funtion
    /// and write stop edge on to the screen
    /// </summary>
    public static void stopEdge(Document doc)
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

                // If the token is the word "stop" and it is a verb
                if (tokenText == "stop" && token.Tag == PartOfSpeech.VERB)
                {
                    // Call the stop function from ShortCuts class
                    //ShortCuts.stopExact();
                    // Print "stop" to the console
                    Console.WriteLine("stop edge");
                }
            }
        }
    }

    /// <summary>
    /// program that implements part of speech tagging for the words stop and firefox.
    /// If stop is a verb and firefox is a proper noun (propn) then call the shortcut stop firefox funtion
    /// and write stop firefox on to the screen
    /// </summary>
    public static void stopFirefox(Document doc)
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

                // If the token is the word "stop" and it is a verb
                if (tokenText == "stop" && token.Tag == PartOfSpeech.VERB)
                {
                    // Call the stop function from ShortCuts class
                    //ShortCuts.stopExact();
                    // Print "stop" to the console
                    Console.WriteLine("stop firefox");
                }
            }
        }
    }

    /// <summary>
    /// program that implements part of speech tagging for the words stop and explorer.
    /// If stop is a verb and explorer is a proper noun (propn) then call the shortcut stop explorer funtion
    /// and write stop explorer on to the screen
    /// </summary>
    /// 
    public static void stopExplorer(Document doc)
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

                // If the token is the word "stop" and it is a verb
                if (tokenText == "stop" && token.Tag == PartOfSpeech.VERB)
                {
                    // Call the stop function from ShortCuts class
                    //ShortCuts.stopExact();
                    // Print "stop" to the console
                    Console.WriteLine("stop explorer");
                }
            }
        }
    }

    /// <summary>
    /// program that implements part of speech tagging for the word stop.
    /// If it is a verb, then call the shortcut stopactive funtion and write stop on to the screen
    /// </summary>
    public static void stopActive(Document doc)
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

                // If the token is the word "stop" and it is a verb
                if (tokenText == "stop" && token.Tag == PartOfSpeech.VERB)
                {
                    // Call the stop function from ShortCuts class
                    //ShortCuts.stopActive();
                    // Print "stop" to the console
                    Console.WriteLine("stop active");
                }
            }
        }
    }
}
