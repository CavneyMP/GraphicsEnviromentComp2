using GraphicsEnvironmentComp2.GraphicContext;
using System.Drawing;
using static GraphicsEnvironmentComp2.Form1;

namespace GraphicsEnvironmentComp2.Commands
{
    /// <summary>
    /// This class allows the user to draw a square by specifying the command, width, and height.
    /// </summary>
    public class SquareCommand : ICommandInterface
    {
        private readonly string _widthParameter;
        private readonly string _heightParameter;
        private readonly GraphicsContext _context;
        private readonly VariableContext _VariableContext;

        /// <summary>
        /// Initializes a new instance of the SquareCommand class.
        /// </summary>
        /// <param name="widthParameter">Width of the square, as a string which can be a numeric value or a variable name.</param>
        /// <param name="heightParameter">Height of the square, as a string which can be a numeric value or a variable name.</param>
        /// <param name="context">The graphics context which holds the current graphics state.</param>
        /// <param name="VariableContext">The context for resolving variable values.</param>
        public SquareCommand(string widthParameter, string heightParameter, GraphicsContext context, VariableContext VariableContext)
        {
            _widthParameter = widthParameter;
            _heightParameter = heightParameter;
            _context = context;
            _VariableContext = VariableContext;
        }

        /// <summary>
        /// Executes the SquareCommand, drawing a square on the existing graphics.
        /// </summary>
        /// <param name="safeGraphics">The SafeGraphics instance to draw on.</param>
        public void Execute(SafeGraphics safeGraphics)
        {
            int width = TryToParseParameter(_widthParameter, _VariableContext);
            int height = TryToParseParameter(_heightParameter, _VariableContext);
            Point currentPosition = _context.CurrentPosition;

            safeGraphics.Execute(graphics =>
            {
                graphics.DrawRectangle(new Pen(_context.CurrentColor), currentPosition.X, currentPosition.Y, width, height);
            });
        }
        /// <summary>
        /// Parses the parameters from variable context to int.
        /// </summary>
        /// <param name="parameter"></param>
        /// <param name="varContext"></param>
        /// <returns></returns>
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
