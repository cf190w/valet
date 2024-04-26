using System;
using System.IO;
using System.Text;
using System.Threading;
using NAudio.Wave;
using Vosk;

class Program
{
    static void Main(string[] args)
    {
        // Load the vosk model
        string modelPath = "vosk-model-en-us-0.22";
        modelPath = Path.GetFullPath(modelPath);
        if (!Directory.Exists(modelPath))
        {
            Console.WriteLine($"Model path {modelPath} does not exist.");
            return;
        }

        if (File.Exists("C:/Users/riley/OneDrive/Desktop/stt/recognized_text.txt"))
        {
            // Clear the contents of the text file
            File.WriteAllText("C:/Users/riley/OneDrive/Desktop/stt/recognized_text.txt", string.Empty);
        }

        var voskModel = new Model(modelPath);

        // Create a vosk recognizer 
        var recognizer = new VoskRecognizer(voskModel, 16000);
        var waveIn = new WaveInEvent();

        // Set up data stream
        waveIn.WaveFormat = new WaveFormat(16000, 1);
        waveIn.DataAvailable += (sender, eventArgs) =>
        {
            if (eventArgs.BytesRecorded > 0)
            {
                recognizer.AcceptWaveform(eventArgs.Buffer, eventArgs.BytesRecorded);
            }
        };

        // Open a text file in append mode
        using (var textFile = new StreamWriter("C:/Users/riley/OneDrive/Desktop/stt/recognized_text.txt", true, Encoding.UTF8))
        {
            Console.WriteLine("listening...");
            waveIn.StartRecording();
            try
            {
                while (true)
                {
                    var result = recognizer.Result();
                    var text = result;
                    Console.WriteLine(text);
                    textFile.WriteLine(text);  // Write recognized text to the text file

                    Thread.Sleep(5000); // Add a delay of 5 seconds
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
            finally
            {
                waveIn.StopRecording();
                recognizer.Dispose();
                voskModel.Dispose();
            }
        }
    }
}