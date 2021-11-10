using System;
public class Empty : ChessPiece {
    public Empty(int givenPiece) : base(givenPiece) {}

    public override Boolean hasAccessToSquare((int, int) targetSquare, ChessBoardModel chessBoard) {
        return false;
    }
    public override bool isOnRankOrFile(char rankOrFile)
    {
        return false;
    }

    public override bool canAttackSquareWithKing((int, int) target, ChessBoardModel chessBoard)
    {
        throw new NotImplementedException();
    }

    public override (int, int) getPosition() {
        return (-1, -1);
    }

    public override void setPosition(int x, int y) {
        return;
    }

    public override char getSignatureChar() {
        return '`';
    }


}
