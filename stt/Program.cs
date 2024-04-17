using NAudio.Wave;
using Vosk;

class Program
{
    static void Main()
    {
        // Load the Vosk model
        string modelPath = @"C:\Users\coone\Downloads\vosk-model-en-us-0.22";
        using (var model = new Model(modelPath))
        using (var recognizer = new VoskRecognizer(model, 1))
        {
            // Set up the audio capture
            using (var capture = new WaveInEvent())
            {
                // Configure audio format
                var desiredFormat = new WaveFormat(16000, 1);
                capture.WaveFormat = desiredFormat;

                // Handle the audio data received event
                capture.DataAvailable += (sender, args) =>
                {
                    if (recognizer.AcceptWaveform(args.Buffer, args.BytesRecorded))
                    {
                        var result = recognizer.Result();
                        System.Console.WriteLine(result);
                    }
                };

                // Start capturing audio
                capture.StartRecording();

                // Wait for user input to stop capturing
                System.Console.WriteLine("Listening... Press any key to stop.");
                System.Console.ReadKey();

                // Stop capturing audio
                capture.StopRecording();
            }
        }
    }
}
