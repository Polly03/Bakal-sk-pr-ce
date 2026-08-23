
/*

namespace Bakalarska_prace.Models
{
    public class ChessBoard
    {
        private Piece[,] board = new Piece[8, 8];

        public bool isReversed = false;

       
        public ChessBoard()
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    Piece nil = new(PieceColor.white, PieceType.none);
                    nil.makeEmptySpace();
                    board[i, j] = nil;
                }
            }
        }

        // metoda pro základní rozpoložení šachovnice

        public Piece[,] setChessBoard()
        {
            for(int i = 0;i < 8; i++)
            {
                Piece BlackPawn = new(PieceColor.black, PieceType.P);
                Piece WhitePawn = new(PieceColor.white, PieceType.P);
                board[1, i] = BlackPawn;
                board[6, i] = WhitePawn;
            }

            // Králové
            Piece BK = new(PieceColor.black, PieceType.K);
            Piece WK = new(PieceColor.white, PieceType.K);
            board[0, 4] = BK;
            board[7, 4] = WK;

            // Dámy
            Piece BQ = new(PieceColor.black, PieceType.Q);
            Piece WQ = new(PieceColor.white, PieceType.Q);
            board[0, 3] = BQ;
            board[7, 3] = WQ;

            // Věže
            Piece BR1 = new(PieceColor.black, PieceType.R);
            Piece BR2 = new(PieceColor.black, PieceType.R);
            Piece WR1 = new(PieceColor.white, PieceType.R);
            Piece WR2 = new(PieceColor.white, PieceType.R);
            board[0, 0] = BR1;
            board[0, 7] = BR2;
            board[7, 0] = WR1;
            board[7, 7] = WR2;

            // Jezdci
            Piece BN1 = new(PieceColor.black, PieceType.N);
            Piece BN2 = new(PieceColor.black, PieceType.N);
            Piece WN1 = new(PieceColor.white, PieceType.N);
            Piece WN2 = new(PieceColor.white, PieceType.N);
            board[0, 1] = BN1;
            board[0, 6] = BN2;
            board[7, 1] = WN1;
            board[7, 6] = WN2;

            // Střelci
            Piece BB1 = new(PieceColor.black, PieceType.B);
            Piece BB2 = new(PieceColor.black, PieceType.B);
            Piece WB1 = new(PieceColor.white, PieceType.B);
            Piece WB2 = new(PieceColor.white, PieceType.B);
            board[0, 2] = BB1;
            board[0, 5] = BB2;
            board[7, 2] = WB1;
            board[7, 5] = WB2;

            return board;
        }

        // selektor pro figurku na indexu i, j

        public Piece returnIndexes(int i, int j)
        {
            return board[i, j];
        }

        // mutator pro nastavení figurky na indexu i, j
        public void SetIndexes(int i, int j, Piece p)
        {
            board[i, j] = p;
        }

        // metoda pro kopii šachovnice kde její figurky jsou taky kopie figurek
        public ChessBoard CopyChessBoard(ChessBoard original)
        {
            ChessBoard copy = new ChessBoard();

            for (int row = 0; row < 8; row++)
            {
                for (int col = 0; col < 8; col++)
                {
                    Piece originalPiece = original.returnIndexes(row, col);
                    Piece copiedPiece = originalPiece.CopyPiece(originalPiece);
                    copy.SetIndexes(row, col, copiedPiece);
                }
            }

            return copy;
        }


        public void PrintToConsole()
        {
            for (int row = 0; row < 8; row++)
            {
                int r = isReversed ? row : 7 - row;

                for (int col = 0; col < 8; col++)
                {
                    int c = isReversed ? 7 - col : col;

                    Piece p = board[r, c];

                    char symbol = p.PieceType switch
                    {
                        PieceType.none => '.',
                        PieceType.P => 'P',
                        PieceType.R => 'R',
                        PieceType.N => 'N',
                        PieceType.B => 'B',
                        PieceType.Q => 'Q',
                        PieceType.K => 'K',
                        _ => '?'
                    };

                    // malé písmeno = černá figurka
                    if (p.PieceColor == PieceColor.black)
                        symbol = char.ToLower(symbol);

                    Console.Write(symbol + " ");
                }

                Console.WriteLine();
            }
            Console.WriteLine();
        }


    }
}
*/