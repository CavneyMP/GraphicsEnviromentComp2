using System;
using System.Collections.Generic;
using System.Drawing;

namespace GraphicsEnvironmentComp2.Commands
{

    /// <summary>
    /// The loop loop command is what is responsible for generating loops which can contain a set of commands to occur recursively 
    /// </summary>
    public class LoopCommand : ICommandInterface
    {
        private readonly int _iterations; // private integer to store a value passed from input to specify desired amounts to run the loop
        private readonly List<ICommandInterface> _commands; // a list to hold the commands that are found in said loop


        public LoopCommand(int iterations)
        {
            _iterations = iterations;
            _commands = new List<ICommandInterface>();
        }


        /// <summary>
        /// The add command is responsible for adding commands to the list. 
        /// </summary>
        /// <param name="command">The command to add</param>
        public void AddCommand(ICommandInterface command)
        {
            _commands.Add(command);
        }

        /// <summary>
        /// Execution method to execute all commands in the loop, a set amount of times 
        /// </summary>
        /// <param name="graphics">The graphics object used for drawing</param>

        public void Execute(Graphics graphics)
        {
            for (int i = 0; i < _iterations; i++) // Increases variable  by one until it reaches value of iterations
            {
                foreach (var command in _commands) // for each command in the list
                {
                    command.Execute(graphics); // execute 
                }
            }
        }

    }
}
