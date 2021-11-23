namespace Zork
{

    [CommandClass]
    public static class RewardCommand
    {
        [Command("REWARD", new string[] { "REWARD" })]

        public static void Reward(Game game, CommandContext commandContext)
        {
            game.Player.Score++;
            game.Output.WriteLine("Rewarding yourself are you?.");
        }
    }
}