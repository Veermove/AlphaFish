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

        if (move.Equals("O-O")) {
            Console.WriteLine("isLongCastleLegal: " + isShortCastleLegal(game));
            return isShortCastleLegal(game);
        } else if (move.Equals("O-O-O")) {
            return isLongCastleLegal(game);
        }

        Char[] moveChar = prepareMove();
        List<ChessPiece> possible = game.getChessBoard().FindAllPieces(x => {
            return x.getColor() == color && x.getSignatureChar() == signature;
        });

        possible = possible.FindAll(x => x.hasAccessToSquare(targetSquare, game.getChessBoard()).Item1);

        if (possible.Count > 1) {
            possible = possible.FindAll(x => x.isOnRankOrFile(moveChar[1]));
            if (possible.Count > 1) {
                possible = possible.FindAll(x => x.isOnRankOrFile(moveChar[2]));
            }
        }



        if (possible.Count != 1) {

            // return false;
            throw new LegalMoveException("Illegal move, corresponding pieces: " + possible.Count);
        }

        isCapture = possible[0].hasAccessToSquare(targetSquare, game.getChessBoard()).Item2;

        currentSquare = possible[0].getPosition();

        Console.WriteLine("is legal: " + !wouldEndUpInCheck(game, possible[0]) + ", for " + possible[0].getSignatureChar());

        return false;
    }

    public Boolean wouldEndUpInCheck(GameModel game, ChessPiece movingPiece) {
        ChessPiece currentKing =
            color == ChessPiece.White ?
            game.getChessBoard().getWhiteKing() : game.getChessBoard().getBlackKing();

        List<ChessPiece> mockPieces = game.getChessBoard().toList();

        // Console.WriteLine( BoardSquareTranslator.toSquare(currentKing.getPosition()) + " " + currentKing.getSignatureChar());

        ChessPiece temp = game.getChessBoard().getSquare(targetSquare);
        game.getChessBoard().setSquare(targetSquare, movingPiece);
        game.getChessBoard().setSquare(currentSquare, ChessPieceDictionary.empty);

        game.getChessBoard().ShowBoard();

        if (isCapture) {
            mockPieces.Remove(temp);
        }

        Boolean result = false;
        foreach(ChessPiece x in mockPieces) {
            if (x.getColor() != color &&
                x.canAttackSquareWithKing(currentKing.getPosition(), game.getChessBoard())) {
                result = true;
            }
        }

        mockPieces.Add(temp);
        game.getChessBoard().setSquare(targetSquare, temp);
        game.getChessBoard().setSquare(currentSquare, movingPiece);

        Console.WriteLine("is capture : " + isCapture);
        Console.WriteLine("is check : " + result);
        return result;
    }

    private Boolean isShortCastleLegal(GameModel game) {
        Boolean overCondition = color == ChessPiece.White ? game.WhiteCastleKingside : game.BlackCastleKingside;
        ChessPiece king = color == ChessPiece.White ? game.getChessBoard().getWhiteKing() : game.getChessBoard().getBlackKing();
        if (overCondition) {
            ChessMove mockMove = new ChessMove("Kf1");
            if (mockMove.isMoveLegal(game)){
                game.getChessBoard().setSquare(BoardSquareTranslator.ToPair("e1"), ChessPieceDictionary.empty);
                game.getChessBoard().setSquare(BoardSquareTranslator.ToPair("f1"), king);
                mockMove = new ChessMove("Kg1");

                game.getChessBoard().setSquare(BoardSquareTranslator.ToPair("e1"), king);
                game.getChessBoard().setSquare(BoardSquareTranslator.ToPair("f1"), ChessPieceDictionary.empty);
                return mockMove.isMoveLegal(game);
            }
        }

        return false;
    }

    private Boolean isLongCastleLegal(GameModel game) {
        Boolean overCondition = color == ChessPiece.White ? game.WhiteCastleKingside : game.BlackCastleKingside;
        ChessPiece king = color == ChessPiece.White ? game.getChessBoard().getWhiteKing() : game.getChessBoard().getBlackKing();
        if (overCondition) {
            ChessMove mockMove = new ChessMove("Kd1");
            if (mockMove.isMoveLegal(game)){
                game.getChessBoard().setSquare(BoardSquareTranslator.ToPair("e1"), ChessPieceDictionary.empty);
                game.getChessBoard().setSquare(BoardSquareTranslator.ToPair("d1"), king);
                mockMove = new ChessMove("Kc1");

                game.getChessBoard().setSquare(BoardSquareTranslator.ToPair("e1"), king);
                game.getChessBoard().setSquare(BoardSquareTranslator.ToPair("d1"), ChessPieceDictionary.empty);
                return mockMove.isMoveLegal(game);
            }
        }

        return false;
    }


    private Char[] prepareMove() {
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

    public void setIsCapture(bool isCpature) {
        isCapture = true;
    }

    public Boolean isMoveOfCorrectForm() {
        if (move.Equals("O-O") || move.Equals("O-O-O")) {
            return true;
        }
        return move_Correctnes.IsMatch(move);
    }

}
