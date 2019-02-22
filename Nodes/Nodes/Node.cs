using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Nodes
{
    public class Node
    {
        public readonly Point Location;
        public Dictionary<Node, int> PathToOtherNodes { get; private set; } = new Dictionary<Node, int>();


        public Node () { }

        public Node (Point location)
        {
            Location = location;
        }

        public void AddPathToOtherNodes (Node OthetNodes, int PathValue)
        {
            PathToOtherNodes.Add(OthetNodes, PathValue);
        }
    }
}
