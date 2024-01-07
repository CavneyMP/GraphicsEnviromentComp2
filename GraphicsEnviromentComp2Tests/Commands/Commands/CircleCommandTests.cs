using Microsoft.VisualStudio.TestTools.UnitTesting;
using GraphicsEnviromentComp2.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GraphicsEnviromentComp2.GraphicContext;
using System.Drawing;

namespace GraphicsEnviromentComp2.Commands.Tests
{

    /// <summary>
    /// Contains tests for Circle Command
    /// </summary>
    [TestClass]
    public class CircleCommandTests
    {

        /// <summary>
        /// This is a Unit test to test if a circle is drawn when we call the circle command.
        /// we set up with radius int pre-set with a new graphics context with a starting point of 100, 100
        /// We call the command circle to draw on the context with the radius variable passed
        /// Then creating a new bitmap
        /// 
        /// We then can assume that the circle has drawn if the centre pixel is not coloured but the relvant top, bottom, left and right of the circle are.
        /// </summary>
        [TestMethod]
        public void CircleCommand_DrawsCircleCorrectly()
        {
            int radius = 50;
            var context = new GraphicsContext();
            context.UpdatePosition(new Point(100, 100)); // Set the center of the circle
            var command = new CircleCommand(radius, context);
            var bmp = new Bitmap(200, 200);
            var graphics = Graphics.FromImage(bmp);

            command.Execute(graphics);

            // Check several points from the starting point of 100, 100 with a 50 radiito verify a circle is drawn.
            Color expectedColor = Color.Black;
            Assert.AreEqual(expectedColor, bmp.GetPixel(100, 50)); // Top of the circle
            Assert.AreEqual(expectedColor, bmp.GetPixel(100, 150)); // Bottom of the circle
            Assert.AreEqual(expectedColor, bmp.GetPixel(50, 100)); // Left of the circle
            Assert.AreEqual(expectedColor, bmp.GetPixel(150, 100)); // Right of the circle
            Assert.AreEqual(Color.Empty.ToArgb(), bmp.GetPixel(100, 100).ToArgb()); // Center of the circle is left uncoloured

            // Clean up
            graphics.Dispose();
            bmp.Dispose();
        }
    }
}