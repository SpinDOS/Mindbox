using AreaCalculate;
using Moq;
using NUnit.Framework;

namespace AreaCalculateTest
{
    public class AreaCalculatorTests
    {
        [Test]
        public void SimpleAreaCalculatorTest()
        {
            // Arrange
            var figure1 = new TestFigure();
            var figure2 = new TestFigure();
            var figure3 = new TestFigure();
            
            var figure1Calculator = new Mock<ITryAreaCalculator>(MockBehavior.Default);
            figure1Calculator.Setup(it => it.TryCalculateArea(figure1)).Returns(1);
            
            var figure2Calculator = new Mock<ITryAreaCalculator>(MockBehavior.Default);
            figure2Calculator.Setup(it => it.TryCalculateArea(figure2)).Returns(2);
            
            var figure3Calculator = new Mock<ITryAreaCalculator>(MockBehavior.Default);
            figure3Calculator.Setup(it => it.TryCalculateArea(figure3)).Returns(0);
            
            var areaCalculator = new AreaCalculator();
            areaCalculator.Calculators.Add(figure1Calculator.Object);
            areaCalculator.Calculators.Add(figure2Calculator.Object);
            areaCalculator.Calculators.Add(figure3Calculator.Object);
            
            // Act
            var figure1Area = areaCalculator.CalculateArea(figure1);
            var figure2Area = areaCalculator.CalculateArea(figure2);
            var figure3Area = areaCalculator.CalculateArea(figure3);
            
            // Assert
            Assert.AreEqual(1, figure1Area);
            Assert.AreEqual(2, figure2Area);
            Assert.AreEqual(0, figure3Area);
        }
        
        [Test]
        public void PriorityUsageTest()
        {
            // Arrange
            var figure = new TestFigure();
            
            var withoutPriority = new Mock<ITryAreaCalculator>(MockBehavior.Strict);
            withoutPriority.Setup(it => it.TryCalculateArea(figure))
                .Throws(new AssertionException("Should not be called"));
            
            const double ExpectedArea = 10;
            var withPriority = new Mock<ITryAreaCalculatorWithPriority>(MockBehavior.Strict);
            withPriority.Setup(it => it.TryCalculateArea(figure)).Returns(ExpectedArea);
            withPriority.Setup(it => it.GetPriority(figure)).Returns(1);
            
            var areaCalculator = new AreaCalculator();
            areaCalculator.Calculators.Add(withoutPriority.Object);
            areaCalculator.Calculators.Add(withPriority.Object);
            
            // Act
            var calculatedArea = areaCalculator.CalculateArea(figure);
            
            // Assert
            Assert.AreEqual(ExpectedArea, calculatedArea);
        }

        [Test]
        public void CalculatorsOrderPreserveTest()
        {
            // Arrange
            var figure = new TestFigure();
            
            var firstCalculator = new Mock<ITryAreaCalculator>(MockBehavior.Strict);
            firstCalculator.Setup(it => it.TryCalculateArea(figure)).Returns(1);
            
            var secondCalculator = new Mock<ITryAreaCalculator>(MockBehavior.Strict);
            secondCalculator.Setup(it => it.TryCalculateArea(figure)).Returns(2);
            
            var areaCalculator = new AreaCalculator();
            areaCalculator.Calculators.Add(firstCalculator.Object);
            areaCalculator.Calculators.Add(secondCalculator.Object);
            
            // Act
            var calculatedArea = areaCalculator.CalculateArea(figure);
            
            // Assert
            Assert.AreEqual(1, calculatedArea);
        }

        [Test]
        public void NoCalculatorTest()
        {
            // Arrange
            var withCalculator = new TestFigure();
            var withoutCalculator = new TestFigure();
            
            var firstCalculator = new Mock<ITryAreaCalculator>(MockBehavior.Default);
            firstCalculator.Setup(it => it.TryCalculateArea(withCalculator)).Returns(1);
            
            var areaCalculator = new AreaCalculator();
            areaCalculator.Calculators.Add(firstCalculator.Object);
            
            // Act
            var calculatedArea = areaCalculator.CalculateArea(withCalculator);
            
            // Assert
            Assert.AreEqual(1, calculatedArea);
            
            TestDelegate calculateWithoutCalculator = () => areaCalculator.CalculateArea(withoutCalculator);
            var exception = Assert.Throws<AreaCalculationException>(calculateWithoutCalculator);
            Assert.AreEqual(withoutCalculator, exception.Figure);
        }
    }
}