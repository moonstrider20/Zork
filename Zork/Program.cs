using System;

namespace Zork
{
    class Program
    {
        private static string Location => Rooms[locationColumn];

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Zork!");

            Commands command = Commands.UNKNOWN;
            while (command != Commands.QUIT)
            {
                Console.Write($"{Location}\n> ");
                command = ToCommand(Console.ReadLine().Trim());

                string outputString;
                switch(command)
                {
                    case Commands.LOOK:
                        outputString = ("A rubber mat saying 'Welcome to Zork!' lies by the door.");
                        break;
                    case Commands.NORTH:
                    case Commands.SOUTH:
                    case Commands.EAST:
                    case Commands.WEST:
                        outputString = Move(command) ? $"You moved {command}." : "The way is shut!";
                        break;
                    case Commands.QUIT:
                        outputString = ("Thank you for playing!");
                        break;
                    default:
                        outputString = ("Unknown command.");
                        break;
                }

                Console.WriteLine(outputString);
            }
        }

        private static Commands ToCommand(string commandString) => (Enum.TryParse<Commands>(commandString, true, out Commands result) ? result : Commands.UNKNOWN);

        private static bool Move(Commands command)
        {
            bool didMove = false;

            switch (command)
            {
                case Commands.NORTH:
                case Commands.SOUTH:
                    break;
                case Commands.EAST when locationColumn < Rooms.Length -1:
                    locationColumn++;
                    didMove = true;
                    break;
                case Commands.WEST when locationColumn > 0:
                    locationColumn--;
                    didMove = true;
                    break;
            }

            return didMove;
        }

        private static string[] Rooms = {"Forest", "West of House", "Behind House", "Clearing", "Canyon View"};
        private static int locationColumn = 1;
    }
}