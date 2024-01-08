using Microsoft.VisualStudio.TestTools.UnitTesting;
using GraphicsEnvironmentComp2.Commands;
using System.Drawing;

namespace Tests
{
    [TestClass()]
    public class EndIfCommandTests
    {
        [TestMethod()]
        public void Execute_ShouldResetShouldExecuteNextFlag()
        {
            // reset flag
            IfCommand.ResetExecutionFlag();

            IfCommand.SetConditionResult(false);

            var endIfCommand = new EndIfCommand();

            endIfCommand.Execute(null);  

            Assert.IsTrue(IfCommand.ExecuteNext,
                "EndIfCommand should reset the ExecuteNext flag to true.");
        }
    }
}
