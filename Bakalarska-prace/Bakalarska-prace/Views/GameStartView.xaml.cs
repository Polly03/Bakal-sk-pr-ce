using Bakalarska_prace.Components;
using Bakalarska_prace.Views;
using Bakalarska_prace.Models;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
// using Chess;

namespace Bakalarska_prace.Views
{
    public partial class GameStartView : UserControl


    {
        private ChessBoard ActualGame { get; set; }

        private Point TargetPos { get; set; }

        public GameStartView()
        {
            InitializeComponent();
            StartAnalyze();
        }

        private void StartAnalyze()
        {
            GenerateChessboard();
            ChessBoard sachovnice = new ChessBoard();
            sachovnice.setChessBoard();
            ActualGame = sachovnice;

            GetGUIfromBoard(sachovnice);
        }

        private void GenerateChessboard()
        {
            ChessBoard.Children.Clear();

            for (int row = 0; row < 8; row++)
            {
                for (int col = 0; col < 8; col++)
                {
                    var square = new ObservableGrid();

                    var background = new Border();
                    background.Background = (row + col) % 2 == 0 ? Brushes.White : Brushes.DarkGray;

                    square.Children.Add(background);

                    ChessBoard.Children.Add(square);
                }
            }
        }

        private void Square_Click(object sender, EventArgs e)
        {
            CleanHighlights();

            var square = (TextBlock)sender;
            var position = (Point)square.Tag;
            TargetPos = position;

            var txt = square.Text;

            if (txt == "\u2659") { DrawPawnMoves(txt, position, PieceColor.white); }
            if (txt == "\u265F") { DrawPawnMoves(txt, position, PieceColor.black); }
            if (txt == "\u2656") { DrawRookMoves(position, PieceColor.white); }
            if (txt == "\u265C") { DrawRookMoves(position, PieceColor.black); }
            if (txt == "\u2657") { DrawBishopMoves(position, PieceColor.white); }
            if (txt == "\u265D") { DrawBishopMoves(position, PieceColor.black); }
            if (txt == "\u2655") 
            {
                DrawBishopMoves(position, PieceColor.white);
                DrawRookMoves(position, PieceColor.white);
            }
            if (txt == "\u265B")
            {
                DrawBishopMoves(position, PieceColor.black);
                DrawRookMoves(position, PieceColor.black);
            }

            if (txt == "\u2654")
            {
                DrawBishopMoves(position, PieceColor.white, true);
                DrawRookMoves(position, PieceColor.white, true);
            }
            if (txt == "\u265A")
            {
                DrawBishopMoves(position, PieceColor.black, true);
                DrawRookMoves(position, PieceColor.black, true);
            }
        }

        private void CleanHighlights()
        {
            for (int i = 0; i < 64; i++)
            {
                var grid = (Grid)ChessBoard.Children[i];
                // Iterate backwards to safely remove during iteration
                for (int j = grid.Children.Count - 1; j >= 1; j--)  // Start from the end, skip index 0 (Border)
                {
                    if (grid.Children[j] is Ellipse)
                    {
                        grid.Children.RemoveAt(j);
                    }
                }
            }
        }

        private void DrawRookMoves(Point position, PieceColor color, bool drawKing = false)
        {
            DrawRookMovesWays(position, color, RookWays.up, drawKing);
            DrawRookMovesWays(position, color, RookWays.down, drawKing);
            DrawRookMovesWays(position, color, RookWays.left , drawKing);
            DrawRookMovesWays(position, color, RookWays.right, drawKing);
        }

        private void DrawBishopMoves(Point position, PieceColor color, bool drawKing = false)
        {
            DrawBishopMovesWays(position, color, BishopWays.upLeft, drawKing);
            DrawBishopMovesWays(position, color, BishopWays.upRight , drawKing);
            DrawBishopMovesWays(position, color, BishopWays.downLeft, drawKing);
            DrawBishopMovesWays(position, color, BishopWays.downRight, drawKing);
        }


        private void DrawRookMovesWays(Point position, PieceColor color, RookWays way, bool drawKing = false)
        {
            List<Point> list = new List<Point>();
            int dx = 0, 
                dy = 0;

            switch (way)
            {
                case RookWays.right: dx = 1; dy = 0; break;
                case RookWays.left: dx = -1; dy = 0; break;
                case RookWays.up: dx = 0; dy = -1; break;
                case RookWays.down: dx = 0; dy = 1; break;
            }

            int x = (int)position.X + dx;
            int y = (int)position.Y + dy;

            while (x >= 0 && x < 8 && y >= 0 && y < 8)
            {
                var piece = ActualGame.returnIndexes(x, y);

                if (piece.PieceType == PieceType.none)
                {
                    list.Add(new Point(x, y));
                }
                else if (piece.PieceColor != color)
                {
                    list.Add(new Point(x, y));
                    break;
                }
                else
                {
                    break;
                }
                x += dx;
                y += dy;

                if(drawKing == true) { break; }
            }

            DrawPointsToClick(list);
        }

        private void DrawBishopMovesWays(Point position, PieceColor color, BishopWays way, bool drawKing = false)
        {
            List<Point> list = new List<Point>();
            int dx = 0,
                dy = 0;

            switch (way)
            {
                case BishopWays.upLeft: dx = -1; dy = -1; break;
                case BishopWays.upRight: dx = -1; dy = 1; break;
                case BishopWays.downLeft: dx = 1; dy = -1; break;
                case BishopWays.downRight: dx = 1; dy = 1; break;
            }

            int x = (int)position.X + dx;
            int y = (int)position.Y + dy;

            while (x >= 0 && x < 8 && y >= 0 && y < 8)
            {
                var piece = ActualGame.returnIndexes(x, y);

                if (piece.PieceType == PieceType.none)
                {
                    list.Add(new Point(x, y));
                }
                else if (piece.PieceColor != color)
                {
                    list.Add(new Point(x, y));
                    break;
                }
                else
                {
                    break;
                }
                x += dx;
                y += dy;

                if (drawKing == true) 
                { 
                    break; 
                }
            }

            DrawPointsToClick(list);
        }


        private void DrawPawnMoves(string sxt, Point pt, PieceColor color) {

            List<Point> pts = new List<Point>();

            if (color == PieceColor.white)
            {
                if (pt.X == 6)
                {
                    Point point1 = new Point(pt.X - 1, pt.Y);
                    Point point2 = new Point(pt.X - 2, pt.Y);
                    pts.Add(point1);
                    pts.Add(point2);
                }
                else
                {
                    Point point1 = new Point(pt.X - 1, pt.Y);
                    pts.Add(point1);
                }
            }
            else
            {
                if (pt.X == 1)
                {
                    Point point1 = new Point(pt.X + 1, pt.Y);
                    Point point2 = new Point(pt.X + 2, pt.Y);
                    pts.Add(point1);
                    pts.Add(point2);
                }
                else
                {
                    Point point1 = new Point(pt.X + 1, pt.Y);
                    pts.Add(point1);
                }
            }
            DrawPointsToClick(pts);
        }

        private void DrawPointsToClick(List<Point> points)
        {
            foreach (var point in points)
            {
                {
                    Ellipse highlight = new Ellipse()
                    {
                        Width = 80,               
                        Height = 80,
                        Fill = Brushes.LightGreen,
                        Opacity = 0.5,
                        Visibility = Visibility.Visible,

                    };
                    highlight.MouseDown += (sender, e) =>
                    {
                        PlayMove(point);
                        e.Handled = true;  // Prevent the click from bubbling to the TextBlock below
                    };
                
                    ((Grid)ChessBoard.Children[GridPos(point)]).Children.Add(highlight);

                    Panel.SetZIndex(highlight, 2);
                }
            }
        }

        private void PlayMove(Point point)
        {
            CleanHighlights();

            ActualGame.PrintToConsole();

            Piece MovingPiece = ActualGame.returnIndexes((int)(TargetPos.X),
                                                         (int)(TargetPos.Y));

            Piece TargetPiece = ActualGame.returnIndexes((int)(point.X), (int)(point.Y));
            

            Piece NewMovingPiece = MovingPiece.CopyPiece(MovingPiece);
            Piece NewTargetPiece = TargetPiece.CopyPiece(TargetPiece);

                ActualGame.SetIndexes((int)(point.X), (int)(point.Y), NewMovingPiece);
                ActualGame.SetIndexes((int)(TargetPos.X),
                                      (int)(TargetPos.Y),
                                      NewTargetPiece.makeEmptySpace());
            
            CleanHighlights();

            GetGUIfromBoard(ActualGame);

            ActualGame.PrintToConsole();
        }

        private int GridPos(Point point)
        {
            return (int)(point.X * 8 + point.Y);
        }

        private void GetGUIfromBoard(ChessBoard board)
        {

            for (int j = 0; j < 64; j++)
            {
                CleanHighlights();

                int indexI = j / 8;
                int indexJ = j % 8;
                Piece figura = board.returnIndexes(indexI, indexJ);

                TextBlock piece = new TextBlock()
                {

                    FontFamily = new FontFamily("Segoe UI Symbol"),
                    FontSize = 75,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center,
                    Tag = new Point(indexI, indexJ),
                };

                if (figura.PieceType == PieceType.none) piece.Text = "";
                if (figura.PieceType == PieceType.P && figura.PieceColor == PieceColor.white) piece.Text = ("\u2659");
                if (figura.PieceType == PieceType.P && figura.PieceColor == PieceColor.black) piece.Text = ("\u265F");
                if (figura.PieceType == PieceType.R && figura.PieceColor == PieceColor.white) piece.Text = ("\u2656");
                if (figura.PieceType == PieceType.R && figura.PieceColor == PieceColor.black) piece.Text = ("\u265C");
                if (figura.PieceType == PieceType.B && figura.PieceColor == PieceColor.white) piece.Text = ("\u2657");
                if (figura.PieceType == PieceType.B && figura.PieceColor == PieceColor.black) piece.Text = ("\u265D");
                if (figura.PieceType == PieceType.N && figura.PieceColor == PieceColor.white) piece.Text = ("\u2658");
                if (figura.PieceType == PieceType.N && figura.PieceColor == PieceColor.black) piece.Text = ("\u265E");
                if (figura.PieceType == PieceType.K && figura.PieceColor == PieceColor.white) piece.Text = ("\u2654");
                if (figura.PieceType == PieceType.K && figura.PieceColor == PieceColor.black) piece.Text = ("\u265A");
                if (figura.PieceType == PieceType.Q && figura.PieceColor == PieceColor.white) piece.Text = ("\u2655");
                if (figura.PieceType == PieceType.Q && figura.PieceColor == PieceColor.black) piece.Text = ("\u265B");

                // do uniform Gridu chessboard vezme board na pozici j a do třídy board přidá jako text znak pro figuru

                var grid = (Grid)ChessBoard.Children[j];
                if (grid.Children.Count > 1)
                {
                    grid.Children.RemoveAt(1);  // smaže starou figuru
                }
                grid.Children.Add(piece);

                piece.MouseDown += (s, e) =>
                {
                    Square_Click(piece, EventArgs.Empty);
                };

                Panel.SetZIndex(piece, 1);

            }
            CleanHighlights();
        }

    }
}
