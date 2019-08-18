using System;

namespace AreaCalculate.Figures
{
    public class ThreeLinesTriangle : FigureBase
    {
        public ThreeLinesTriangle(LineLength a, LineLength b, LineLength c)
        {
            ValidateLength(a, b, c, nameof(a));
            ValidateLength(b, a, c, nameof(b));
            ValidateLength(c, a, b, nameof(c));
            
            A = a;
            B = b;
            C = c;
        }
        
        public LineLength A { get; }
        public LineLength B { get; }
        public LineLength C { get; }

        private static void ValidateLength(LineLength line1, LineLength line2, LineLength line3, string line1Name)
        {
            if (line1.Length > line2.Length + line3.Length)
                throw new ArgumentOutOfRangeException(line1Name, $"{line1} is greater than {line2} + {line3}");
        }
    }
}