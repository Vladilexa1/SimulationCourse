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
        private List<Coordinates> PathToFood;
        Coordinates coordinatesNearestFood;
        public Herbivore()
        {
            color = Color.Blue;
            Velocity = 2;
            HP = 10;
        }
        public override Entity MakeMove(Map map)
        {
            coordinatesNearestFood = FindNearestFood(map, this.coordinates);
            PathFinder pathFinder = new PathFinder(this.coordinates, map);
            PathToFood = pathFinder.GetPath(coordinatesNearestFood);
            if (coordinates.CalculatedDistanse(this.coordinates, coordinatesNearestFood) != 1)
            {
                ShiftCreature();
            }
            else
            {
                EatFood(map, coordinatesNearestFood);
            }
            return this;
        }
        private void ShiftCreature()
        {
            for (int i = 0; i < Velocity; i++)
            {
                if (coordinates.CalculatedDistanse(this.coordinates, coordinatesNearestFood) != 1)
                {
                    this.coordinates = PathToFood[i];
                }
            }
        }
        //private bool PathToFoodIsClear(Map map)
        //{
        //    if (PathToFood == null) return false;
        //    for (int i = 0; i < PathToFood.Count - 1; i++)
        //    {
        //        if (!map.IsSquareEmpty(PathToFood[i]))
        //        {
        //            return false;
        //        }
        //    }
        //    return true;
        //}

        //private bool LastFoodHaveInMap(Map map)
        //{
        //    if (coordinatesNearestFood == null) return false;
        //    return map.ThisCoordinatesIsGrass(coordinatesNearestFood);
        //}

        public override Coordinates FindNearestFood(Map map, Coordinates coordinates)
        {
            HashSet<Coordinates> coordinatesFood = new HashSet<Coordinates>();
            foreach (var entitys in map.Maps)
            {
                if (map.ThisCoordinatesIsGrass(entitys.Key))
                {
                    coordinatesFood.Add(entitys.Key);
                }
            }
            Coordinates nearestFood = null;
            int minDistanse = int.MaxValue;
            foreach (var foodCoordinates in coordinatesFood)
            {
                int distanse = coordinates.CalculatedDistanse(coordinates, foodCoordinates);
                if (distanse < minDistanse)
                {
                    minDistanse = distanse;
                    nearestFood = foodCoordinates;
                }
            }
            return nearestFood;
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
