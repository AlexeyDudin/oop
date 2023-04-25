using Lab3_2.Interfaces;

namespace Lab3_2.CalculatorDescriptions
{
    public class DoubleValue : IVarOrFunc
    {
        public double? Value { get; set; } = double.NaN;
        public double? GetValue()
        {
            return Value;
        }
    }
}
