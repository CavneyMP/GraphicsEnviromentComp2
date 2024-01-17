using System;
using System.Collections.Generic;
using static GraphicsEnvironmentComp2.Form1;

namespace GraphicsEnvironmentComp2.Commands
{
    /// <summary>
    /// The LoopCommand is responsible for generating loops which can contain a set of commands to be executed recursively.
    /// </summary>
    public class LoopCommand : ICommandInterface
    {
        private readonly int _iterations; // private integer to store the value passed from input to specify desired number of iterations
        private readonly List<ICommandInterface> _commands; // a list to hold the commands that are found in the loop

        public LoopCommand(int iterations)
        {
            _iterations = iterations;
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
        /// Executes all commands in the loop for a set number of iterations.
        /// </summary>
        /// <param name="safeGraphics">The SafeGraphics object used for thread-safe drawing.</param>
        public void Execute(SafeGraphics safeGraphics)
        {
            for (int i = 0; i < _iterations; i++) // Loops through the number of iterations
            {
                foreach (var command in _commands) // For each command in the list
                {
                    command.Execute(safeGraphics); // Execute the command using SafeGraphics
                }
            }
        }
    }
}
