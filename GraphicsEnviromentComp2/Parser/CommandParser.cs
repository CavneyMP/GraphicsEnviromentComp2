using GraphicsEnviromentComp2.Commands;
using GraphicsEnviromentComp2.Commands.GraphicsEnviromentComp2.Commands;
using GraphicsEnviromentComp2.Factory;
using GraphicsEnviromentComp2.GraphicContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicsEnviromentComp2.Parser
{
    /// <summary>
    ///  This class parses the user input to create the required command. 
    ///  It handles variable assignmennt, and command creation using the command factory.
    /// </summary>
    public class CommandParser
    {
        private VariableContext _variableContext; // Prviate field to store the varaible context.
        
        /// <summary>
        /// This method initlizaes the new instance of the Command Parser Class and retreives the varaible values.
        /// </summary>
        /// <param name="variableContext">The context used to store and retreive variables.</param>

        public CommandParser(VariableContext variableContext)
        {
            _variableContext = variableContext;
        }

        /// <summary>
        /// Here the user input is parsed to create and return the required command.
        /// It can handle the varaible assignments, and creates the commands using the command interface.
        /// </summary>
        /// <param name="userInput">This will be the whole input from the user, which needs to containe the command or relevant varaible assignment</param>
        /// <param name="multiLineContent">Handles user input over muliple lines for same function as above</param>
        /// <returns>This will pass the relevant information to the command factory to retreive the command which matchs user input </returns>
        /// <exception cref="ArgumentException"></exception>

        public ICommandInterface ParseCommand(string userInput, string multiLineContent)
        {
            if (userInput.Contains("="))// As = is not used for any command, we can assume that if the user input contains an = symbol, it will be to assign a varaible
            {
                var parts = userInput.Split('=');
                if (parts.Length == 2)
                {
                    string variableName = parts[0].Trim();
                    if (int.TryParse(parts[1].Trim(), out int value))
                    {
                        _variableContext.SetVariable(variableName, value);  // Set the variable
                        return new NoOpCommand(); // No Operation is preformed, but is required for an exection as per the command factory. 
                    }
                    else
                    {
                        throw new ArgumentException($"Invalid value for variable '{variableName}'. An integer is required.");
                    }
                }

                else
                {
                    throw new ArgumentException("Invalid variable assignment. Please use format 'variable = value' where variable is the name.");
                }
            }
            // This section will parse the users input by white space and cleanse the input, while storing the first item of the aray as the command as the rest as params
            string[] tokens = userInput.Split(' ');
            string command = tokens[0].ToLower().Trim();
            string[] parameters = tokens.Skip(1).ToArray();

            // The command, paramerters, multiline context and varaible context are all passed to the command factory. 
            return CommandFactory.GetCommand(command, parameters, multiLineContent, _variableContext);
        }
    }
}
