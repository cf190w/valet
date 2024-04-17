#!/usr/bin/env python

import vosk
import sys
import os
import pyaudio

#Load the vosk model
model_path = ""
model_path = os.path.expanduser(model_path)
if not os.path.exists(model_path):
    print(f"Model path {model_path} does not exist.")
    sys.exit(1)
vosk_model = vosk.Model(model_path)

#Create a vosk recognizer 
recognizer = vosk.KaldiRecognizer(vosk_model, 16000)
p = pyaudio.PyAudio()
#set up data stream
stream = p.open(format=pyaudio.paInt16, channels=1, rate=16000, input=True, frames_per_buffer=8000)
print("listening...")
while True:
    data = stream.read(4000)
    if len(data) == 0:
        break
    if recognizer.AcceptWaveform(data):
        result = recognizer.Result()
        print(result)
