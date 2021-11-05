using System;
using System.Collections.Generic;

class GameModel {

    private String positionFEN;
    private ChessBoardModel ChessBoard;
    private Boolean whiteToMove;
    private Boolean WhiteCastleKingside;
    private Boolean WhiteCastleQueenside;
    private Boolean BlackCastleKingside;
    private Boolean BlackCastleQueenside;
    private ChessMove enPassant;
    private int HalfmoveClock;
    private int FullmoveClock;

    public GameModel(String positionFEN, ChessBoardModel ChessBoard,
        Boolean whiteToMove,
        Boolean WhiteCastleKingside, Boolean WhiteCastleQueenside,
        Boolean BlackCastleKingside, Boolean BlackCastleQueenside,
        ChessMove enPassant,
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

    public Boolean getColor() {
        return whiteToMove;
    }
    public void startGame() {
        while (true) {
            displayGameInfo();
            String moveInput = Console.ReadLine();
            ChessMove move = new ChessMove(moveInput);
            move.isMoveLegal(this);
            // Console.WriteLine(move.isMoveOfCorrectForm());
            // if (!move.isMoveLegal(this) || !move.isMoveOfCorrectForm()) {
            //     continue;
            // }
            // ChessBoard.makeMove(move);
            // String fen = ChessFenTranslator.stringFromPosition(this);
            // updateGameState();
            break;
        }
    }

    public ChessBoardModel getChessBoard() {
        return ChessBoard;
    }


    public void displayGameInfo() {
        Console.Write("\u001b[1J");
        Console.Write("\u001b[H");
        Console.Write("FEN string: \n");
        Console.Write("\u001b[34m");
        Console.WriteLine(positionFEN);
        Console.Write("\u001b[31m");
        Console.Write("Board: \n");
        Console.Write("\u001b[37m");
        ChessBoard.ShowBoard();
        if (whiteToMove) {
            Console.Write("\u001b[37;40m");
            Console.Write("White to play\n");
        } else {
            Console.Write("\u001b[30;47m");
            Console.Write("Black to play\n");
        }
        Console.Write("\u001b[0m");
        Console.Write("\u001b[39m");

    }
}
