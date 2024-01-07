using GraphicsEnviromentComp2.GraphicContext;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicsEnviromentComp2.Commands
{

    /// <summary>
    /// The MoveToCommand class inherits the IcommandInterface and is there to allow the user to move the cursor of the which the pen is at.
    /// </summary>
    public class MoveToCommand : ICommandInterface
    {
        private Point _newPosition;
        private readonly GraphicsContext _GraphicContext;

        /// <summary>
        /// Ths initializes a new instance of the MoveToCommand with the graphic context and a new specified position
        /// </summary>
        /// <param name="newPosition">The new x, y position to move to</param>
        /// <param name="GraphicContext"> The graphics context that maintains the current state of the panel </param>
        public MoveToCommand(Point newPosition, GraphicsContext GraphicContext)
        {
            _newPosition = newPosition;
            _GraphicContext = GraphicContext;
        }
        /// <summary>
        /// this is the execution method of the icommandInterface which updates the graphic context.
        /// </summary>
        /// <param name="graphics">The graphics object thats needed but is not used here</param>
        public void Execute(Graphics graphics)
        {
            // Update the current position in the drawing context
            _GraphicContext.UpdatePosition(_newPosition);


        }
    }
}
