using System;

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
        int[,] chessBoard = new int[8,8];
        char[] positionChar = position.ToCharArray();

        int indexX = 0;
        int indexY = 0;
        for(int i = 0; i < positionChar.Length; i++) {
            if (positionChar[i] == '/') {
                indexX = 0;
                indexY++;
            } else if ((int)positionChar[i] >= 48 && (int)positionChar[i] <= 45) {
                indexX += (int)positionChar[i] - 48;
            } else {
                chessBoard[indexX, indexY] = ChessPieceDictionary
                    .ChessPiecesCharToIntDict
                    .GetValueOrDefault(positionChar[i], 0);
                indexX++;
            }
        }

        return new ChessBoardModel(chessBoard);
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

    private static ChessMoveModel parseToEnPassant(String enPassantInfo) {
        return new ChessMoveModel(enPassantInfo);
    }

    public static String stringFromPosition (GameModel gameState) {
        return "";
    }
}
