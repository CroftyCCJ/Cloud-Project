using Microsoft.WindowsAzure.Storage.Queue;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebRole1.Services
{
    public class QueueService
    {
        public QueueService()
        {

        }

        public async void AddMessageToQueue(CloudQueue queue, string query)
        {

            bool createdQueue = await queue.CreateIfNotExistsAsync();
            if (createdQueue)
            {
                Console.WriteLine("The queue was created.");
            }

            CloudQueueMessage message = new CloudQueueMessage(query);

            await queue.AddMessageAsync(message);
        }

        public async Task<string> GetMessageFromQueue(CloudQueue outqueue)
        {
            bool exists = await outqueue.ExistsAsync();

            if (exists)
            {
                CloudQueueMessage retrievedMessage;

                do
                {
                    retrievedMessage = await outqueue.GetMessageAsync();
                } while (retrievedMessage == null);

                if (retrievedMessage != null)
                {
                    string theMessage = retrievedMessage.AsString;
                    await outqueue.DeleteMessageAsync(retrievedMessage);
                    return theMessage;
                }
                else
                {
                    return "null";
                }
            }
            else
            {
                return "No queue";
            }
        }
    }
}