using Microsoft.VisualStudio.TestTools.UnitTesting;
using GraphicsEnviromentComp2.GraphicContext;
using System.Drawing;
using GraphicsEnviromentComp2.Commands;

namespace ASEGraphicAssignment.Commands.Tests
{
    /// <summary>
    /// Contains tests for Circle Command
    /// </summary>
    [TestClass]
    public class CircleCommandTests
    {
        /// <summary>
        /// Tests if a circle is drawn correctly by the CircleCommand.
        /// A circle is drawn on a bitmap and the colors of specific points are checked.
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

            // Check several points from the starting point of 100, 100 with a 50 radius to verify a circle is drawn.
            int expectedArgb = Color.Black.ToArgb();
            Assert.AreEqual(expectedArgb, bmp.GetPixel(100, 50).ToArgb(), "Top of the circle is not the expected color."); // Top of the circle
            Assert.AreEqual(expectedArgb, bmp.GetPixel(100, 150).ToArgb(), "Bottom of the circle is not the expected color."); // Bottom of the circle
            Assert.AreEqual(expectedArgb, bmp.GetPixel(50, 100).ToArgb(), "Left of the circle is not the expected color."); // Left of the circle
            Assert.AreEqual(expectedArgb, bmp.GetPixel(150, 100).ToArgb(), "Right of the circle is not the expected color."); // Right of the circle
            Assert.AreEqual(Color.Empty.ToArgb(), bmp.GetPixel(100, 100).ToArgb(), "Center of the circle should not be colored."); // Center of the circle is left uncoloured

            // Clean up
            graphics.Dispose();
            bmp.Dispose();
        }
    }
}
