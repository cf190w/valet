﻿using Catalyst;
using Mosaik.Core;

namespace NLP;

public class Program {
  public static async Task Main() {
    Catalyst.Models.English.Register(); //You need to pre-register each language (and install the respective NuGet Packages)
    Storage.Current = new DiskStorage("catalyst-models");
    var nlp = await Pipeline.ForAsync(Language.English);
    var doc = new Document("The quick brown fox jumps over the lazy dog", Language.English);
    nlp.ProcessSingle(doc);
    Console.WriteLine(doc.ToJson());
  }
}

