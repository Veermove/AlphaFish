using System;

public class Knight : ChessPiece {
    private int posHor;
    private int posVer;
    public Knight(int givenPiece, int posHor, int posVer) : base(givenPiece) {
        this.posHor = posHor;
        this.posVer = posVer;
    }

    (int, int)[] offests = {(1, 2), (-1, 2), (-1, -2), (1, -2), (2, 1), (2, -1), (-2, 1), (-2, -1)};

    public override Boolean hasAccessToSquare((int, int) targetSquare, ChessBoardModel chessBoard) {
        for (int i = 0; i < offests.GetLength(0); i++) {
            if ((posHor + offests[i].Item1, posVer + offests[i].Item2) == targetSquare) {
                return true;
            }
        }
        return false;
    }

    public override bool canAttackSquareWithKing((int, int) target, ChessBoardModel chessBoard)
    {
        return hasAccessToSquare(target, chessBoard);
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
        return 'N';
    }
}
