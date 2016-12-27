using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyChess.Classes.Pieces
{
    public class Queen : Bishob
    {

        public Queen(Color color)
            : base(color)
        {
        }

        public override IEnumerable<Move> GetLegalMoves(Square fromSquare)
        {
            var legalMoves = new List<Move>(base.GetLegalMoves(fromSquare));
            var upLine = fromSquare.GetNeighbors(xDirection: 1, yDirection: 0, isUntilObistecal: true);
            var rightLine = fromSquare.GetNeighbors(xDirection: 0, yDirection: 1, isUntilObistecal: true);
            var downLine = fromSquare.GetNeighbors(xDirection: -1, yDirection: 0, isUntilObistecal: true);
            var leftLine = fromSquare.GetNeighbors(xDirection: 0, yDirection: -1, isUntilObistecal: true);
            legalMoves.AddRange(
                upLine
                .Union(rightLine)
                .Union(downLine)
                .Union(leftLine)
                .Where(x => x.IsEmpty() || x.Piece.Color != Color)
                .Select(x => new Move(isValid: true) { From = fromSquare, To = x, Piece = this }));

            return legalMoves;
        }

        public override float GetWight()
        {
            return 9.0F;
        }
    }
}
