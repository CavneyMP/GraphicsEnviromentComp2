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
    /// This class allows the user to draw a circle by calling the command.
    /// </summary>
    public class CircleCommand : ICommandInterface
    {
        private readonly int _radius;
        private readonly GraphicsContext _context;

        /// <summary>
        /// Initializes a new instance of the CircleCommand class.
        /// </summary>
        /// <param name="radius">The requested radius of the circle</param>
        /// <param name="context">The graphics context, that hold current drawing data</param>
        public CircleCommand(int radius, GraphicsContext context)
        {
            _radius = radius;
            _context = context;
        }

        /// <summary>
        /// Executes the circle drawing command on the existing graphics.
        /// </summary>
        /// <param name="graphics">The exisiting graphics</param>
        public void Execute(Graphics graphics)
        {
            int diameter = _radius * 2;
            int topLeftX = _context.CurrentPosition.X - _radius;
            int topLeftY = _context.CurrentPosition.Y - _radius;
            graphics.DrawEllipse(new Pen(_context.CurrentColor), topLeftX, topLeftY, diameter, diameter);
        }
    }
}