using System;

public class Queen : ChessPiece {
    private int posHor;
    private int posVer;
    public Queen(int givenPiece, int posHor, int posVer) : base(givenPiece) {
        this.posHor = posHor;
        this.posVer = posVer;
    }

    private (int, int)[] offsets = {(-1, 1), (1, 1), (-1, -1), (1, -1), (-1, 0), (1, 0), (0, -1), (0, 1)};

    public override Boolean hasAccessToSquare((int,int) targetSquare, ChessBoardModel chessBoard) {
        (int, int, Boolean)[] branches = new (int, int, Boolean)[8];
        for (int i = 0; i < 8; i++) {
            branches[i] = (posVer + offsets[i].Item1, posHor + offsets[i].Item2, true);
        }
        (int, int, Boolean) target = (targetSquare.Item1, targetSquare.Item2, true);

        for (int j = 0; j < 7; j++) {
            for (int i = 0; i < 7; i++) {
                if (target == branches[i]) {
                    return true;
                }
                if (branches[i].Item3) {
                    branches[i] = (branches[i].Item1 + offsets[i].Item1, branches[i].Item2 + offsets[i].Item2, branches[i].Item3);
                    if (chessBoard.isSquareOccupied(branches[i].Item1, branches[i].Item2)) {
                        branches[i].Item3 = false;
                    }
                }
            }
        }
        return false;
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

    public override (int, int) getPosition() {
        return (posHor, posVer);
    }

    public override void setPosition(int x, int y) {
        posHor = x;
        posVer = y;
    }

    public override char getSignatureChar() {
        return 'Q';
    }
}
