using GraphicsEnvironmentComp2.Commands;
using System.Drawing;
using static GraphicsEnvironmentComp2.Form1;

public class ClearCommand : ICommandInterface
{
    ///<summary>
    /// A class to instantiate the logic for the clear command that should reset all pixel 
    /// to 244, 244, 244 which is the canvas colour from VS propertys, effectively clearing the canvas.
    /// </summary>
    public ClearCommand()
    {
        // Nothing required...
    }

    /// <summary>
    /// Clears the canvas to the form background colour.
    /// </summary>
    /// <param name="safeGraphics">SafeGraphics instance for thread-safe drawing.</param>
    public void Execute(SafeGraphics safeGraphics)
    {
        safeGraphics.Execute(graphics =>
        {
            graphics.Clear(Color.FromArgb(224, 224, 224)); // Set canvas to the form background colour.
        });
    }
}
