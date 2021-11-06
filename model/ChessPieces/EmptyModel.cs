using System;
public class Empty : ChessPiece {
    public Empty(int givenPiece) : base(givenPiece) {}

    public override Boolean hasAccessToSquare((int, int) targetSquare) {
        return false;
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
        return '`';
    }


}
