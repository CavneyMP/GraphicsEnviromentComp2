using Microsoft.VisualStudio.TestTools.UnitTesting;
using GraphicsEnvironmentComp2.GraphicContext;
using GraphicsEnviromentComp2.CustomException;

namespace GraphicsEnvironmentComp2.GraphicContext.Tests
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
            // This creates a new variable Context and defines a variable name and value
            var variableContext = new VariableContext();
            string variableName = "x";
            int value = 100;

            // Sets the variable
            variableContext.SetVariable(variableName, value);

            // Checks the value is received, and correctly. 
            Assert.AreEqual(value, variableContext.GetVariable(variableName), "Variable value does not match the expected value.");
        }

        /// <summary>
        /// This ensures the GetVariable method throws an exception when trying to retrieve an invalid variable.
        /// </summary>
        [TestMethod()]
        public void GetVariable_UndefinedVariable_ThrowException()
        {
            var variableContext = new VariableContext();
            string undefinedVariableName = "undefinedVariable";

            //CustomArgumentException is thrown when trying to get an undefined variable
            Assert.ThrowsException<CustomArgumentException>(() =>
            {
                variableContext.GetVariable(undefinedVariableName);
            }, "Expected a CustomArgumentException to be thrown for an undefined variable.");
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

            // Set the initial value and then update it with a new value.
            variableContext.SetVariable(variableName, firstValue);
            variableContext.SetVariable(variableName, updatedValue);

            // Ensure the new variable holds the updated value.
            Assert.AreEqual(updatedValue, variableContext.GetVariable(variableName), "Variable value did not update to the new value.");
        }
    }
}
