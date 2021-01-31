using System;
using System.Collections.Generic;
using System.Text;

namespace DrawLib
{
    public class Frame
    {
        private double frameLength;
        private double frameWidth;
        public double Length => frameLength;
        public double Width => frameWidth;

        private Dictionary<int, IShape> shapes;
        public Frame(double length, double width)
        {
            frameLength = length;
            frameWidth = width;
            shapes = new Dictionary<int, IShape>();
        }

        internal bool isFitInsideFrame( IShape shape)
        {

            if (null != shape as Circle)
            {
                Circle circle = shape as Circle;
                Point center = circle.getCenter();
                double radius = circle.getRadius();
                if (0 > (center.x - radius) || 0 > (center.y - radius) ||
                    frameLength < (center.x + radius) || frameWidth < (center.y + radius))
                    return false;
                else
                    return true;
            }
            else
                throw new NotImplementedException(); //TODO Second phase Rectangle
        }
        internal bool isShapeAlreadyAdded(IShape shape)
        {
            if (null != shape as Circle)
            {
                Circle circle = shape as Circle;
                Point center = circle.getCenter();
                double radius = circle.getRadius();
                foreach (KeyValuePair<int, IShape> entry in shapes)
                {
                    if (entry.Value.getCenter().x == center.x && entry.Value.getCenter().y == center.y
                        && (entry.Value as Circle).getRadius() == radius)
                        return false;
                }
                return true;
            }
            throw new NotImplementedException();
        }
        internal int addShape(IShape shape)
        {
            if (isFitInsideFrame(shape))
            {
                if (isShapeAlreadyAdded(shape))
                    shapes.Add(shapes.Count, shape);
            }
            else
                throw new Exception("Shape out of frame");
            return shapes.Count;
        }


        public void updateLength( double length)
        {
            frameLength = length;
        }                                                               
        public void updateWidth( double width)
        {
            frameWidth = width;
        }        
    }
}
