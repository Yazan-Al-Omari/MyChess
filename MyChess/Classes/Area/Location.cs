using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyChess.Classes.Area
{
    public class Location
    {
        private int _x ,_y;
        public int X { get { return _x; } }
        public int Y { get { return _y; } }
        public Location(int x, int y)
        {
            _x = x;
            _y = y;
        }

        public Location GetNeighbor(int xOffset, int yOffset)
        {
            int xLoc = this.X + xOffset;
            int yLoc = this.Y + yOffset;
            if (xLoc > 7 || xLoc < 0 || yLoc > 7 || yLoc < 0)
                return null;
            else
            {
                return new Location(xLoc, yLoc);
            }
        }


        public override bool Equals(object obj)
        {
            var other = obj as Location;
            if(other == null) return false;
            return this.X == other.X && this.Y == other.Y;
        }

        public override int GetHashCode()
        {
            return (this.X.ToString() + this.Y.ToString()).GetHashCode();
        } 
    }
}
