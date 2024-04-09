using Catalyst;
using Mosaik.Core;
using Newtonsoft.Json;

namespace NLP;

public class Program {
  public static async Task Main() {
    Catalyst.Models.English.Register(); //You need to pre-register each language (and install the respective NuGet Packages)
    Storage.Current = new DiskStorage("catalyst-models");
    var nlp = await Pipeline.ForAsync(Language.English);
    var doc = new Document("Hey Valet. Copy and paste this text", Language.English);
    nlp.ProcessSingle(doc);
    Console.WriteLine(doc.ToJson());
    string prettyJson = JsonConvert.SerializeObject(doc, Formatting.Indented);
    Console.WriteLine(prettyJson);
  }
}

