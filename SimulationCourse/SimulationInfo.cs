using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimulationCourse;
using SimulationCourse.Entitys;
namespace SimulationCourse
{
    public static class SimulationInfo
    {
        private static int countRock = 0;
        private static int countGrass = 0;
        public static int countHerbivore = 0;
        private static int countHant;
        public static void WriteCountEntitys(Map map)
        {
            Console.SetCursorPosition(0, 45);
            countRock = 0;
            countGrass = 0;
            countHerbivore = 0;
            foreach (var item in map.Maps)
            {
                if (item.Value.GetType() == new Rock().GetType())
                {
                    countRock++;
                }
                if (item.Value.GetType() == new Grass().GetType())
                {
                    countGrass++;
                }
                if (item.Value.GetType() == new Herbivore().GetType())
                {
                    countHerbivore++;
                }
            }
            Console.WriteLine($"Count Rock = {countRock}" + "  " + $"Count Grass = {countGrass}" + "  " 
                + $"Count Herbivore = {countHerbivore}");
        }
        public static void GrassAdd(Map map)
        {
            if (countGrass == 1)
            {
                for (int i = 0; i < 100; i++)
                {
                    map.EntitySetup(new Grass() { coordinates = new Coordinates(6, 8) });
                }
            }
        }
    }
}
