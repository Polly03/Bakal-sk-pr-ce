/*
namespace Bakalarska_prace.Models
{

    public enum PieceType {K, Q, N, B, R, P, none}

  
    public class Piece
    {
        public PieceColor PieceColor {  get; set; }
        public int value { get; set; }
        public PieceType PieceType { get; set; }

        public bool Highlighted = false;

     
        public Piece(PieceColor PieceColor, PieceType PieceType)
        {
            this.PieceColor = PieceColor;
                
            this.PieceType = PieceType;
            switch (PieceType)
            {
                case PieceType.K:
                    value = 0;
                    break;
                case PieceType.none:
                    value = 0;
                    break;
                case PieceType.Q:
                    value = 9;
                    break;
                case PieceType.P: 
                    value = 1; 
                    break;
                case PieceType.R:
                    value = 5;
                    break;
                
                default:
                    value = 3;
                    break;
            }

        }

        // metoda pro prázdnou plochu na šachovnici
        public Piece makeEmptySpace() { 
            Piece space = new(PieceColor.white, PieceType.none);
            return space;
        }

        // metoda vrací přesnou kopii figurky
        public Piece CopyPiece(Piece piece)
        {
            Piece newPiece = new Piece(piece.PieceColor, piece.PieceType);
            return newPiece;
        }

        public Piece NegColor()
        {
            if(PieceColor == PieceColor.white)
            {
                return new Piece(PieceColor.black, PieceType.none);
            }
            else
            {
                return new Piece(PieceColor.white, PieceType.none);
            }
        }
    }

    

  
   
    
    
}

*/