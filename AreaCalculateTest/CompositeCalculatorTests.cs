using System;
using AreaCalculate;
using AreaCalculate.Calculators;
using AreaCalculate.Figures;
using Moq;
using NUnit.Framework;

namespace AreaCalculateTest
{
    public class CompositeCalculatorTests
    {
        [Test]
        public void SimpleCompositeTest()
        {
            // Arrange
            var figure1 = new TestFigure();
            var figure2 = new TestFigure();
            var figure3 = new TestFigure();
            var compositeFigure = new CompositeFigure(new FigureBase[] { figure1, figure2, figure3 });

            var areaCalculator = new Mock<IAreaCalculator>(MockBehavior.Strict);
            areaCalculator.Setup(it => it.CalculateArea(figure1)).Returns(100);
            areaCalculator.Setup(it => it.CalculateArea(figure2)).Returns(20);
            areaCalculator.Setup(it => it.CalculateArea(figure3)).Returns(5.3);

            var compositeCalculator = new CompositeAreaCalculator(areaCalculator.Object);
            
            // Act
            var calculatedArea = compositeCalculator.TryCalculateArea(compositeFigure);
            
            // Assert
            Assert.AreEqual(125.3, calculatedArea, DoubleEquality.Epsilon);
        }

        [Test]
        public void EmptyCompositeTest()
        {
            // Arrange
            var compositeFigure = new CompositeFigure(Array.Empty<FigureBase>());
            
            var areaCalculator = new Mock<IAreaCalculator>(MockBehavior.Strict);
            var compositeCalculator = new CompositeAreaCalculator(areaCalculator.Object);
            
            // Act
            var calculatedArea = compositeCalculator.TryCalculateArea(compositeFigure);
            
            // Assert
            Assert.AreEqual(0, calculatedArea, 0);
        }

        [Test]
        public void DuplicateFigureTest()
        {
            // Arrange
            var figure = new TestFigure();
            var compositeFigure = new CompositeFigure(new FigureBase[] { figure, figure });

            var areaCalculator = new Mock<IAreaCalculator>(MockBehavior.Strict);
            areaCalculator.Setup(it => it.CalculateArea(figure)).Returns(10.5);

            var compositeCalculator = new CompositeAreaCalculator(areaCalculator.Object);
            
            // Act
            var calculatedArea = compositeCalculator.TryCalculateArea(compositeFigure);
            
            // Assert
            Assert.AreEqual(21, calculatedArea, DoubleEquality.Epsilon);
        }

        [Test]
        public void NestedCompositeTest()
        {
            // Arrange
            var figure = new TestFigure();
            var innerComposite = new CompositeFigure(Array.Empty<FigureBase>());
            var compositeFigure = new CompositeFigure(new FigureBase[] { innerComposite, figure });

            var areaCalculator = new Mock<IAreaCalculator>(MockBehavior.Strict);
            areaCalculator.Setup(it => it.CalculateArea(figure)).Returns(1.5);
            areaCalculator.Setup(it => it.CalculateArea(innerComposite)).Returns(2.1);

            var compositeCalculator = new CompositeAreaCalculator(areaCalculator.Object);
            
            // Act
            var calculatedArea = compositeCalculator.TryCalculateArea(compositeFigure);
            
            // Assert
            Assert.AreEqual(3.6, calculatedArea, DoubleEquality.Epsilon);
        }

        [Test]
        public void NotCompositeTest()
        {
            // Arrange
            var notComposite = new TestFigure();
            var areaCalculator = new Mock<IAreaCalculator>(MockBehavior.Strict);
            var calculator = new CompositeAreaCalculator(areaCalculator.Object);
            
            // Act
            var calculatedArea = calculator.TryCalculateArea(notComposite);
            
            // Assert
            Assert.Null(calculatedArea);
        }
    }
}