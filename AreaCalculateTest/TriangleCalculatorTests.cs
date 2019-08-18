using AreaCalculate.Calculators;
using AreaCalculate.Figures;
using NUnit.Framework;

namespace AreaCalculateTest
{
    public class TriangleCalculatorTests
    {
        [Test]
        public void SimpleTriangleTest()
        {
            // Arrange
            var triangle = new ThreeLinesTriangle(2.5, 3, 4);
            var triangleCalculator = new TriangleAreaCalculator();
            
            // Act
            var calculatedArea = triangleCalculator.TryCalculateArea(triangle);
            
            // Assert
            Assert.AreEqual(3.7453095666446585, calculatedArea, DoubleEquality.Epsilon);
        }

        [Test]
        public void RightAngleTriangleTest()
        {
            // Arrange
            var triangle = new ThreeLinesTriangle(4, 5, 3);
            var triangleCalculator = new TriangleAreaCalculator();
            
            // Act
            var calculatedArea = triangleCalculator.TryCalculateArea(triangle);
            
            // Assert
            Assert.AreEqual(6, calculatedArea, DoubleEquality.Epsilon);
        }

        [Test]
        public void LineTriangleTest()
        {
            // Arrange
            var triangle = new ThreeLinesTriangle(6, 2.5, 3.5);
            var triangleCalculator = new TriangleAreaCalculator();
            
            // Act
            var calculatedArea = triangleCalculator.TryCalculateArea(triangle);
            
            // Assert
            Assert.AreEqual(0, calculatedArea, DoubleEquality.Epsilon);
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