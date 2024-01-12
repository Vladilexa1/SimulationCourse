using System.Net.Http.Headers;
using SimulationCourse.Entitys;

namespace SimulationCourse
{
    public class Program
    {
        public const int MAP_HEIGTH = 100;
        public const int MAP_WIDTH = 20;
        public const char START_SIMULATION_KEY = '1';
        public const char STOP_SIMULATION_KEY = '2';
        public const char ONE_TURN_KEY = '3';
        public static ConsoleKeyInfo dummyKey = new ConsoleKeyInfo('0', ConsoleKey.D0, false, false, false);
        public static ConsoleKeyInfo pressedKey = new ConsoleKeyInfo('1', ConsoleKey.D1, false, false, false);
        static Map Maps = Simulation.InitSimulation();
        static void Main(string[] args)
        {
            Console.SetWindowSize(MAP_HEIGTH, MAP_WIDTH + 3);
            Console.CursorVisible = false;

            while (true)
            {
                CheckKey();
                Thread.Sleep(100);
            }
        }
        public static void CheckKey()
        {
            if(Console.KeyAvailable) pressedKey = Console.ReadKey(true);
            if (pressedKey == dummyKey) return;
            if (pressedKey.KeyChar == '1') Simulation.StartSimulation(Maps);
            if (pressedKey.KeyChar == '3') Simulation.NextTurn(Maps);
            pressedKey = dummyKey;
        }
        internal static bool CommandKeyIsPressed()
        {
            if (Console.KeyAvailable)
            {
                pressedKey = Console.ReadKey(true);
                if (pressedKey.KeyChar == START_SIMULATION_KEY || 
                    pressedKey.KeyChar == STOP_SIMULATION_KEY || 
                    pressedKey.KeyChar == ONE_TURN_KEY)
                    return true;
            }
            return false;
        }
    }
}
