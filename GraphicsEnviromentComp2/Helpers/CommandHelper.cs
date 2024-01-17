using GraphicsEnvironmentComp2.Commands;
using GraphicsEnvironmentComp2.Commands.GraphicsEnvironmentComp2.Commands;
using GraphicsEnvironmentComp2.Factory;
using GraphicsEnvironmentComp2.GraphicContext;
using System;
using System.Collections.Generic;
using System.Linq;
using GraphicsEnviromentComp2.CustomException;
using GraphicsEnvironmentComp2.Parser;

namespace GraphicsEnvironmentComp2.Helpers
{
    
    ///<summary>
    /// All the helper methods, that are used by the parser
    /// </summary>

    public static class CommandParserHelper
    {

        /// <summary>
        /// Sets  the parameters in the method functions as variables
        /// </summary>
        /// <param name="parser">The command parser instance</param>
        public static void InitializeMethodParameters(CommandParser parser)
        {
            foreach (var param in parser.MethodParameters)
            {
                parser.VariableContext.SetVariable(param, 0);
            }
        }
        /// <summary>
        /// Sets the method arguments in the command parser
        /// </summary>
        /// <param name="parser">The parser instance</param>
        /// <param name="parameters">The list of parameters for the method</param>
        /// <param name="args">The list of arugments passed by user</param>
        /// <exception cref="ArgumentException"></exception>
        public static void SetMethodArguments(CommandParser parser, List<string> parameters, List<string> args)
        {
            if (parameters.Count != args.Count)
            {
                throw new CustomArgumentException(" Tech message XXXX", "Incorrect number of arguments for the method.");
            }

            for (int i = 0; i < parameters.Count; i++)
            {
                if (int.TryParse(args[i], out int value))
                {
                    parser.VariableContext.SetVariable(parameters[i], value);
                }
                else
                {
                    throw new CustomArgumentException(" Tech message XXXX", "Invalid argument");
                }
            }
        }

        /// <summary>
        /// Handles assignment of variables
        /// </summary>
        /// <param name="parser">The command parser instance</param>
        /// <param name="userInput">The user input containing the variable</param>
        /// <returns>The corresponding command interface, no operation performed</returns>
        /// <exception cref="CustomArgumentException"></exception>

        public static ICommandInterface HandleVariableAssignment(CommandParser parser, string userInput)
        {
            var parts = userInput.Split('=');
            if (parts.Length == 2)
            {
                string variableName = parts[0].Trim();
                if (int.TryParse(parts[1].Trim(), out int value))
                {
                    parser.VariableContext.SetVariable(variableName, value);
                    return new NoOpCommand();
                }
                else
                {
                    throw new CustomArgumentException($" Tech message XXXX", $"Invalid value of variable '{{{variableName}}}' an integer is required.");
                }
            }
            else
            {
                throw new CustomArgumentException(" Tech message XXXX", "Invalid variable assignment please use 'variable = value' where the variable is the name and the value is an integer you want to store");
            }
        }
    }
}
