using AreaCalculate.Figures;

namespace AreaCalculate
{
    public interface ITryAreaCalculatorWithPriority : ITryAreaCalculator
    {
        int GetPriority(FigureBase figure);
    }
}