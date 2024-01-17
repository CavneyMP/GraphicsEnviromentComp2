using GraphicsEnvironmentComp2.GraphicContext;
using System.Drawing;
using static GraphicsEnvironmentComp2.Form1;

namespace GraphicsEnvironmentComp2.Commands
{
    public class CircleCommand : ICommandInterface
    {
        private readonly string _radiusParameter;
        private readonly GraphicsContext _context;
        private readonly VariableContext _VariableContext;

        public CircleCommand(string radiusParameter, GraphicsContext context, VariableContext VariableContext)
        {
            _radiusParameter = radiusParameter;
            _context = context;
            _VariableContext = VariableContext;
        }

        
        ///<summary>
        /// Executes the circle drawing command using the provided SafeGraphics instance.
        /// </summary>
        /// <param name="safeGraphics">SafeGraphics instance for thread-safe drawing.</param>
        public void Execute(SafeGraphics safeGraphics)
        {
            int radius = TryToParseParameter(_radiusParameter, _VariableContext);
            int diameter = radius * 2;
            int topLeftX = _context.CurrentPosition.X - radius;
            int topLeftY = _context.CurrentPosition.Y - radius;

            safeGraphics.Execute(graphics =>
            {
                graphics.DrawEllipse(new Pen(_context.CurrentColor), topLeftX, topLeftY, diameter, diameter);
            });
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
