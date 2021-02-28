using System;
using System.Collections.Generic;
using System.Text;

namespace DrawLib
{
    public class Rectangle : IShape
    {
        Point point; //Origin assume as center
        double Length, Width;
        public Rectangle( Point pt, double length,double width )
        {
            point = pt;
            Length = length;
            Width = width;
        }

        public void Draw()
        {
            Console.WriteLine("Rectangle Origin (" + point.x.ToString()+ ", " +
                                point.y.ToString() + ") H: "+ Length.ToString()+"W: "+ Width.ToString());
        }

        public Point getCenter()
        {
            return point;
        }
        public double getLength()
        {
            return Length;
        }
        public double getWidth()
        {
            return Width;
        } 
        public void Move(Point originMoveToPoint)
        {
            if (originMoveToPoint.x >= 0 && originMoveToPoint.y >= 0)
            {
                point = originMoveToPoint;
                Console.WriteLine("Rectangle Moved");
            }
        }

        public void Resize(double resizeFactor)
        {
            if (resizeFactor > 0)
            {
                Width *= resizeFactor;
                Length *= resizeFactor;
                Console.WriteLine("Rectangle Resized");
            }
            
        }
    }
}
