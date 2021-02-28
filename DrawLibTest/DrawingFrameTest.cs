using NUnit.Framework;
using DrawLib;
using System;

namespace DrawLibTest
{
    public class FrameTests
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
        public void ModifyFrameTest()
        {
            Assert.IsNull(drawManager.getFrame());  //No Frames now
            drawManager.addFrame(15, 16);

            Frame f = drawManager.getFrame();
            Assert.AreEqual(f.Width, 16);

            f.ModifyFrame(18, 19); //Should change frame
            Assert.AreNotEqual(f.Length, 18);
            Assert.AreNotEqual(f.Width, 19);
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
    }
}