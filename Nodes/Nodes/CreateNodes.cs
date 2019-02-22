using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Nodes
{
    //  класс для хранения данных о посещении и стоимости узлов
    public class DataNode
    {
        public DataNode() { }
        public bool visit = false;
        public int distance = 999999;
    }

    static public class CreateNodes
    {

        //  Метод, который создаёт в области с узлами заданное число узлов
        static public List<Node> CreateRandomNodes(NodesView nodesView, int count, int maxCountPathForNode)
        {
            int maxArea = (int)(count * 2.7);
            int distanceBetweenNodes = 25;
            int maxPatnLength = 40;
            Random r = new Random();
            List<Node> listNodes = new List<Node>();

            //  создать узлы
            for (int i=0; i<=count; i++)
            {
                Point location = new Point(r.Next(maxArea), r.Next(maxArea));
                bool AreThereNodesNearby = false;
                foreach (Node n in listNodes)
                {
                    int PathLendh = Math.Abs(location.X - n.Location.X) + Math.Abs(location.Y - n.Location.Y);
                    if (PathLendh < distanceBetweenNodes) { AreThereNodesNearby = true; break; }
                }
                if (AreThereNodesNearby) { i--; continue; }
                listNodes.Add(new Node(location));
            }

            //  Создать пути между узлами
            foreach(Node thisNode in listNodes)
            {
               foreach(Node n in listNodes)
                {
                    if (thisNode == n) continue;
                    int PathLendh = Math.Abs(thisNode.Location.X - n.Location.X) + Math.Abs(thisNode.Location.Y - n.Location.Y);
                    if (PathLendh <= maxPatnLength && n.PathToOtherNodes.Count <= maxCountPathForNode)
                    {
                        if (!thisNode.PathToOtherNodes.ContainsKey(n))
                        thisNode.AddPathToOtherNodes(n, PathLendh);
                        if (!n.PathToOtherNodes.ContainsKey(thisNode))
                        n.AddPathToOtherNodes(thisNode, PathLendh);
                    }
                    if (thisNode.PathToOtherNodes.Count >= maxCountPathForNode) break;
                }
            }

            return listNodes;
        }

        //  Метод поиска кратчайшего пути алгоритмом Дейкстры
        public static List<Node> ShortestPath (List<Node> nodes, Node startNode, Node finishNode)
        {
            //  составление таблицы узлов с отметкой о посещении и расстояния
            Dictionary<Node, DataNode> nodesVisit = new Dictionary<Node, DataNode>();
            foreach (Node theNode in nodes)
            {
                nodesVisit.Add(theNode, new DataNode());
            }

            nodesVisit[startNode].distance = 0;
            Node nodeWithMinPath = startNode;
            int patchMimNode = 0;
            bool end = false;
            while (!end)
            {
                end = true;
                foreach (Node theNode in nodeWithMinPath.PathToOtherNodes.Keys)
                {
                    int newDistance = patchMimNode + nodeWithMinPath.PathToOtherNodes[theNode];
                    if (nodesVisit[theNode].distance > newDistance) nodesVisit[theNode].distance = newDistance;
                }
                nodesVisit[nodeWithMinPath].visit = true;
                patchMimNode = 999999;
                //  Поиск нового минимального узла
                foreach (Node theNode in nodesVisit.Keys)
                {
                    DataNode FindData = nodesVisit[theNode];
                    if ((FindData.distance < patchMimNode) && (FindData.visit == false) ) { nodeWithMinPath = theNode; patchMimNode = FindData.distance; }
                }
                if (patchMimNode != 999999) end = false;
                
            }
            //  Поиск кратчайшего пути
            if (nodesVisit[finishNode].distance == 999999) return new List<Node>(); //  В этом случе точка не доступна
            List<Node> resultPatch = new List<Node>();
            end = false;
            Node actualNod = finishNode;
            resultPatch.Add(actualNod);
            while (!end)
            {
                foreach (Node theNode in actualNod.PathToOtherNodes.Keys)
                {
                    if (nodesVisit[actualNod].distance == (nodesVisit[theNode].distance + theNode.PathToOtherNodes[actualNod]))
                    {
                        resultPatch.Add(theNode);
                        actualNod = theNode;
                        break;
                    }
                }
                if (actualNod == startNode) end = true;
            }
            return resultPatch;
        }

    }
}
