using SimulationCourse.Entitys;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulationCourse
{
    internal class ZAMETKI
    {
        //public void MM(Map map)
        //{
        //    List<Coordinates> entities = new List<Coordinates>();
        //    List<Entity> newEntities = new List<Entity>();
        //    foreach (var item in map.Maps)
        //    {
        //        if (item.Value.GetType() == new Herbivore().GetType())
        //        {
        //            entities.Add(item.Value.coordinates);
        //            newEntities.Add(((Herbivore)item.Value).MakeMove(map));
        //        }
        //    }
        //    for (int i = 0; i < entities.Count; i++)
        //    {
        //        map.DeleteEntitys(entities[i]);
        //    }
        //    for (int i = 0; i < entities.Count; i++)
        //    {
        //        map.NewEntitySetup(newEntities[i]);
        //    }
        //}
        //public override Coordinates FindNearestFood(Map map, Coordinates coordinates)
        //{
        //    HashSet<Coordinates> coordinatesFood = new HashSet<Coordinates>();
        //    foreach (var entitys in map.Maps)
        //    {
        //        if (map.ThisCoordinatesIsGrass(entitys.Key))
        //        {
        //            coordinatesFood.Add(entitys.Key);
        //        }
        //    }
        //    Coordinates nearestFood = null;
        //    int minDistanse = int.MaxValue;
        //    foreach (var foodCoordinates in coordinatesFood)
        //    {
        //        int distanse = coordinates.CalculatedDistanse(coordinates, foodCoordinates);
        //        if (distanse < minDistanse)
        //        {
        //            minDistanse = distanse;
        //            nearestFood = foodCoordinates;
        //        }
        //    }
        //    return nearestFood;
        //}
    }
}
