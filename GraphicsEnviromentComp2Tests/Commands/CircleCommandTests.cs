﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using GraphicsEnvironmentComp2.GraphicContext;
using System.Drawing;
using GraphicsEnvironmentComp2.Commands;
using static GraphicsEnvironmentComp2.Form1;

namespace ASEGraphicAssignment.Commands.Tests
{
    
    ///<summary>
    /// Contains tests for Circle Command
    /// </summary>
    [TestClass]
    public class CircleCommandTests
    {
        /// <summary>
        /// Tests if a circle is drawn correctly by the CircleCommand.
        /// A circle is drawn on a bitmap, and the colours of specific points are checked.
        /// </summary>
        [TestMethod]
        public void CircleCommand_DrawsCircleCorrectly()
        {
            string radius = "50"; // Radius as a string
            var context = new GraphicsContext();
            context.UpdatePosition(new Point(100, 100)); // Set the centre of the circle

            var variableContext = new VariableContext();
            var command = new CircleCommand(radius, context, variableContext);
            var bmp = new Bitmap(200, 200);
            var graphics = Graphics.FromImage(bmp);
            var safeGraphics = new SafeGraphics(graphics);

            command.Execute(safeGraphics);

            int expectedArgb = Color.Black.ToArgb();
            // Check several points from the starting point of 100, 100 with a 50 radius to verify a circle is drawn.
            Assert.AreEqual(expectedArgb, bmp.GetPixel(100, 50).ToArgb(), "Top of the circle is not the expected color.");
            Assert.AreEqual(expectedArgb, bmp.GetPixel(100, 150).ToArgb(), "Bottom of the circle is not the expected color.");
            Assert.AreEqual(expectedArgb, bmp.GetPixel(50, 100).ToArgb(), "Left of the circle is not the expected color.");
            Assert.AreEqual(expectedArgb, bmp.GetPixel(150, 100).ToArgb(), "Right of the circle is not the expected color.");
            Assert.AreEqual(Color.Empty.ToArgb(), bmp.GetPixel(100, 100).ToArgb(), "Center of the circle should not be colored.");

            graphics.Dispose();
            bmp.Dispose();
        }
    }
}
