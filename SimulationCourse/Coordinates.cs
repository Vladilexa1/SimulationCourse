
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
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType()) return false;
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
            if (x < 1 || x > Program.MAP_HEIGTH - 2) return false;
            if (y < 1 || y > Program.MAP_WIDTH - 2) return false;
            return true;
        }
        public int CalculatedDistanse(Coordinates current, Coordinates target)
        {
            return Math.Abs(target.X - current.X) + Math.Abs(target.Y - current.Y);
        }
    }
}