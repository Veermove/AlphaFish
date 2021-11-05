using System;
using System.Text.RegularExpressions;

class ChessMove {
    private String move;
    private Boolean isCapture;

    private int color;

    private int movingPiece;
    private (int, int) targetSquare;
    private (int, int) currentSquare;
    private static Regex move_Correctnes = new Regex("[abcdefghQKBNR]{0,1}[abcdefghx]{0,1}[abcdefgh][12345678]");
    private static Regex move_boardSquare = new Regex("^[abcdefgh][12345678]$");

    public ChessMove(String move) {
        this.move = move;
    }

    public Boolean isMoveLegal(GameModel game) {
        color = game.getColor() ? ChessPiece.White : ChessPiece.Black;

        prepereMove();
        return false;
    }

    public void prepereMove() {
        isCapture = move.Contains('x');
        Char[] moveChar = move.ToCharArray();
        if (move.Length == 2) {
            movingPiece = ChessPiece.Pawn;
        } else {
            movingPiece = ChessPieceDictionary.ChessPiecesCharToIntDict.GetValueOrDefault(moveChar[0], 0) - ChessPiece.White;
        }
        targetSquare.Item1 = (int)moveChar[moveChar.GetLength(0) - 2] - 97;
        targetSquare.Item2 = (int)moveChar[moveChar.GetLength(0) - 1] - 49;
    }

    public Boolean isMoveOfCorrectForm() {
        if (move.Equals("O-O") || move.Equals("O-O-O")) {
            return true;
        }
        return move_Correctnes.IsMatch(move);
    }

}
