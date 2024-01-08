using Microsoft.VisualStudio.TestTools.UnitTesting;
using GraphicsEnvironmentComp2.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GraphicsEnvironmentComp2.GraphicContext;
using System.Drawing;

namespace GraphicsEnvironmentComp2.Commands.Tests
{
    /// <summary>
    /// This class contains tests for the square command
    /// </summary>
    public class SquareCommandTests
    {
        /// <summary>
        /// We are testing if the square command sucessfully draws a square on a bit map when called, but looking at pixel data.
        /// </summary>
        [TestMethod]
        public void SquareCommand_DrawsSquareCorrectly()
        {
            int squareWidth = 50;
            int squareHeight = 50;
            var context = new GraphicsContext();
            context.UpdatePosition(new Point(10, 10)); //Starting position for the square
            var command = new SquareCommand(squareWidth, squareHeight, context);
            var bmp = new Bitmap(100, 100);
            var graphics = Graphics.FromImage(bmp);

            command.Execute(graphics);
            
            Color expectedColor = Color.Black; // Test color
            Assert.AreEqual(expectedColor, bmp.GetPixel(10, 10)); // Check top-left corner of the square
            Assert.AreEqual(expectedColor, bmp.GetPixel(59, 59)); // Check bottom-right corner inside the square

            // For good pracice
            graphics.Dispose();
            bmp.Dispose();
        }
    }
}