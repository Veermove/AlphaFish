using System;
using System.Text.RegularExpressions;
namespace AlphaFish
{
    class Program
    {
        static void Main(string[] args)
        {
            ChessPieceDictionary.fillDictionary();
            // ChessPiece test = new Rook(12, 1, 1);
            // Console.WriteLine(test.hasAccessToSquare((1 ,0)));
            GameModel game = ChessFenTranslator.positionFromString("k7/8/1q6/1B2rNN1/1B5b/1B6/1Q6/K2R3R w - - 0 1");
            // game.displayGameInfo();
            game.startGame();

        }
    }
}
