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
    /// A test class to test the move to command for user cursor
    /// </summary>
    [TestClass]
    public class MoveToCommandTests
    {
        /// <summary>
        /// Test to ensure that the current and new position are updated when method us used. 
        /// </summary>
        [TestMethod]
        public void Execute_ShouldUpdateGraphicsContextPosition()
        {
            // Here we are creating a new graphic context and creating a new point called target position, we then pass the target position to the move to command and check the cursor moves to.
            var graphicsContext = new GraphicsContext();
            var targetPosition = new Point(10, 10);
            var moveToCommand = new MoveToCommand(targetPosition, graphicsContext);

            // Using bitmap.bitmap https://learn.microsoft.com/en-us/dotnet/api/system.drawing.bitmap?iew=dotnet-plat-ext-7.0 Here we are intializing a new instance of thhe bitmap class with the area 100, 100 pixel, and we we can use this as pixel data.
            using (var dummyBitmap = new Bitmap(100, 100))
            {
                using (var dummyGraphics = Graphics.FromImage(dummyBitmap))
                {
                    moveToCommand.Execute(dummyGraphics); // Using the dummy Graphics object
                }
            }

            // Assert
            Assert.AreEqual(targetPosition, graphicsContext.CurrentPosition, "The Graphic contexts position has not updated when moveTo command called.");
        }
    }
}