using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CrazyPassenger.ConsoleApp
{
    internal class Program
    {
        private const int Passengers = 100;

        private static void Main(string[] args)
        {
            int simulationToRuns = args.Length > 0 ? int.Parse(args[0]) : 1;
            int lastPassengerGotOwnSeatCount;

            List<Task<bool>> simulationTasks = new List<Task<bool>>();
            int noOfSimulationsCompleted = 0;

            for (int i = 1; i <= simulationToRuns; i++)
            {
                var t = Task<bool>.Factory.StartNew(() =>
                {
                    var simulation = new Simulation(Passengers, new AirPlaneFactory()); // CREATE SIMULATION
                    simulation.Setup();                                                 // SETUP SIMULATION

                    return simulation.Run();                                            // RUN SIMULATION AND RETURN TRUE IF LAST PASSENGER GOT ASSIGNED SEAT
                });

                //Update console when simulation completes
                t.ContinueWith((t1) =>
                {
                    Interlocked.Increment(ref noOfSimulationsCompleted);
                    Console.Clear();
                    Console.WriteLine("Completed Simulations = " + noOfSimulationsCompleted);
                }, TaskContinuationOptions.OnlyOnRanToCompletion);

                simulationTasks.Add(t);
            }

            Task.WaitAll(simulationTasks.ToArray());                                    // WAIT FOR ALL SIMULATIONS TO COMPLETE

            lastPassengerGotOwnSeatCount = simulationTasks.Count(x => x.Result);


            Console.WriteLine("\n\n\n=================== Total Simulations Run " + simulationToRuns + " ============================");
            Console.WriteLine("\nSimulations where last passenger got own seat = " + lastPassengerGotOwnSeatCount);
            Console.WriteLine("\nProbability for last passenger to get own seat = " +
                              lastPassengerGotOwnSeatCount/(decimal) simulationToRuns);
            Console.WriteLine("\n===========================================================");
        }
    }
}
