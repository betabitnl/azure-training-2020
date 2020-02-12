using System;
using System.Threading;
using Microsoft.ApplicationInsights;
using Microsoft.ApplicationInsights.Extensibility;

namespace Betabit.Training.Azure.ApplicationInsights.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            int zero = 1 - 1;
            var random = new Random();

            // Create a TelemetryClient with the instrumentation key to track information in Application Insights
            var telemetryClient = new TelemetryClient(new TelemetryConfiguration("<YOUR-INSTRUMENTATION-KEY>"));
            for (int i = 0; i < 50; i++)
            {
                try
                {
                    // Divide by zero
                    var answer = 12 / zero;
                }
                catch (Exception ex)
                {
                    // So we get an Exception we can track using Application Insights
                    telemetryClient.TrackException(ex);
                    Console.WriteLine(ex.Message);
                }
                Thread.Sleep(random.Next(500, 2500));
            }
            Console.WriteLine("Aaaand, we're done!");
        }
    }
}
