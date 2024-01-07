using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulationCourse.Entitys
{
    internal class Predator : Creature
    {
        public Predator() 
        {
            color = Color.Red;
            Velocity = 3;
            HP = 10;
        }
        public override Entity MakeMove(Map map)
        {
            MapConsoleRenderer renderer = new MapConsoleRenderer();
            var coordinatesNearestFood = map.FindNearestFood(this.coordinates, map.GetCoordinatesAllHerbivore());
            PathFinder pathFinder = new PathFinder(this.coordinates, map);
            var PathToFood = pathFinder.GetPath(coordinatesNearestFood);
            if (coordinates.CalculatedDistanse(this.coordinates, coordinatesNearestFood) != 1)
            {
                HP -= 3;
                if (HP < 0)
                {
                    map.DeleteEntitys(this.coordinates);
                    renderer.DeleteEntitys(this.coordinates);
                }
                else
                {
                    ShiftCreature(PathToFood, coordinatesNearestFood);
                }
            }
            else
            {
                EatFood(map, coordinatesNearestFood);
            }
            return this;
        }
        public override void EatFood(Map map, Coordinates coordinates)
        {
            MapConsoleRenderer renderer = new MapConsoleRenderer();
            if (map.ThisCoordinatesIsHerbivore(coordinates))
            {
                if (((Herbivore)map.Maps[coordinates]).HP != 0)
                {
                    ((Herbivore)map.Maps[coordinates]).HP -= 5;
                }
                else
                {
                    map.DeleteEntitys(coordinates);
                    renderer.DeleteEntitys(coordinates);
                }
                HP += 0;
            }
        }
    }
}
