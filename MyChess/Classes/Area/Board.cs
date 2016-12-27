using MyChess.Classes.Area;
using MyChess.Classes.Pieces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyChess.Classes
{
    public class Board
    {
        private Square[,] _squares = new Square [8,8];
        public Square[,] Squares { get { return _squares; } }

        public Board()
        {
            initSquares();
        }
        public Board(Square[,] squares)
        {
            Array.Copy(squares, _squares, _squares.Length);
            initSquares();
        }

        private void initSquares()
        {
            for (int x= 0; x < 8; x++)
            {
                for (int y=0; y < 8; y++)
                {
                    if (_squares[x, y] == null)
                    {
                        _squares[x, y] = new Square(x,y) { Board = this };
                    }
                    else
                    {
                        _squares[x, y] = new Square(x,y) { Board = this, Piece = _squares[x, y].Piece };
                    }
                }
            }
        }

        public Board Clone()
        {
            return new Board(_squares);
        }

        public Square GetSquare(Location location)
        {
            if (location == null) return null;
            return _squares[location.X, location.Y];
        }

        public Board Play(Move move)
        {
            var result = this.Clone();
            if (move.Validate(result))
            {
                GetSquare(move.From).Piece = null;
                GetSquare(move.To).Piece = move.Piece;
            }
            else
            {
                throw new Exception("Illegal Move!");
            }
            return result;
        }

        public IEnumerable<Square> AllSquares()
        {
            var xLimit = Enumerable.Range(0, Squares.GetUpperBound(0) + 1);
            var yLimit = Enumerable.Range(0, Squares.GetUpperBound(1) + 1);
            return xLimit.SelectMany(x => yLimit.Select(y => Squares[x, y]));
        }

        public float Evaluate(Color myColor)
        {
            var myScore = AllSquares().Where(x => !x.IsEmpty() && x.Piece.Color == myColor).Sum(x => x.Evaluate());
            var hisScore = AllSquares().Where(x => !x.IsEmpty() && x.Piece.Color != myColor).Sum(x => x.Evaluate());

            return myScore - hisScore;
        }
    }
}
