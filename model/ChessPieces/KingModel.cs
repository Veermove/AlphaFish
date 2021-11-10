using System;

public class King : ChessPiece {
    private int posHor;
    private int posVer;
    public King(int givenPiece, int posHor, int posVer) : base(givenPiece) {
        this.posHor = posHor;
        this.posVer = posVer;
    }

    public override Boolean hasAccessToSquare((int, int) targetSquare, ChessBoardModel chessBoard) {
        return (posVer + 1, posHor + 1) == targetSquare ||
        (posVer + 1, posHor) == targetSquare ||
        (posVer + 1, posHor - 1) == targetSquare ||
        (posVer, posHor + 1) == targetSquare ||
        (posVer, posHor - 1) == targetSquare ||
        (posVer -1, posHor + 1) == targetSquare ||
        (posVer -1, posHor) == targetSquare ||
        (posVer -1, posHor -1) == targetSquare;
        ;
    }

    public override bool canAttackSquareWithKing((int, int) target, ChessBoardModel chessBoard)
    {
        return false;
    }

    public override (int, int) getPosition() {
        return (posHor, posVer);
    }

    public override void setPosition(int x, int y) {
        posHor = x;
        posVer = y;
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
        return 'K';
    }
}
