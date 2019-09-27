using System;

namespace SampleEventGenerator
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;
    using Microsoft.Azure.EventHubs;
    using Newtonsoft.Json;

    public class Program
    {
        private static EventHubClient eventHubClient;
        private const string EventHubConnectionString = "Event Hubs connection string";
        private const string EventHubName = "Event Hub name";

        public static void Main(string[] args)
        {
            MainAsync(args).GetAwaiter().GetResult();
        }

        private static async Task MainAsync(string[] args)
        {
            // Creates an EventHubsConnectionStringBuilder object from a the connection string, and sets the EntityPath.
            // Typically the connection string should have the Entity Path in it, but for the sake of this simple scenario
            // we are using the connection string from the namespace.
            var connectionStringBuilder = new EventHubsConnectionStringBuilder(EventHubConnectionString)
            {
                EntityPath = EventHubName
            };

            eventHubClient = EventHubClient.CreateFromConnectionString(connectionStringBuilder.ToString());

            await SendMessagesToEventHub(100);

            await eventHubClient.CloseAsync();

            Console.WriteLine("Press any key to exit.");
            Console.ReadLine();
        }

        // Creates an Event Hub client and sends 100 messages to the event hub.
        private static async Task SendMessagesToEventHub(int numMessagesToSend)
        {
            var rnd = new Random();

            for (var i = 0; i < numMessagesToSend; i++)
            {
                try
                {
                    // Generate SomeJson Data
                    Dictionary<string, string> points = new Dictionary<string, string>
                    {
                        { "Message", "Data...."},
                        { "Id", $"id-{i}" },
                        { "Code",$"code-{i}"}
                    };

                    string message = JsonConvert.SerializeObject(points, Formatting.Indented);


                    // Create Event
                    EventData eventData = new EventData(Encoding.UTF8.GetBytes(message));
                    // Set MetaDataProperties
                    eventData.Properties["eventType"] = "SampleEvent";
                    eventData.Properties["eventCode"] = "BlaBla";


                    await eventHubClient.SendAsync(eventData);
                    Console.WriteLine($"Sent message: '{message}'");

                }
                catch (Exception exception)
                {
                    Console.WriteLine($"{DateTime.Now} > Exception: {exception.Message}");
                }

                await Task.Delay(10);
            }

            Console.WriteLine($"{numMessagesToSend} messages sent.");
        }
    }
}
