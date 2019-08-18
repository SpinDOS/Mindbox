using System;
using AreaCalculate;
using AreaCalculate.Calculators;
using AreaCalculate.Figures;
using Moq;
using NUnit.Framework;

namespace AreaCalculateTest
{
    public class IntegrationTests
    {
        [Test]
        public void IntegrationTest()
        {
            // Arrange
            var circle = new Circle(1);
            var customFigure = new TestFigure();
            var innerComposite = new CompositeFigure(new FigureBase[] { circle, customFigure });
            
            var emptyComposite = new CompositeFigure(Array.Empty<FigureBase>());
            var triangle = new ThreeLinesTriangle(2.5, 3, 4);
            
            var composite = new CompositeFigure(new FigureBase[] { innerComposite, emptyComposite, triangle });
            var circle2 = new Circle(2);

            var customCalculatorNotUsed = new Mock<ITryAreaCalculator>(MockBehavior.Default);
            customCalculatorNotUsed.Setup(it => it.TryCalculateArea(customFigure))
                .Throws(new AssertionException("Should not be called"));
            
            var customCalculator = new Mock<ITryAreaCalculatorWithPriority>(MockBehavior.Default);
            customCalculator.Setup(it => it.TryCalculateArea(customFigure)).Returns(15.2);
            customCalculator.Setup(it => it.GetPriority(customFigure)).Returns(100);
            
            var areaCalculator = new AreaCalculator();
            areaCalculator.Calculators.Add(new CompositeAreaCalculator(areaCalculator));
            areaCalculator.Calculators.Add(new TriangleAreaCalculator());
            areaCalculator.Calculators.Add(new RightAngleTriangleCalculator());
            areaCalculator.Calculators.Add(new CircleAreaCalculator());
            areaCalculator.Calculators.Add(customCalculatorNotUsed.Object);
            areaCalculator.Calculators.Add(customCalculator.Object);
            
            // Act
            var compositeArea = areaCalculator.CalculateArea(composite);
            var triangleArea = areaCalculator.CalculateArea(triangle);
            var circle2Area = areaCalculator.CalculateArea(circle2);
            
            // Assert
            const double ExpectedTriangleArea = 3.7453095666446585;
            var expectedCompositeArea = Math.PI + 15.2 + ExpectedTriangleArea;
            
            Assert.AreEqual(expectedCompositeArea, compositeArea, DoubleEquality.Epsilon);
            Assert.AreEqual(ExpectedTriangleArea, triangleArea, DoubleEquality.Epsilon);
            Assert.AreEqual(4 * Math.PI, circle2Area, DoubleEquality.Epsilon);
        }
    }
}