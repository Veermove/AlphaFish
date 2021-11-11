using System;

public class Pawn : ChessPiece {

    private int posHor;
    private int posVer;

    private Boolean hasMoved = false;
    public Pawn(int givenPiece, int posHor, int posVer) : base(givenPiece) {
        this.posHor = posHor;
        this.posVer = posVer;
    }

    public override (Boolean, Boolean) hasAccessToSquare((int, int) targetSquare, ChessBoardModel chessBoard) {
        if(!hasMoved) {
            //WTROKANMGJDK
            // CANT MOVE TO SPACES UP IF THERE IS A PIECE THERE
            return (hasAccessToSquareViaSpecialMove(targetSquare), false);
        }
        if ( targetSquare == (posVer + 1, posHor)) {
            return (true, false);
        } else if ( targetSquare == (posVer + 1, posHor + 1) || targetSquare == (posVer + 1, posHor - 1)) {
            if (chessBoard.getSquare(targetSquare).getColor() != this.getColor()) {
                return (true, true);
            } else {
                return (false, false);
            }
        }
        return (false, false);
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
