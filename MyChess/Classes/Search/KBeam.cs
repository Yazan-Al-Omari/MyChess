using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyChess.Classes.Search
{
    public class DepthFirstSeach
    {
        private Node _root;
        private const int branches = 5;
        private const int MAX_DEPTH = 6;

        public DepthFirstSeach(Node root)
        {
            _root = root;
        }

        public Node SearchBestNode(Pieces.Color color)
        {
            Node best = null;
            GetBestNode(_root, ref best, 0, color);
            return best;
        }

        private void GetBestNode(Node root, ref Node best, int depth, Pieces.Color color)
        {
            var children = root.GetChildren().OrderByDescending(x => x.GetHeuristic(color)).Take(branches);
            var currentBest = children.FirstOrDefault();
            if (currentBest != null && currentBest.GetHeuristic(color) > best.GetHeuristic(color))
            {
                best = currentBest;
            }
            if (depth >= MAX_DEPTH) return;
            foreach (var child in children)
            {
                GetBestNode(child, ref best, depth + 1, color);
            }
        }

    }

   
}
