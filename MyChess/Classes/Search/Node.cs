using MyChess.Classes.Pieces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyChess.Classes.Search
{
    public class Node
    {
        private Board _state;
        private Move _move;
        private float? _heuristic;
        private ICollection<Node> _children;

        public Node(Board state, Move move)
        {
            _state = state;
            _move = move;
            _children = new List<Node>();
        }

        public bool isLeaf(Node node)
        {
            return !(node._children.Any());
        }

        public void AddChild(Node node)
        {
            _children.Add(node);
        }

        public Board GetState() { return _state; }
        public Move GetMove() { return _move; }
        public float GetHeuristic(Pieces.Color color)
        {
            if (!_heuristic.HasValue)
            {
                _heuristic = _state.Evaluate(color);
            }
            return _heuristic.Value;
        }

        public IEnumerable<Node> GetChildren()
        {
            return _children;
        }
    }
}
