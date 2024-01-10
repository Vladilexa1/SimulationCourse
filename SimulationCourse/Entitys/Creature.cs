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
        public virtual Entity MakeMove(Map map)
        {
            var coordinatesNearestFood = map.FindNearestFood(this.coordinates, GetAllFood(map));
            PathFinder pathFinder = new PathFinder(this.coordinates, map);
            var PathToFood = pathFinder.GetPath(coordinatesNearestFood);
            if (coordinates.CalculatedDistanse(this.coordinates, coordinatesNearestFood) != 1)
            {
                ShiftCreature(PathToFood, coordinatesNearestFood);
            }
            else
            {
                EatFood(map, coordinatesNearestFood);
            }
            return this;
        }
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
        public abstract void EatFood(Map map, Coordinates coordinates);
        public abstract HashSet<Coordinates> GetAllFood(Map map);
    }
}
