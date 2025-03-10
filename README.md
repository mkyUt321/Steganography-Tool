# Steganography-Tool
This project is a Steganography Tool that allows users to create and extract files with steganography.
And this project was created for self-learning.

## Features

- Hide files within other files.
- Extract hidden files from a given file.
- Supports multiple file types.

## Supported File Types for Extraction
The tool supports the following file types for extraction:

- PDF (`%PDF ... %%EOF`)
- HTML (`<html ... </html>`)
- JPG / JPEG (`FF D8 FF ... FF D9`)
- PNG (`‰PNG ... IEND®B`‚`)
- GIF (`GIF8 ... ;`)
- SVG (`<svg ... </svg>`)
- ZIP (`PK... ... PK...`)

If the file format is not supported, the extracted file will be saved with a `.bin` extension.

## How does it work?

### Hiding a File
The application reads the contents of both the cover file and the file to hide.
It then concatenates the byte arrays of these two files to create a single combined file.

<img width="540" alt="Image" src="https://github.com/user-attachments/assets/fff6f9a2-4ee8-48e0-a142-d9a7ad1e1e10" />

### Extracting Hidden Files
The application scans the combined file for known file signatures (markers) within the byte array. These markers help identify the start and end of the hidden files.

<img width="540" alt="Image" src="https://github.com/user-attachments/assets/878e17b5-beef-4556-98e5-a6a90f0d1a66" />

## Usage
The executable file is `SteganographyTool.exe`.

### Hiding a File

1. Open the application.
2. Navigate to the "Create Steganography" form.
3. Click the "Select Cover File" button to choose the file that will hide another file.
4. Click the "Select File to Hide" button to choose the file you want to hide.
5. Click the "Create" button to combine the files and save the resulting file.

### Extracting Hidden Files

1. Open the application.
2. Navigate to the "Extract Steganography" form.
3. Select the file from which you want to extract hidden files.
4. The application will display a list of detected hidden files.
5. Double-click on a file in the list to save it to your desired location.
6. Alternatively, click the "Download All" button to save all detected hidden files to a selected folder.
