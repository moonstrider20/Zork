using System;

namespace Zork
{

    [CommandClass]
    public static class InventoryCommand
    {
        [Command("INVENTORY", new string[] { "INVENTORY", "I" })]

        public static void Inventroy(Game game, CommandContext commandContext)
        {
            if (game.Player.Inventory.Count == 0)
            {
                game.Output.WriteLine("You are empty handed.");
                return;
            }

            game.Output.WriteLine("You are carrying:");
            foreach( var item in game.Player.Inventory)
            {
                game.Output.WriteLine(item.Value.Description);
            }
        }
    }
}