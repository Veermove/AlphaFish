using System;
public class Empty : ChessPiece {
    public Empty(int givenPiece) : base(givenPiece) {}

    public override Boolean hasAccessToSquare((int, int) targetSquare) {
        return false;
    }

    public override char getSignatureChar() {
        return '`';
    }
}
