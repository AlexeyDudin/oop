using Lab3_2.Interfaces;
using System.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Lab3_2
{
    public class Calculator
    {
        private Dictionary<string, double?> variables = new Dictionary<string, double?>();
        private Dictionary<string, FunctionHelper> functions = new Dictionary<string, FunctionHelper>();

        public Calculator() { }

        public void DeclareVariable(string name)
        {
            if (variables.ContainsKey(name))
                throw new ArgumentException($"Переменная с именем {name} ранее была объявлена");
            if (functions.ContainsKey(name))
                throw new ArgumentException($"Нельзя объявить переменную с данным именем! Имеется функция с именем {name}");

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

            if (double.TryParse(value.Replace('.', ','), out double doubleValue))
                SetVariableValue(name, doubleValue);
            else if (variables.ContainsKey(value)) //Если имя value есть среди переменных
                SetVariableValue(name, variables[value]);
            else if (functions.ContainsKey(value)) //Если имя value есть среди функций
                SetVariableValue(name, ExecuteFunction(functions[value]));
            else
                throw new ArgumentException($"Неизвестное имя второго параметра");
        }

        private double? GetValueFromFunction(string variable)
        {
            double? result = null;
            double convertedResult;
            if (!double.TryParse(variable, out convertedResult)) //Если это число
            {
                //если не число
                if (variables.ContainsKey(variable)) //если переменная
                    result = GetValue(variable);
                else if (functions.ContainsKey(variable)) //если функция
                    result = ExecuteFunction(functions[variable]);
            }
            else
                result = convertedResult;
            return result;
        }

        private double? ExecuteFunction(FunctionHelper function)
        {
            double? firstValue = GetValueFromFunction(function.FirstVar);
            double? secondValue = GetValueFromFunction(function.SecondVar);
            return function.ExecuteFunction(firstValue, secondValue);
        }

        public double? GetValue(string name)
        {
            if (!variables.ContainsKey(name) && !functions.ContainsKey(name))
                throw new ArgumentException($"Переменной или функции с именем {name} не существует!");
            if (functions.ContainsKey(name))
                return ExecuteFunction(functions[name]);
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

        public void SetFunction(string name, string value) 
        {
            if (!functions.ContainsKey(name))
                DeclareFunction(name);
            if (functions.ContainsKey(value))
                functions[name] = functions[value];
            else
                functions[name] = FunctionHelper.Parse(value);
        }

        public Dictionary<string, double?> GetAllVariables()
        {
            return variables.OrderBy(v => v.Key).ToDictionary(v => v.Key, v => v.Value);
        }
        public Dictionary<string, FunctionHelper> GetAllFunctions()
        {
            return functions.OrderBy(v => v.Key).ToDictionary(v => v.Key, v => v.Value);
        }
        public double? PrintFunctionResult(string name)
        {
            if (!functions.ContainsKey(name))
                throw new ArgumentException($"Функции с именем {name} не существует");
            return ExecuteFunction(functions[name]);
        }
    }
}
