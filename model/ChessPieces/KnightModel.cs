using System;

public class Knight : ChessPiece {
    private int posHor;
    private int posVer;
    public Knight(int givenPiece, int posHor, int posVer) : base(givenPiece) {
        this.posHor = posHor;
        this.posVer = posVer;
    }

    public override Boolean hasAccessToSquare((int, int) targetSquare) {
        return (posVer - 1, posHor + 2) == targetSquare ||
        (posVer + 1, posHor + 2) == targetSquare ||
        (posVer - 1, posHor - 2) == targetSquare ||
        (posVer + 1, posHor - 2) == targetSquare ||
        (posVer + 2, posHor + 1) == targetSquare ||
        (posVer + 2, posHor - 1) == targetSquare ||
        (posVer - 2, posHor + 1) == targetSquare ||
        (posVer - 2, posHor - 1) == targetSquare;
    }

    public override bool isOnRankOrFile(char rankOrFile)
    {
        if (Char.IsDigit(rankOrFile)) {
            int givenP = BoardSquareTranslator.digitToInt(rankOrFile);
            return givenP == posVer;
        } else {
            int givenP = BoardSquareTranslator.letterToInt(rankOrFile);
            return givenP == posHor;
        }
    }


    public override char getSignatureChar() {
        return 'N';
    }
}
