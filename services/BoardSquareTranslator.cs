using System;

class BoardSquareTranslator {

    public static (int, int) ToPair(String square) {
        if (square.Length > 2) {
            throw new InvalidArgumentException();
        }
        Char[] move = square.ToCharArray();
        return ToPair(move[0], move[1]);
    }

    public static (int, int) ToPair(char letterIn, char DigitIn) {
        int letterTranslated = (int)letterIn - 97;
        int digitTranslated = (int)DigitIn - 48 - 1;
        return (letterTranslated, digitTranslated);
    }

    public static int letterToInt(char letter) {
        return (int)letter - 97;
    }

    public static int digitToInt(char digit) {
        return (int)digit - 48 - 1;
    }

    public static String toSquare(int x, int y) {
        Char a = (Char)(x + 97);
        Char b = (Char)(y + 49);
        return String.Format("{0}{1}", a, b);
    }

    public static String toSquare((int, int) a) {
        return toSquare(a.Item1, a.Item2);
    }
}
