using Bakalarska_prace.Services;
using Chess;
using Microsoft.AspNetCore.SignalR.Client;
using System.Collections.Generic;
using System.Data.Common;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace Bakalarska_prace.Views
{
    public partial class GameStartView : UserControl
    {
        private readonly ChessGameLogicService _gameService;
        private string _selectedSquare = null;

        public GameStartView()
        {
            InitializeComponent();
            _gameService = new ChessGameLogicService(PieceColor.White);

            InitializeBoardUI();
            RenderBoard();
        }

        private void InitializeBoardUI()
        {
            ChessBoard.Children.Clear();

            for (int row = 0; row < 8; row++)
            {
                for (int col = 0; col < 8; col++)
                {
                    var squareGrid = new Grid
                    {
                        Tag = ChessGameLogicService.IndexToSquare(row, col)
                    };

                    var background = new Border
                    {
                        Background = (row + col) % 2 == 0 ? Brushes.LightGray : Brushes.DarkGray
                    };

                    squareGrid.Children.Add(background);
                    squareGrid.MouseDown += Square_MouseDown;

                    ChessBoard.Children.Add(squareGrid);
                }
            }
        }

        private void RenderBoard()
        {
            CleanHighlights();

            for (int row = 0; row < 8; row++)
            {
                for (int col = 0; col < 8; col++)
                {
                    int actualRow = _gameService.SideOfBoard == PieceColor.White ? row : 7 - row;
                    int actualCol = _gameService.SideOfBoard == PieceColor.White ? col : 7 - col;

                    int gridIndex = row * 8 + col;
                    var squareGrid = (Grid)ChessBoard.Children[gridIndex];

                    while (squareGrid.Children.Count > 1)
                    {
                        squareGrid.Children.RemoveAt(1);
                    }

                    Piece piece = _gameService.GetPieceAt(actualRow, actualCol);
                    if (piece != null)
                    {
                        TextBlock txtPiece = new TextBlock
                        {
                            Text = GetUnicodeSymbol(piece),
                            FontFamily = new FontFamily("Segoe UI Symbol"),
                            FontSize = 48,
                            HorizontalAlignment = HorizontalAlignment.Center,
                            VerticalAlignment = VerticalAlignment.Center,
                            IsHitTestVisible = false 
                        };

                        squareGrid.Children.Add(txtPiece);
                    }
                }
            }
        }
        private void Square_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var squareGrid = (Grid)sender;
            string clickedSquare = squareGrid.Tag.ToString();

            if (_selectedSquare != null)
            {
                if (_gameService.MakeMove(_selectedSquare, clickedSquare))
                {
                    _selectedSquare = null;
                    RenderBoard();
                    return;
                }
            }

            _selectedSquare = clickedSquare;
            CleanHighlights();

            List<string> validTargets = _gameService.GetValidMovesForSquare(clickedSquare);
            HighlightValidMoves(validTargets);
        }

        private void HighlightValidMoves(List<string> targetSquares)
        {
            foreach (var target in targetSquares)
            {
                foreach (Grid squareGrid in ChessBoard.Children)
                {
                    if (squareGrid.Tag?.ToString() == target)
                    {
                        Ellipse dot = new Ellipse
                        {
                            Width = 20,
                            Height = 20,
                            Fill = Brushes.LightGreen,
                            Opacity = 0.7,
                            HorizontalAlignment = HorizontalAlignment.Center,
                            VerticalAlignment = VerticalAlignment.Center,
                            IsHitTestVisible = false
                        };

                        squareGrid.Children.Add(dot);
                    }
                }
            }
        }

        private void CleanHighlights()
        {
            foreach (Grid squareGrid in ChessBoard.Children)
            {
                for (int i = squareGrid.Children.Count - 1; i >= 1; i--)
                {
                    if (squareGrid.Children[i] is Ellipse)
                    {
                        squareGrid.Children.RemoveAt(i);
                    }
                }
            }
        }

        private string GetUnicodeSymbol(Piece piece)
        {
            if (piece == null) return string.Empty;

            // Vytáhneme znak figurky (např. "P" pro bílého pěšce, "p" pro černého)
            // Pokud .Notation neexistuje, nahraď za: piece.ToString()
            string notation = piece.ToString();

            return notation switch
            {
                // BÍLÉ FIGURKY (Velká písmena)
                "wp" => "\u2659",
                "wr" => "\u2656",
                "wn" => "\u2658",
                "wb" => "\u2657",
                "wq" => "\u2655",
                "wk" => "\u2654",

                // ČERNÉ FIGURKY (Malá písmena)
                "bp" => "\u265F",
                "br" => "\u265C",
                "bn" => "\u265E",
                "bb" => "\u265D",
                "bq" => "\u265B",
                "bk" => "\u265A",

                _ => string.Empty
            };
        }
    }
}