using Microsoft.VisualStudio.TestTools.UnitTesting;
using GraphicsEnvironmentComp2.Commands;
using GraphicsEnvironmentComp2.GraphicContext;
using System.Drawing;
using static GraphicsEnvironmentComp2.Form1;

namespace GraphicsEnvironmentComp2.Commands.Tests
{
    [TestClass]
    public class SquareCommandTests
    {
        [TestMethod]
        public void SquareCommand_DrawsSquareCorrectly()
        {
            int squareWidth = 50;
            int squareHeight = 50;
            var context = new GraphicsContext();
            var variableContext = new VariableContext();
            context.UpdatePosition(new Point(10, 10)); // Starting position for the square
            var command = new SquareCommand(squareWidth.ToString(), squareHeight.ToString(), context, variableContext);
            var bmp = new Bitmap(100, 100);
            var graphics = Graphics.FromImage(bmp);

            var safeGraphics = new SafeGraphics(graphics); // Create SafeGraphics object

            command.Execute(safeGraphics);

            Color expectedColour = Color.Black; // Test colour

            // Check points on the border of the square
            Assert.AreEqual(expectedColour, bmp.GetPixel(10, 10)); // Top-left corner of the square
            Assert.AreEqual(expectedColour, bmp.GetPixel(59, 10)); // Top-right corner of the square
            Assert.AreEqual(expectedColour, bmp.GetPixel(10, 59)); // Bottom-left corner of the square
            Assert.AreEqual(expectedColour, bmp.GetPixel(59, 59)); // Bottom-right corner of the square

            // Check points outside the square
            Assert.AreNotEqual(expectedColour, bmp.GetPixel(9, 9)); // Outside top-left
            Assert.AreNotEqual(expectedColour, bmp.GetPixel(60, 60)); // Outside bottom-right

            graphics.Dispose();
            bmp.Dispose();
        }
    }
}
