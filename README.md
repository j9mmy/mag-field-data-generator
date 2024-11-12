# Magnetic Field Data Generator

This program is a simple console application that generates synthetic magnetic field measurement data for testing and simulation purposes. It creates random values representing magnetic field strength (in milliTesla, mT) over a user-defined number of samples, within a specified range. The generated data is saved in a CSV format, which can be used for data analysis, system testing, or validation of magnetic field measurement processing systems.

This was made as I needed to generate synthetic magnetic field measurement data for testing, without being constrained by a website-paywall (f.e. column limit). I thought I might as well share it for anyone interested.

## Features
- Generates random magnetic field strength data within a specified range.
- Allows the user to define the number of samples, minimum, and maximum magnetic field strength values.
- Saves the generated data in a CSV file (`results.csv`) located in the `data` folder.
- Provides progress updates during data generation.
- Logs any errors that occur during the process in an `error.log` file.

## Example

Here is an example of how the output might look in the `results.csv` file:

```
Sample,Y AXIS Results (mT)
0,1.9061805097451296
1,1.8894907807492927
2,2.469958115033466
3,1.540480873880225
...
```

## Requirements
- .NET 8.0 SDK or later

## Usage
1. **Download and Extract**
   - Download the latest release from the [Releases](https://github.com/j9mmy/mag-field-data-generator/releases) page.

2. **Running the application**
   1. Run the application by opening `program.exe`
   2. Enter the number of rows you want to generate.
   3. Enter the minimum magnetic field value.
   4. Enter the maximum magnetic field value.
   5. Let the program generate the data.
   6. The generated data will be saved to `data/results.csv`.
   
_Note: For separation purposes, keep the program housed inside it's own folder. Later, when running for the first time, a data folder will be created where the generated files will be stored._
