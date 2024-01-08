using System;
using System.Drawing;
using GraphicsEnvironmentComp2.GraphicContext;

namespace GraphicsEnvironmentComp2.Commands
{
    public class IfCommand : ICommandInterface
    {
        /// <summary>
        /// Mimics if statements found in coding languages, executes if condition is true, does not if false. 
        /// </summary>
        private string _condition;
        private VariableContext _variableContext;

        /// <summary>
        /// Determines what should be executed next based on last evaluation 
        /// </summary>
        public static bool ExecuteNext { get; private set; } = true;

        /// <summary>
        /// The method to reset the flag, found in end if.
        /// </summary>

        public static void ResetExecutionFlag()
        {
            ExecuteNext = true;
        }
        /// <summary>
        /// New instance of If command with the specified condition and variable context for comparison 
        /// </summary>
        /// <param name="condition">The condition to check against</param>
        /// <param name="variableContext">Where the variable values are found</param>
        public IfCommand(string condition, VariableContext variableContext)
        {
            _condition = condition.Trim();
            _variableContext = variableContext;
        }

        /// <summary>
        /// Executes command, holds logic to evaluate the two values
        /// </summary>
        /// <param name="graphics">The graphics context, holding the graphical state</param>
        /// <exception cref="ArgumentException"></exception>

        public void Execute(Graphics graphics)
        {
            string[] parts = _condition.Split(' ');
            if (parts.Length == 3)
            {
                string variableName = parts[0];
                string operatorSymbol = parts[1];
                int value = int.Parse(parts[2]);

                int variableValue = _variableContext.GetVariable(variableName);

                switch (operatorSymbol)
                {
                    case "<":
                        ExecuteNext = variableValue < value;
                        break;
                    case "==":
                        ExecuteNext = variableValue == value;
                        break;
                    case ">":
                        ExecuteNext = variableValue > value;
                        break;
                    default:
                        throw new ArgumentException($"Unsupported operator '{operatorSymbol}'.");
                }
            }
            else
            {
                throw new ArgumentException("Condition was not in the correct format.");
            }
        }
    }
}
