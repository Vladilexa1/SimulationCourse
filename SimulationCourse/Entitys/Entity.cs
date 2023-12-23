using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulationCourse.Entitys
{
    public abstract class Entity
    {
        public Color color;
        public Coordinates coordinates;
        public Entity()
        {
            coordinates = GetOneRandomCoordinates();
        }
        public Coordinates GetOneRandomCoordinates()
        {
            Random random = new Random();
            int randomHeigth = random.Next(1, Program.MAP_HEIGTH - 1);
            int randomWidth = random.Next(1, Program.MAP_WIDTH - 1);
            return new Coordinates(randomHeigth, randomWidth);
        }
        public Coordinates GetUnikalCoordinates(Dictionary<Coordinates, Entity> map) 
        {
            while (map.ContainsKey(coordinates))
            { 
                coordinates = GetOneRandomCoordinates();
            }
            return coordinates;
        }
    }
}
