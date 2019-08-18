using System;
using System.Linq;
using AreaCalculate.Figures;

namespace AreaCalculate.Calculators
{
    public class CompositeAreaCalculator : TryAreaCalculatorBase<CompositeFigure>
    {
        private readonly IAreaCalculator _areaCalculator;
        
        public CompositeAreaCalculator(IAreaCalculator areaCalculator)
        {
            _areaCalculator = areaCalculator ?? 
                              throw new ArgumentNullException(nameof(areaCalculator));
        }
        
        public override double? TryCalculateArea(CompositeFigure figure)
        {
            return figure.Figures.Sum(it => _areaCalculator.CalculateArea(it));
        }
    }
}