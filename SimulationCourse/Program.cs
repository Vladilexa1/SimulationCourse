using System.Net.Http.Headers;
using SimulationCourse.Entitys;

namespace SimulationCourse
{
    public class Program
    {
        public const int MAP_HEIGTH = 100;
        public const int MAP_WIDTH = 20;
        static void Main(string[] args)
        {
            Console.SetWindowSize(MAP_HEIGTH, MAP_WIDTH + 3);
            Console.CursorVisible = false;

            Simulation.StartSimulation();

            
            Console.ReadLine();
        }
        

    }
}
