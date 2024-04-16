using System;
using System.Threading.Tasks;
using Catalyst;
using Mosaik.Core;
using Newtonsoft.Json;

namespace NLP;

public class Program 
{
  public static async Task Main() 
  {
    //Register the English language model
    Catalyst.Models.English.Register(); //You need to pre-register each language (and install the respective NuGet Packages)
    // Configure storage
    Storage.Current = new DiskStorage("catalyst-models");
    // Create a Catalyst NLP pipeline for English
    var nlp = await Pipeline.ForAsync(Language.English);
    // Input text and create a document
    var doc = new Document("Hey Valet. Copy and paste this text", Language.English);
    // Process the document
    nlp.ProcessSingle(doc);

    //Formatting
    // Convert the 'doc' object to a JSON string and print it to the console
    Console.WriteLine(doc.ToJson());
    // Convert the 'doc' object to a pretty (indented) JSON string
    string prettyJson = JsonConvert.SerializeObject(doc, Formatting.Indented);
    // Print the pretty JSON string to the console
    Console.WriteLine(prettyJson);


    // Count the number of verbs in the 'doc' object and print the count to the console
    int verbs = verbCount(doc);
    Console.WriteLine($"The document contains {verbs} verbs.");

    // Count the number of nouns in the 'doc' object and print the count to the console
    int nouns = nounCount(doc);
    Console.WriteLine($"The document contains {nouns} nouns.");

    /*

    // Check if the 'input' string contains the word "copy"
    if (input.Contains("copy"))
    {
        // If it does, call the 'wordCopyFunction' function
        wordCopyFunction();
    }
    // Check if the 'input' string contains the word "paste"
    else if (input.Contains("paste"))
    {
        // If it does, call the 'wordPasteFunction' function
        wordPasteFunction();
    }
    // Check if the 'input' string contains the word "close"
    else if (input.Contains("close"))
    {
        // If it does, call the 'closeApplicationFunction' function
        closeApplicationFunction();
    }
    else
    {
        // If the 'input' string doesn't contain any of the above words, print an error message
        Console.WriteLine("Invalid input. Please try again.");
    }
    
    */

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

    /*

    /// <summary>
    /// Function for the word copy to be called 
    /// </summary>
    public static void wordCopyFunction ()
    {

    }

    /// <summary>
    /// Function for the word paste to be called 
    /// </summary>
    public static void wordPasteFunction ()
    {

    }

    /// <summary>
    /// Function for the word close to be called 
    /// </summary>
    public static void closeApplicationFunction ()
    {

    }

    */

}


