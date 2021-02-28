using System;
using DrawLib;

namespace DrawClient
{
    class Program
    {
        static void Main(string[] args)
        {
            DrawManager drawManager = new DrawManager();
            drawManager.addFrame(25, 25);
            IShape shape = new Circle(new Point(5, 5), 2);

            drawManager.addShape(shape);
            shape.Draw();

            drawManager.MoveShape(0, new Point(7,8));
            shape.Draw();
            drawManager.ResizeShape(0, 2);
            shape.Draw();

            Console.WriteLine("Hello World!");
            
        }
    }
}
