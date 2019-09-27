# Readme

> Note: Heavily inspired/based on/copied from [SampleSender](https://github.com/Azure/azure-event-hubs/blob/master/samples/DotNet/Microsoft.Azure.EventHubs/SampleSender/readme.md)

## Prerequisites

* [Microsoft Visual Studio 2015 or 2017](http://www.visualstudio.com).
* [.NET Core Visual Studio 2015 or 2017 tools](http://www.microsoft.com/net/core).
* An Azure subscription.
* An event hub namespace and an event hub.

## Run the sample

To run the sample, follow these steps:

1. Clone or download this GitHub repo.
2. [Create an Event Hubs namespace and an event hub](https://docs.microsoft.com/azure/event-hubs/event-hubs-create).
3. In Visual Studio, select **File**, then **Open Project/Soultion**. 
4. Load the SampleEventGenerator.sln solution file into Visual Studio.
5. Add the [Microsoft.Azure.EventHubs](https://www.nuget.org/packages/Microsoft.Azure.EventHubs/) NuGet package to the project.
6. In Program.cs, replace the placeholders in brackets with the proper values that were obtained when creating the event hub. Make sure that the `Event Hubs connection string` is the namespace-level connection string, and not the event hub string:
    ```csharp
    private const string EhConnectionString = "Event Hubs connection string";
    private const string EhEntityPath = "Event Hub name";
    ```
7. Run the program, and ensure that there are no errors.
