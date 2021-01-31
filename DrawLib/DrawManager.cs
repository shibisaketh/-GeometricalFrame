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
    }
}
