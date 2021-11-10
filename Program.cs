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
            // GameModel game = ChessFenTranslator.positionFromString("k7/8/8/8/8/8/3R4/K6r w - - 0 1");
            GameModel game = ChessFenTranslator.positionFromString("1r1n1rk1/ppq2b2/2b3p1/2pB3p/2P4P/4P3/PBQ2PP1/1R3RK1 b - - 0 1");


            // game.displayGameInfo();
            game.startGame();

        }
    }
}
