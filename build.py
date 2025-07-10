#!/usr/bin/python

import sys
import requests
import os
import zipfile
import subprocess

#wow
#such trolling

current_os = sys.platform
model_url = "https://alphacephei.com/vosk/models/vosk-model-small-en-us-0.15.zip"

if current_os == "win32":
    subdir = "Valet_UI"
    script_name = "vosk_stt.py"
    build_command = ["dotnet", "build", "-o", "stt"]
    print("Building for Windows...")
elif current_os == "linux":
    subdir = "Valet_nix"
    script_name = "vosk_stt.py"
    build_command = ["dotnet", "build", "-o", "stt"]
    print("Building for Linux...")
else:
    subdir = None
    script_name = None
    build_command = None
    print("Unsupported OS.")

if subdir and script_name and build_command:
    output_path = os.path.join(subdir, "vosk-model-small-en-us-0.15.zip")
    response = requests.get(model_url, stream=True)

    if response.status_code == 200:
        with open(output_path, "wb") as file:
            for chunk in response.iter_content(chunk_size=8192):
                file.write(chunk)
        print("ZIP file downloaded successfully.")

        # Extract the ZIP file to the stt subfolder
        extract_dir = os.path.join(subdir, "stt")
        with zipfile.ZipFile(output_path, "r") as zip_ref:
            zip_ref.extractall(extract_dir)
        print("ZIP file extracted successfully.")

        #delete the ZIP file
        os.remove(output_path)
        print("ZIP file deleted.")

        #define the new model name
        new_model_name = "vosk-model-small-en-us-0.15"  # Update with the desired model name

        #update vosk_stt.py
        script_path = os.path.join(extract_dir, script_name)
        with open(script_path, "r") as file:
            lines = file.readlines()

        updated_lines = []
        for line in lines:
            if line.startswith("model_path =") and "os.path.expanduser" not in line:
                updated_lines.append(f'model_path = "{new_model_name}"\n')
            else:
                updated_lines.append(line)

        with open(script_path, "w") as file:
            file.writelines(updated_lines)

        print(f"Updated {script_name} in {extract_dir}.")

        #navigate to the appropriate directory and run the build command
        os.chdir(subdir)
        print(f"Changed directory to {os.getcwd()}.")

        process = subprocess.Popen(build_command, stdout=subprocess.PIPE, stderr=subprocess.STDOUT, universal_newlines=True)

        #display real-time output
        for line in process.stdout:
            print(line, end="")

        process.wait()

        print("Build completed.")

    else:
        print("Failed to download ZIP file. Status code:", response.status_code)
else:
    print("ZIP file not downloaded. Unsupported OS.")

sys.exit()
