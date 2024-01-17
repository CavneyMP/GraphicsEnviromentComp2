using Microsoft.VisualStudio.TestTools.UnitTesting;
using GraphicsEnvironmentComp2.Commands;
using GraphicsEnvironmentComp2.GraphicContext;
using System.Drawing;
using static GraphicsEnvironmentComp2.Form1;

namespace GraphicsEnvironmentComp2.Commands.Tests
{
    /// <summary>
    /// A test class to test the MoveToCommand for user cursor.
    /// </summary>
    [TestClass]
    public class MoveToCommandTests
    {
        /// <summary>
        /// Test to ensure that the current and new position are updated when method is used.
        /// </summary>
        [TestMethod]
        public void Execute_ShouldUpdateGraphicsContextPosition()
        {
            // Arrange
            var graphicsContext = new GraphicsContext();
            var variableContext = new VariableContext();
            var targetPosition = new Point(10, 10);
            var moveToCommand = new MoveToCommand(targetPosition.X.ToString(), targetPosition.Y.ToString(), graphicsContext, variableContext);

            // Act
            using (var dummyBitmap = new Bitmap(100, 100))
            {
                using (var dummyGraphics = Graphics.FromImage(dummyBitmap))
                {
                    var safeGraphics = new SafeGraphics(dummyGraphics); 
                    moveToCommand.Execute(safeGraphics); 
                }
            }

            // Assert
            Assert.AreEqual(targetPosition, graphicsContext.CurrentPosition, "The Graphic Context's position should update when MoveTo command is called.");
        }
    }
}
