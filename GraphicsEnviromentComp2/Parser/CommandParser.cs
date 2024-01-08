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


        /// <summary>
        /// Initialises a new instance of the command parser class 
        /// </summary>
        /// <param name="variableContext">Stores and retrieves variables</param>
        public CommandParser(VariableContext variableContext)
        {
            _variableContext = variableContext;
        }

        /// <summary>
        /// Parses the given user input and returns the relevant command
        /// </summary>
        /// <param name="userInput">Input from the windows form</param>
        /// <param name="multiLineContent">Input from multi line windows form</param>
        /// <returns>The relevant command matching user input</returns>

        public ICommandInterface ParseCommand(string userInput, string multiLineContent)
        {
            string trimmedInput = userInput.Trim();
            string[] tokens = trimmedInput.Split(' ');
            string command = tokens[0].ToLower();

            // Check if it's an 'if' or 'endif' for if statment function
            if (command == "if")
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
                return new NoOpCommand(); // Skip command execution when condition is not met
            }
            else
            {
                // Existing switch case or logic to handle other commands
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
    }
}
