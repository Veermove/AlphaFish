using System;

public class Queen : ChessPiece {
    private int posHor;
    private int posVer;
    public Queen(int givenPiece, int posHor, int posVer) : base(givenPiece) {
        this.posHor = posHor;
        this.posVer = posVer;
    }

    private (int, int)[] offsets = {(-1, 1), (1, 1), (-1, -1), (1, -1), (-1, 0), (1, 0), (0, -1), (0, 1)};

    public override Boolean hasAccessToSquare((int, int) targetSquare) {
        (int, int)[] branches = new (int, int)[8];
        for (int i = 0; i < 8; i++) {
            branches[i] = (posVer, posHor);
        }

        for (int j = 0; j < 8; j++) {

            for (int i = 0; i < 8; i++) {
                if (targetSquare == branches[i]) {
                    return true;
                }
            }
            for (int i = 0; i < 8; i++ ) {
                branches[i] = (branches[i].Item1 + offsets[i].Item1, branches[i].Item2 + offsets[i].Item2);
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
