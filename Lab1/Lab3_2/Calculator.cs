using Lab3_2.Interfaces;

namespace Lab3_2
{
    public class Calculator
    {
        private Dictionary<string, double?> variables = new Dictionary<string, double?>();
        private Dictionary<string, Func<double>?> functions = new Dictionary<string, Func<double>?>();

        public Calculator() { }

        public void DeclareVariable(string name)
        {
            if (variables.ContainsKey(name))
                throw new ArgumentException($"Переменная с именем {name} ранее была объявлена");
            if (functions.ContainsKey(name))
                throw new ArgumentException($"Имеется функция с именем {name}");

            variables.Add(name, double.NaN);
        }

        public void SetVariableValue(string name, double? value)
        {
            if (!variables.ContainsKey(name))
                DeclareVariable(name);
            variables[name] = value;
        }

        public void SetVariableValue(string name, string value)
        {
            //Если value - это число
            if (double.TryParse(value, out var doubleValue))
                SetVariableValue(name, doubleValue);
            else if (variables.ContainsKey(value)) //Если имя value есть среди переменных
            {
                SetVariableValue(name, variables[value]);
            }
            else if (functions.ContainsKey(value)) //Если имя value есть среди функций
            {

            }
            else
                throw new ArgumentException($"Неизвестное имя второго параметра");
        }

        public double? GetValiableValue(string name)
        {
            if (!variables.ContainsKey(name))
                throw new ArgumentException($"Переменной с именем {name} не существует!");
            return variables[name];
        }

        public void DeclareFunction(string name)
        {
            if (functions.ContainsKey(name))
                throw new ArgumentException($"Функция с именем {name} ранее была объявлена");
            if (variables.ContainsKey(name))
                throw new ArgumentException($"Имеется переменная с именем {name}");
            functions.Add(name, null);
        }

        public void SetFunction(string name, Func<double> function) 
        {
            if (!functions.ContainsKey(name))
                throw new ArgumentException($"Функции с именем {name} не существует!");
            functions[name] = function;
        }

        public Dictionary<string, double?> GetAllVariables()
        {
            return variables;
        }
    }
}
