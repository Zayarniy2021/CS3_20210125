using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Utilites.Models;

namespace UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        private static int TestsCount = 0;

        [TestInitialize]
        public void InitTest()
        {
            System.IO.File.AppendAllText("tests.log", $"Test {++TestsCount} запушен в {DateTime.Now}\r\n");
        }

        [TestMethod]
        public void TestSum1()
        {
            int sum;
            var serviceRes = Utilites.Models.Service.Sum(2,2);
            int correctRes = 4;
            Assert.AreEqual(correctRes, serviceRes);

        }

        [ClassInitialize]
        public static void InitClass(TestContext context)
        {
            //будет запускаться перед каждым тестом
            System.IO.File.AppendAllText("tests.log", $"Test {context.TestName} starts in {DateTime.Now}\r\n");
        }
    }
}
