using Microsoft.VisualStudio.TestTools.UnitTesting;
using GraphicsEnvironmentComp2.Commands;
using System.Drawing;
using GraphicsEnviromentComp2.CustomException;
using GraphicsEnvironmentComp2.GraphicContext;

namespace GraphicsEnvironmentComp2.Commands.Tests
{
    [TestClass]
    public class IfCommandTests
    {
        [TestMethod]
        public void ResetExecutionFlag_ExecutionFlagShouldBeTrue()
        {
            // Arrange
            IfCommand.SetConditionResult(false);

            // Act
            IfCommand.ResetExecutionFlag();

            // Assert
            Assert.IsTrue(IfCommand.ExecuteNext);
        }

        [TestMethod]
        public void IfCommand_WithValidCondition_ShouldSetExecutionFlag()
        {
            // Arrange
            var variableContext = new VariableContext();
            variableContext.SetVariable("myVar", 10); // Set a variable value

            var ifCommand = new IfCommand("myVar == 10", variableContext);

            // Act
            ifCommand.Execute(null); // Pass null for SafeGraphics, as it's not used in this test

            // Assert
            Assert.IsTrue(IfCommand.ExecuteNext);
        }
    }
}
