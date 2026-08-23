using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chess;
using Bakalarska_prace.Models;

namespace Bakalarska_prace.Services
{
    internal class ChessGameLogicService
    {
        private ChessBoard _board;
        public PieceColor SideOfBoard { get; set; }
        public PieceColor Turn {  get; set; }

        public ChessGameLogicService(PieceColor sideOfBoard)
        {
            _board = new ChessBoard();
            SideOfBoard = sideOfBoard;
            Turn = PieceColor.White;
        }
        public string Fen => _board.ToFen();

        public bool MakeMove(string from, string to)
        {
            try
            {
                return _board.Move(new Move(from, to));
            }
            catch
            {
                return false;
            }
        }

        public bool UndoMove()
        {
            if (_board.ExecutedMoves.Count > 0)
            {
                _board.Cancel();
                return true;
            }
            return false;
        }

        public List<string> GetValidMovesForSquare(string square)
        {
            var validMoves = new List<string>();
            var moves = _board.Moves(); 

            foreach (var move in moves)
            {
                string fromSquare = move.OriginalPosition.ToString().ToLower();
                string toSquare = move.NewPosition.ToString().ToLower();

                if (fromSquare == square.ToLower())
                {
                    validMoves.Add(toSquare);
                }
            }
            return validMoves;
        }

        public Piece GetPieceAt(int row, int col)
        {
            string square = IndexToSquare(row, col);
            return _board[square];
        }
        public static string IndexToSquare(int row, int col)
        {
            char file = (char)('a' + col);
            int rank = 8 - row;
            return $"{file}{rank}";
        }
    }
}
