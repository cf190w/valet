#!/usr/bin/python

import sys
import requests
import os


current_os = sys.platform
model_url = "https://alphacephei.com/vosk/models/vosk-model-small-en-us-0.15.zip"

if current_os == "win32":
    subdir = "Valet_UI/stt"
    print("Building for Windows...")
elif current_os == "linux":
    subdir = "Valet_nix/stt"
    print("Building for Linux...")
else:
    subdir = None
    print("Unsupported OS.")

if subdir:
    output_path = os.path.join(subdir, "vosk-model-small-en-us-0.15.zip")
    response = requests.get(model_url, stream=True)

    if response.status_code == 200:
        with open(output_path, "wb") as file:
            for chunk in response.iter_content(chunk_size=8192):
                file.write(chunk)
        print("ZIP file downloaded successfully.")
    else:
        print("Failed to download ZIP file. Status code:", response.status_code)
else:
    print("ZIP file not downloaded. Unsupported OS.")

sys.exit()
