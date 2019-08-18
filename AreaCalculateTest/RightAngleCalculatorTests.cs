using AreaCalculate.Calculators;
using AreaCalculate.Figures;
using NUnit.Framework;

namespace AreaCalculateTest
{
    public class RightAngleCalculatorTests
    {
        [Test]
        public void SimpleRightAngleTriangleTest()
        {
            // Arrange
            var triangle = new ThreeLinesTriangle(4, 5, 3);
            var triangleCalculator = new RightAngleTriangleCalculator();
            
            // Act
            var calculatedArea = triangleCalculator.TryCalculateArea(triangle);
            
            // Assert
            Assert.AreEqual(6, calculatedArea, DoubleEquality.Epsilon);
        }

        [Test]
        [TestCase(1, 1, 1)]
        [TestCase(1, 2, 2.2)]
        public void NotRightAngleCalculatorTest(double a, double b, double c)
        {
            // Arrange
            var triangle = new ThreeLinesTriangle(a, b, c);
            var triangleCalculator = new RightAngleTriangleCalculator();
            
            // Act
            var calculatedArea = triangleCalculator.TryCalculateArea(triangle);
            
            // Assert
            Assert.Null(calculatedArea);
        }

        [Test]
        public void BigEpsilonTest()
        {
            // Arrange
            var triangle = new ThreeLinesTriangle(1, 2, 2.2);
            var triangleCalculator = new RightAngleTriangleCalculator(0.5);
            
            // Act
            var calculatedArea = triangleCalculator.TryCalculateArea(triangle);
            
            // Assert
            Assert.NotNull(calculatedArea);
        }

        [Test]
        public void NotTriangleTest()
        {
            // Arrange
            var notTriangle = new TestFigure();
            var calculator = new TriangleAreaCalculator();
            
            // Act
            var calculatedArea = calculator.TryCalculateArea(notTriangle);
            
            // Assert
            Assert.Null(calculatedArea);
        }
    }
}