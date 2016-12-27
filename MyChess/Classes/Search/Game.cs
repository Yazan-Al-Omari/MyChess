using MyChess.Classes.Pieces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyChess.Classes.Search
{
    public class Game
    {
        public Board Board { get; set; }
        public Color CurrentPlayer { get; set; }

        public string Play()
        {
            var currentBoard = Board.Clone();
            var node = new Node(currentBoard, null);
            var allMoves = currentBoard.AllSquares().Where(x => !x.IsEmpty()).SelectMany(x => x.Piece.GetLegalMoves(x));
            foreach (var move in allMoves)
            {
                node.AddChild(new Node(currentBoard.Play(move), move));
            }

            var BestState = new DepthFirstSeach(node).SearchBestNode(CurrentPlayer);
            return BestState.GetMove().ToString();
        }

    }
}
