using GraphicsEnvironmentComp2.GraphicContext;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using static GraphicsEnvironmentComp2.Form1;

namespace GraphicsEnvironmentComp2.Commands
{
    /// <summary>
    /// The logic for invoking the method already set
    /// </summary>
    public class MethodInvocationCommand : ICommandInterface
    {
        private readonly UserDefinedMethod _method;
        private readonly List<string> _arguments;
        private readonly VariableContext _variableContext;
        private readonly GraphicsContext _graphicsContext;

        /// <summary>
        /// A new instance of MethodInvocation 
        /// </summary>
        /// <param name="method">The user defined method</param>
        /// <param name="arguments">The arguments for the method</param>
        /// <param name="variableContext">The variable context to use</param>
        /// <param name="graphicsContext">The graphic context to use</param>
        public MethodInvocationCommand(UserDefinedMethod method, List<string> arguments, VariableContext variableContext, GraphicsContext graphicsContext)
        {
            _method = method;
            _arguments = arguments;
            _variableContext = variableContext;
            _graphicsContext = graphicsContext;
        }


        /// <summary>
        /// Executes invoking of the method
        /// </summary>
        /// <param name="graphics">The graphics object for drawing</param>
        /// <exception cref="ArgumentException">Exception thrown</exception>
        public void Execute(SafeGraphics safeGraphics)
        {
            if (_method.Parameters.Count != _arguments.Count)
            {
                throw new ArgumentException("Incorrect number of arguments for the method.");
            }

            Dictionary<string, int> originalValues = new Dictionary<string, int>();
            for (int i = 0; i < _method.Parameters.Count; i++)
            {
                string paramName = _method.Parameters[i];
                if (_variableContext.VariableExists(paramName))
                {
                    originalValues[paramName] = _variableContext.GetVariable(paramName);
                }
                _variableContext.SetVariable(paramName, int.Parse(_arguments[i]));
            }

            foreach (var command in _method.Commands)
            {
                command.Execute(safeGraphics);
            }

            foreach (var param in _method.Parameters)
            {
                if (originalValues.ContainsKey(param))
                {
                    _variableContext.SetVariable(param, originalValues[param]);
                }
                else
                {
                    _variableContext.SetVariable(param, 0);
                }
            }
        }
    }
}
