using GraphicsEnvironmentComp2.GraphicContext;
using System.Drawing;

namespace GraphicsEnvironmentComp2.Commands
{
    /// <summary>
    /// This class allows the user to draw a circle by calling the command.
    /// </summary>
    public class CircleCommand : ICommandInterface
    {
        private readonly string _radiusParameter;
        private readonly GraphicsContext _context;
        private readonly VariableContext _VariableContext;

        /// <summary>
        /// Initializes a new instance of the CircleCommand class.
        /// </summary>
        /// <param name="radiusParameter">The requested radius of the circle as a string, which can be a numeric value or a variable name.</param>
        /// <param name="context">The graphics context that holds current drawing data.</param>
        /// <param name="VariableContext">The context for resolving variable values.</param>
        public CircleCommand(string radiusParameter, GraphicsContext context, VariableContext VariableContext)
        {
            _radiusParameter = radiusParameter;
            _context = context;
            _VariableContext = VariableContext;
        }

        /// <summary>
        /// Executes the circle drawing command on the existing graphics.
        /// </summary>
        /// <param name="graphics">The existing graphics to draw on.</param>
        public void Execute(Graphics graphics)
        {
            int radius = TryToParseParameter(_radiusParameter, _VariableContext);
            int diameter = radius * 2;
            int topLeftX = _context.CurrentPosition.X - radius;
            int topLeftY = _context.CurrentPosition.Y - radius;

            graphics.DrawEllipse(new Pen(_context.CurrentColor), topLeftX, topLeftY, diameter, diameter);
        }

        private int TryToParseParameter(string parameter, VariableContext varContext)
        {
            if (int.TryParse(parameter, out int value))
            {
                return value;
            }
            else
            {
                return varContext.GetVariable(parameter);
            }
        }
    }
}
