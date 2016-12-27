using MyChess.Classes.Area;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyChess.Classes.Pieces
{
    public class Move
    {
        public Location From { get; set; }
        public Location To { get; set; }
        public Piece Piece { get; set; }

        private bool? _isValid;
        public Move(bool? isValid = null)
        {
            _isValid = isValid;
        }

        public bool Validate(Board board)
        {
            if (_isValid == null)
            {
                _isValid = Piece.GetLegalMoves(board.GetSquare(From)).Any(x => x.To == To);
            }
            return _isValid.Value;
        }

        public override string ToString()
        {
            return string.Format("{0}{1}{2}{3}", new object[] { translateInt(From.Y), 8 - From.X, translateInt(To.Y), 8 - To.X });
        }

 
        private static char translateInt(int x)
        {
            switch (x)
            {
                case 0:
                    return 'a';

                case 1:
                    return 'b';

                case 2:
                    return 'c';

                case 3:
                    return 'd';

                case 4:
                    return 'e';

                case 5:
                    return 'f';

                case 6:
                    return 'g';

                case 7:
                    return 'h';
            }
            return ' ';
        }

    }
}
