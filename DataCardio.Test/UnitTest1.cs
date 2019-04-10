using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DataCardio.Test
{
    [TestClass]
    public class UnitTest1
    {
        [DataTestMethod]
        [DataRow("w","non puoi inserire delle lettere")]
        [DataRow(10,189,147)]
        public void TestMethod1()
        {


        }
    }
}
