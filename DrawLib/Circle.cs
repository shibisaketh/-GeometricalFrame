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
        public Point getCenter()
        {
            return point;
        }
        public double getRadius()
        {
            return radius;
        }
    }
}
