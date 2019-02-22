using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Nodes
{
    public class NodesView : PictureBox
    {
        private List<Node> _ListOfNodes = new List<Node>();
        private List<Path> _ListOfPath = new List<Path>();
        private Node _In;
        private Node _Out;

        public NodesView ()
        {
            this.Paint += PaintNode;
            this.Paint += PaintPath;
            this.Paint += PaintShortestPath;
            this.MouseClick += SelectNode;
        }

        private void SelectNode(object sender, MouseEventArgs e)
        {
            foreach (Node theNode in _ListOfNodes)
            {
                if (((theNode.Location.X - 3) <= e.X) && ((theNode.Location.X + 3) >= e.X))
                    if (((theNode.Location.Y - 3) <= e.Y) && ((theNode.Location.Y + 3) >= e.Y))
                        if (e.Button == MouseButtons.Left) _In = theNode;
                        else
                            if (e.Button == MouseButtons.Right) _Out = theNode;
            }
            this.Refresh();
        }

        public void AddNode (Node newNode)
        {
            _ListOfNodes.Add(newNode);
            CrealeListOfPath();
        }

        public void AddNode (List<Node> newNodes)
        {
            _ListOfNodes = newNodes;
            CrealeListOfPath();
        }

        public void Clear ()
        {
            _ListOfNodes.Clear();
            _ListOfPath.Clear();
            _In = null;
            _Out = null;
        }


        //  Метод прорисовки узлов
        private void PaintNode(object sender, PaintEventArgs e)
        {
            foreach (Node n in _ListOfNodes)
            {
                e.Graphics.FillRectangle(Brushes.Black, n.Location.X-1, n.Location.Y-1, 3, 3);
            }
            if (_In != null)
            e.Graphics.FillRectangle(Brushes.Red, _In.Location.X - 2, _In.Location.Y - 2, 5, 5);
            if (_Out != null)
            e.Graphics.FillRectangle(Brushes.Green, _Out.Location.X - 2, _Out.Location.Y - 2, 5, 5);

        }

        // Прорисовка путей с узлам
        private void PaintPath(object sender, PaintEventArgs e)
        {
            foreach (Path p in _ListOfPath)
            {
                e.Graphics.DrawLine(Pens.Black, p.Node1.Location, p.Node2.Location);
            }
        }

        // Метод состовления карты путей
        private void CrealeListOfPath ()
        {
            foreach (Node thisNode in _ListOfNodes)
            {
                foreach (Node n in thisNode.PathToOtherNodes.Keys)
                {
                    bool isTherePath = false;
                    foreach (Path p in _ListOfPath)
                    {
                        if ((p.Node1 == n) && (p.Node2 == thisNode) || (p.Node2 == n) && (p.Node1 == thisNode))
                        {
                            isTherePath = true; break;
                        }
                    }
                    if (!isTherePath)
                    {
                        Path p = new Path(thisNode, n, thisNode.PathToOtherNodes[n]);
                        _ListOfPath.Add(p);
                    }
                }

            }
        }

        //  Отрисовка путей
        public void PaintShortestPath(object sender, PaintEventArgs e)
        {
            if (_In == null || _Out == null) return;
            List<Node> listOfNodesShortestPath = CreateNodes.ShortestPath(_ListOfNodes, _In, _Out);
            for (int i = 0; i< listOfNodesShortestPath.Count-1; i++)
            {
                e.Graphics.DrawLine(Pens.Red, listOfNodesShortestPath[i].Location, listOfNodesShortestPath[i+1].Location);
            }
        }


        //  Метод поиска точки
        public Node FindNode (Point FindPoint)
        {
            foreach (Node theNode in _ListOfNodes)
            {
                if (((theNode.Location.X - 3) <= FindPoint.X) && ((theNode.Location.X + 3) >= FindPoint.X))
                    if (((theNode.Location.Y - 3) <= FindPoint.Y) && ((theNode.Location.Y + 3) >= FindPoint.Y))
                        return theNode;
            }
            return null;
        }
        

    }
    public struct Path
    {
        public Path  (Node node1, Node node2, int length)
        {
            Node1 = node1;
            Node2 = node2;
            Length = length;
        }
        public Node Node1;
        public Node Node2;
        public int Length;
    }
}
