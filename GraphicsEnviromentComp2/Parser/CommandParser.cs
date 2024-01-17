using GraphicsEnviromentComp2.CustomException;
using GraphicsEnvironmentComp2.Commands;
using GraphicsEnvironmentComp2.Commands.GraphicsEnvironmentComp2.Commands;
using GraphicsEnvironmentComp2.Factory;
using GraphicsEnvironmentComp2.GraphicContext;
using GraphicsEnvironmentComp2.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GraphicsEnvironmentComp2.Parser
{
    /// <summary>
    /// Parses user commands and generates appropriate command objects.
    /// </summary>
    public class CommandParser
    {
        private VariableContext _variableContext;
        private LoopCommand _currentLoop = null;
        private Dictionary<string, UserDefinedMethod> _userDefinedMethods = new Dictionary<string, UserDefinedMethod>(StringComparer.OrdinalIgnoreCase);
        private bool _isDefiningMethod = false;
        private string _currentMethodName;
        private List<string> _methodParameters = new List<string>();
        private List<ICommandInterface> _methodCommands = new List<ICommandInterface>();

        /// <summary>
        /// Initializes a new instance of the <see cref="CommandParser"/> class.
        /// </summary>
        /// <param name="variableContext">The variable context to use for variable operations.</param>
        public CommandParser(VariableContext variableContext)
        {
            _variableContext = variableContext;
        }

        /// <summary>
        /// Parses a user command and generates the corresponding command object.
        /// </summary>
        /// <param name="userInput">The user input to parse.</param>
        /// <param name="multiLineContent">Multi-line content, if any.</param>
        /// <returns>The parsed command object.</returns>
        public ICommandInterface ParseCommand(string userInput, string multiLineContent)
        {
            string trimmedInput = userInput.Trim();
            string[] tokens = trimmedInput.Split(' ');
            string command = tokens[0].ToLower();

            if (_isDefiningMethod)
            {
                if (command == "endmethod")
                {
                    _isDefiningMethod = false;
                    _userDefinedMethods[_currentMethodName] = new UserDefinedMethod(_currentMethodName, _methodParameters, _methodCommands);
                    return new NoOpCommand();
                }
                else
                {
                    ICommandInterface commandToAdd = CommandFactory.GetCommand(tokens[0], tokens.Skip(1).ToArray(), multiLineContent, _variableContext);
                    _methodCommands.Add(commandToAdd);
                    return new NoOpCommand();
                }
            }
            else if (command == "method")
            {
                _isDefiningMethod = true;
                _currentMethodName = tokens[1];
                _methodParameters = tokens.Skip(2).Select(t => t.Trim(new char[] { '(', ')' })).ToList();
                CommandParserHelper.InitializeMethodParameters(this);
                _methodCommands.Clear();
                return new NoOpCommand();
            }
            else if (command == "endmethod")
            {
                throw new CustomArgumentException(" Tech message XXXX", "Unexpected 'endmethod' found. No matching 'method' command found.");
            }
            else if (_userDefinedMethods.ContainsKey(command))
            {
                var args = trimmedInput.Contains("(")
                    ? trimmedInput.Split(new[] { '(', ',', ')' }, StringSplitOptions.RemoveEmptyEntries).Skip(1).ToList()
                    : new List<string>();
                if (_userDefinedMethods.TryGetValue(command, out UserDefinedMethod method))
                {
                    CommandParserHelper.SetMethodArguments(this, method.Parameters, args);
                    return new MethodInvocationCommand(method, args, _variableContext, new GraphicsContext());
                }
            }
            else if (command == "loop" && int.TryParse(tokens[1], out int iterations))
            {
                _currentLoop = new LoopCommand(iterations);
                return new NoOpCommand();
            }
            else if (command == "endloop")
            {
                if (_currentLoop != null)
                {
                    LoopCommand completedLoop = _currentLoop;
                    _currentLoop = null;
                    return completedLoop;
                }
                else
                {
                    throw new CustomArgumentException(" Tech message XXXX", "No matching 'loop' command found for 'endloop'.");
                }
            }
            else if (_currentLoop != null)
            {
                ICommandInterface commandToAdd = CommandFactory.GetCommand(command, tokens.Skip(1).ToArray(), multiLineContent, _variableContext);
                _currentLoop.AddCommand(commandToAdd);
                return new NoOpCommand();
            }
            else if (command == "if")
            {
                return new IfCommand(string.Join(" ", tokens.Skip(1)), _variableContext);
            }
            else if (command == "endif")
            {
                return new EndIfCommand();
            }
            else if (!trimmedInput.StartsWith("if") && trimmedInput.Contains("="))
            {
                return CommandParserHelper.HandleVariableAssignment(this, trimmedInput);
            }
            else if (!IfCommand.ExecuteNext)
            {
                return new NoOpCommand();
            }
            else
            {
                return CommandFactory.GetCommand(command, tokens.Skip(1).ToArray(), multiLineContent, _variableContext);
            }
            return new NoOpCommand();
        }

        public VariableContext VariableContext => _variableContext;
        public List<string> MethodParameters => _methodParameters;
    }
}
