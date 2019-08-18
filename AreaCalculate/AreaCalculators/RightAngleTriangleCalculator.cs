using System;
using AreaCalculate.Figures;

namespace AreaCalculate.Calculators
{
    public class RightAngleTriangleCalculator : TryAreaCalculatorBase<ThreeLinesTriangle>
    {
        private readonly double _epsilon;

        public RightAngleTriangleCalculator() : this(1e-8) { }

        public RightAngleTriangleCalculator(double epsilon) => _epsilon = Math.Abs(epsilon);

        public override double? TryCalculateArea(ThreeLinesTriangle figure)
        {
            DetermineHypotenuse(figure, out var hypotenuse, out var cathet1, out var cathet2);

            if (!AreEqual(Sqr(hypotenuse), Sqr(cathet1) + Sqr(cathet2)))
                return null;

            return cathet1 * cathet2 / 2;
        }

        public override int GetPriority(ThreeLinesTriangle figure) => base.GetPriority(figure) + 1000;
        
        private bool AreEqual(double x, double y) => Math.Abs(x - y) <= _epsilon;

        private static void DetermineHypotenuse(
            ThreeLinesTriangle triangle, out double hypotenuse, out double cathet1, out double cathet2)
        {
            hypotenuse = triangle.A.Length;
            cathet1 = triangle.B.Length;
            cathet2 = triangle.C.Length;
            
            if (hypotenuse < cathet1)
                Swap(ref hypotenuse, ref cathet1);
            if (hypotenuse < cathet2)
                Swap(ref hypotenuse, ref cathet2);
        }

        private static void Swap(ref double x, ref double y)
        {
            var z = x;
            x = y;
            y = z;
        }

        private static double Sqr(double x) => x * x;
    }
}