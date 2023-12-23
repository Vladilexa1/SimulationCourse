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
            
            Console.SetWindowSize(MAP_HEIGTH, MAP_WIDTH + 2 + 25);
            Console.CursorVisible = false;

            

            MapConsoleRenderer mapConsoleRenderer = new MapConsoleRenderer();
            Map map = new Map();
            Actions actions = new Actions();
            actions.InitActions(map);
            SimulationInfo.WriteCountEntitys(map);

            for (int i = 0; i < 1000; i++)
            {
                Thread.Sleep(100);
                actions.MM(map);
               //mapConsoleRenderer.Renderer(map);
                SimulationInfo.WriteCountEntitys(map);
                //mapConsoleRenderer.Renderer(map);
            }
            
            
            Console.ReadLine();
        }
        // переделать постанвку фигур на карту
        // возможно вынести генеринг координт в отдельный класс

    }
}
