#!/usr/bin/env python

import sys
import requests
import zipfile

current_os = sys.platform
model_url = "https://alphacephei.com/vosk/models/vosk-model-en-us-0.22.zip"
output_file = "output.zip"

def extract_and_write_file(zip_file_path, output_folder):
    with zipfile.ZipFile(zip_file_path, "r") as zip_ref:
        zip_ref.extractall(output_folder)

if current_os == "win32":
    subdir = "Valet_UI/stt"
    print("building for windows")
    response = requests.get(model_url)
    with open(output_file, "wb") as file:
        file.write(response.content)

elif current_os == "linux":
    subdir = "Valet_nix/stt"
    print("building for linux")
    response = requests.get(model_url)
    with open(output_file, "wb") as file:
        file.write(response.content)
    extract_and_write_file(output_file, subdir)

