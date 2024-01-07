using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulationCourse.Entitys
{
    public abstract class Creature : Entity
    {
        public int HP;
        public int Velocity;
        public abstract Entity MakeMove(Map map);
        public abstract void EatFood(Map map, Coordinates coordinates);
        public void ShiftCreature(List<Coordinates> pathToFood, Coordinates coordinatesNearestFood)
        {
            for (int i = 0; i < Velocity; i++)
            {
                if (coordinates.CalculatedDistanse(this.coordinates, coordinatesNearestFood) != 1)
                {
                    if (pathToFood.Count > i)
                    {
                        this.coordinates = pathToFood[i];
                    }
                }
            }
        }
    }
}
