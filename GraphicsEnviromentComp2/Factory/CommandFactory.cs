using GraphicsEnvironmentComp2.Commands;
using System;
using GraphicsEnviromentComp2.CustomException;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GraphicsEnvironmentComp2.GraphicContext;

namespace GraphicsEnvironmentComp2.Factory
{
    /// <summary>
    /// The factory class is responsible for creating the command that is matched from the parsed user input.
    /// It is able to match the input command and passes the parsed parameters to return the relevant command object.
    /// </summary>
    public static class CommandFactory
    {
        private static readonly GraphicsContext _GraphicContext = new GraphicsContext();

        /// <summary>
        /// This method attempts to interpret a parameter as an integer, or retreives its value from the varaible context, if it is already present in the dictionairy. 
        /// </summary>
        /// <param name="parameter"> The interpretated parameter</param>
        /// <param name="varContext"> This is the context containing the varaible values</param>
        /// <returns> The paired integer to the variable name from the varaible context</returns>
        private static int TryToParseParameter(string parameter, VariableContext varContext)
        {
            if (int.TryParse(parameter, out int value))
            {
                return value;
            }
            else
            {
                return varContext.GetVariable(parameter);
            }
        }

        /// <summary>
        /// This method holds all the logic to carry out each command, it matchs the user input and returns the relevant command object.
        /// </summary>
        /// <param name="command"> The command name input by the user</param>
        /// <param name="parameters"> The parameters parsed from input to pass to the new object</param>
        /// <param name="multiLineContent"> When multi line is used, this will hold the content</param>
        /// <param name="variableContext"> Context containing the varaible values</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public static ICommandInterface GetCommand(string command, string[] parameters, string multiLineContent, VariableContext variableContext)
        {
            switch (command.ToLower().Trim())
            {
                case "reset":
                    return new ResetCommand(_GraphicContext);

                case "drawto":
                    if (parameters.Length == 2)
                    {
                        return new DrawToCommand(parameters[0], parameters[1], _GraphicContext, variableContext);
                    }
                    else
                    {
                        throw new CustomArgumentException(" Tech message XXXX","DrawTo command requires two parameters x and y pixel coordinates.");
                    }

                case "moveto":
                    if (parameters.Length == 2)
                    {
                        return new MoveToCommand(parameters[0], parameters[1], _GraphicContext, variableContext);
                    }
                    else
                    {
                        throw new CustomArgumentException("Tech message XXXX", "MoveTo command requires two parameters: x and y coordinates (either as integers or variable names).");
                    }


                case "clear":
                    return new ClearCommand();

                case "save":
                    if (parameters.Length == 1)
                    {
                        return new SaveCommand(parameters[0], multiLineContent);
                    }
                    throw new CustomArgumentException(" Tech message XXXX","Save command requires a file path parameter.");

                case "circle":
                    if (parameters.Length == 1)
                    {
                        return new CircleCommand(parameters[0], _GraphicContext, variableContext);
                    }
                    throw new CustomArgumentException("Tech message XXXX", "Circle command requires one parameter: radius (either as an integer or a variable name).");


                case "square":
                    if (parameters.Length == 2)
                    {
                        return new SquareCommand(parameters[0], parameters[1], _GraphicContext, variableContext);
                    }
                    throw new CustomArgumentException("Tech message XXXX", "Square command requires two parameters: width and height (either as integers or variable names).");


                case "changecolour":
                    if (parameters.Length == 1)
                    {
                        Color newColour;
                        switch (parameters[0])
                        {
                            case "red":
                                newColour = Color.Red;
                                break;
                            case "green":
                                newColour = Color.Green;
                                break;
                            case "blue":
                                newColour = Color.Blue;
                                break;
                            default:
                                throw new CustomArgumentException(" Tech message XXXX","Only choose from red, green, or blue as a parameter.");
                        }
                        return new ChangePenColorCommand(newColour, _GraphicContext);
                    }
                    throw new CustomArgumentException(" Tech message XXXX","ChangeColor command requires one parameter for the color name.");


                case "load":
                    if (parameters.Length == 1)
                    {
                        return new LoadCommand(parameters[0]);
                    }
                    throw new CustomArgumentException(" Tech message XXXX","Load command requires a file path parameter.");


                case "change":
                    if (parameters.Length == 3)
                    {
                        string operatorSymbol = parameters[1];
                        string variableName = parameters[0];
                        if (int.TryParse(parameters[2], out int amount))
                        {
                            return new ChangeVariableCommand(variableName, operatorSymbol, amount, variableContext);
                        }
                        throw new CustomArgumentException(" Tech message XXXX","Amount must be an integer.");
                    }
                    throw new CustomArgumentException(" Tech message XXXX","Change command requires 3 parameters, operator, variable name, and amount.");

                default:
                    throw new CustomArgumentException($" Tech message XXXX", $"Command '{{{command}}}' has not been recognized.");
            }
        }
    }
}