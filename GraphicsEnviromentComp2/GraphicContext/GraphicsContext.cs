using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicsEnvironmentComp2.GraphicContext
{
    /
    
    <summary>
    ///This is a class that is defined to maintain the state necessary for the drawing envrioment, it is to hold drawing position, color and pen settings.
    /// </summary>
    public class GraphicsContext
    {
        public Point CurrentPosition { get; private set; }
        public Color CurrentColor { get; private set; }
        public Pen CurrentPen { get; private set; }


        /// <summary>
        /// This initializes the instance of the graphicsContext class
        /// </summary>

        public GraphicsContext()
        {
            CurrentPosition = new Point(0, 0); // Default position
            CurrentColor = Color.Black;        // Default colour
            CurrentPen = new Pen(CurrentColor); // Default pen
        }



        /// <summary>
        /// This updates the current positon
        /// </summary>
        /// <param name="newPosition">The new position that is set</param>

        public void UpdatePosition(Point newPosition)
        {
            CurrentPosition = newPosition;
        }

        /// <summary>
        /// This method updates the colour
        /// </summary>
        /// <param name="newColour"> Needs the colour the user wishes to set to i.e red</param>

        public void UpdateColour(Color newColour)
        {
            CurrentColor = newColour;
            CurrentPen = new Pen(CurrentColor); // Update the pen when colour changes
        }

        /// <summary>
        /// This resets the cursor back to 0,0 which is the far top left
        /// </summary>
        public void Reset()
        {
            CurrentPosition = new Point(0, 0); // Reset to default position
            UpdateColour(Color.Black);          // Reset colour
        }
    }
}
