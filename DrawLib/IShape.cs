using System;
using System.Collections.Generic;
using System.Text;

namespace DrawLib
{
    public interface IShape
    {
        public Point getCenter();
        
        public void Move(Point centreMoveToPoint);
        public void Resize(double resizeFactor);
        public void Draw();
    }
}
