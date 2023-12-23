using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulationCourse
{
    public struct Pixel
    {
        const string OnePixelSprite = "█";
        public int X { get; }
        public int Y { get; }
        public ConsoleColor color;
        public Pixel(int x, int y, ConsoleColor color)
        {
            X = x;
            Y = y;
            this.color = color;
        }
        public void setOnePixel()
        {
            Console.SetCursorPosition(X, Y);
            Console.ForegroundColor = color;
            Console.WriteLine(OnePixelSprite);
            Console.ResetColor();
        }
    }
}
