using System;
using System.Text.RegularExpressions;
namespace AlphaFish
{
    class Program
    {
        static void Main(string[] args)
        {
            ChessPieceDictionary.fillDictionary();
            GameModel game = ChessFenTranslator.positionFromString("rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR w KQkq - 0 1");
            game.displayGameInfo();
            // game.startGame();

        }
    }
}
