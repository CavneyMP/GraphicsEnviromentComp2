using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GraphicsEnviromentComp2.CustomException;


namespace GraphicsEnvironmentComp2.GraphicContext
{
    /// <summary>
    /// This class manages a collection of variables that can be set, used and modified by user input
    /// Varaibles are stored with name and values in a pair and only accepts name as a string, and value as a integer.
    /// </summary>
    public class VariableContext
    {
        private Dictionary<string, int> variables = new Dictionary<string, int>(); // A dictionary used to store varaible value and its assignged name.

        /// <summary>
        /// This method "SetVariable" sets a varible when called, it requires name and value to be passed as paramerters.
        /// If the variable exists, it over writes, if it does not, it adds it to the dictionary with the specified param.
        /// </summary>
        /// <param name="name">The name of the variable</param>
        /// <param name="value">The integer to be assigned to the variable</param>
        public void SetVariable(string name, int value)
        {
            if (variables.ContainsKey(name)) // Check if exisitng variable name in dictionary
            {
                variables[name] = value; // If exists, then re-writes with new value passed.
            }
            else 
            {
                variables.Add(name, value); // If new to dictionary, then adds the name and value passed by the user.
            }
        }

        /// <summary>
        /// This gets the value of the variable, if it is found in the dictionary, if not it will throw and execption and report the reason for the error back.
        /// </summary>
        /// <param name="name">This is the name of the variable that is try to be found in the dicitonary</param>
        /// <returns>If found, it will return the interger value it is paired with</returns>
        /// <exception cref="ArgumentException"></exception>

        public int GetVariable(string name) 
        {
            if (variables.TryGetValue(name, out int value)) // If varaible is
            {
                return value; // Return value
            }
            else
            {
                throw new CustomArgumentException($" Tech message XXXX", $"Variable '{{{name}}}' is not defined."); // If value is not found, exception is thrown to report back to the user.
            }
        }


        /// <summary>
        /// Command to check a variable exists for error handling. 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public bool VariableExists(string name)
        {
            return variables.ContainsKey(name);
        }
    }
}

