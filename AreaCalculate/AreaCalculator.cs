using System;
using System.Collections.Generic;
using System.Linq;
using AreaCalculate.Figures;

namespace AreaCalculate
{
    public class AreaCalculator : IAreaCalculator, ITryAreaCalculatorCollection
    {
        public ICollection<ITryAreaCalculator> Calculators { get; } = new List<ITryAreaCalculator>();

        public double CalculateArea(FigureBase figure)
        {
            figure = figure ?? throw new ArgumentNullException(nameof(figure));
            return Calculators
                       .OrderByDescending(it => (it as ITryAreaCalculatorWithPriority)?.GetPriority(figure) ?? 0)
                       .Select(it => it.TryCalculateArea(figure))
                       .FirstOrDefault(it => it != null)
                   ?? throw new AreaCalculationException(figure, "Cannot calculate area for " + figure);
        }
    }
}