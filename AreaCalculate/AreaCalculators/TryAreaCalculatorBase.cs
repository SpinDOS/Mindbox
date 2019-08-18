using AreaCalculate.Figures;

namespace AreaCalculate.Calculators
{
    public abstract class TryAreaCalculatorBase<TFigure> : ITryAreaCalculatorWithPriority
        where TFigure : FigureBase
    {
        public virtual double? TryCalculateArea(FigureBase figure)
        {
            if (figure is TFigure typedFigure)
                return TryCalculateArea(typedFigure);
            
            return null;
        }

        public virtual int GetPriority(FigureBase figure)
        {
            return figure is TFigure typedFigure? GetPriority(typedFigure) : default;
        }

        public virtual int GetPriority(TFigure figure) => 100;

        public abstract double? TryCalculateArea(TFigure figure);
    }
}