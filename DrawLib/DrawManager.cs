using System;

namespace DrawLib
{
    public class DrawManager
    {
        private Frame frame;// { get; set; }
        public void addFrame( double length, double width)
        {
            if (null == frame)  //Now only 1 Frame allowed, assume single thread
                frame = new Frame(length, width);
        }
        public Frame getFrame()
        {
            return frame;
        }
        public int addShape( IShape shape )
        {
            if (frame is null)
                throw new Exception("Frame is not added");
            return frame.addShape(shape);
        }

        /// <summary>
        /// This will be private and wont allow to access from outside
        /// </summary>
        /// <param name="shapeId"></param>
        /// <returns></returns>
        private IShape getShape(int shapeId)
        {
            if (frame is null)
                throw new Exception("Frame is not added");
            return frame.getShape(shapeId);
        }    
        public void MoveShape(int shapeId, Point centreToMove)
        {
            if (frame is null)
                throw new Exception("Frame is not added");
            frame.MoveShape(shapeId, centreToMove);
        } 
        public void ResizeShape(int shapeId, double factorX)
        {
            if (frame is null)
                throw new Exception("Frame is not added");
            if(factorX > 0)
                frame.ResizeShape(shapeId, factorX);
            else
                throw new Exception("Invalid factorX");
        }
    }
}
