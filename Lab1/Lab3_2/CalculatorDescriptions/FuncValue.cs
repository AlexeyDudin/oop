using Lab3_2.Interfaces;

namespace Lab3_2.CalculatorDescriptions
{
    public class FuncValue : IVarOrFunc
    {
        private double? _value;

        private void ExecuteFunction(IVarOrFunc val1, IVarOrFunc val2, string op)
        {
            switch (op)
            {
                case "+":
                    _value = Summ(val1.GetValue(), val2.GetValue());
                    break;
                case "-":
                    _value = Sub(val1.GetValue(), val2.GetValue());
                    break;
                case "*":
                    _value = Multiply(val1.GetValue(), val2.GetValue());
                    break;
                case "/":
                    _value = Divide(val1.GetValue(), val2.GetValue());
                    break;
            }
        }

        private double? Summ(double? val1, double? val2)
        {
            if (val1 == null || val2 == null)
                return null;
            return val1 + val2;
        }
        private double? Sub(double? val1, double? val2)
        {
            if (val1 == null || val2 == null)
                return null;
            return val1 - val2;
        }
        private double? Multiply(double? val1, double? val2)
        {
            if (val1 == null || val2 == null)
                return null;
            return val1 * val2;
        }
        private double? Divide(double? val1, double? val2)
        {
            if (val1 == null || val2 == null)
                return null;
            return val1 / val2;
        }

        public double? GetValue()
        {
            return _value;
        }
    }
}
