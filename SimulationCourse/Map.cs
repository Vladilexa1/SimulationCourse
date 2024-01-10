using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimulationCourse.Entitys;

namespace SimulationCourse
{
    public class Map
    {
        public Dictionary<Coordinates, Entity> Maps = new Dictionary<Coordinates, Entity>();
        public void EntitySetup(Entity entity)
        {
            Maps.Add(entity.GetUnikalCoordinates(Maps), entity);
        }
        internal void NewEntitySetup(Entity newEntity)
        {
            Maps.Add(newEntity.coordinates, newEntity);
        }
        public void DeleteEntitys(Coordinates coordinates)
        {
            Maps.Remove(coordinates);
        }
        public bool ThisCoordinatesIsGrass(Coordinates coordinates)
        {
            return Maps.ContainsKey(coordinates) && Maps[coordinates] is Grass;
        }
        public bool IsSquareEmpty(Coordinates coordinates)
        {
            return !Maps.ContainsKey(coordinates);
        }
        internal bool ThisCoordinatesIsRock(Coordinates coordinates)
        {
            return Maps.ContainsKey(coordinates) && Maps[coordinates] is Rock;
        }
        internal bool ThisCoordinatesIsHerbivore(Coordinates coordinates)
        {
            return Maps.ContainsKey(coordinates) && Maps[coordinates] is Herbivore;
        }
        public Coordinates FindNearestFood(Coordinates coordinates, HashSet<Coordinates> coordinatesAllFood)
        {
            Coordinates nearestFood = null;
            int minDistanse = int.MaxValue;
            foreach (var foodCoordinates in coordinatesAllFood)
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
        public HashSet<Coordinates> GetCoordinatesAllGrass()
        {
            HashSet<Coordinates> coordinatesFood = new HashSet<Coordinates>();
            foreach (var entitys in Maps)
            {
                if (ThisCoordinatesIsGrass(entitys.Key)) 
                {
                    coordinatesFood.Add(entitys.Key);
                }
            }
            return coordinatesFood;
        }
        public HashSet<Coordinates> GetCoordinatesAllHerbivore()
        {
            HashSet<Coordinates> coordinatesFood = new HashSet<Coordinates>();
            foreach (var entitys in Maps)
            {
                if (ThisCoordinatesIsHerbivore(entitys.Key))
                {
                    coordinatesFood.Add(entitys.Key);
                }
            }
            return coordinatesFood;
        }

    }
}
