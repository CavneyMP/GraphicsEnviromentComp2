using System.Drawing;

namespace GraphicsEnvironmentComp2.Commands
{

    /// <summary>
    /// Required to mark end of if statement operation
    /// </summary>
    public class EndIfCommand : ICommandInterface
    {
        public void Execute(Graphics graphics)
        {
            // Reset the flag
            IfCommand.ResetExecutionFlag();
        }
    }
}
