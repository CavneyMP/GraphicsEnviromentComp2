using Microsoft.VisualStudio.TestTools.UnitTesting;
using GraphicsEnviromentComp2.GraphicContext;
using System;

namespace GraphicsEnviromentComp2.GraphicContext.Tests
{
    /// <summary>
    /// A unit tests for the VariableContext class.
    /// </summary>
    [TestClass()]
    public class VariableContextTests
    {
        /// <summary>
        /// Ensures Set Variable is correctly setting the value to the variable name. 
        /// </summary>
        [TestMethod()]
        public void SetVariable_ShouldStoreValue()
        {
            // This creates a new variable Context and defines a varible name and value
            var variableContext = new VariableContext();
            string variableName = "x";
            int value = 100;

            // Sets the variable
            variableContext.SetVariable(variableName, value);

            // Checks the value is recevied, and correctly. 
            Assert.AreEqual(value, variableContext.GetVariable(variableName), "Variable value does not match the expected value.");
        }

        /// <summary>
        /// This ensures the GetVariable method throws an exception when trying to retrieve an invalid variable.
        /// </summary>
        [TestMethod()]
        public void GetVariable_UndefinedVariable_ThrowException()
        {
            // New variable context, and sets a variable that has not been defined. 
            var variableContext = new VariableContext();
            string variableName = "undefinedVariable";

            // Attempts to retreive, when it cannot, and should be given the exception.
            var ex = Assert.ThrowsException<ArgumentException>(() => variableContext.GetVariable(variableName));
            Assert.AreEqual($"Variable '{variableName}' is not defined.", ex.Message, "Exception message does not match the expected message.");
        }

        /// <summary>
        /// Ensures set variable method correctly updates the value of an existing variable.
        /// </summary>
        [TestMethod()]
        public void SetVariable_UpdatingVariable_ShouldUpdateValue()
        {
            // Creates a new VariableContext and defines a variable name and two values.
            var variableContext = new VariableContext();
            string variableName = "x";
            int firstValue = 100;
            int updatedValue = 200;

            // Set initial value and then update with a new value.
            variableContext.SetVariable(variableName, firstValue);
            variableContext.SetVariable(variableName, updatedValue);

            // Ensure the new varible is held under the value.
            Assert.AreEqual(updatedValue, variableContext.GetVariable(variableName), "Variable value did not update to the new value.");
        }
    }
}
