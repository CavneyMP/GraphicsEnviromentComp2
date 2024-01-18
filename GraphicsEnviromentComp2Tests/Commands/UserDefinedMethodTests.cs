using Microsoft.VisualStudio.TestTools.UnitTesting;
using GraphicsEnvironmentComp2;
using System.Collections.Generic;
using GraphicsEnvironmentComp2.Commands;
using static GraphicsEnvironmentComp2.Form1;

namespace GraphicsEnvironmentComp2.Tests

{
    /// <summary>
    /// This class contains unit tests for the user defined methods, to ensure it works properly
    /// </summary>
    [TestClass()]
    public class UserDefinedMethodTests
    {
        /// <summary>
        /// Tests whether the constructor initializes the properties correctly
        /// </summary>
        [TestMethod()]
        public void UserDefinedMethod_Constructor_InitializesProperties()
        {
            string methodName = "MyMethod";
            List<string> parameters = new List<string> { "param1", "param2" };
            List<ICommandInterface> commands = new List<ICommandInterface>
            {
                new SimulateCommand(),
                new SimulateCommand()
            };

            var userDefinedMethod = new UserDefinedMethod(methodName, parameters, commands);

           
            Assert.AreEqual(methodName, userDefinedMethod.MethodName);
            CollectionAssert.AreEqual(parameters, userDefinedMethod.Parameters);
            CollectionAssert.AreEqual(commands, userDefinedMethod.Commands);
        }

        /// <summary>
        /// A mock implementation of the iCommand interface for testing purposes.
        /// </summary>

        private class SimulateCommand : ICommandInterface
        {
            public void Execute(SafeGraphics safeGraphics)
            {
            }
        }
    }
}
