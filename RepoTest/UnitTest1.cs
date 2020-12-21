using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RepoTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void AgeCalculator(DateTime birthday)
        {
            DateTime now = DateTime.Now;
            int age = now.Year - birthday.Year;


        }
    }
}
