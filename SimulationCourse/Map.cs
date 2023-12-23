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

        public Map()
        {

        }
        public void EntitySetup(Entity entity)
        {
            Maps.Add(entity.GetUnikalCoordinates(Maps), entity);
        }
        internal void NewEntitySetup(Entity newEntity)
        {
            newEntity.color = Color.Red;
            Maps.Add(newEntity.coordinates, newEntity);
        }
        public void DeleteEntitys(Coordinates coordinates)
        {
            Maps.Remove(coordinates);
        }
        public bool ThisCoordinatesIsGrass(Coordinates coordinates)
        {
            return Maps.ContainsKey(coordinates) && Maps[coordinates] is Grass; //&& Maps[coordinates].GetType() == new Grass().GetType()
        }
        public bool IsSquareEmpty(Coordinates coordinates)
        {
            return !Maps.ContainsKey(coordinates);
        }

        internal bool ThisCoordinatesIsRock(Coordinates coordinates)
        {
            return Maps.ContainsKey(coordinates) && Maps[coordinates] is Rock;
        }
    }
}
