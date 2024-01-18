using System;
using System.Collections.Generic;
using GraphicsEnvironmentComp2.GraphicContext;
using static GraphicsEnvironmentComp2.Form1;

namespace GraphicsEnvironmentComp2.Commands
{
    /// <summary>
    /// The LoopCommand is responsible for generating loops which can contain a set of commands to be executed recursively.
    /// </summary>
    public class LoopCommand : ICommandInterface
    {
        private readonly string _variableName; // Variable name for dynamic iteration count
        private readonly VariableContext _variableContext; // Variable context to access the variable
        private readonly List<ICommandInterface> _commands; // List to hold the commands that are found in the loop

        // Constructor accepting a variable name and variable context
        public LoopCommand(string variableName, VariableContext variableContext)
        {
            _variableName = variableName;
            _variableContext = variableContext;
            _commands = new List<ICommandInterface>();
        }

        /// <summary>
        /// Adds a command to the list of commands to be executed in the loop.
        /// </summary>
        /// <param name="command">The command to add.</param>
        public void AddCommand(ICommandInterface command)
        {
            _commands.Add(command);
        }

        /// <summary>
        /// Executes all commands in the loop for the number of iterations specified by the variable.
        /// </summary>
        /// <param name="safeGraphics">The SafeGraphics object used for thread-safe drawing.</param>
        public void Execute(SafeGraphics safeGraphics)
        {
            if (!_variableContext.VariableExists(_variableName))
            {
                throw new ArgumentException($"Variable '{_variableName}' does not exist.");
            }

            int iterations = _variableContext.GetVariable(_variableName);
            for (int i = 0; i < iterations; i++) // Loops through the number of iterations determined by the variable
            {
                foreach (var command in _commands) // For each command in the list
                {
                    command.Execute(safeGraphics); // Execute the command using SafeGraphics
                }
            }
        }
    }
}
