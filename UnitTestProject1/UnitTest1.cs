using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using examination_card1; 

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        private MainWindow window;

        [TestInitialize]
        public void Setup()
        {
            window = new MainWindow();
        }

        [TestMethod]
        public void TestValidScores()
        {
            Assert.IsTrue(window.IsValidScore(10, 10));
            Assert.IsTrue(window.IsValidScore(50, 50));
            Assert.IsTrue(window.IsValidScore(30, 30));
            Assert.IsTrue(window.IsValidScore(10, 10));
        }

        [TestMethod]
        public void TestInvalidScores()
        {
            Assert.IsFalse(window.IsValidScore(-1, 10));
            Assert.IsFalse(window.IsValidScore(11, 10));
            Assert.IsFalse(window.IsValidScore(51, 50));
            Assert.IsFalse(window.IsValidScore(31, 30));
        }

        [TestMethod]
        public void TestGradeCalculation()
        {
            Assert.AreEqual("5 (отлично)", window.GetGrade(70));
            Assert.AreEqual("4 (хорошо)", window.GetGrade(40));
            Assert.AreEqual("3 (удовлетворительно)", window.GetGrade(20));
            Assert.AreEqual("2 (неудовлетворительно)", window.GetGrade(19));
        }
    }
}