using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;


class ChessMove {
    private String move;
    private Boolean isCapture;
    private ChessPiece movingPiece;
    private (int, int) targetSquare;

    private (int, int) currentSquare;
    private static Regex move_Correctnes = new Regex("[abcdefghQKBNR]{0,1}[abcdefghx]{0,1}[abcdefgh][12345678]");
    private static Regex move_boardSquare = new Regex("^[abcdefgh][12345678]$");

    private int color;
    char signature;

    public ChessMove(String move) {
        this.move = move;
    }

    public Boolean isMoveLegal(GameModel game) {
        // check which color plays
        color = game.getColor() ? ChessPiece.White : ChessPiece.Black;

        Char[] moveChar = prepareMove();
        List<ChessPiece> possible = game.getChessBoard().FindAllPieces(x => {
            return x.getColor() == color && x.getSignatureChar() == signature;
        });

        Console.WriteLine(possible.Count);

        possible = possible.FindAll(x => x.hasAccessToSquare(targetSquare, game.getChessBoard()));

        Console.WriteLine(possible.Count);

        if (possible.Count > 1) {
            possible = possible.FindAll(x => x.isOnRankOrFile(moveChar[1]));
        }

        if (possible.Count != 1) {
            throw new LegalMoveException("Illegal move, corresponding pieces: " + possible.Count);
        }

        currentSquare = possible[0].getPosition();

        if (isCapture && game.getChessBoard().isSquareOccupied(targetSquare)) {
            if (game.getChessBoard().getSquare(targetSquare).getColor() != color) {
                // move is capture
            }
        }

        Console.WriteLine("is legal: " + !wouldEndUpInCheck(game, possible[0]) + ", for " + possible[0].getSignatureChar());



        // foreach (ChessPiece item in possible)
        // {
        //     Console.WriteLine(item.getSignatureChar() + " " + item);
        // }


        return false;
    }

    public Boolean wouldEndUpInCheck(GameModel game, ChessPiece movingPiece) {
        ChessPiece currentKing =
            color == ChessPiece.White ?
            game.getChessBoard().getWhiteKing() : game.getChessBoard().getBlackKing();

        List<ChessPiece> mockPieces = game.getChessBoard().toList();

        Console.WriteLine( BoardSquareTranslator.toSquare(currentKing.getPosition()) + " " + currentKing.getSignatureChar());

        game.getChessBoard().setSquare(targetSquare, movingPiece);
        game.getChessBoard().setSquare(currentSquare, ChessPieceDictionary.empty);

        game.getChessBoard().ShowBoard();

        Boolean result = false;
        foreach(ChessPiece x in mockPieces) {
            if (x.getColor() != color &&
                x.canAttackSquareWithKing(currentKing.getPosition(), game.getChessBoard())) {
                result = true;
            }
        }
        game.getChessBoard().setSquare(targetSquare, ChessPieceDictionary.empty);
        game.getChessBoard().setSquare(currentSquare, movingPiece);

        Console.WriteLine("is check : " + result);
        return result;
    }
    public Char[] prepareMove() {
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
        targetSquare = BoardSquareTranslator.ToPair(
            moveChar[moveChar.GetLength(0) - 2],
            moveChar[moveChar.GetLength(0) - 1]);

        return moveChar;
    }

    public Boolean isMoveOfCorrectForm() {
        if (move.Equals("O-O") || move.Equals("O-O-O")) {
            return true;
        }
        return move_Correctnes.IsMatch(move);
    }

}
