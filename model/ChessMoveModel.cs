using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;


class ChessMove {
    private String move;
    private Boolean isCapture;
    private ChessPiece movingPiece;
    private (int, int) targetSquare;
    private static Regex move_Correctnes = new Regex("[abcdefghQKBNR]{0,1}[abcdefghx]{0,1}[abcdefgh][12345678]");
    private static Regex move_boardSquare = new Regex("^[abcdefgh][12345678]$");

    private int color;
    char signature;

    public ChessMove(String move) {
        this.move = move;
    }

    public Boolean isMoveLegal(GameModel game) {
        color = game.getColor() ? ChessPiece.White : ChessPiece.Black;
        prepareMove();
        List<ChessPiece> possible = game.getChessBoard().FindAllPieces(x => {
            return x.getColor() == color && x.getSignatureChar() == signature;
        });
        possible = possible.FindAll(x => x.hasAccessToSquare(targetSquare));

        foreach (ChessPiece item in possible)
        {
            Console.WriteLine(item.getSignatureChar() + " " + item);
        }


        return false;
    }

    public void prepareMove() {
        isCapture = move.Contains('x');
        Char[] moveChar = move.ToCharArray();
        if (moveChar.GetLength(0) == 2) {
            signature = 'P';
        } else if (moveChar.GetLength(0) == 3) {
            signature = moveChar[0];
        } else {
            if (!Char.IsUpper(moveChar[0])) {
                signature = 'P';
            } else {
                signature = moveChar[0];
            }
        }
        targetSquare.Item2 = (int)moveChar[moveChar.GetLength(0) - 2] - 98;
        targetSquare.Item1 = (int)moveChar[moveChar.GetLength(0) - 1] - 50 + 8;
    }

    public Boolean isMoveOfCorrectForm() {
        if (move.Equals("O-O") || move.Equals("O-O-O")) {
            return true;
        }
        return move_Correctnes.IsMatch(move);
    }

}
