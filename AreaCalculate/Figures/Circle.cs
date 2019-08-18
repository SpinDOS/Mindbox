using System;

namespace AreaCalculate.Figures
{
    public class Circle : FigureBase
    {
        public Circle(double radius)
        {
            if (radius < 0)
                throw new ArgumentOutOfRangeException(nameof(radius), "Radius cannot be negative number");

            Radius = radius;
        }

        public double Radius { get; }
    }
}