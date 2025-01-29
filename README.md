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

## How does it work?

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
