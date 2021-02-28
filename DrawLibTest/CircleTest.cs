using NUnit.Framework;
using DrawLib;
using System;

namespace DrawLibTest
{
    public class CircleTests
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
        public void AddCircle()
        {
            drawManager.addFrame(10, 12);
            IShape shape = new Circle(new Point(5, 5), 3);
            Assert.AreEqual(1, drawManager.addShape(shape));
        }
       [Test]
        public void AddCircleWithoutFrame()
        {
            try
            {
                IShape shape = new Circle(new Point(5, 5), 6);
                drawManager.addShape(shape);
            }
            catch (Exception ex)
            {
                Assert.IsTrue(true, ex.Message);
            }
           
        }       
        
        [Test]
        public void Add2Circle()
        {
            drawManager.addFrame(50, 60);
            IShape shape = new Circle(new Point(20, 28), 12);
            Assert.AreEqual(1, drawManager.addShape(shape));
            IShape shape2 = new Circle(new Point(7, 7), 6);
            Assert.AreEqual(2, drawManager.addShape(shape2));

        }
        [Test]
        public void OutofFrame()
        {
            drawManager.addFrame(10, 10);
            IShape shape = new Circle(new Point(2, 5), 16);
            Assert.Throws<Exception>(() => drawManager.addShape(shape));
        }
        [Test] 
        public void AddSameCircle()
        {
            drawManager.addFrame(50, 60);
            IShape shape = new Circle(new Point(20, 28), 12);
            Assert.AreEqual(1, drawManager.addShape(shape));
            IShape shape2 = new Circle(new Point(7, 7), 6);
            Assert.AreEqual(2, drawManager.addShape(shape2));
            IShape shape3 = new Circle(new Point(20, 28), 12);
            Assert.AreEqual(2, drawManager.addShape(shape3)); //Not added, count not increesed
        }
        [Test] 
        public void MoveCircle()
        {
            drawManager.addFrame(50, 60);
            IShape shape = new Circle(new Point(20, 28), 12);
            shape.Move(new Point(5, 5));
            Assert.AreEqual(5, shape.getCenter().x);
            Assert.AreEqual(5, shape.getCenter().y);
            
        }
        [Test]
        public void ResizeCircle()
        {
            drawManager.addFrame(50, 60);
            Circle shape = new Circle(new Point(20, 28), 12);
            shape.Resize(2);
            Assert.AreEqual(24, shape.getRadius());

        }
        [Test] 
        public void MoveCircleinFrame()
        {
            drawManager.addFrame(50, 60);
            IShape shape = new Circle(new Point(20, 28), 12);
            Assert.AreEqual(1, drawManager.addShape(shape));

            drawManager.MoveShape(0, new Point(7, 8));
            Assert.AreEqual(7, shape.getCenter().x);
            Assert.AreEqual(8, shape.getCenter().y);
            
        }   
        [Test] 
        public void ResizeCircleinFrame()
        {
            drawManager.addFrame(50, 60);
            Circle shape = new Circle(new Point(20, 28), 8);
            Assert.AreEqual(1, drawManager.addShape(shape));

            drawManager.ResizeShape(0, 1.5);
            Assert.AreEqual(12, shape.getRadius());
            
        }     
        [Test] 
        public void DrawCircle()
        {
            drawManager.addFrame(50, 60);
            IShape shape = new Circle(new Point(20, 28), 12);
            shape.Draw();
        } 
        [Test] 
        public void getCircleShape()
        {
            drawManager.addFrame(50, 60);
            IShape shape = new Circle(new Point(20, 28), 12);
            Assert.AreEqual(1, drawManager.addShape(shape));
            //IShape shape2 = drawManager.getShape(0);
            Assert.AreEqual(20, shape.getCenter().x);
            Assert.AreEqual(28, shape.getCenter().y);
        }

        [Test]
        public void ResizeandMoveCircleinFrame()
        {
            drawManager.addFrame(50, 60);
            Circle shape = new Circle(new Point(10, 12), 10);
            Assert.AreEqual(1, drawManager.addShape(shape));
            try
            {
                drawManager.ResizeShape(0, 1.5);    //fail wont change resize
            }
            catch (Exception ex)
            {
                Assert.IsTrue(true, ex.Message);
                Assert.AreEqual(10, shape.getRadius());
            }
            drawManager.MoveShape(0, new Point(12,14));
            Assert.AreEqual(12, shape.getCenter().x);
            Assert.AreEqual(14, shape.getCenter().y);
        }
        [Test]
        public void ResizeandMoveCircleinFrame2()
        {
            drawManager.addFrame(50, 60);
            Circle shape = new Circle(new Point(30, 32), 18);
            Assert.AreEqual(1, drawManager.addShape(shape));
            try
            {
                drawManager.ResizeShape(0, 1.5);    //fail wont change resize
            }
            catch (Exception ex)
            {
                Assert.IsTrue(true, ex.Message);
                Assert.AreEqual(18, shape.getRadius());
            }
            drawManager.MoveShape(0, new Point(12,14));
            Assert.AreEqual(12, shape.getCenter().x);
            Assert.AreEqual(14, shape.getCenter().y);
        }

        [Test]
        public void ResizeCircleOutFrame()
        {
            drawManager.addFrame(50, 60);
            Circle shape = new Circle(new Point(10, 12), 10);
            Assert.AreEqual(1, drawManager.addShape(shape));

            try
            {
                drawManager.ResizeShape(0, 2);
                Assert.AreEqual(10, shape.getRadius());
            }
            catch (Exception ex)
            {
                Assert.IsTrue(true, ex.Message);
                Assert.AreEqual(10, shape.getRadius());
            }

        }
    }
}