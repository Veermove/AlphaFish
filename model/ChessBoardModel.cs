using System;
using System.Collections.Generic;

public class ChessBoardModel {
    private ChessPiece[,] chessBoard;
    private List<ChessPiece> onBoard;

    private ChessPiece whiteKing;
    private ChessPiece blackKing;

    public ChessBoardModel(ChessPiece[,] ChessBoard, List<ChessPiece> onBoard) {
        this.chessBoard = ChessBoard;
        this.onBoard = onBoard;

        this.whiteKing = onBoard.Find(x => x.getColor() == 8
            && x.getSignatureChar() == 'K');

        this.blackKing = onBoard.Find(x => x.getColor() == 16
            && x.getSignatureChar() == 'K');
    }

    public ChessPiece getWhiteKing() {
        return whiteKing;
    }

    public ChessPiece getBlackKing() {
        return blackKing;
    }

    public List<ChessPiece> toList() {
        return onBoard;
    }

    public ChessPiece getSquare(int x, int y) {
        return chessBoard[x, 7 - y];
    }

    public ChessPiece getSquare((int, int) target) {
        return getSquare(target.Item1, target.Item2);
    }


    public void setSquare(int x, int y, ChessPiece move) {
        chessBoard[x, 7 - y] = move;
    }

    public ChessBoardModel setTempSquare((int, int) target, ChessPiece move) {
        setSquare(target.Item1, target.Item2, move);
        return this;
    }

    public void setSquare((int, int) target, ChessPiece move) {
        setSquare(target.Item1, target.Item2, move);
    }

    public Boolean isSquareOccupied(int x, int y) {
        if (x < 0 || x > 7 || y < 0 || y > 7) {
            return true;
        }
        return !(chessBoard[x, 7 - y] is Empty);
    }

    public Boolean isSquareOccupied((int, int) target) {
        return isSquareOccupied(target.Item1, target.Item2);
    }

    public List<ChessPiece> FindAllPieces(Predicate<ChessPiece> match) {
        return onBoard.FindAll(match);
    }

    public void ShowBoard() {
        int row = 0;
        Console.WriteLine("+---+---+---+---+---+---+---+---+");

        for (int i = 0; i < 16; i++) {
            if (i % 2 == 1) {
                Console.WriteLine("+---+---+---+---+---+---+---+---+");
            } else {
                Console.Write("|");
                for (int j = 0; j < 8; j++) {
                    Console.Write(" ");
                    Console.Write(ChessPieceDictionary
                        .ChessPieceIntToCharDict
                        .GetValueOrDefault(chessBoard[j, row].getPieceAndCol(), ' '));
                    Console.Write(" |");
                }
                Console.Write(" " + (8 - row) + "\n");
                row++;
            }
        }
        Console.Write("  a   b   c   d   e   f   g   h   \n");
    }
}
