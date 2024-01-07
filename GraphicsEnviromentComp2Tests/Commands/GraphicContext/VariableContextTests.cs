using Microsoft.VisualStudio.TestTools.UnitTesting;
using GraphicsEnviromentComp2.GraphicContext;
using System;

namespace GraphicsEnviromentComp2.GraphicContext.Tests
{
    /// <summary>
    /// Provides unit tests for the VariableContext class to ensure it behaves as expected.
    /// </summary>
    [TestClass()]
    public class VariableContextTests
    {
        /// <summary>
        /// Tests whether the SetVariable method correctly stores the value for a given variable name.
        /// </summary>
        [TestMethod()]
        public void SetVariable_ShouldStoreCorrectValue()
        {
            // Arrange: Create a new VariableContext and define a variable name and value.
            var variableContext = new VariableContext();
            string variableName = "x";
            int value = 100;

            // Act: Set the variable in the context.
            variableContext.SetVariable(variableName, value);

            // Assert: Verify that the value can be retrieved correctly.
            Assert.AreEqual(value, variableContext.GetVariable(variableName), "Variable value does not match the expected value.");
        }

        /// <summary>
        /// Tests whether the GetVariable method throws an exception when trying to retrieve an undefined variable.
        /// </summary>
        [TestMethod()]
        public void GetVariable_UndefinedVariable_ShouldThrowException()
        {
            // Arrange: Create a new VariableContext and define a variable name that hasn't been set.
            var variableContext = new VariableContext();
            string variableName = "undefinedVariable";

            // Act & Assert: Attempt to retrieve the variable and confirm that the correct exception is thrown.
            var ex = Assert.ThrowsException<ArgumentException>(() => variableContext.GetVariable(variableName));
            Assert.AreEqual($"Variable '{variableName}' is not defined.", ex.Message, "Exception message does not match the expected message.");
        }

        /// <summary>
        /// Tests whether the SetVariable method correctly updates the value of an existing variable.
        /// </summary>
        [TestMethod()]
        public void SetVariable_UpdateExistingVariable_ShouldUpdateValue()
        {
            // Arrange: Create a new VariableContext and define a variable name and two different values.
            var variableContext = new VariableContext();
            string variableName = "x";
            int initialValue = 100;
            int updatedValue = 200;

            // Act: Set the initial value and then update it to a new value.
            variableContext.SetVariable(variableName, initialValue);
            variableContext.SetVariable(variableName, updatedValue);

            // Assert: Verify that the variable now holds the updated value.
            Assert.AreEqual(updatedValue, variableContext.GetVariable(variableName), "Variable value did not update to the new value.");
        }
    }
}
