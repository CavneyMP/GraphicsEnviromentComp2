using Microsoft.VisualStudio.TestTools.UnitTesting;
using GraphicsEnvironmentComp2.Commands;
using GraphicsEnvironmentComp2.GraphicContext;
using System.Drawing;
using static GraphicsEnvironmentComp2.Form1;
using System;

namespace GraphicsEnvironmentComp2.Commands.Tests
{
    [TestClass()]
    public class LoopCommandTests
    {
        [TestMethod()]
        public void LoopCommand_Execute_ShouldExecuteCommandsForIterations()
        {
            var context = new GraphicsContext();
            var variableContext = new VariableContext();
            var loopCommand = new LoopCommand(3); // 3 iterations
            int executionCount = 0;

            ICommandInterface mockCommand = new MockCommand(() => executionCount++);

            loopCommand.AddCommand(mockCommand);

            var bmp = new Bitmap(100, 100);
            var graphics = Graphics.FromImage(bmp);
            var safeGraphics = new SafeGraphics(graphics);

            loopCommand.Execute(safeGraphics);

            Assert.AreEqual(3, executionCount); // Should execute 3 times

            graphics.Dispose();
            bmp.Dispose();
        }

        private class MockCommand : ICommandInterface
        {
            private readonly Action executeAction;

            public MockCommand(Action executeAction)
            {
                this.executeAction = executeAction;
            }

            public void Execute(SafeGraphics safeGraphics)
            {
                executeAction.Invoke();
            }
        }
    }
}