using System;
using System.Collections.Generic;
using System.Text;

namespace DrawLib
{
    public class Circle : IShape
    {
        Point point;
        double radius;
        public Circle( Point pt, double rad)
        {
            point = pt;
            radius = rad;
        }

        public void Draw()
        {
            Console.WriteLine("Circle (" + point.x.ToString()+ ", " +
                                point.y.ToString() + ")  Radius: "+ radius.ToString());
        }

        public Point getCenter()
        {
            return point;
        }
        public double getRadius()
        {
            return radius;
        }

        public void Move(Point centreMoveToPoint)
        {
            if (centreMoveToPoint.x >= 0 && centreMoveToPoint.y >= 0)
            {
                point = centreMoveToPoint;
                Console.WriteLine("Circle Moved");
            }
        }

        public void Resize(double resizeFactor)
        {
            if (resizeFactor > 0)
            {
                radius *= resizeFactor;
                Console.WriteLine("Circle Resized");
            }
            
        }
    }
}
