using System;
using Zork;

namespace Zork
{
    internal class ConsoleInputService : IInputService
    {
        public event EventHandler<string> InputReceived;
        //public event EventHandler<string> InputResponse;

        public void GetInput()
        {
            string inputString = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(inputString) == false)
            {
                InputReceived?.Invoke(this, inputString);
            }
        }

        public string ReadLine()
        {
            //GetInput();
            string inputString = Console.ReadLine().Trim().ToUpper();
            return inputString;
        }

        public string GetResponse(string inputString)
        {
            string response = inputString;
            return response;
        }
    }
}
