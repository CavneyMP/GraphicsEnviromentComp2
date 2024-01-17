using System.Drawing;
using static GraphicsEnvironmentComp2.Form1;

namespace GraphicsEnvironmentComp2.Commands
{

    /// <summary>
    /// Required to mark end of if statement operation
    /// </summary>
    public class EndIfCommand : ICommandInterface
    {
        public void Execute(SafeGraphics safeGraphics)
        {
            // Reset the flag
            IfCommand.ResetExecutionFlag();
        }
    }
}
