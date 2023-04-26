namespace Lab3_2
{
    public class FunctionHelper
    {
        public string FirstVar { get; set; } = string.Empty;
        public string SecondVar { get; set; } = string.Empty;
        public Operator Operator { get; set; }

        public static FunctionHelper Parse(string value)
        {
            FunctionHelper helper = new FunctionHelper();
            List<string> splitValues = value.Split(' ', '+', '-', '*', '/').ToList();
            splitValues.RemoveAll(sv => sv == "");
            if (splitValues.Count != 2)
                throw new ArgumentException($"Не верно задана функция {value}. Должно быть <param1><operator><param2>.");
            helper.FirstVar = splitValues[0];
            helper.SecondVar = splitValues[1];

            var operatorChar = value.Substring(helper.FirstVar.Length, 1);
            switch (operatorChar)
            {
                case "+":
                    helper.Operator = Operator.Sum;
                    break;
                case "-":
                    helper.Operator = Operator.Sub;
                    break;
                case "*":
                    helper.Operator = Operator.Mul;
                    break;
                case "/":
                    helper.Operator = Operator.Div;
                    break;
                default:
                    throw new ArgumentException("Ошибка парсинга строки при задании функции. Невозможно определить оператор");
            }
            return helper;
        }

        public double ExecuteFunction(double first, double second)
        {
            switch (this.Operator)
            {
                case Operator.Sum:
                    return first + second;
                case Operator.Sub:
                    return first - second;
                case Operator.Mul:
                    return first * second;
                default:
                    return first / second;
            }
        }

        public override string ToString()
        {
            switch (this.Operator)
            {
                case Operator.Sum:
                    return $"{this.FirstVar}+{this.SecondVar}";
                case Operator.Sub:
                    return $"{this.FirstVar}-{this.SecondVar}";
                case Operator.Mul:
                    return $"{this.FirstVar}*{this.SecondVar}";
                default:
                    return $"{this.FirstVar}/{this.SecondVar}";
            }
        }
    }
}
