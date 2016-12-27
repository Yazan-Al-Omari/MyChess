using MyChess.Classes.Area;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyChess.Classes.Pieces
{
    public class Bishob : Piece
    {
        public Bishob(Color color)
            : base(color)
        {
        }
        public override IEnumerable<Move> GetLegalMoves(Square fromSquare)
        {
            var legalMoves = new List<Move>();
            var upLeftLine = fromSquare.GetNeighbors(xDirection: 1, yDirection: -1, isUntilObistecal: true);
            var upRightLine = fromSquare.GetNeighbors(xDirection: 1, yDirection: 1, isUntilObistecal: true);
            var downLeftLine = fromSquare.GetNeighbors(xDirection: -1, yDirection: -1, isUntilObistecal: true);
            var downRightLine = fromSquare.GetNeighbors(xDirection: -1, yDirection: 1, isUntilObistecal: true);
            legalMoves.AddRange(
                upLeftLine
                .Union(upRightLine)
                .Union(downLeftLine)
                .Union(downRightLine)
                .Where(x => x.IsEmpty() || x.Piece.Color != Color)
                .Select(x => new Move(isValid: true) { From = fromSquare, To = x, Piece = this }));

            return legalMoves;
        }

        public override float GetWight()
        {
            return 4.0F;
        }
    }
}
