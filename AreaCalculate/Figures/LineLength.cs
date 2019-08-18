using System;

namespace AreaCalculate.Figures
{
    public struct LineLength
    {
        public LineLength(double length)
        {
            if (length < 0)
                throw new ArgumentOutOfRangeException(nameof(length), "Length cannot be negative number");

            Length = length;
        }
        
        public double Length { get; }
        
        public static implicit operator LineLength(double length) => new LineLength(length);
    }
}