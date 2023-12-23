
namespace SimulationCourse
{
    public class Coordinates
    {
        public int X;
        public int Y;
        public Coordinates(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        //public override bool Equals(object? obj)
        //{
        //    if (this == obj) return true;
        //    if (obj == null || GetType() != obj.GetType()) return false;
        //    Coordinates that = (Coordinates)obj;
        //    if (X != that.X) return false;
        //    return Y.Equals(that.Y);
        //}
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            Coordinates other = (Coordinates)obj;
            return X == other.X && Y == other.Y;
        }

        public override int GetHashCode()
        {
            int result = X.GetHashCode();
            result = 131 * result + Y.GetHashCode();
            return result;
        }

        internal bool CoordinatesAreOnMap(Coordinates coordinates)
        {
            int x = coordinates.X;
            int y = coordinates.Y;
            if (x < 1 || x > Program.MAP_HEIGTH - 1) return false;
            if (y < 1 || y > Program.MAP_WIDTH - 1) return false;
            return true;
        }
        public int CalculatedDistanse(Coordinates coordinates1, Coordinates coordinates2)
        {
            return Math.Abs(coordinates2.X - coordinates1.X) + Math.Abs(coordinates2.Y - coordinates1.Y);
        }
        internal Coordinates Shift(Coordinates shift)
        {
            return new Coordinates(shift.X, shift.Y);
        }
    }
}