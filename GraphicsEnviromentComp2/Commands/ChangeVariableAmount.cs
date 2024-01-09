using GraphicsEnviromentComp2.CustomException;
using GraphicsEnvironmentComp2.GraphicContext;
using System;
using System.Drawing;

namespace GraphicsEnvironmentComp2.Commands
{

    /// <summary>
    /// A class to change the value of a stored varaible by simple operators
    /// </summary>
    public class ChangeVariableCommand : ICommandInterface
    {
        private readonly string _variableName;
        private readonly string _operatorSymbol;
        private readonly int _amount;
        private readonly VariableContext _variableContext;

        public ChangeVariableCommand(string variableName, string operatorSymbol, int amount, VariableContext variableContext)
        {
            _variableName = variableName;
            _operatorSymbol = operatorSymbol;
            _amount = amount;
            _variableContext = variableContext;
        }
        /// <summary>
        /// Execution method that looks checks the variable exists, and if so looks to find the operator and preform the desired action based on it.
        /// </summary>
        /// <param name="graphics"></param>
        /// <exception cref="ArgumentException"></exception>
        public void Execute(Graphics graphics)
        {

            if (!_variableContext.VariableExists(_variableName))
            {
                throw new CustomArgumentException($" Tech message XXXX","Variable '{_variableName}' does not exist.");
            }

            int currentValue = _variableContext.GetVariable(_variableName);
            int newValue = _variableContext.GetVariable(_variableName);

            switch (_operatorSymbol)
            {
                case "+":
                    _variableContext.SetVariable(_variableName, currentValue + _amount);
                    break;
                case "-":
                    _variableContext.SetVariable(_variableName, currentValue - _amount);
                    break;
                default:
                    throw new CustomArgumentException($" Tech message XXXX", $"operatorSymbol '{{{_operatorSymbol}}}' is not recognized.");
            }
        }
    }
}