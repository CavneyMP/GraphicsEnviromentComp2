using Microsoft.VisualStudio.TestTools.UnitTesting;
using GraphicsEnvironmentComp2.Commands;
using GraphicsEnvironmentComp2.GraphicContext;
using System.Drawing;

namespace GraphicsEnvironmentComp2.Commands.Tests
{
    [TestClass()]
    public class DrawToCommandTests
    {
        [TestMethod()]
        public void DrawToCommandTest()
        {

            var graphicsContext = new GraphicsContext();
            var variableContext = new VariableContext();
            string xParameter = "10";
            string yParameter = "10";
            var drawToCommand = new DrawToCommand(xParameter, yParameter, graphicsContext, variableContext);

            using (var dummyBitmap = new Bitmap(100, 100))
            using (var dummyGraphics = Graphics.FromImage(dummyBitmap))
            {
                drawToCommand.Execute(dummyGraphics);
            }

            var targetPosition = new Point(10, 10); // The expected position after drawing
            Assert.AreEqual(targetPosition, graphicsContext.CurrentPosition, "The Graphic contexts position has not updated when draw command called");
        }
    }
}
