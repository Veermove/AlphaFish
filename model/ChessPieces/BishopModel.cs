using System;
public class Bishop : ChessPiece {
    private int posHor;
    private int posVer;
    public Bishop (int givenPiece, int posHor, int posVer) : base(givenPiece) {
        this.posHor = posHor;
        this.posVer = posVer;
    }

    private (int, int)[] offsets = {(-1, 1), (1, 1), (-1, -1), (1, -1)};

    public override (Boolean, Boolean) hasAccessToSquare((int, int) targetSquare, ChessBoardModel chessBoard) {
        for (int i = 0; i < offsets.GetLength(0); i++) {
            int tempC = posHor;
            int tempR = posVer;
            while (true) {

                tempC += offsets[i].Item1;
                tempR += offsets[i].Item2;

                if (tempC < 0 || tempR < 0 || tempC > 7 || tempR > 7) {
                    break;
                }
                if (chessBoard.isSquareOccupied(tempC, tempR)) {
                    if (targetSquare != (tempC, tempR)) {
                        break;
                    } else {
                        if (chessBoard.getSquare(targetSquare).getColor() != this.getColor()) {
                            return (true, true);
                        } else {
                            return (false, false);
                        }
                    }
                } else {
                    if (targetSquare == (tempC, tempR)) {
                        return (true, false);
                    }
                }
            }
        }
        return (false, false);
    }

    public override Boolean canAttackSquareWithKing((int, int) targetSquare, ChessBoardModel chessBoard) {
        for (int i = 0; i < offsets.GetLength(0); i++) {
            int tempC = posHor;
            int tempR = posVer;
            while (true){
                tempC += offsets[i].Item1;
                tempR += offsets[i].Item2;
                if (tempC < 0 || tempR < 0 || tempC > 7 || tempR > 7) {
                    break;
                }

                // Console.WriteLine(BoardSquareTranslator.toSquare(tempC, tempR) + " == " + targetSquare + ", is occ: " + chessBoard.isSquareOccupied(tempC, tempR));
                // Console.WriteLine(tempC + " " + tempR);

                if (chessBoard.isSquareOccupied(tempC, tempR)) {
                    if (targetSquare != (tempC, tempR)) {
                        break;
                    } else {
                        return true;
                    }
                }
            }
        }
        return false;
    }

    public override (int, int) getPosition() {
        return (posHor, posVer);
    }

    public override void setPosition(int x, int y) {
        posHor = x;
        posVer = y;
    }

    public override bool isOnRankOrFile(char rankOrFile)
    {
        if (Char.IsDigit(rankOrFile)) {
            int givenP = BoardSquareTranslator.digitToInt(rankOrFile);
            return givenP == posVer;
        } else {
            int givenP = BoardSquareTranslator.letterToInt(rankOrFile);
            return givenP == posHor;
        }
    }

    public override char getSignatureChar() {
        return 'B';
    }
}
