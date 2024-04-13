using Microsoft.VisualStudio.TestTools.UnitTesting;
using CalcLibrary;

namespace CalcTest
{
    [TestClass]
    public class CalcTest
    {
        [TestMethod]
        public void CalculateTestMethodGetOperands()
        {
            string[] expression = Calc.GetOperands("23+4,5");
            Assert.AreEqual("23", expression[0]);
            Assert.AreEqual("4,5", expression[1]);

            expression = Calc.GetOperands("-23-4,5");
            Assert.AreEqual("-23", expression[0]);
            Assert.AreEqual("4,5", expression[1]);

            expression = Calc.GetOperands("-23+4,5");
            Assert.AreEqual("-23", expression[0]);
            Assert.AreEqual("4,5", expression[1]);

            expression = Calc.GetOperands("23-4,5");
            Assert.AreEqual("23", expression[0]);
            Assert.AreEqual("4,5", expression[1]);

            expression = Calc.GetOperands("-23+4,5");
            Assert.AreEqual("-23", expression[0]);
            Assert.AreEqual("4,5", expression[1]);
        }
        [TestMethod]
        public void CalculateTestMethodGetOperation()
        {
            string operation = Calc.GetOperation("23+4,5");
            Assert.AreEqual('+', operation[0]);

            operation = Calc.GetOperation("23-4,5");
            Assert.AreEqual('-', operation[0]);

            operation = Calc.GetOperation("23*4,5");
            Assert.AreEqual('*', operation[0]);

            operation = Calc.GetOperation("23/4,5");
            Assert.AreEqual('/', operation[0]);

            operation = Calc.GetOperation("-23*4,5");
            Assert.AreEqual('*', operation[0]);

            operation = Calc.GetOperation("-23-4,5");
            Assert.AreEqual('-', operation[0]);

            operation = Calc.GetOperation("-23+4,5");
            Assert.AreEqual('+', operation[0]);

            operation = Calc.GetOperation("-23/4,5");
            Assert.AreEqual('/', operation[0]);
        }

        [TestMethod]
        public void ResultTestMethod()
        {
            Assert.AreEqual("27,5", Calc.DoubleOperation["+"](23, 4.5).ToString());
            Assert.AreEqual("27,5", Calc.DoOperation("23+4,5"));

            Assert.AreEqual("-5,5", Calc.DoubleOperation["-"](-10, -4.5).ToString());
            Assert.AreEqual("-14,5", Calc.DoOperation("-10-4,5"));

            Assert.AreEqual("-4,6", Calc.DoubleOperation["*"](2, -2.3).ToString());
            Assert.AreEqual("49,7", Calc.DoOperation("7*7,1"));

            Assert.AreEqual("-4", Calc.DoubleOperation["/"](-10, 2.5).ToString());
            Assert.AreEqual("5", Calc.DoOperation("10/2"));
        }
    }
}
