using MyChess.Classes.Area;
using MyChess.Classes.Pieces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyChess.Classes
{
    public class Square : Location
    {
        public Board Board { get; set; }
        public Piece Piece { get; set; }

        public Square(int x, int y)
            : base(x, y)
        {

        }

        public IEnumerable<Square> GetNeighbors(int xDirection, int yDirection, bool isUntilObistecal = false, int count = 8)
        {
            List<Square> neighbors = new List<Square>();
            var currentX = X;
            var currentY = Y;
            var currentNieghbor = this as Location;
            var i = 0;
            do
            {
                currentX += xDirection;
                currentY += yDirection;
                currentNieghbor = GetNeighbor(currentX, currentY);
                if (currentNieghbor == null) break;
                var currentSquare = Board.GetSquare(currentNieghbor);
                neighbors.Add(currentSquare);
                if (isUntilObistecal && !currentSquare.IsEmpty()) break;
                i++;
            }
            while (currentNieghbor != null && i < count);
            return neighbors;
        }

        public bool IsEmpty()
        {
            return (Piece == null);
        }
        public IEnumerable<Square> GetThreats()   
        {
            return Board.AllSquares().Where(x=>!x.IsEmpty()).SelectMany(x => x.Piece.GetLegalMoves(this)).Where(x => x.To == this && x.Piece.Color != Piece.Color).Select(x => Board.GetSquare(x.From));
        }

        public IEnumerable<Square> GetDefenders()
        {
            return Board.AllSquares().Where(x => !x.IsEmpty()).SelectMany(x => x.Piece.GetLegalMoves(this)).Where(x => x.To == this && x.Piece.Color == Piece.Color).Select(x => Board.GetSquare(x.From));
        }


        public float Evaluate()
        {
            var sum = Piece.GetWight();
            var threats = GetThreats();
            var defenders = GetDefenders();
            if (threats.Any(x=>x.Piece.GetWight() < Piece.GetWight()))
            {
                sum -= Piece.GetWight() + 1;
            }
            if (defenders.Any())
            {
                sum += 1;
            }
            var attacks = Piece.GetLegalMoves(this).Select(x => Board.GetSquare(x.To)).Where(x => !x.IsEmpty() && x.Piece.Color != Piece.Color);
            foreach (var attack in attacks)
            {
                sum += attack.Piece.GetWight() / 2;
            }
            return sum;
        }

    }
}
