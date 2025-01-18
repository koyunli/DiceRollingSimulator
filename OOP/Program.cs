// See https://aka.ms/new-console-template for more information


using System;

namespace DiceRollingSimulator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the dice throwing simulator!");

            // Get the number of rolls from the user
            Console.Write("How many dice rolls would you like to simulate? ");
            if (!int.TryParse(Console.ReadLine(), out int numberOfRolls) || numberOfRolls <= 0)
            {
                Console.WriteLine("Invalid input. Please enter a positive integer.");
                return;
            }

            // Create an instance of the DiceSimulator class
            DiceSimulator simulator = new DiceSimulator();

            // Get the results from the simulator
            int[] rollResults = simulator.SimulateRolls(numberOfRolls);

            // Display the results as a histogram
            Console.WriteLine("\nDICE ROLLING SIMULATION RESULTS");
            Console.WriteLine("Each \"*\" represents 1% of the total number of rolls.");
            Console.WriteLine($"Total number of rolls = {numberOfRolls}.\n");

            for (int i = 2; i <= 12; i++)
            {
                double percentage = (rollResults[i] / (double)numberOfRolls) * 100;
                int numStars = (int)Math.Round(percentage);
                Console.WriteLine($"{i}: {new string('*', numStars)}");
            }

            Console.WriteLine("\nThank you for using the dice throwing simulator. Goodbye!");
        }
    }

    class DiceSimulator
    {
        private Random random;

        public DiceSimulator()
        {
            random = new Random();
        }

        // Simulate rolling two dice for the specified number of rolls
        public int[] SimulateRolls(int numberOfRolls)
        {
            int[] rollCounts = new int[13]; // Indexes 2 through 12 will be used

            for (int i = 0; i < numberOfRolls; i++)
            {
                int roll1 = random.Next(1, 7); // Roll the first die
                int roll2 = random.Next(1, 7); // Roll the second die
                int sum = roll1 + roll2;

                rollCounts[sum]++;
            }

            return rollCounts;
        }
    }
}
