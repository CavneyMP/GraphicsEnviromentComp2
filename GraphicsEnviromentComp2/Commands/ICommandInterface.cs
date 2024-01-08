using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicsEnvironmentComp2.Commands
{
    /// <summary>
    /// Here we are creating an interface which will serve as a template for all other commands
    /// This will allow for easier expansion onto assignment two and ensures all methods execute the operations in a linear fashion
    /// </summary>
    public interface ICommandInterface
    {
        /// <summary>
        /// Command will execte using the graphics context. The command will preform what is set in its own class.
        /// </summary>
        /// <param name="graphics">Graphics context to be carried out</param>
        void Execute(Graphics graphics);
    }
}
