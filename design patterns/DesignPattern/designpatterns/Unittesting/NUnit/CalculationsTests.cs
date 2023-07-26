using MathOperations;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnit
{
    [TestFixture]
    public class CalculationsTests
    {
        private Calculator? calculation;

        [SetUp] 
        public void SetUp() 
        {
            calculation = new Calculation();
         
        }

        [TestCaseSource(nameof(CommonTestCases))]
        [ Order(1)]
        public void AddTest(int n1, int n2)
        {
            calculation = new Calculation(n1, n2);
            int res = calculation.Add();
            Assert.AreEqual(n1 + n2, res);

        }

        [TestCaseSource(nameof(CommonTestCases))]
        [Order(2)]
        //[Ignore("In progress ")]
        public void SubTest(int n1, int n2)
        {

            int res = calculation.Sub();
            Assert.AreEqual(n1-n2, res);

        }

        [TestCaseSource(nameof(CommonTestCases))]
        [Order(3)]
        public void MulTest(int n1,  int n2)
        {

            int res = calculation.Mul();
            Assert.AreEqual(n1*n2, res);

        }
        private static IEnumerable<TestCaseData> CommonTestCases()
        {
            yield return new TestCaseData(10, 20);
            yield return new TestCaseData(15, 5);
            yield return new TestCaseData(5, 6);
        }

        [TearDown]
        public void TearDown()
        {
            calculation = null;
        }
    }
}
