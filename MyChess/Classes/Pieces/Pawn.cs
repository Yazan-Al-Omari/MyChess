using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyChess.Classes.Pieces
{
    public class Pawn : Piece
    {

        public Pawn(Color color)
            : base(color)
        {
        }

        public override IEnumerable<Move> GetLegalMoves(Square fromSquare)
        {
            var legalMoves = new List<Move>();
            var board = fromSquare.Board;
            if (fromSquare.X == 1)
            {
                var upLine = fromSquare.GetNeighbors(xDirection: 1, yDirection: 0, isUntilObistecal: false, count: 2);
                if (upLine.All(x => x.IsEmpty())) legalMoves.Add(new Move(isValid: true) { From = fromSquare, To = fromSquare.GetNeighbor(2, 0), Piece = this });
            }
            var upMiddle = board.GetSquare(fromSquare.GetNeighbor(1, 0));
            var upLeft =  board.GetSquare(fromSquare.GetNeighbor(1, -1));
            var upRight =  board.GetSquare(fromSquare.GetNeighbor(1, 1));
            if (upMiddle != null && upMiddle.IsEmpty()) legalMoves.Add(new Move(isValid: true) { From = fromSquare, To = upMiddle, Piece = this });
            if (upLeft != null && !upMiddle.IsEmpty() && upLeft.Piece.Color != Color) legalMoves.Add(new Move(isValid: true) { From = fromSquare, To = upLeft, Piece = this });
            if (upRight != null && !upRight.IsEmpty() && upLeft.Piece.Color != Color) legalMoves.Add(new Move(isValid: true) { From = fromSquare, To = upRight, Piece = this });
            return legalMoves;
        }

        public override float GetWight()
        {
            return 1.0F;
        }
    }
}
