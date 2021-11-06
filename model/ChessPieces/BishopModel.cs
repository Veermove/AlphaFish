using System;
public class Bishop : ChessPiece {
    private int posHor;
    private int posVer;
    public Bishop (int givenPiece, int posHor, int posVer) : base(givenPiece) {
        this.posHor = posHor;
        this.posVer = posVer;
    }

    private (int, int)[] offsets = {(-1, 1), (1, 1), (-1, -1), (1, -1)};

    public override Boolean hasAccessToSquare((int, int) targetSquare) {
        (int, int)[] branches = new (int, int)[4];
        branches[0] = (posVer, posHor);
        branches[1] = (posVer, posHor);
        branches[2] = (posVer, posHor);
        branches[3] = (posVer, posHor);
        for (int j = 0; j < 8; j++) {
            if (targetSquare == branches[0] || targetSquare == branches[1] ||
                targetSquare == branches[2] || targetSquare == branches[3]) {
                return true;
            } else {
                for (int i = 0; i < 4; i++ ) {
                    branches[i] = (branches[i].Item1 + offsets[i].Item1, branches[i].Item2 + offsets[i].Item2);
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
        return 'B';
    }
}
