using Microsoft.VisualStudio.TestTools.UnitTesting;
using GraphicsEnvironmentComp2.Parser;
using GraphicsEnvironmentComp2.GraphicContext;
using System;
using System.Linq;

namespace GraphicsEnvironmentComp2.Tests
{
    /
    <summary>
    /// Test class for the command parser
    /// </summary>
    [TestClass()]
    public class CommandParserTests
    {
        /// <summary>
        /// This is a test method that checks that the single line command has been parsed correctly by checking what it recognises as parameters
        /// </summary>
        [TestMethod()]
        public void ParseSingleLineCommandWithParametersTest()
        {
            var variableContext = new VariableContext(); // Create VariableContext instance
            var parser = new CommandParser(variableContext); //Pass VariableContext to CommandParser
            string input = "moveto 100 100";
            string multiLineContent = "";

            var commandResult = parser.ParseCommand(input, multiLineContent);
            string[] tokens = input.Split(' ');

            Assert.IsNotNull(commandResult, "Command result should not be null.");
            Assert.AreEqual("moveto", tokens[0], "First token did not match command.");
            Assert.AreEqual("100", tokens[1], "Second token does not match expected param.");
            Assert.AreEqual("100", tokens[2], "Third token does not match expected param.");
        }

        /// <summary>
        /// Test method to check that multi line commands get recognised by checking there are two separate tokens when the parsing has occurred as this will show that one input has been split up correctly
        /// </summary>
        [TestMethod()]
        public void ParseMultiLineCommandsTest()
        {
            var variableContext = new VariableContext(); // Create VariableContext instance
            var parser = new CommandParser(variableContext); //Pass VariableContext to CommandParser
            string multiLineInput = "moveto 100 100\nreset";

            string[] lines = multiLineInput.Split(new string[] { "\r\n", "\r", "\n" }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var line in lines)
            {
                var commandResult = parser.ParseCommand(line, multiLineInput);
                string[] tokens = line.Split(' ');

                Assert.IsNotNull(commandResult, "Command result should not be null: " + line);
                Assert.IsTrue(tokens.Length >= 1, "There should be at least one command: " + line);
            }
        }
    }
}
