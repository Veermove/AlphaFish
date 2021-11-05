using System;

public class King : ChessPiece {
    private int posHor;
    private int posVer;
    public King(int givenPiece, int posHor, int posVer) : base(givenPiece) {
        this.posHor = posHor;
        this.posVer = posVer;
    }

    public override Boolean hasAccessToSquare((int, int) targetSquare) {
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

    public override char getSignatureChar() {
        return 'K';
    }
}
