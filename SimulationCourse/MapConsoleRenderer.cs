using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimulationCourse.Entitys;

namespace SimulationCourse
{
    public class MapConsoleRenderer
    {
        private const int X_SIZE = Program.MAP_HEIGTH;
        private const int Y_SIZE = Program.MAP_WIDTH;
        
        public void Renderer(Map map)
        {
            RenderEntity(map);
        }
        public void SetBorderMap(Rock rock)
        {
            ConsoleColor colorSprite = colorizePixel(rock);
            for (int i = 0; i < X_SIZE; i++)
            {
                new Pixel(i, 0, colorSprite).setOnePixel();
                new Pixel(i, Y_SIZE - 1, colorSprite).setOnePixel();
            }
            for (int i = 0; i < Y_SIZE; i++)
            {
                new Pixel(0, i, colorSprite).setOnePixel();
                new Pixel(X_SIZE - 1, i, colorSprite).setOnePixel();
            }
        }
        private void RenderEntity(Map map)
        {
            foreach (var item in map.Maps)
            {
                new Pixel(item.Key.X, item.Key.Y, colorizePixel(item.Value)).setOnePixel();
            }
        }
        public void DeleteEntitys(Coordinates coordinates)
        {
            Console.SetCursorPosition(coordinates.X, coordinates.Y);
            Console.Write(" ");
        }
        public void RenderOneEntity(Entity entity)
        {
            Console.SetCursorPosition(entity.coordinates.X, entity.coordinates.Y);
            new Pixel(entity.coordinates.X, entity.coordinates.Y, colorizePixel(entity)).setOnePixel();
        }
        private ConsoleColor colorizePixel(Entity entity)
        {
            switch (entity.color)
            {
                case Color.Red:
                    return ConsoleColor.Red;
                case Color.Green:
                    return ConsoleColor.Green;
                case Color.Blue:
                    return ConsoleColor.Blue;
                case Color.Grey:
                    return ConsoleColor.DarkGray;
                default:
                    return ConsoleColor.Yellow;
            }
        }
    }
}
