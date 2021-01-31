using System;
using System.Collections.Generic;
using System.Text;

namespace DrawLib
{
    public class Point
    {
        public double x;
        public double y;

        public Point(int v1, int v2)
        {
            x = v1;
            y = v2;
        }
    }
    public interface IShape
    {
        public Point getCenter();
        //public double getRadius();
    }
}
