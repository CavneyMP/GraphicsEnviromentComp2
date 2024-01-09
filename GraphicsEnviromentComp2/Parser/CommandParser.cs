using GraphicsEnvironmentComp2.Commands;
using GraphicsEnvironmentComp2.Commands.GraphicsEnvironmentComp2.Commands;
using GraphicsEnvironmentComp2.Factory;
using GraphicsEnvironmentComp2.GraphicContext;
using System;
using System.Linq;

namespace GraphicsEnvironmentComp2.Parser
{
    /// <summary>
    /// Command parser is a class to parse user input to decipher command and parameters
    /// </summary>
    public class CommandParser
    {
        private VariableContext _variableContext; // Store the variable context.
        private LoopCommand _currentLoop = null; // To keep track of the current loop being parsed.

        /// <summary>
        /// Initializes a new instance of the command parser class 
        /// </summary>
        /// <param name="variableContext">Stores and retrieves variables</param>
        public CommandParser(VariableContext variableContext)
        {
            _variableContext = variableContext;
        }

        
        /// <summary>
        /// Parses the given user input and returns the relevant command
        /// </summary>
        /// <param name="userInput">Input from the user</param>
        /// <param name="multiLineContent">Input from multi line content</param>
        /// <returns>The relevant command matching user input</returns>
        public ICommandInterface ParseCommand(string userInput, string multiLineContent)
        {
            string trimmedInput = userInput.Trim();
            string[] tokens = trimmedInput.Split(' ');
            string command = tokens[0].ToLower();

            // Handle loop start
            if (command == "loop" && int.TryParse(tokens[1], out int iterations))
            {
                _currentLoop = new LoopCommand(iterations);
                return new NoOpCommand();  // Loop start isn't an executable command itself
            }
            // Handle loop end
            else if (command == "endloop")
            {
                if (_currentLoop != null)
                {
                    LoopCommand completedLoop = _currentLoop;
                    _currentLoop = null; // Reset current loop
                    return completedLoop; // Return the completed loop to be executed
                }
                else
                {
                    throw new ArgumentException("No matching 'loop' command found for 'endloop'.");
                }
            }
            // Handle commands inside a loop
            else if (_currentLoop != null)
            {
                // If we're currently parsing a loop, add the command to the loop instead of executing it immediately basically
                ICommandInterface commandToAdd = CommandFactory.GetCommand(command, tokens.Skip(1).ToArray(), multiLineContent, _variableContext);
                _currentLoop.AddCommand(commandToAdd);
                return new NoOpCommand();
            }
            // Handle 'if', 'endif', variable assignments, and other commands
            else if (command == "if")
            {
                return new IfCommand(string.Join(" ", tokens.Skip(1)), _variableContext);
            }
            else if (command == "endif")
            {
                return new EndIfCommand();
            }

            // Check for variable assignment only if it doesn't start with 'if' and contains '='
            else if (!trimmedInput.StartsWith("if") && trimmedInput.Contains("="))
            {
                return HandleVariableAssignment(trimmedInput);
            }
            else if (!IfCommand.ExecuteNext)
            {
                return new NoOpCommand(); // Skip execution when condition is not met
            }
            else
            {
                // Existing switch case commands
                return CommandFactory.GetCommand(command, tokens.Skip(1).ToArray(), multiLineContent, _variableContext);
            }
        }










        /// <summary>
        /// This is a method respobsible for handling the variable assignment when found in user input
        /// </summary>
        /// <param name="userInput">Input from windows form</param>
        /// <returns>Only needs to store variable so returns the no op command or else throws exception</returns>
        /// <exception cref="ArgumentException">Relevant exception to report back</exception>

        private ICommandInterface HandleVariableAssignment(string userInput)
        {
            var parts = userInput.Split('=');
            if (parts.Length == 2)
            {
                string variableName = parts[0].Trim();
                if (int.TryParse(parts[1].Trim(), out int value))
                {
                    _variableContext.SetVariable(variableName, value);  // Set the variable
                    return new NoOpCommand(); // No Operation, command factory just requires execution
                }
                else
                {
                    throw new ArgumentException($"Invalid value of variable '{variableName}' an integer is required.");
                }
            }
            else
            {
                throw new ArgumentException("Invalid variable assignment please use format 'variable = value' where variable is the name and the value is interger you want to store");
            }
        }

        /// <summary>
        /// A method to handle varaible increments. has the parse its own commands to assist loop function. 
        /// </summary>
        /// <param name="userInput">The input from the user</param>
        /// <returns>Returns a new instance of the increment command, which holds the logic to increment any given variable</returns>
        /// <exception cref="ArgumentException"></exception>
        private ICommandInterface HandleIncrementCommand(string userInput)
        {
            var parts = userInput.Split('+');
            if (parts.Length == 2 && _variableContext.VariableExists(parts[0].Trim()))
            {
                string variableName = parts[0].Trim();
                if (int.TryParse(parts[1].Trim(), out int incrementValue))
                {
                    return new IncrementCommand(variableName, incrementValue, _variableContext);
                }
                else
                {
                    throw new ArgumentException($"Invalid increment value in '{userInput}' as it must be an integer.");
                }
            }
            else
            {
                throw new ArgumentException($"Invalid increment command format '{userInput}' please use 'variable + value'.");
            }
        }
    }
}
