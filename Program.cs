using System;

namespace AlphaFish
{
    class Program
    {
        static void Main(string[] args)
        {
            ChessPieceDictionary.fillDictionary();
            // Console.Write(ChessPieceDictionary
            //         .ChessPieceIntToCharDict
            //         .GetValueOrDefault('K', 0));

            GameModel game = ChessFenTranslator.positionFromString("rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR w KQkq - 0 1");
            game.displayGameInfo();
        }
    }
}
