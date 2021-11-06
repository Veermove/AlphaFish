using System;

public class Pawn : ChessPiece {

    private int posHor;
    private int posVer;

    private Boolean hasMoved = false;
    public Pawn(int givenPiece, int posHor, int posVer) : base(givenPiece) {
        this.posHor = posHor;
        this.posVer = posVer;
    }

    public override Boolean hasAccessToSquare((int, int) targetSquare) {
        if(!hasMoved) {
            return hasAccessToSquareViaSpecialMove(targetSquare);
        }
        return targetSquare == (posVer + 1, posHor);
    }

    private Boolean hasAccessToSquareViaSpecialMove((int, int) targetSquare) {
        // Console.WriteLine("special move!");
        return targetSquare == (posVer + 2, posHor);
    }

    public override bool isOnRankOrFile(char rankOrFile)
    {
        throw new NotImplementedException();
    }

    public override char getSignatureChar() {
        return 'P';
    }
}
