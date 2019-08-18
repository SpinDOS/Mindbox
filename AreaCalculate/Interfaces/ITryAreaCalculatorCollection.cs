using System.Collections.Generic;

namespace AreaCalculate
{
    public interface ITryAreaCalculatorCollection
    {
        ICollection<ITryAreaCalculator> Calculators { get; }
    }
}