using System;

namespace Zork
{
    [CommandClass]
    public static class LookCommand
    {
        [Command("LOOK", new string[] { "LOOK", "L" })]
        public static void Look(Game game, CommandContext commandContext)
        {
            game.Output.WriteLine($"{game.Player.Location}\n{game.Player.Location.Description}");
            if (game.Player.Location.Items.Count != 0)
            {
                foreach (var item in game.Player.Location.Items)
                {
                    game.Output.WriteLine($"There is a {item.Key}");
                }
            }
        }
    }
}