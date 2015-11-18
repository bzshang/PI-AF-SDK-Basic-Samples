# PI-AF-SDK-Basic-Samples
Self-contained and reproducible samples of basic operations using AF SDK.

Each example is a separate class and output to the Console.

## Solution contents

`PI-AF-SDK-Basic-Samples-Console` contains the Console application that runs the examples.

`ExamplesLibrary` contains the examples.

## Requirements

1. AF Client 2.5+
2. .NET Framework 4+
3. Visual Studio 2012+
4. AF Server and PI Data Archive

## Getting started

### Import the NuGreen database.

Many of the examples uses the NuGreen database. To use the NuGreen database, follow these steps:

1. Create an AF Database named "NuGreen".
2. Import the database from the provided NuGreen.xml via PI System Explorer>File>Import from File.
3. Verify that a root element "NuGreen" is created inside the NuGreen database.
4. Check in the changes if not done so already.

### AF Server and PI Data Archive Names

The code examples come with simple placeholders such as `<AFSERVER>` and `<PISERVER>`.

Please replace these with your server names before starting.

### Dependencies

Some examples depend on having run prior examples successfully. This is because these dependent examples require AF objects and/or PI Points to have been created previously. The comments in the code above each class will explicitly list out the dependencies of each example.

## Recommended learning path

A recommended learning path for going through the examples is as follows:

1. ConnectionExamples/AFConnectionExample
2. ConnectionExamples/PIConnectionExample
3. AFElementExamples/FindElementsExample
4. AFElementExamples/PartialLoadElementsExample
5. AFElementExamples/LoadElementsExample
6. AFAttributetExamples/FindAttributeWalkDownExample
7. AFAttributeExamples/FindAttributesByPathExample 
8. AFAttributeExamples/FindElementAttributesExample
9. ReadingValuesExamples/ReadFromAFExample
10. PIPointExamples/FindPIPointsExample
11. ReadingValuesExamples/ReadFromPIExample
12. BuildAFDatabaseExamples/BuildSimpleDatabaseExample
13. WriteValuesExample/WriteValuesUsingAFExample
14. PIPointExamples/CreatePIPointsExample
15. WriteValuesExample/WriteValuesUsingPIExample
16. AFEventFrameExamples/CreateEventFrameExample
17. AFEventFrameExamples/FindEventFramesExample
