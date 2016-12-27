using MyChess.Classes.Area;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace MyChess.Classes.Pieces
{
    public abstract class Piece
    {
        private Color _color;
        public Color Color { get { return _color; } }
        public Piece(Color color)
        {
            _color = color;
        }
        public abstract IEnumerable<Move> GetLegalMoves(Square fromSquare);

        public abstract float GetWight();

    }
    public enum Color : byte
    {
        White,
        Black
    }
}

