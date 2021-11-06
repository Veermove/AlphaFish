using System;
using System.Collections.Generic;

class ChessFenTranslator {

    public static GameModel positionFromString (String _FEN) {
        String[] infoFromFEN = _FEN.Split(' ', 6);
        Boolean[] castlingInforFromFEN = parseCastling(infoFromFEN[2]);

        return new GameModel(
            _FEN,
            parseToChessBoard(infoFromFEN[0]),
            infoFromFEN[1].Equals("w"),
            castlingInforFromFEN[0],
            castlingInforFromFEN[1],
            castlingInforFromFEN[2],
            castlingInforFromFEN[3],
            parseToEnPassant(infoFromFEN[3]),
            Int16.Parse(infoFromFEN[4]),
            Int16.Parse(infoFromFEN[5])
            );
    }
    private static ChessBoardModel parseToChessBoard(String position) {
        ChessPiece[,] chessBoard = new ChessPiece[8,8];
        char[] positionChar = position.ToCharArray();
        List<ChessPiece> onBoard = new List<ChessPiece>();

        for (int i = 0; i < chessBoard.GetLength(0); i++) {
            for (int j = 0; j < chessBoard.GetLength(1); j++) {
                chessBoard[i, j] = new Empty(0);
            }
        }

        int indexX = 0;
        int indexY = 0;
        for(int i = 0; i < positionChar.Length; i++) {
            if (positionChar[i] == '/') {
                indexX = 0;
                indexY++;
            } else if ((int)positionChar[i] >= 48 && (int)positionChar[i] <= 56) {
                indexX += (int)positionChar[i] - 48;
            } else {
                int piece = ChessPieceDictionary.ChessPiecesCharToIntDict
                    .GetValueOrDefault(positionChar[i], 0);
                switch (piece) {
                    case 17:
                    case 9:
                        chessBoard[indexX, indexY] = new King(piece, indexX, 7 - indexY);
                        onBoard.Add( chessBoard[indexX, indexY]);
                        break;

                    case 18:
                    case 10:
                        chessBoard[indexX, indexY] = new Queen(piece, indexX, 7 - indexY);
                        onBoard.Add( chessBoard[indexX, indexY]);
                        break;

                    case 19:
                    case 11:
                        chessBoard[indexX, indexY] = new Rook(piece, indexX, 7 - indexY);
                        onBoard.Add( chessBoard[indexX, indexY]);
                        break;

                    case 20:
                    case 12:
                        chessBoard[indexX, indexY] = new Bishop(piece, indexX, 7 - indexY);
                        onBoard.Add( chessBoard[indexX, indexY]);
                        break;

                    case 21:
                    case 13:
                        chessBoard[indexX, indexY] = new Knight(piece, indexX, 7 - indexY);
                        onBoard.Add( chessBoard[indexX, indexY]);
                        break;

                    case 22:
                    case 14:
                        chessBoard[indexX, indexY] = new Pawn(piece, indexX, 7 - indexY);
                        onBoard.Add( chessBoard[indexX, indexY]);
                        break;

                    case 0:
                    default:
                        chessBoard[indexX, indexY] = new Empty(piece);
                        break;
                }
                indexX++;
            }
        }

        return new ChessBoardModel(chessBoard, onBoard);
    }

    private static Boolean[] parseCastling(String castilingInfo) {
        Boolean[] castlingInfoArray = new Boolean[4];
        Array.Fill<Boolean>(castlingInfoArray, false);

        Char[] castlingInfoChars = castilingInfo.ToCharArray();
        for (int i = 0; i < castlingInfoChars.Length; i++) {
            switch (castlingInfoChars[i]) {
                case 'K':
                    castlingInfoArray[0] = true;
                    break;
                case 'Q':
                    castlingInfoArray[1] = true;
                    break;
                case 'k':
                    castlingInfoArray[2] =  true;
                    break;
                case 'q':
                    castlingInfoArray[3] = true;
                    break;
            }
        }
        return castlingInfoArray;
    }

    private static ChessMove parseToEnPassant(String enPassantInfo) {
        return new ChessMove(enPassantInfo);
    }

    public static String stringFromPosition (GameModel gameState) {
        return "";
    }
}
