using GraphicsEnviromentComp2.Commands;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class ClearCommand : ICommandInterface
{

    /// <summary>
    /// A class to instantiate the logic for the clear command that should reset all pixel to 244, 244, 244 which is the canvas colour from VS propertys, effectivly clearing the canvas.
    /// </summary>
    public ClearCommand()
    {
        // Nothing required...
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="graphics"></param>
    public void Execute(Graphics graphics)
    {
        graphics.Clear(Color.FromArgb(224, 224, 224)); // Set canvas to the form background colour. 
    }
}


