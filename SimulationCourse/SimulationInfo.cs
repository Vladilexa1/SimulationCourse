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
                if (item.Value is Rock)
                {
                    countRock++;
                }
                if (item.Value is Grass)
                {
                    countGrass++;
                }
                if (item.Value is Herbivore)
                {
                    countHerbivore++;
                }
            }
            Console.WriteLine($"Count Rock = {countRock}" + "  " + $"Count Grass = {countGrass}" + "  " 
                + $"Count Herbivore = {countHerbivore}"); // поправить
        }
        public static void GrassAdd(Map map)
        {
            MapConsoleRenderer mapConsoleRenderer = new MapConsoleRenderer();
            if (countGrass < 10)
            {
                for (int i = 0; i < 100; i++)
                {
                    Grass grass = new Grass();
                    map.EntitySetup(grass);
                    mapConsoleRenderer.RenderOneEntity(grass);
                }
            }
            if (countHerbivore < 3)
            {
                for (int i = 0; i < 10; i++)
                {
                    Herbivore herbivore = new Herbivore();
                    map.EntitySetup(herbivore);
                    mapConsoleRenderer.RenderOneEntity(herbivore);
                }
            }
        }
    }
}
