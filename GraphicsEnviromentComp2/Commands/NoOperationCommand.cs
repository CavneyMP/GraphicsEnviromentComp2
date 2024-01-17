using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GraphicsEnvironmentComp2.GraphicContext;
using GraphicsEnvironmentComp2.Commands;
using GraphicsEnvironmentComp2.Factory;
using static GraphicsEnvironmentComp2.Form1;

namespace GraphicsEnvironmentComp2.Commands
{
    namespace GraphicsEnvironmentComp2.Commands
    {
        /// <summary>
        /// A command that performs no operation
        /// </summary>
        public class NoOpCommand : ICommandInterface
        {
            /// <summary>
            /// Performs no operation.
            /// </summary>
            /// <param name="graphics">Graphics context which is not used in this command.</param>
            public void Execute(SafeGraphics safeGraphics)
            {
                // Nothing is done intentionally. 
            }
        }
    }
}
