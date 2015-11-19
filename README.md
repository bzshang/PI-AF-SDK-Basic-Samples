# PI-AF-SDK-Basic-Samples
This repository provides self-contained and reproducible samples of basic operations using AF SDK.

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

Some examples depend on having run prior examples successfully. This is because these dependent examples require AF objects and/or PI Points to have been created by the prior examples. The comments in the code above each class will explicitly list out the dependencies of each example. For instance,

```
    /// <prerequisite-examples>
    /// BuildSimpleDatabaseExample, CreateEventFramesExample
    /// </prerequisite-examples>
```    

###

To run a particular example, simply instantiate a new object from the example type and call its Run() method.

To run the AFConnectionExample, for instance, use:
```csharp
IExample example = new AFConnectionExample();
example.Run()
```

## Recommended learning path

A recommended learning path for going through the examples is as follows:

### 1.0 Connecting

- [ConnectionExamples/AFConnectionExample](/ExamplesLibrary/ConnectionExamples/AFConnectionExample.cs)
- [ConnectionExamples/PIConnectionExample](/ExamplesLibrary/ConnectionExamples/PIConnectionExample.cs)

### 2.0 Finding and loading AF Elements

- [AFElementExamples/FindElementsExample](/ExamplesLibrary/ConnectionExamples/FindElementsExample.cs)
- [AFElementExamples/PartialLoadElementsExample](/ExamplesLibrary/ConnectionExamples/PartialLoadElementsExample.cs)
- [AFElementExamples/LoadElementsExample](/ExamplesLibrary/ConnectionExamples/LoadElementsExample.cs)
 
### 3.0 Finding AF attributes

- [AFAttributetExamples/FindAttributeWalkDownExample](/ExamplesLibrary/ConnectionExamples/FindAttributeWalkDownExample.cs)
- [AFAttributeExamples/FindAttributesByPathExample](/ExamplesLibrary/ConnectionExamples/FindAttributesByPathExample.cs)
- [AFAttributeExamples/FindElementAttributesExample](/ExamplesLibrary/ConnectionExamples/FindElementAttributesExample.cs)

### 4.0 Finding PIPoints

- [PIPointExamples/FindPIPointsExample](/ExamplesLibrary/ConnectionExamples/FindPIPointsExample.cs)

### 5.0 Reading values

- [ReadingValuesExamples/ReadFromAFExample](/ExamplesLibrary/ConnectionExamples/ReadFromAFExample.cs)
- [ReadingValuesExamples/ReadFromPIExample](/ExamplesLibrary/ConnectionExamples/ReadFromPIExample.cs)

### 6.0 Creating AF objects

- [BuildAFDatabaseExamples/BuildSimpleDatabaseExample](/ExamplesLibrary/ConnectionExamples/BuildSimpleDatabaseExample.cs)

### 7.0 Create PI Points 

- [PIPointExamples/CreatePIPointsExample](/ExamplesLibrary/ConnectionExamples/CreatePIPointsExample.cs)

### 8.0 Writing values

- [WriteValuesExample/WriteValuesUsingAFExample](/ExamplesLibrary/ConnectionExamples/WriteValuesUsingAFExample.cs)
- [WriteValuesExample/WriteValuesUsingPIExample](/ExamplesLibrary/ConnectionExamples/WriteValuesUsingPIExample.cs)

### 9.0 Event frames

- [AFEventFrameExamples/CreateEventFrameExample](/ExamplesLibrary/ConnectionExamples/CreateEventFrameExample.cs)
- [AFEventFrameExamples/FindEventFramesExample](/ExamplesLibrary/ConnectionExamples/FindEventFramesExample.cs)
