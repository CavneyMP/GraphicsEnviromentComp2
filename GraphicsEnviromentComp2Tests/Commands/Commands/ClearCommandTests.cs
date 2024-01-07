using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    /// <summary>
    /// Contains Tests for clear Command
    /// </summary>
    [TestClass()]
    public class ClearCommandTests
    {
        /// <summary>
        /// This tests is to see if the clear command changes the display pixes back to default.
        /// </summary>
        [TestMethod()]
        public void Execute_ShouldClearCanvasWithSpecificColor()
        {
            // Here we are creating a new instance of the clear command and assigning the background colour to a variable
            var clearCommand = new ClearCommand();
            var expectedColour = Color.FromArgb(224, 224, 224);

            // Create a new bitmap to test
            using (var dummyBitmap = new Bitmap(100, 100))
            {
                using (var dummyGraphics = Graphics.FromImage(dummyBitmap))
                {
                    clearCommand.Execute(dummyGraphics); // Using the dummy Graphics object
                }

                // Check if the colour of the pixel at (0, 0) matches the expected color
                var actualColour = dummyBitmap.GetPixel(0, 0);
                Assert.AreEqual(expectedColour, actualColour,
                    "The colour of the pixel at (0, 0) should match the expected background color.");
            }
        }
    }
}