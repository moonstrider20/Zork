using System;
namespace Zork
{
    [CommandClass]
    public static class DropCommand
    {
        [Command("DROP", "DROP")]
        public static void Drop(Game game, CommandContext commandContext)
        {
            if (game.Player.Inventory.Count == 0)
            {
                game.Output.WriteLine("You are empty handed.");
                return;
            }

            string theItem = game.inputString[1].Trim().ToUpper();
            
            foreach (var item in game.Player.Inventory)
            {
                if (item.Key.ToUpper() == theItem)
                {
                    game.Player.Inventory.Remove(item.Key);
                    game.Player.Location.Items.Add(item.Key, item.Value);
                    game.Output.WriteLine($"You dropped the {item.Key}");
                    game.Player.Score -= item.Value.Points;
                    break;
                }
                game.Output.WriteLine("You can't see any such thing.");
            }
        }
    }
}
