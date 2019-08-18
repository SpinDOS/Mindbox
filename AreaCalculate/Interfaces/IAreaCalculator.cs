using AreaCalculate.Figures;

namespace AreaCalculate
{
    public interface IAreaCalculator
    {
        double CalculateArea(FigureBase figure);
    }
}