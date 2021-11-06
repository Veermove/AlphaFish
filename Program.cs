using System;
using System.Text.RegularExpressions;
namespace AlphaFish
{
    class Program
    {
        static void Main(string[] args)
        {
            ChessPieceDictionary.fillDictionary();
            GameModel game = ChessFenTranslator.positionFromString("r6r/k7/7R/8/8/8/K7/R6R w - - 0 1");
            // game.displayGameInfo();
            game.startGame();

        }
    }
}
