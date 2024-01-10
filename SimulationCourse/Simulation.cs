using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimulationCourse;
using SimulationCourse.Entitys;
namespace SimulationCourse
{
    public static class Simulation
    {
        public static int countRock = 0;
        public static int countGrass = 0;
        public static int countHerbivore = 0;
        public static void WriteCountEntitys(Map map)
        {
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
            // space to clear previous number
            Console.SetCursorPosition(0, Program.MAP_WIDTH + 1);
            Console.SetCursorPosition(0, Program.MAP_WIDTH + 1);
            Console.WriteLine($"Count Rock = {countRock}   ");
            Console.SetCursorPosition(Program.MAP_HEIGTH / 3, Program.MAP_WIDTH + 1);
            Console.Write($"Count Grass = {countGrass}      ");
            Console.SetCursorPosition((Program.MAP_HEIGTH / 3)*2, Program.MAP_WIDTH + 1);
            Console.Write($"Count Herbivore = {countHerbivore}     ");
        }
        public static void StartSimulation()
        {
            Map map = new Map();
            Actions actions = new Actions();
            actions.InitActions(map);
            WriteCountEntitys(map);
            while (true)
            {
                NextTurn(map);
            }
        }
        public static void NextTurn(Map map) 
        {
            Actions actions = new Actions();
            Thread.Sleep(1);
            actions.turnActions(map);
            WriteCountEntitys(map);
        }
        public static void PauseSimulation()
        {
            Console.ReadKey();
        }
    }
}
