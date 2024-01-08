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
    /// This is tests class to test the draw too method 
    /// </summary>
    [TestClass()]
    public class DrawToCommandTests
    {
        /// <summary>
        /// Tests if the DrawTOCOmmand correctly updates the graphics object with a line
        /// </summary>
        [TestMethod()]
        public void DrawToCommandTest()
        {
            // Here we are creaing a new graphic context and creating a new point called target position, we then pass the target position to the draw to command and check the cursor moves to.
            var graphicsContext = new GraphicsContext();
            var targetPosition = new Point(10, 10);
            var drawToCommand = new DrawToCommand(targetPosition, graphicsContext);


            // Using bitmap.bitmap https://learn.microsoft.com/en-us/dotnet/api/system.drawing.bitmap?view=dotnet-plat-ext-7.0 Here we are intializing a new instance of thhe bitmap class with the area 100, 100 pixel, and we we can use this as pixel data.
            using (var dummyBitmap = new Bitmap(100, 100))
            using (var dummyGraphics = Graphics.FromImage(dummyBitmap))
            {
                drawToCommand.Execute(dummyGraphics); // Here we are drawing on the dummy Graphics object
            }
            // Check to see if the graphics contexts current position has updated. 
            Assert.AreEqual(targetPosition, graphicsContext.CurrentPosition, "The Graphic contexts position has not updated when draw command called");
         }
    }
}