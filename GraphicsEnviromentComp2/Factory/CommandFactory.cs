using GraphicsEnviromentComp2.Commands;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GraphicsEnviromentComp2.GraphicContext;

namespace GraphicsEnviromentComp2.Factory
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
                        int x = TryToParseParameter(parameters[0], variableContext);
                        int y = TryToParseParameter(parameters[1], variableContext);
                        return new DrawToCommand(new Point(x, y), _GraphicContext);
                    }
                    else
                    {
                        throw new ArgumentException("DrawTo command requires two parameters: x and y coordinates.");
                    }
                     
                case "moveto":
                        if (parameters.Length == 2
                            && int.TryParse(parameters[0], out int moveX)
                            && int.TryParse(parameters[1], out int moveY))
                        {
                            return new MoveToCommand(new Point(moveX, moveY), _GraphicContext);
                        }
                        throw new ArgumentException("MoveTo command requires two integer parameters: x and y coordinates.");

                    case "clear":
                        return new ClearCommand();

                    case "save":
                        if (parameters.Length == 1)
                        {
                            return new SaveCommand(parameters[0], multiLineContent);
                        }
                        throw new ArgumentException("Save command requires a file path parameter.");

                    case "circle":
                        if (parameters.Length == 1 && int.TryParse(parameters[0], out int radius))
                        {
                            return new CircleCommand(radius, _GraphicContext);
                        }
                        throw new ArgumentException("Circle command requires one integer parameter: radius.");


                    case "square":
                        if (parameters.Length == 2
                            && int.TryParse(parameters[0], out int width)
                            && int.TryParse(parameters[1], out int height))
                        {
                            return new SquareCommand(width, height, _GraphicContext);
                        }
                        throw new ArgumentException("Square command requires two integers to represent the width and height.");

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
                                    throw new ArgumentException("Only choose from red, green, or blue as a parameter.");
                            }
                            return new ChangePenColorCommand(newColour, _GraphicContext);
                        }
                        throw new ArgumentException("ChangeColor command requires one parameter for the color name.");


                    case "load":
                        if (parameters.Length == 1)
                        {
                            return new LoadCommand(parameters[0]);
                        }
                        throw new ArgumentException("Load command requires a file path parameter.");

                    default:
                        throw new ArgumentException($"Command '{command}' is not recognized.");
                }
            }
        }
    }
