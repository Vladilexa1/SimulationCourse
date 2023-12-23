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
        public abstract Entity MakeMove(Map map);
        public abstract Coordinates FindNearestFood(Map map, Coordinates coordinates);
        public abstract void EatFood(Map map, Coordinates coordinates);
    }
}
