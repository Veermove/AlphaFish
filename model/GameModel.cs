using System;

class GameModel {

    private String positionFEN;
    private ChessBoardModel ChessBoard;
    private Boolean whiteToMove;
    private Boolean WhiteCastleKingside;
    private Boolean WhiteCastleQueenside;
    private Boolean BlackCastleKingside;
    private Boolean BlackCastleQueenside;
    private ChessMoveModel enPassant;
    private int HalfmoveClock;
    private int FullmoveClock;

    public GameModel(String positionFEN, ChessBoardModel ChessBoard,
        Boolean whiteToMove,
        Boolean WhiteCastleKingside, Boolean WhiteCastleQueenside,
        Boolean BlackCastleKingside, Boolean BlackCastleQueenside,
        ChessMoveModel enPassant,
        int HalfmoveClock, int FullmoveClock)
    {
        this.positionFEN = positionFEN;
        this.ChessBoard = ChessBoard;
        this.whiteToMove = whiteToMove;
        this.WhiteCastleKingside = WhiteCastleKingside;
        this.WhiteCastleQueenside = WhiteCastleQueenside;
        this.BlackCastleKingside = BlackCastleQueenside;
        this.BlackCastleQueenside = BlackCastleQueenside;
        this.enPassant = enPassant;
        this.HalfmoveClock = HalfmoveClock;
        this.FullmoveClock = FullmoveClock;
    }

    public void displayGameInfo() {
        Console.WriteLine(positionFEN);
        Console.Write("Board: \n");
        ChessBoard.ShowBoard();
    }
}
