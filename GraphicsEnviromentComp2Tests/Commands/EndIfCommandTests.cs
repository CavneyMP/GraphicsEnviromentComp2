using Microsoft.VisualStudio.TestTools.UnitTesting;
using GraphicsEnvironmentComp2.Commands;
using System.Drawing;

namespace Tests
{

    /// <summary>
    /// Unit tests to test the endIf command
    /// </summary>
    [TestClass()]
    public class EndIfCommandTests
    {
    /// <summary>
    /// Tests that the endif command execute method resets the flag. 
    /// </summary>
        [TestMethod()]
        public void Execute_ShouldResetShouldExecuteNextFlag()
        {
            // reset flag
            IfCommand.ResetExecutionFlag();

            IfCommand.SetConditionResult(false);

            var endIfCommand = new EndIfCommand();

            endIfCommand.Execute(null);

            // Assert that the ExecuteNext flag is reset to true
            Assert.IsTrue(IfCommand.ExecuteNext, "EndIfCommand should reset the ExecuteNext flag to true.");
        }
    }
}