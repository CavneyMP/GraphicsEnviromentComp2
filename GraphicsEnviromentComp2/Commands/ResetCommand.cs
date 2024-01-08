using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GraphicsEnvironmentComp2.GraphicContext;
using GraphicsEnvironmentComp2.Commands;
using GraphicsEnvironmentComp2.Factory;



namespace GraphicsEnvironmentComp2.Commands
{

    /// <summary>
    /// This is the reset command implementation and will intend to reset the cursor back to 0, 0 which is the far top left 
    /// </summary>
    public class ResetCommand : ICommandInterface

    {
        private readonly GraphicsContext _GraphicContext;

        /// <summary>
        /// This initizalises a new instance of the reset command
        /// </summary>
        /// <param name="GraphicContext">The graphic context that has the cursor reset on</param>

        public ResetCommand(GraphicsContext GraphicContext)
        {
            _GraphicContext = GraphicContext;

        }
        /// <summary>
        /// This executes the command, resetting the cursor position in the graphic context to the orgin back to 0, 0 which is the far top left 
        /// </summary>
        /// <param name="graphics"></param>
        public void Execute(Graphics graphics)
        {
            _GraphicContext.Reset();
        }
    }
}



