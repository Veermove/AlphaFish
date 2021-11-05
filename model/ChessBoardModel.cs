using System;
using System.Collections.Generic;

class ChessBoardModel {
    private ChessPiece[,] chessBoard;
    private List<ChessPiece> onBoard;

    public ChessBoardModel(ChessPiece[,] ChessBoard, List<ChessPiece> onBoard) {
        this.chessBoard = ChessBoard;
        this.onBoard = onBoard;
    }

    public ChessPiece getSquare(int x, int y) {
        return chessBoard[x, y];
    }

    public List<ChessPiece> FindAllPieces(Predicate<ChessPiece> match) {
        return onBoard.FindAll(match);
    }

    public void ShowBoard() {
        for (int i = 0; i < chessBoard.GetLength(0); i++) {
            for (int j = 0; j < chessBoard.GetLength(1); j++) {
                Console.Write("\u001b[1m");
                Console.Write(ChessPieceDictionary
                .ChessPieceIntToCharDict
                .GetValueOrDefault(chessBoard[j, i].getPieceAndCol(), ' '));
                Console.Write(" ");
            }
            Console.Write("\n");
        }
        Console.Write("\u001b[22m");
    }
}
