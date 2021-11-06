using System;
public abstract class ChessPiece
{
    public const int None = 0;
    public const int King = 1;
    public const int Queen = 2;
    public const int Rook = 3;
    public const int Bishop = 4;
    public const int Knight = 5;
    public const int Pawn = 6;

    public const int White = 8;
    public const int Black = 16;

    private int color;
    private int piece;
    private int pieceOfColor;

    public ChessPiece(int givenPiece) {
        if (givenPiece == 0) {
            color = 0;
            piece = 0;
            pieceOfColor = 0;
        }
        else if (givenPiece > 16) {
            this.color = Black;
            this.piece = givenPiece - Black;
        } else {
            this.color = White;
            this.piece = givenPiece - White;
        }
        this.pieceOfColor = givenPiece;
    }

    // ---->> (posHor, posVer) <<----
    public abstract Boolean hasAccessToSquare((int,int) target);
    public abstract Boolean isOnRankOrFile(Char rankOrFile);
    public abstract char getSignatureChar();

    public int getColor() {
        return color;
    }

    public int getPieceAndCol() {
        return pieceOfColor;
    }

}
