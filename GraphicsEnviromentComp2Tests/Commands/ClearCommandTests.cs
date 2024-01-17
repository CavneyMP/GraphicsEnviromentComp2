using Microsoft.VisualStudio.TestTools.UnitTesting;
using GraphicsEnvironmentComp2.Commands;
using System.Drawing;
using static GraphicsEnvironmentComp2.Form1;

namespace Tests
{
    /// <summary>
    /// Contains Tests for Clear Command
    /// </summary>
    [TestClass()]
    public class ClearCommandTests
    {
        /// <summary>
        /// This test is to see if the ClearCommand changes the display pixels back to default.
        /// </summary>
        [TestMethod()]
        public void Execute_ShouldClearCanvasWithSpecificColor()
        {
            // Create a new instance of the ClearCommand
            var clearCommand = new ClearCommand();
            var expectedColour = Color.FromArgb(224, 224, 224); // Background colour

            // Create a new bitmap to test
            using (var dummyBitmap = new Bitmap(100, 100))
            {
                using (var dummyGraphics = Graphics.FromImage(dummyBitmap))
                {
                    var safeGraphics = new SafeGraphics(dummyGraphics); // Create SafeGraphics object
                    clearCommand.Execute(safeGraphics); // Execute ClearCommand with SafeGraphics
                }

                // Check if the colour of the pixel at (0, 0) matches the expected color
                var actualColour = dummyBitmap.GetPixel(0, 0);
                Assert.AreEqual(expectedColour, actualColour,
                    "The colour of the pixel at (0, 0) should match the expected background color.");
            }
        }
    }
}
