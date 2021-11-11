using System;
using System.Text.RegularExpressions;
namespace AlphaFish
{
    class Program
    {
        static void Main(string[] args)
        {
            ChessPieceDictionary.fillDictionary();
            // GameModel game = ChessFenTranslator.positionFromString("r6r/k7/7R/8/8/8/K7/R6R w - - 0 1");
            // GameModel game = ChessFenTranslator.positionFromString("k7/8/8/8/8/8/8/K2R1r2 w - - 0 1");
            // GameModel game = ChessFenTranslator.positionFromString("k7/8/8/8/8/8/3R3R/K2r4 w - - 0 1");
            // GameModel game = ChessFenTranslator.positionFromString("k7/4N1N1/8/5q2/8/4N1N1/2q5/K7 w - - 0 1");
            // GameModel game = ChessFenTranslator.positionFromString("1q2kr2/8/8/8/8/8/8/R3K2R w KQ - 0 1");
            GameModel game = ChessFenTranslator.positionFromString("3k4/8/8/8/8/3N4/8/r2K3R w - - 0 1");
            // GameModel game = ChessFenTranslator.positionFromString("1r1n1rk1/ppq2b2/2b3p1/2pB3p/2P4P/4P3/PBQ2PP1/1R3RK1 b - - 0 1");


            // game.displayGameInfo();
            game.startGame();

        }
    }
}
