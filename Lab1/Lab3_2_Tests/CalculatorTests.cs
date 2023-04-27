using Lab3_2;
using Lab3_2.Interfaces;

namespace Lab3_2_Tests
{
    public class CalculatorTests
    {

        private ICalc _calculator;

        [SetUp]
        public void Setup()
        {
            _calculator = new Calculator();
        }

        [Test]
        public void DeclareVariable_ThrowsArgumentException_WhenVariableAlreadyDeclared()
        {
            // Arrange
            _calculator.DeclareVariable("x");

            // Act & Assert
            Assert.Throws<System.ArgumentException>(() => _calculator.DeclareVariable("x"));
        }

        [Test]
        public void DeclareVariable_ThrowsArgumentException_WhenFunctionWithSameNameExists()
        {
            // Arrange
            _calculator.DeclareFunction("sin");

            // Act & Assert
            Assert.Throws<System.ArgumentException>(() => _calculator.DeclareVariable("sin"));
        }

        [Test]
        public void SetVariableValue_DeclaresVariable_WhenItDoesNotExist()
        {
            // Act
            _calculator.SetVariableValue("x", 10.0);

            // Assert
            Assert.AreEqual(_calculator.GetValue("x"), 10.0);
        }

        [Test]
        public void SetVariableValue_UpdatesValue_WhenVariableExists()
        {
            // Arrange
            _calculator.SetVariableValue("x", 20);

            // Act
            _calculator.SetVariableValue("x", 10.0);

            // Assert
            Assert.AreEqual(_calculator.GetValue("x"), 10);
        }

        [Test]
        public void SetVariableValue_ThrowsArgumentException_WhenVariableDoesNotExistAndValueIsNotValidVariableOrFunctionName()
        {
            // Act & Assert
            Assert.Throws<System.ArgumentException>(() => _calculator.SetVariableValue("x", "invalid_value"));
        }

        [Test]
        public void GetValue_ThrowsArgumentException_WhenVariableDoesNotExist()
        {
            // Act & Assert
            Assert.Throws<System.ArgumentException>(() => _calculator.GetValue("x"));
        }

        [Test]
        public void GetValue_ReturnsFunctionResult_WhenFunctionExists()
        {
            // Arrange
            _calculator.SetVariableValue("x", "5");
            _calculator.SetFunction("funx", "x*5");

            // Act
            var result = _calculator.GetValue("funx");

            // Assert
            Assert.AreEqual(result, 25);
        }

        [Test]
        public void DeclareFunction_ThrowsArgumentException_WhenFunctionAlreadyDeclared()
        {
            // Arrange
            _calculator.DeclareFunction("sin");

            // Act & Assert
            Assert.Throws<System.ArgumentException>(() => _calculator.DeclareFunction("sin"));
        }
    }
}
