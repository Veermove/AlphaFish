using System;

public class Queen : ChessPiece {
    private int posHor;
    private int posVer;
    public Queen(int givenPiece, int posHor, int posVer) : base(givenPiece) {
        this.posHor = posHor;
        this.posVer = posVer;
    }

    private (int, int)[] offsets = {(-1, 1), (1, 1), (-1, -1), (1, -1), (-1, 0), (1, 0), (0, -1), (0, 1)};

    public override Boolean hasAccessToSquare((int,int) targetSquare, ChessBoardModel chessBoard) {
        (int, int, Boolean)[] branches = new (int, int, Boolean)[8];
        for (int i = 0; i < 8; i++) {
            branches[i] = (posVer + offsets[i].Item1, posHor + offsets[i].Item2, true);
        }
        (int, int, Boolean) target = (targetSquare.Item1, targetSquare.Item2, true);

        for (int j = 0; j < 8; j++) {
            for (int i = 0; i < 8; i++) {
                if (target == branches[i]) {
                    return true;
                }
                if (branches[i].Item3) {
                    branches[i] = (branches[i].Item1 + offsets[i].Item1, branches[i].Item2 + offsets[i].Item2, branches[i].Item3);
                    if (chessBoard.isSquareOccupied(branches[i].Item1, branches[i].Item2)) {
                        branches[i].Item3 = false;
                    }
                }
            }
        }
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
        return 'Q';
    }
}
