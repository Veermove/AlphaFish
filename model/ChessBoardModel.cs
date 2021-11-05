using System;

class ChessBoardModel {
    private ChessPiece[,] chessBoard;

    public ChessBoardModel(ChessPiece[,] ChessBoard) {
        this.chessBoard = ChessBoard;
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
