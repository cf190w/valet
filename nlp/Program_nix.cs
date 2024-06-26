﻿using System;
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
}
