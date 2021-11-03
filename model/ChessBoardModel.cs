using System;

class ChessBoardModel {
    private int[,] chessBoard;

    public ChessBoardModel(int[,] ChessBoard) {
        this.chessBoard = ChessBoard;
    }

    public void ShowBoard() {
        for (int i = 0; i < chessBoard.GetLength(0); i++) {
            for (int j = 0; j < chessBoard.GetLength(1); j++) {
                Console.Write(ChessPieceDictionary
                .ChessPieceIntToCharDict
                .GetValueOrDefault(chessBoard[j, i], '`'));
            }
            Console.Write("\n");
        }
    }
}
