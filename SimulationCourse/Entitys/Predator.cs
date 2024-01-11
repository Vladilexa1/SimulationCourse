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
            return base.MakeMove(map);
        }
        public override void EatFood(Map map, Coordinates coordinates)
        {
            if (map.ThisCoordinatesIsHerbivore(coordinates))
            {
                if ((map.GetEntityForCoordinates(coordinates) as Herbivore).HP != 0)
                {
                    (map.GetEntityForCoordinates(coordinates) as Herbivore).HP -= 5;
                }
                else
                {
                    MapConsoleRenderer renderer = new MapConsoleRenderer();
                    map.DeleteEntitys(coordinates);
                    renderer.DeleteEntitys(coordinates);
                }
                HP += 6;
            }
        }
        public override HashSet<Entity> GetAllFood(Map map)
        {
           return map.GetAllHerbivore();
        }
    }
}
