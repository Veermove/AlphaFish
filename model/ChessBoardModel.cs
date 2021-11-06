using System;
using System.Collections.Generic;

public class ChessBoardModel {
    private ChessPiece[,] chessBoard;
    private List<ChessPiece> onBoard;

    private ChessPiece empty = new Empty(0);

    public ChessBoardModel(ChessPiece[,] ChessBoard, List<ChessPiece> onBoard) {
        this.chessBoard = ChessBoard;
        this.onBoard = onBoard;
    }

    public ChessPiece getSquare(int x, int y) {
        return chessBoard[x, y];
    }

    public ChessPiece getSquare((int, int) target) {
        return getSquare(target.Item1, target.Item2);
    }

    public Boolean isSquareOccupied(int x, int y) {
        if (x < 0 || x > 7 || y < 0 || y > 7) {
            return true;
        }
        return !(chessBoard[x, y] is Empty);
    }

    public Boolean isSquareOccupied((int, int) target) {
        return isSquareOccupied(target.Item1, target.Item2);
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
