using System;
using AreaCalculate.Figures;

namespace AreaCalculate
{
    public class AreaCalculationException : Exception
    {
        public AreaCalculationException(FigureBase figure, string message) 
            : base(message)
        {
            Figure = figure;
        }
        
        public FigureBase Figure { get; }
    }
}