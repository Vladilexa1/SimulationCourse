using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace SimulationCourse
{
    internal class PathFinder // переделать в А*
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
            Queue<Node> queue = new Queue<Node>();
            HashSet<Node> chectNode = new HashSet<Node>();
            startNode.H = targetCoordinates.CalculatedDistanse(startNode.coordinates, targetCoordinates);
            queue.Enqueue(startNode);
           
            while (queue.Count > 0)
            {
                Node current = queue.Where(x => x.F == queue.Min(y => y.F)).FirstOrDefault();
               
                if (current.coordinates.X == targetCoordinates.X && current.coordinates.Y == targetCoordinates.Y) return current;
            
                chectNode.Add(current);
            
                current = queue.Dequeue();

                if (current.coordinates.X == targetCoordinates.X && current.coordinates.Y == targetCoordinates.Y)
                {
                    return current;
                }

                var neughbors = GetNeighbors(current);
                foreach (var neighbor in neughbors)
                {
                    if (chectNode.Contains(neighbor)) continue;
                    int tentativeG = current.G + 1;
                    if (!queue.Contains(neighbor) || tentativeG < neighbor.G)
                    {
                        neighbor.lastNode = current;
                        neighbor.G = tentativeG;
                        neighbor.H = targetCoordinates.CalculatedDistanse(neighbor.coordinates, targetCoordinates);
                        if (!queue.Contains(neighbor))
                        {
                            queue.Enqueue(neighbor);
                        }
                    }
                }
            }
            return startNode;
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
        private List<Node> GetNeighbors(Node current)
        {
            List<Node> neighbors = new List<Node>();
            var leftNeighbors = new Coordinates(current.coordinates.X - 1, current.coordinates.Y);
            var rightNeighbors = new Coordinates(current.coordinates.X + 1, current.coordinates.Y);
            var topNeighbors = new Coordinates(current.coordinates.X, current.coordinates.Y - 1);
            var bottomNeighbors = new Coordinates(current.coordinates.X, current.coordinates.Y + 1);
            
            if (IsMoveable(rightNeighbors))  neighbors.Add(new Node(rightNeighbors, current, current.G + 1));
            if (IsMoveable(leftNeighbors))   neighbors.Add(new Node(leftNeighbors, current, current.G + 1));
            if (IsMoveable(bottomNeighbors)) neighbors.Add(new Node(bottomNeighbors, current, current.G + 1));
            if (IsMoveable(topNeighbors))    neighbors.Add(new Node(topNeighbors, current, current.G + 1));
            return neighbors;
        }

        private bool IsMoveable(Coordinates coordinates)
        {
            if (!coordinates.CoordinatesAreOnMap(coordinates)) return false;
            if (map.Maps.ContainsKey(coordinates) && !map.ThisCoordinatesIsGrass(coordinates)) return false;
            return true;
        }
    }
    public class Node
    {
        public Coordinates coordinates;
        public Node lastNode;
        public int G;
        public int H;
        public int F { get => G + H; }
        public Node(Coordinates coordinates, Node lastNode, int G)
        {
            this.coordinates = coordinates;
            this.lastNode = lastNode;
            this.G = G;
            this.H = 0;
        }
    }
    
}


