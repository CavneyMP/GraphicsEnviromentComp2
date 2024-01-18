using Microsoft.VisualStudio.TestTools.UnitTesting;
using GraphicsEnvironmentComp2.Commands;
using GraphicsEnvironmentComp2.GraphicContext;
using System.Drawing;
using static GraphicsEnvironmentComp2.Form1;
using System;

namespace GraphicsEnvironmentComp2.Commands.Tests
{

    /// <summary>
    /// A class which contains tests for the loop command
    /// </summary>
    [TestClass()]
    public class LoopCommandTests
    {
        /// <summary>
        /// The test is looking to make sure that the loop command executes the commands for the correct number of iterations
        /// </summary>
        [TestMethod()]
        public void LoopCommand_Execute_ShouldExecuteCommandsForIterations()
        {
            var context = new GraphicsContext();
            var variableContext = new VariableContext();
            string iterationVariable = "iterations";
            int iterationCount = 3;
            variableContext.SetVariable(iterationVariable, iterationCount); 

            var loopCommand = new LoopCommand(iterationVariable, variableContext); 
            int executionCount = 0;

            ICommandInterface mockCommand = new MockCommand(() => executionCount++);

            loopCommand.AddCommand(mockCommand);

            var bmp = new Bitmap(100, 100);
            var graphics = Graphics.FromImage(bmp);
            var safeGraphics = new SafeGraphics(graphics);

            loopCommand.Execute(safeGraphics);

            Assert.AreEqual(iterationCount, executionCount); // Should execute 3 times

            graphics.Dispose();
            bmp.Dispose();
        }


        /// <summary>
        /// Mock command for testing purposes
        /// </summary>

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