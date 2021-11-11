using System;

public class King : ChessPiece {
    private int posHor;
    private int posVer;
    public King(int givenPiece, int posHor, int posVer) : base(givenPiece) {
        this.posHor = posHor;
        this.posVer = posVer;
    }

     (int, int)[] offests = {(1, 1), (1, 0), (1, -1), (0, 1), (0, -1), (-1, 1), (-1, 0), (-1, -1)};

    public override (Boolean, Boolean) hasAccessToSquare((int, int) targetSquare, ChessBoardModel chessBoard) {
        for (int i = 0; i < offests.GetLength(0); i++) {

            int tempC = posHor + offests[i].Item1;
            int tempR = posVer + offests[i].Item2;
            if (targetSquare == (tempC, tempR)) {
                if (chessBoard.isSquareOccupied(targetSquare)) {
                    if (chessBoard.getSquare(targetSquare).getColor() != this.getColor()) {
                        return (true, true);
                    } else {
                        return (false, false);
                    }
                } else {
                    return (true, false);
                }
            }
        }
        return (false, false);
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
