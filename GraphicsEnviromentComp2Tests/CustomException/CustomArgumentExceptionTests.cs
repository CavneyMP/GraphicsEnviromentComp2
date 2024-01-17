using Microsoft.VisualStudio.TestTools.UnitTesting;
using GraphicsEnviromentComp2.CustomException;
using System;

namespace GraphicsEnviromentComp2.CustomException.Tests
{
    [TestClass]
    public class CustomArgumentExceptionTests
    {
        [TestMethod]
        public void CustomArgumentException_Constructor_InitializesProperties()
        {
            string systemMessage = "System message";
            string userFriendlyMessage = "User-friendly message";

            var customException = new CustomArgumentException(systemMessage, userFriendlyMessage);

            Assert.AreEqual(systemMessage, customException.Message);
            Assert.AreEqual(userFriendlyMessage, customException.UserFriendlyMessage);
        }
    }
}
