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
        public static int countMoves = 0;
        public static void WriteCountEntitys(Map map)
        {
            countGrass = map.GetAllGrass().Count;
            countHerbivore = map.GetAllHerbivore().Count;
            // space to clear previous number
            Console.SetCursorPosition(0, Program.MAP_WIDTH + 1);
            Console.SetCursorPosition(0, Program.MAP_WIDTH + 1);
            Console.WriteLine($"Count Grass = {countGrass}   ");
            Console.SetCursorPosition(Program.MAP_HEIGTH / 3, Program.MAP_WIDTH + 1);
            Console.Write($"Count Herbivore = {countHerbivore}      ");
            Console.SetCursorPosition((Program.MAP_HEIGTH / 3)*2, Program.MAP_WIDTH + 1);
            Console.Write($"Count Moves = {countMoves}     ");
        }
        public static void StartSimulation(Map map)
        {
            while (!Program.CommandKeyIsPressed())
            {
                NextTurn(map);
            }
        }
        public static Map InitSimulation()
        {
            Map map = new Map();
            Actions actions = new Actions();
            actions.InitActions(map);
            WriteCountEntitys(map);
            return map;
        }
        public static void NextTurn(Map map) 
        {
            Actions actions = new Actions();
            Thread.Sleep(1);
            actions.TurnActions(map);
            WriteCountEntitys(map);
            countMoves++;
        }
    }
}
