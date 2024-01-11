using System;
using System.Collections.Generic;
using System.IO.MemoryMappedFiles;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;

namespace SimulationCourse.Entitys
{
    public class Herbivore : Creature
    {
        public Herbivore()
        {
            color = Color.Blue;
            Velocity = 2;
            HP = 10;
        }
        public override Entity MakeMove(Map map)
        {
            return base.MakeMove(map);
        }
        public override void EatFood(Map map, Coordinates coordinates)
        {
            MapConsoleRenderer renderer = new MapConsoleRenderer();
            if (map.ThisCoordinatesIsGrass(coordinates))
            {
                map.DeleteEntitys(coordinates);
                renderer.DeleteEntitys(coordinates);
                HP += 5;
            }
        }
        public override HashSet<Entity> GetAllFood(Map map)
        {
            return map.GetAllGrass();
        }
    }
}
