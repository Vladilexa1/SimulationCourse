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
        //Травоядное, наследуется от Creature. Стремятся найти ресурс (траву),
        //может потратить свой ход на движение в сторону травы, либо на её поглощение.
        // найти еду 
        // если координаты все пусты в следующем ходу и прошлые координаты жто еда, продолжить путь к ней
        // 
        // 
        public Herbivore()
        {
            color = Color.Blue;
            Velocity = 2;
            HP = 10;
        }
        public override Entity MakeMove(Map map)
        {
            var coordinatesNearestFood = map.FindNearestFood(this.coordinates, map.GetCoordinatesAllGrass());
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
    }
}
