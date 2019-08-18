using System;
using AreaCalculate.Figures;

namespace AreaCalculate.Calculators
{
    public class CircleAreaCalculator : TryAreaCalculatorBase<Circle>
    {
        public override double? TryCalculateArea(Circle figure)
        {
            return Math.PI * figure.Radius * figure.Radius;
        }
    }
}