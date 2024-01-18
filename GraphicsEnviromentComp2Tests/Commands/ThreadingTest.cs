using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading;

namespace GraphicsEnviromentComp2Tests.Commands
{
    [TestClass]
    public class ThreadingTest
    {
        [TestMethod]
        public void VerifyThreadingWorks()
        {
            bool thread1Started = false;
            bool thread2Started = false;

            Thread program1Thread = new Thread(() =>
            {
                Thread.Sleep(2000);
                thread1Started = true;
            });

            Thread program2Thread = new Thread(() =>
            {
                Thread.Sleep(1000);
                thread2Started = true;
            });

            program1Thread.Start();
            program2Thread.Start();

            program1Thread.Join();
            program2Thread.Join();

            Assert.IsTrue(thread1Started);
            Assert.IsTrue(thread2Started);
        }
    }
}