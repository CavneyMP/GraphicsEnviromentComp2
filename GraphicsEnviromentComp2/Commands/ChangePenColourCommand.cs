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
    /// This class represents a command to change the current pen colour that is held in the drawing context to a new colour that the user inputs
    /// </summary>
    public class ChangePenColorCommand : ICommandInterface
    {
        private readonly Color _newColour;
        private readonly GraphicsContext _context;
        
        /// <summary>
        /// This initializes a new instance of the ChangePenColourCommand with a pen colour
        /// </summary>
        /// <param name="newColour"></param>
        /// <param name="context"></param>
        
        public ChangePenColorCommand(Color newColour, GraphicsContext context)
        {
            _newColour = newColour;
            _context = context;
        }

        /// <summary>
        /// Excecutes the command to the graphic context by calling the update colour method.
        /// </summary>
        /// <param name="graphics">The exisiting graphic object, not used here</param>

        public void Execute(Graphics graphics)
        {
            _context.UpdateColor(_newColour);
        }
    }
}
