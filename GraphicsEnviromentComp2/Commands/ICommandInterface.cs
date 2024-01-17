using GraphicsEnvironmentComp2; // Ensure SafeGraphics is accessible
using System.Drawing;

namespace GraphicsEnvironmentComp2.Commands
{
    /// <summary>
    /// Interface serving as a template for all commands.
    /// Ensures all methods execute the operations in a linear fashion.
    /// </summary>
    public interface ICommandInterface
    {
        /// <summary>
        /// Executes the command using the provided SafeGraphics instance.
        /// </summary>
        /// <param name="safeGraphics">SafeGraphics instance for thread-safe drawing.</param>
        void Execute(Form1.SafeGraphics safeGraphics);
    }
}
