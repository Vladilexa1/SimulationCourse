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
        private Dictionary<Coordinates, Entity> Maps = new Dictionary<Coordinates, Entity>();
        public void EntitySetup(Entity entity)
        {
            Maps.Add(entity.GetUnikalCoordinates(Maps), entity);
        }
        public List<Entity> GetAllEntity()
        {
            return Maps.Values.ToList();
        }
        public Entity GetEntityForCoordinates(Coordinates coordinates)
        {
            return Maps[coordinates];
        }
        public void DeleteEntitys(Coordinates coordinates)
        {
            Maps.Remove(coordinates);
        }
        public bool IsSquareEmpty(Coordinates coordinates)
        {
            return !Maps.ContainsKey(coordinates);
        }
        public bool ThisCoordinatesIsGrass(Coordinates coordinates)
        {
            return Maps.ContainsKey(coordinates) && Maps[coordinates] is Grass;
        }
        internal bool ThisCoordinatesIsHerbivore(Coordinates coordinates)
        {
            return Maps.ContainsKey(coordinates) && Maps[coordinates] is Herbivore;
        }
        internal bool ThisCoordinatesIsPredator(Coordinates coordinates)
        {
            return Maps.ContainsKey(coordinates) && Maps[coordinates] is Predator;
        }
        public Coordinates FindNearestFood(Coordinates coordinates, HashSet<Entity> AllFood)
        {
            Coordinates nearestFood = null;
            int minDistanse = int.MaxValue;
            foreach (var foodCoordinates in AllFood)
            {
                int distanse = coordinates.CalculatedDistanse(coordinates, foodCoordinates.coordinates);
                if (distanse < minDistanse)
                {
                    minDistanse = distanse;
                    nearestFood = foodCoordinates.coordinates;
                }
            }
            return nearestFood;
        }
        public HashSet<Entity> GetAllGrass()
        {
            HashSet<Entity> coordinatesFood = new HashSet<Entity>();
            foreach (var entitys in Maps)
            {
                if (ThisCoordinatesIsGrass(entitys.Key)) 
                {
                    coordinatesFood.Add(entitys.Value);
                }
            }
            return coordinatesFood;
        }
        public HashSet<Entity> GetAllHerbivore()
        {
            HashSet<Entity> coordinatesFood = new HashSet<Entity>();
            foreach (var entitys in Maps)
            {
                if (ThisCoordinatesIsHerbivore(entitys.Key))
                {
                    coordinatesFood.Add(entitys.Value);
                }
            }
            return coordinatesFood;
        }
        public HashSet<Entity> GetAllPredator()
        {
            HashSet<Entity> coordinatesFood = new HashSet<Entity>();
            foreach (var entitys in Maps)
            {
                if (ThisCoordinatesIsPredator(entitys.Key))
                {
                    coordinatesFood.Add(entitys.Value);
                }
            }
            return coordinatesFood;
        }
    }
}
