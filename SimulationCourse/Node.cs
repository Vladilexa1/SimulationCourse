using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulationCourse
{
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
        public override bool Equals(object? obj)
        {
            return this.coordinates.Equals(((Node)obj).coordinates);
        }
        public override int GetHashCode()
        {
            int result = coordinates.GetHashCode();
            result = 222 * result;
            return result;
        }
    }

}

