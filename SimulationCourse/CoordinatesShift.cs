using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulationCourse
{
    public class CoordinatesShift
    {
        public int X;
        public int Y;
        public CoordinatesShift(int x, int y)
        {
            X = x;
            Y = y;
        }
        public int CalculatedDistanse(CoordinatesShift shift)
        {
            return Math.Abs(shift.X) + Math.Abs(shift.Y);
        }
    }
}
