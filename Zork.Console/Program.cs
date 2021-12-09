using System;

namespace Zork
{
    class Program
    {
        static void Main(string[] args)
        {
            const string defaultGameFilename = "Zork.json";
            string gameFilename = args.Length > 0 ? args[(int)CommandLineArguments.GameFilename] : defaultGameFilename;

            ConsoleOutputService output = new ConsoleOutputService();
            ConsoleInputService input = new ConsoleInputService();
            Game.StartFromFile(gameFilename,input, output);
            Game.Instance.CommandManager.PerformCommand(Game.Instance, "LOOK");
            
            while (Game.Instance.IsRunning)
            {
                output.Write("> ");
                input.GetInput();
            }
            
            output.WriteLine("Thank you for playing!");
        }

        private enum CommandLineArguments
        {
            GameFilename = 0
        }
    }
}