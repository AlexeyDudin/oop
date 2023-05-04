namespace Lab3_2
{
    //Убрать парсинг, хранить ссылки на переменные/функции
    public class FunctionHelper
    {
        public string FirstVar { get; set; } = string.Empty;
        public int? FirstVarHash { get; set; } = null;
        public string SecondVar { get; set; } = string.Empty;
        public int? SecondVarHash { get; set; } = null;
        public Operator Operator { get; set; } = Operator.None;

        public static FunctionHelper Parse(string value)
        {
            FunctionHelper helper = new FunctionHelper();
            List<string> splitValues = value.Split(' ', '+', '-', '*', '/').ToList();
            splitValues.RemoveAll(sv => sv == "");
            if (splitValues.Count == 1)
            {
                helper.FirstVar = value;
                return helper;
            }
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

        public double ExecuteFunction(double? first, double? second = double.NaN)
        {
            if ((first == null) || (first is double.NaN))
                return double.NaN;
            FirstVarHash = first.GetHashCode();

            if (this.Operator != Operator.None && (second == null || second is double.NaN))
                return double.NaN;
            SecondVarHash = second.GetHashCode();

            switch (this.Operator)
            {
                case Operator.Sum:
                    return first.Value + second.Value;
                case Operator.Sub:
                    return first.Value - second.Value;
                case Operator.Mul:
                    return first.Value * second.Value;
                case Operator.Div:
                    return first.Value / second.Value;
                default:
                    return first.Value;
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
                case Operator.Div:
                    return $"{this.FirstVar}/{this.SecondVar}";
                default:
                    return $"{this.FirstVar}";
            }
        }
    }
}
