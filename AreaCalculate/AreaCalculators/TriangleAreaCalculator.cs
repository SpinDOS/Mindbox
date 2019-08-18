using System;
using AreaCalculate.Figures;

namespace AreaCalculate.Calculators
{
    public class TriangleAreaCalculator : TryAreaCalculatorBase<ThreeLinesTriangle>
    {
        public override double? TryCalculateArea(ThreeLinesTriangle figure)
        {
            var halfPerimeter = (figure.A.Length + figure.B.Length + figure.C.Length) / 2;

            var areaSqr = halfPerimeter *
                          (halfPerimeter - figure.A.Length) *
                          (halfPerimeter - figure.B.Length) *
                          (halfPerimeter - figure.C.Length);
            
            return Math.Sqrt(areaSqr);
        }
    }
}