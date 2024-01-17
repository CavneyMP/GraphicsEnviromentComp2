using GraphicsEnvironmentComp2.GraphicContext;
using System;
using System.Drawing;
using static GraphicsEnvironmentComp2.Form1;

namespace GraphicsEnvironmentComp2.Commands
{
    /// <summary>
    /// The MoveToCommand class inherits the ICommandInterface and is used to move the cursor to a new position.
    /// </summary>
    public class MoveToCommand : ICommandInterface
    {
        private readonly string _xParameter;
        private readonly string _yParameter;
        private readonly GraphicsContext _GraphicContext;
        private readonly VariableContext _VariableContext;

        /// <summary>
        /// Initializes a new instance of the MoveToCommand with the graphic context and specified position parameters.
        /// </summary>
        /// <param name="xParameter">The x-coordinate as a string, which can be a numeric value or a variable name.</param>
        /// <param name="yParameter">The y-coordinate as a string, which can be a numeric value or a variable name.</param>
        /// <param name="GraphicContext">The graphics context that maintains the current state of the panel.</param>
        /// <param name="VariableContext">The context for resolving variable values.</param>
        public MoveToCommand(string xParameter, string yParameter, GraphicsContext GraphicContext, VariableContext VariableContext)
        {
            _xParameter = xParameter;
            _yParameter = yParameter;
            _GraphicContext = GraphicContext;
            _VariableContext = VariableContext;
        }

        /// <summary>
        /// Executes the MoveToCommand, updating the graphic context with the new position.
        /// </summary>
        /// <param name="graphics">The graphics object (not used in this command).</param>
        public void Execute(SafeGraphics safeGraphics)
        {
            int x = TryToParseParameter(_xParameter, _VariableContext);
            int y = TryToParseParameter(_yParameter, _VariableContext);

            Point newPosition = new Point(x, y);

            // Update the current position in the drawing context
            _GraphicContext.UpdatePosition(newPosition);
        }

        /// <summary>
        /// Tries to parse a parameter as an integer or resolves it as a variable.
        /// </summary>
        /// <param name="parameter">The parameter to parse.</param>
        /// <param name="varContext">The variable context for resolving variables.</param>
        /// <returns>The resolved integer value of the parameter.</returns>
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
