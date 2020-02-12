using System;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.ServiceBus;

namespace Betabit.Training.Azure.ServiceBus.ConsoleApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var client = new QueueClient(Secrets.CONNECTIONSTRING, Secrets.QUEUENAME);

            Console.WriteLine("Enter 'q' (without quotes) and hit enter to quit");
            string messageBody = GetInput();

            while (!messageBody.Equals("q", StringComparison.OrdinalIgnoreCase))
            {
                var body = Encoding.UTF8.GetBytes(messageBody);
                await client.SendAsync(new Message(body));
                messageBody = GetInput();
            }
        }

        #region Private methods

        private static string GetInput()
        {
            Console.WriteLine("What would you like to send?");
            var messageBody = Console.ReadLine();
            return messageBody;
        }

        #endregion
    }
}