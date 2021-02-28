using NUnit.Framework;
using DrawLib;
using System;

namespace DrawLibTest
{
    public class RectangleTests
    {
        private DrawManager drawManager;
        [SetUp]
        public void Setup()
        {
            drawManager = new DrawManager();
        }
        [TearDown]
        public void Clean()
        {
            drawManager = null;
        }
        [Test]
        public void AddRectangle()
        {
            drawManager.addFrame(10, 12);
            IShape shape = new Rectangle(new Point(5, 5), 3,4);
            Assert.AreEqual(1, drawManager.addShape(shape));
        }
       [Test]
        public void AddRectangleWithoutFrame()
        {
            try
            {
                IShape shape = new Rectangle(new Point(5, 5), 6,4);
                drawManager.addShape(shape);
            }
            catch (Exception ex)
            {
                Assert.IsTrue(true, ex.Message);
            }
           
        }       
        
        [Test]
        public void Add2Rectangle()
        {
            drawManager.addFrame(50, 60);
            IShape shape = new Rectangle(new Point(20, 28), 12,6);
            Assert.AreEqual(1, drawManager.addShape(shape));
            IShape shape2 = new Rectangle(new Point(7, 7),6,4);
            Assert.AreEqual(2, drawManager.addShape(shape2));

        }
        [Test]
        public void OutofFrame()
        {
            drawManager.addFrame(10, 10);
            IShape shape = new Rectangle(new Point(2, 5), 16,6);
            Assert.Throws<Exception>(() => drawManager.addShape(shape));
        }
        [Test] 
        public void AddSameRectangle()
        {
            drawManager.addFrame(50, 60);
            IShape shape = new Rectangle(new Point(20, 28), 12, 16);
            Assert.AreEqual(1, drawManager.addShape(shape));
            IShape shape2 = new Rectangle(new Point(7, 7), 6, 16);
            Assert.AreEqual(2, drawManager.addShape(shape2));
            IShape shape3 = new Rectangle(new Point(7, 7), 6, 16);
            Assert.AreEqual(2, drawManager.addShape(shape3)); //Not added, count not increesed
        }
        [Test] 
        public void MoveRectangle()
        {
            drawManager.addFrame(50, 60);
            IShape shape = new Rectangle(new Point(20, 28), 12, 12);
            shape.Move(new Point(5, 5));
            Assert.AreEqual(5, shape.getCenter().x);
            Assert.AreEqual(5, shape.getCenter().y);
            
        }
        [Test]
        public void ResizeRectangle()
        {
            drawManager.addFrame(50, 60);
            Rectangle shape = new Rectangle(new Point(20, 28), 12, 12);
            shape.Resize(2);
            Assert.AreEqual(24, shape.getLength());

        }
        [Test] 
        public void MoveRectangleinFrame()
        {
            drawManager.addFrame(50, 60);
            IShape shape = new Rectangle(new Point(20, 28),1,2);
            Assert.AreEqual(1, drawManager.addShape(shape));

            drawManager.MoveShape(0, new Point(7, 8));
            Assert.AreEqual(7, shape.getCenter().x);
            Assert.AreEqual(8, shape.getCenter().y);
            
        }   
        [Test] 
        public void ResizeRectangleinFrame()
        {
            drawManager.addFrame(50, 60);
            Rectangle shape = new Rectangle(new Point(20, 28), 8,8);
            Assert.AreEqual(1, drawManager.addShape(shape));

            drawManager.ResizeShape(0, 1.5);
            Assert.AreEqual(12, shape.getLength());
            
        }     
        [Test] 
        public void DrawRectangle()
        {
            drawManager.addFrame(50, 60);
            IShape shape = new Rectangle(new Point(20, 28), 12,8);
            shape.Draw();
        } 
        [Test] 
        public void getRectangleShape()
        {
            drawManager.addFrame(50, 60);
            IShape shape = new Rectangle(new Point(20, 28), 12,11);
            Assert.AreEqual(1, drawManager.addShape(shape));
            //IShape shape2 = drawManager.getShape(0);
            Assert.AreEqual(20, shape.getCenter().x);
            Assert.AreEqual(28, shape.getCenter().y);
        }

        [Test]
        public void ResizeandMoveRectangleinFrame()
        {
            drawManager.addFrame(50, 60);
            Rectangle shape = new Rectangle(new Point(10, 12), 35,11);
            Assert.AreEqual(1, drawManager.addShape(shape));
            try
            {
                drawManager.ResizeShape(0, 2.5);    //fail  resize wont change
            }
            catch (Exception ex)
            {
                Assert.IsTrue(true, ex.Message);
                Assert.AreEqual(35, shape.getLength());
            }
            drawManager.MoveShape(0, new Point(12,14));
            Assert.AreEqual(12, shape.getCenter().x);
            Assert.AreEqual(14, shape.getCenter().y);
        }
        [Test]
        public void ResizeandMoveRectangleinFrame2()
        {
            drawManager.addFrame(50, 60);
            Rectangle shape = new Rectangle(new Point(30, 32),5,2);
            Assert.AreEqual(1, drawManager.addShape(shape));
            try
            {
                drawManager.ResizeShape(0, 1.5);    //fail wont change resize
            }
            catch (Exception ex)
            {
                Assert.IsTrue(true, ex.Message);
                Assert.AreEqual(2, shape.getWidth());
            }
            drawManager.MoveShape(0, new Point(12,14));
            Assert.AreEqual(12, shape.getCenter().x);
            Assert.AreEqual(14, shape.getCenter().y);
        }

        [Test]
        public void ResizeRectangleOutFrame()
        {
            drawManager.addFrame(50, 60);
            Rectangle shape = new Rectangle(new Point(10, 12),5,2);
            Assert.AreEqual(1, drawManager.addShape(shape));

            try
            {
                drawManager.ResizeShape(0, 2);
                Assert.AreEqual(10, shape.getLength());
            }
            catch (Exception ex)
            {
                Assert.IsTrue(true, ex.Message);
                Assert.AreEqual(10, shape.getLength());
            }

        }
    }
}