using System;

public class Pawn : ChessPiece {

    private int posHor;
    private int posVer;

    private Boolean hasMoved = false;
    public Pawn(int givenPiece, int posHor, int posVer) : base(givenPiece) {
        this.posHor = posHor;
        this.posVer = posVer;
    }

    public override Boolean hasAccessToSquare((int, int) targetSquare, ChessBoardModel chessBoard) {
        if(!hasMoved) {
            return hasAccessToSquareViaSpecialMove(targetSquare);
        }
        return targetSquare == (posVer + 1, posHor)
            || targetSquare == (posVer + 1, posHor + 1)
            || targetSquare == (posVer + 1, posHor - 1);
    }

    public override bool canAttackSquareWithKing((int, int) target, ChessBoardModel chessBoard)
    {
       return ( target == (posVer + 1, posHor + 1) || target == (posVer + 1, posHor - 1) )
            &&  chessBoard.getSquare(target.Item1, target.Item2)
                .Equals(this.getColor() == ChessPiece.White ? chessBoard.getBlackKing() : chessBoard.getWhiteKing());
    }

    private Boolean hasAccessToSquareViaSpecialMove((int, int) targetSquare) {
        // Console.WriteLine("special move!");
        return targetSquare == (posVer + 2, posHor);
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
        throw new NotImplementedException();
    }

    public override char getSignatureChar() {
        return 'P';
    }
}
