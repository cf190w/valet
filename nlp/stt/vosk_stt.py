#!/usr/bin/env python

import vosk
import os
import pyaudio
import json
import logging
import sys

#Load the vosk model
model_path = "vosk-model-en-us-0.22"
vosk.SetLogLevel(-1)
logging.getLogger('pyaudio').setLevel(logging.WARNING)
model_path = os.path.expanduser(model_path)
if not os.path.exists(model_path):
    print(f"Model path {model_path} does not exist.")
    # Check if the text file exists

# Create a vosk recognizer
vosk_model = vosk.Model(model_path)
recognizer = vosk.KaldiRecognizer(vosk_model, 16000)
p = pyaudio.PyAudio()

# Set up data stream
stream = p.open(format=pyaudio.paInt16, channels=1, rate=16000, input=True, frames_per_buffer=8000)

# Listen for audio and send recognized text through the pipe
print("listening...")
while True:
    data = stream.read(8000)
    if len(data) == 0:
        break
    if recognizer.AcceptWaveform(data):
        result = json.loads(recognizer.Result())
        text = result["text"]
        print(text)
        sys.stdout.flush()
