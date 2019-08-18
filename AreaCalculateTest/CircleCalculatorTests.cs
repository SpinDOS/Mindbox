using System;
using AreaCalculate.Calculators;
using AreaCalculate.Figures;
using NUnit.Framework;

namespace AreaCalculateTest
{
    public class CircleCalculatorTests
    {
        [Test]
        [TestCase(0d, 0d)]
        [TestCase(1, Math.PI)]
        [TestCase(3, 9 * Math.PI)]
        [TestCase(1.5, 2.25 * Math.PI)]
        public void CircleCalculatorTest(double radius, double area)
        {
            // Arrange
            var circle = new Circle(radius);
            var calculator = new CircleAreaCalculator();

            // Act
            var calculatedArea = calculator.TryCalculateArea(circle);
            
            // Assert
            Assert.AreEqual(area, calculatedArea, DoubleEquality.Epsilon);
        }

        [Test]
        public void NotCircleTest()
        {
            // Arrange
            var notCircle = new TestFigure();
            var calculator = new CircleAreaCalculator();
            
            // Act
            var calculatedArea = calculator.TryCalculateArea(notCircle);
            
            // Assert
            Assert.Null(calculatedArea);
        }
    }
}