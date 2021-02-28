using System;
using System.Collections.Generic;
using System.Text;

namespace DrawLib
{
    public class Frame
    {
        private double frameLength;
        private double frameWidth;
        private double Xmin { get; set; }/// Minimum x needed to draw shapes
        private double Ymin { get; set; }/// Minimum y needed to draw shapes
        public double Length => frameLength;
        public double Width => frameWidth;

        private Dictionary<int, IShape> shapes;
        public Frame(double length, double width)
        {
            frameLength = length;
            frameWidth = width;
            Xmin = Ymin = 0;
            shapes = new Dictionary<int, IShape>();
        }
        public void updateLength(double length)
        {
            frameLength = length;
        }
        public void updateWidth(double width)
        {
            frameWidth = width;
        }

        public bool ModifyFrame(double length, double width)
        {
            if (length > 0 && width < 0 && length >= Xmin && width >= Ymin)
            {
                frameLength = length;
                frameWidth = width;
                return true;
            }
            return false;
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
            else if (null != shape as Rectangle)
            {
                Rectangle rectangle = shape as Rectangle;
                Point origin = rectangle.getCenter();
                if (0 > origin.x || 0 > origin.y || frameLength < (origin.x + rectangle.getLength()) || frameWidth < (origin.y + rectangle.getWidth()))
                    return false;
                else
                    return true;
            }
            else 
                throw new NotImplementedException(); //Other shapes
        }
        internal bool isShapeAlreadyAdded(IShape shape)
        {
            Circle circle = shape as Circle;
            Rectangle rectangle = shape as Rectangle;
            Point center = shape.getCenter();
            foreach (KeyValuePair<int, IShape> entry in shapes)
            {
                if (circle != null && null != entry.Value as Circle)
                {
                    if (entry.Value.getCenter().x == center.x && entry.Value.getCenter().y == center.y
                    && (entry.Value as Circle).getRadius() == circle.getRadius())
                        return false;
                }
                else if (rectangle != null && null != entry.Value as Rectangle)
                {
                    if (entry.Value.getCenter().x == center.x && entry.Value.getCenter().y == center.y
                    && (entry.Value as Rectangle).getLength() == rectangle.getLength()
                    && (entry.Value as Rectangle).getWidth() == rectangle.getWidth())
                        return false;
                }             
            }
            return true;
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
        internal IShape getShape(int shapeId)
        {
            if (shapes.Count > shapeId)
            {
                return shapes[shapeId];
            }
            else
                throw new Exception("No Shape found");
        }
        internal void MoveShape(int shapeId, Point centreToMove)
        {
            if (shapes.Count > shapeId)
            {
                Circle circle = shapes[shapeId] as Circle;
                Rectangle rectangle = shapes[shapeId] as Rectangle;
                if (circle != null)
                {
                    if (circle != null && centreToMove.x + circle.getRadius() < frameLength
                                  && centreToMove.y + circle.getRadius() < frameWidth)
                    {
                        circle.Move(centreToMove);
                    }
                    else
                        throw new Exception("Can't Move! Out of Frame");
                }
                else if (rectangle != null)
                {
                    if (rectangle != null && centreToMove.x + rectangle.getWidth() < frameLength
                                  && centreToMove.y + rectangle.getLength() < frameWidth)
                    {
                        rectangle.Move(centreToMove);
                    }
                    else
                        throw new Exception("Can't Move! Out of Frame");
                }
                else
                    throw new Exception("No Shape found");
            }
        }
        internal void ResizeShape(int shapeId, double factorX)
        {
            if (shapes.Count > shapeId)
            {
                Circle circle =  shapes[shapeId] as Circle;
                Rectangle rectangle =  shapes[shapeId] as Rectangle;
                if (circle != null)
                {
                    if(factorX <= 1 || (factorX > 1 && factorX * circle.getRadius() + circle.getCenter().x < frameLength
                                                 && factorX * circle.getRadius() + circle.getCenter().y < frameWidth
                                                 && factorX * circle.getRadius() - circle.getCenter().x <= 0
                                                 && factorX * circle.getRadius() - circle.getCenter().y <= 0))
                    {
                        circle.Resize(factorX);                        
                    }
                    else
                        throw new Exception("Can't Resize! Out of Frame");
                }
                else if(rectangle != null)
                {
                    if(factorX <= 1 || (factorX > 1 &&  rectangle.getCenter().x + factorX * rectangle.getWidth() < frameLength
                        && rectangle.getCenter().y + factorX * rectangle.getLength() < frameWidth
                        && rectangle.getCenter().x + factorX * rectangle.getWidth() < frameWidth))
                    {
                        rectangle.Resize(factorX);                        
                    }
                    else
                        throw new Exception("Can't Resize! Out of Frame");
                }
                else
                    throw new Exception("Invalid Shape");
            }
            else
                throw new Exception("No Shape found");
        }    
    }
}
