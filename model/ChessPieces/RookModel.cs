using System;

public class Rook : ChessPiece {
    private int posHor;
    private int posVer;
    public Rook(int givenPiece, int posHor, int posVer) : base(givenPiece) {
        this.posHor = posHor;
        this.posVer = posVer;
    }

    private (int, int)[] offsets = {(-1, 0), (1, 0), (0, -1), (0, 1)};

    public override Boolean hasAccessToSquare((int, int) targetSquare) {
        (int, int)[] branches = new (int, int)[4];
        for (int i = 0; i < branches.GetLength(0); i++) {
            branches[i] = (posHor, posVer);
        }
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
            // int givenP = (int)rankOrFile - 50 + 8;
            return givenP == posVer;
        } else {
            int givenP = BoardSquareTranslator.letterToInt(rankOrFile);
            // int givenP = (int)rankOrFile - 97;
            return givenP == posHor;
        }
    }

    public override char getSignatureChar() {
        return 'R';
    }
}
