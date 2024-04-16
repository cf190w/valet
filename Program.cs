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
    Console.WriteLine(doc.ToJson());
    string prettyJson = JsonConvert.SerializeObject(doc, Formatting.Indented);
    Console.WriteLine(prettyJson);

    
    int verbs = verbCount(doc);
    Console.WriteLine($"The document contains {verbs} verbs.");

    int nouns = nounCount(doc);
    Console.WriteLine($"The document contains {nouns} nouns.");

    if (input.Contains("copy"))
    {
        wordCopyFunction();
    }
    else if (input.Contains("paste"))
    {
        wordPasteFunction();
    }
    else if (input.Contains("close"))
    {
        closeApplicationFunction();
    }
    else
    {
        Console.WriteLine("Invalid input. Please try again.");
    }

    wordCopyFunction();
    wordPasteFunction();
    closeApplicationFunction();
    
  }

  /// <summary>
  /// Counts how many verbs are in the sentence. Also stores all the verbs in the sentence 
  /// </summary>
  public static int verbCount (Document doc)
  {
    int verbCount = 0;
    foreach (var tokenList in doc.TokensData)
    {
        foreach (var token in tokenList)
        {
            if (token.Tag == PartOfSpeech.VERB)
            {
                verbCount++;
            }
        }
    }
    return verbCount;
  }
  
  /// <summary>
  /// Counts how many nouns are in the sentence. Also stores all the nouns in the sentence
  /// </summary>
  public static int nounCount (Document doc)
  {
    int nounCount = 0;
    foreach (var tokenList in doc.TokensData)
    {
        foreach (var token in tokenList)
        {
            if (token.Tag == PartOfSpeech.NOUN)
            {
                nounCount++;
            }
        }
    }
    return nounCount;
  }

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
}

