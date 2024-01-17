using GraphicsEnvironmentComp2.Commands;
using System.Collections.Generic;

namespace GraphicsEnvironmentComp2
{

    /// <summary>
    /// A user defined method, storing ability
    /// </summary>
    public class UserDefinedMethod
    {
        /// <summary>
        /// retrieves name of method
        /// </summary>
        public string MethodName { get; }
        /// <summary>
        /// List of parameters for methd
        /// </summary>
        public List<string> Parameters { get; }

        /// <summary>
        /// Rerieves list of commands for method
        /// </summary>
        public List<ICommandInterface> Commands { get; }

        /// <summary>
        /// A new instance of user defined method
        /// </summary>
        /// <param name="methodName">The name of the method</param>
        /// <param name="parameters">List of parameters for the method</param>
        /// <param name="commands">List of commands for methods</param>
        public UserDefinedMethod(string methodName, List<string> parameters, List<ICommandInterface> commands)
        {
            MethodName = methodName;
            Parameters = parameters;
            Commands = commands;
        }
    }
}
