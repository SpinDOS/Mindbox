using AreaCalculate.Figures;

namespace AreaCalculate
{
    public interface ITryAreaCalculator
    {
        double? TryCalculateArea(FigureBase figure);
    }
}