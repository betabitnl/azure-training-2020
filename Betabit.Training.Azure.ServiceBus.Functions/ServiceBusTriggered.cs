using System.IO;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;

namespace Betabit.Training.Azure.ServiceBus.Functions
{
    public static class ServiceBusTriggered
    {
        #region Constants
        
        const string QUEUE_NAME = "<YOUR-QUEUE-NAME>";

        #endregion

        [FunctionName(nameof(ServiceBusTriggered))]
        public static async Task Run(
            [ServiceBusTrigger(QUEUE_NAME, Connection = "servicebusConnectionstring")]string myQueueItem,
            [Blob("output/{sys.randguid}.txt", FileAccess.Write, Connection = "storageConnectionstring")] Stream stream,
            ILogger log)
        {
            using var writer = new StreamWriter(stream);
            await writer.WriteLineAsync(myQueueItem);
        }
    }
}