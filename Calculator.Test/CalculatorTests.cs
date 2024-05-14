namespace Calculator.Test
{
    [TestClass]
    public class CalculatorTests
    {
        [TestMethod]
        public void Calculator_Compute_ValidAddition_ReturnsComputedValue()
        {
            var calculator = new Calculator();
            var result = calculator.Compute<int>("15 3 +");

            Assert.AreEqual(18, result);
        }

        [TestMethod]
        public void Calculator_Compute_ValidSubtraction_ReturnsComputedValue()
        {
            var calculator = new Calculator();
            var result = calculator.Compute<int>("15 3 -");

            Assert.AreEqual(12, result);
        }

        [TestMethod]
        public void Calculator_Compute_ValidProduct_ReturnsComputedValue()
        {
            var calculator = new Calculator();
            var result = calculator.Compute<int>("15 3 *");

            Assert.AreEqual(45, result);
        }

        [TestMethod]
        public void Calculator_Compute_ValidDivision_ReturnsComputedValue()
        {
            var calculator = new Calculator();
            var result = calculator.Compute<int>("15 3 /");

            Assert.AreEqual(5, result);
        }

        [TestMethod]
        public void Calculator_Compute_DivisionByZero_CallsSendErrorMethod()
        {
            var methodWasCalled = false;

            var calculator = new Calculator();
            calculator.OnError += delegate (Exception ex)
            {
                methodWasCalled = true;
            };

            calculator.Compute<int>("15 0 /");
            Assert.IsTrue(methodWasCalled);
        }

        [TestMethod]
        public void Calculator_Compute_InvalidOperator_CallsSendErrorMethod()
        {
            var methodWasCalled = false;

            var calculator = new Calculator();
            calculator.OnError += delegate (Exception ex)
            {
                methodWasCalled = true;
            };

            calculator.Compute<int>("15 3 ;");
            Assert.IsTrue(methodWasCalled);
        }

        [TestMethod]
        public void Calculator_Compute_InvalidOperand_CallsSendErrorMethod()
        {
            var methodWasCalled = false;

            var calculator = new Calculator();
            calculator.OnError += delegate (Exception ex)
            {
                methodWasCalled = true;
            };

            calculator.Compute<int>("k 3 /");
            Assert.IsTrue(methodWasCalled);
        }

        [TestMethod]
        public void Calculator_Compute_InvalidNumberOfTokens_CallsSendErrorMethod()
        {
            var methodWasCalled = false;

            var calculator = new Calculator();
            calculator.OnError += delegate (Exception ex)
            {
                methodWasCalled = true;
            };

            calculator.Compute<int>("15 3 1 /");
            Assert.IsTrue(methodWasCalled);
        }
    }
}