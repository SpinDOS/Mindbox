using System;
using System.Collections.Generic;

namespace AreaCalculate.Figures
{
    public class CompositeFigure : FigureBase
    {
        public CompositeFigure(FigureBase[] figures)
        {
            Figures = figures ?? throw new ArgumentNullException(nameof(figures));
        }
        
        public IReadOnlyCollection<FigureBase> Figures { get; }
    }
}