using System;
using Zork;

string[] responses = new string[]
{
    "Good day.",
    "Nice weather we've been having lately.",
    "Nice to see you."
};

var command = new Command("HELLO", new string[] { "HELLO", "HI", "HOWDY" },
    (game, commandContext) =>
    {
        string selectResponse = responses[Game.Random.Next(responses.Length)];
    });

Game.Instance.CommandManger.AddCommand(command);
