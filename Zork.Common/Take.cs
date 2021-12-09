using System;
namespace Zork
{
    [CommandClass]
    public static class TakeCommand
    {
        [Command("TAKE", new string[] { "TAKE" })]
        public static void Take(Game game, CommandContext commandContext)
        {
            if (game.Player.Location.Items.Count == 0)
            {
                game.Output.WriteLine("You can't see any such thing.");
                return;
            }
            
            if (game.Player.Inventory.Count == game.World.MaxInventory)
            {
                game.Output.WriteLine("You can't carry anymore items!");
                return;
            }

            string theItem = game.inputString[1].Trim().ToUpper();

            foreach (var item in game.Player.Location.Items)
            {
                if (item.Key.ToUpper() == theItem)
                {
                    game.Player.Inventory.Add(item.Key, item.Value);
                    game.Player.Location.Items.Remove(item.Key);
                    game.Output.WriteLine($"You took the {item.Key}");
                    game.Player.Score += item.Value.Points;
                    break;
                }
            }
        }
    }
}
