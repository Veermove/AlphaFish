using System.Collections.Generic;
class ChessPieceDictionary {
    public static Dictionary<char, int> ChessPiecesCharToIntDict;
    public static Dictionary<int, char> ChessPieceIntToCharDict;

    public static void fillDictionary() {
        ChessPiecesCharToIntDict = new Dictionary<char, int>();
        ChessPieceIntToCharDict = new Dictionary<int, char>();
        ChessPiecesCharToIntDict.Add('k', 17);
        ChessPiecesCharToIntDict.Add('q', 18);
        ChessPiecesCharToIntDict.Add('r', 19);
        ChessPiecesCharToIntDict.Add('b', 20);
        ChessPiecesCharToIntDict.Add('n', 21);
        ChessPiecesCharToIntDict.Add('p', 22);
        ChessPiecesCharToIntDict.Add('K', 9);
        ChessPiecesCharToIntDict.Add('Q', 10);
        ChessPiecesCharToIntDict.Add('R', 11);
        ChessPiecesCharToIntDict.Add('B', 12);
        ChessPiecesCharToIntDict.Add('N', 13);
        ChessPiecesCharToIntDict.Add('P', 14);

        ChessPieceIntToCharDict.Add(17, 'k');
        ChessPieceIntToCharDict.Add(18, 'q');
        ChessPieceIntToCharDict.Add(19, 'r');
        ChessPieceIntToCharDict.Add(20, 'b');
        ChessPieceIntToCharDict.Add(21, 'n');
        ChessPieceIntToCharDict.Add(22, 'p');
        ChessPieceIntToCharDict.Add(9, 'K');
        ChessPieceIntToCharDict.Add(10, 'Q');
        ChessPieceIntToCharDict.Add(11, 'R');
        ChessPieceIntToCharDict.Add(12, 'B');
        ChessPieceIntToCharDict.Add(13, 'N');
        ChessPieceIntToCharDict.Add(14, 'P');
    }

}
