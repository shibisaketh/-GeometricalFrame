using NUnit.Framework;
using DrawLib;
using System;

namespace DrawLibTest
{
    public class Tests
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
        public void FrameAdd()
        {
            Assert.IsNull(drawManager.getFrame());  //No Frames now

            drawManager.addFrame(5, 6);
            Assert.IsNotNull(drawManager.getFrame());
        } 
        [Test]
        public void ChangeFrameSize()
        {
            Assert.IsNull(drawManager.getFrame());  //No Frames now

            drawManager.addFrame(5, 6);
            Frame frame = drawManager.getFrame();
            frame.updateLength(10);
            frame.updateWidth(20);
            Assert.AreEqual(drawManager.getFrame().Length, 10);
            Assert.AreEqual(drawManager.getFrame().Width, 20);
        }      
        [Test]
        public void SingleFrame()
        {
            Assert.IsNull(drawManager.getFrame());  //No Frames now

            drawManager.addFrame(5, 6);
            Assert.IsNotNull(drawManager.getFrame());
            
            drawManager.addFrame(8, 9); //Should not add new frame
            Frame f = drawManager.getFrame();

            Assert.AreNotEqual(f.Length, 8);
            Assert.AreNotEqual(f.Width, 9);
        }
        [Test]
        public void FrameLength()
        {
            Assert.IsNull(drawManager.getFrame());  //No Frames now

            drawManager.addFrame(5, 6);

            Frame f = drawManager.getFrame();
            Assert.AreEqual(f.Length, 5);

            drawManager.addFrame(8, 9); //Should not add new frame
            Assert.AreNotEqual(f.Length, 8);

            f.updateLength(10);
            Assert.AreEqual(f.Length, 10);
        }
        [Test]
        public void FrameWidth()
        {
            Assert.IsNull(drawManager.getFrame());  //No Frames now

            drawManager.addFrame(5, 6);

            Frame f = drawManager.getFrame();
            Assert.AreEqual(f.Width, 6);

            drawManager.addFrame(8, 9); //Should not add new frame
            Assert.AreNotEqual(f.Width, 9);
            f.updateWidth(12);
            Assert.AreEqual(f.Width, 12);
        }
        [Test]
        public void FrameFlow()
        {
            Assert.IsNull(drawManager.getFrame());  //No Frames now

            drawManager.addFrame(5, 6);
            Assert.IsNotNull(drawManager.getFrame());

            Frame f = drawManager.getFrame();
            Assert.AreEqual(f.Length, 5);
            Assert.AreEqual(f.Width, 6);

            drawManager.addFrame(8, 9); //Should not add new frame
            Assert.AreNotEqual(f.Length, 8);
            Assert.AreNotEqual(f.Width, 9);

            f.updateLength(10);
            Assert.AreEqual(f.Length, 10);

            f.updateWidth(12);
            Assert.AreEqual(f.Width, 12);
        }
        [Test]
        public void NoFrame()
        {
            try
            {
                IShape shape = new Circle(new Point(5, 5), 6);
                Assert.Throws<Exception>(() => drawManager.addShape(shape));
            }
            catch( Exception ex)
            {
                Assert.IsTrue(false, "Exception occured");
            }
        }
        [Test]
        public void AddCircle()
        {
            drawManager.addFrame(10, 12);
            IShape shape = new Circle(new Point(5, 5), 3);
            Assert.AreEqual(1, drawManager.addShape(shape));
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
        public void AddSameCircle()
        {
            drawManager.addFrame(50, 60);
            IShape shape = new Circle(new Point(20, 28), 12);
            Assert.AreEqual(1, drawManager.addShape(shape));
            IShape shape2 = new Circle(new Point(7, 7), 6);
            Assert.AreEqual(2, drawManager.addShape(shape2));
            IShape shape3 = new Circle(new Point(20, 28), 12);
            Assert.AreEqual(2, drawManager.addShape(shape3)); //Not added, count not increesed
        }    }
}