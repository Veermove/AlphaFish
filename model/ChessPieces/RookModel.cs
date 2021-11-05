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

    public override char getSignatureChar() {
        return 'R';
    }
}
