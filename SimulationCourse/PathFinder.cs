using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace SimulationCourse
{
    internal class PathFinder
    {
        private Node startNode;
        private Map map;
        public PathFinder(Coordinates startCoordinates, Map map)
        {
            startNode = new Node(startCoordinates, null, 0);
            this.map = map;
        }
        private Node SearchPath(Coordinates targetCoordinates)
        {
            HashSet<Node> queue = new HashSet<Node>();
            HashSet<Node> chectNode = new HashSet<Node>();
            startNode.H = Distanse(startNode.coordinates, targetCoordinates);
            queue.Add(startNode);

            while (queue.Count > 0)
            {
                Node current = queue.Where(x => x.F == queue.Min(y => y.F)).FirstOrDefault();

                if (current.coordinates.Equals(targetCoordinates))
                { return current; }

                chectNode.Add(current);

                queue.Remove(current);

                var neughbors = GetNeighbors(current, targetCoordinates);
                foreach (var neighbor in neughbors)
                {
                    if (chectNode.Contains(neighbor)) continue;
                    if (!queue.Contains(neighbor))
                    {
                        neighbor.lastNode = current;
                        neighbor.H = Distanse(neighbor.coordinates, targetCoordinates);
                        if (!queue.Contains(neighbor))
                        {
                            queue.Add(neighbor);
                        }
                    }
                }
            }
            return startNode;
        }
        private int Distanse(Coordinates coordinates1, Coordinates coordinates2)
        {
            return Math.Abs(coordinates2.X - coordinates1.X) + Math.Abs(coordinates2.Y - coordinates1.Y);
        }
        public List<Coordinates> GetPath(Coordinates target)
        {
            List<Coordinates> path = new List<Coordinates>();
            Node targetNode = SearchPath(target);
            while (targetNode.lastNode != null)
            {
                path.Add(targetNode.coordinates);
                targetNode = targetNode.lastNode;
            }
            path.Reverse();
            return path;
        }
        private List<Node> GetNeighbors(Node current, Coordinates targetCoordinates)
        {
            List<Node> neighbors = new List<Node>();
            var leftNeighbors = new Coordinates(current.coordinates.X - 1, current.coordinates.Y);
            var rightNeighbors = new Coordinates(current.coordinates.X + 1, current.coordinates.Y);
            var topNeighbors = new Coordinates(current.coordinates.X, current.coordinates.Y - 1);
            var bottomNeighbors = new Coordinates(current.coordinates.X, current.coordinates.Y + 1);

            if (IsMoveable(rightNeighbors, targetCoordinates)) neighbors.Add(new Node(rightNeighbors, current, current.G + 1));
            if (IsMoveable(leftNeighbors, targetCoordinates)) neighbors.Add(new Node(leftNeighbors, current, current.G + 1));
            if (IsMoveable(bottomNeighbors, targetCoordinates)) neighbors.Add(new Node(bottomNeighbors, current, current.G + 1));
            if (IsMoveable(topNeighbors, targetCoordinates)) neighbors.Add(new Node(topNeighbors, current, current.G + 1));
            return neighbors;
        }
        private bool IsMoveable(Coordinates coordinates, Coordinates targetCoordinates)
        {
            if (coordinates.Equals(targetCoordinates)) return true;
            if (!coordinates.CoordinatesAreOnMap(coordinates)) return false;
            if (!map.IsSquareEmpty(coordinates)) return false;
            return true;
        }
    }
}


