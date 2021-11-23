using System;

namespace Zork
{

    [CommandClass]
    public static class ScoreCommand
    {
        [Command("SCORE", new string[] { "SCORE"})]

        public static void Score(Game game, CommandContext commandContext) => game.Output.WriteLine($"Your score would be {game.Player.Score} in {game.Player.Moves} move(s).");
    }
}