using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3_2
{
    public class StreamHandler
    {
        private readonly TextReader _intput;
        private readonly TextWriter _output;
        private Calculator calculator = new Calculator();
        private Dictionary<string, Action<string, string>> Commands = new Dictionary<string, Action<string, string>>();
        
        public StreamHandler(TextReader intput, TextWriter output)
        {
            _intput = intput;
            _output = output;
            InitializeCommand();
        }


        public void Work()
        {
            string? readString;
            do
            {
                _output.Write("Введите команду: ");
                readString = _intput.ReadLine();
                try
                {
                    if (string.IsNullOrWhiteSpace(readString))
                    {
                        _output.WriteLine("Введена пустая строка!");
                        PrintCommandsHelp();
                        continue;
                    }

                    List<string> splitStrings = SplitCommand(readString);

                    if (!Commands.ContainsKey(splitStrings[0]))
                    {
                        _output.WriteLine("Не известная комманда");
                        PrintCommandsHelp();
                        continue;
                    }

                    string firstParam = "";
                    if (splitStrings.Count > 1)
                        firstParam = splitStrings[1];

                    string secondParam = "";
                    if (splitStrings.Count > 2)
                        secondParam = splitStrings[2];

                    if (!IsCommandParamsOk(splitStrings[0], firstParam, secondParam))
                    {
                        _output.WriteLine("Не корректные параметры команды");
                        PrintCommandsHelp();
                        continue;
                    }

                    Commands[splitStrings[0]](firstParam, secondParam);
                }
                catch (Exception ex)
                {
                    _output.WriteLine(ex.Message);
                }
            } while (readString != "quit");
        }

        private List<string> SplitCommand(string command)
        {
            List<string> result = command.Split(' ', '=').ToList();
            result.RemoveAll(s => s == "");

            if (result.Count > 3)
            {
                for (int i = 3; i < result.Count; i++)
                {
                    result[2] += result[i];
                }
                while (result.Count != 3)
                {
                    result.RemoveAt(3);
                }
            }

            return result;
        }

        private bool IsCommandParamsOk(string command, string firstParam, string secondParam)
        {
            switch (command)
            {
                case "var":
                    return !string.IsNullOrWhiteSpace(firstParam);
                case "print":
                    return !string.IsNullOrWhiteSpace(firstParam);
                case "let":
                    return !string.IsNullOrWhiteSpace(firstParam);
                case "printvars":
                case "printfns":
                    return true;
                case "fn":
                    return !string.IsNullOrWhiteSpace(firstParam) && !string.IsNullOrWhiteSpace(secondParam);
                default:
                    return false;
            }
        }

        private void CalcAddIdentifyer(string name, string value = "") => calculator.DeclareVariable(name);
        private void CalcSetVariable(string name, string value) => calculator.SetVariableValue(name, value);
        private void PrintResult(string name, string value = "")
        {
            var variableResult = calculator.GetValue(name);
            if (variableResult == null)
                _output.WriteLine("Переменная или функция с таким именем не задана!");
            else if (variableResult is double.NaN)
                _output.WriteLine("nan");
            else
                _output.WriteLine(variableResult.Value);
        }
        private void PrintVariables(string name = "", string value = "")
        {
            var allVariables = calculator.GetAllVariables();
            foreach( var variable in allVariables ) 
            {
                _output.WriteLine($"{variable.Key}:{variable.Value}");
            }
        }
        private void PrintFunctions(string name = "", string value = "")
        {
            //TODO отсортировать по имени функции
            var allFuncs = calculator.GetAllFunctions();
            foreach (var func in allFuncs)
            {
                _output.WriteLine($"{func.Key}:{calculator.GetValue(func.Key)}");
            }
        }
        private void AddFunction(string name, string value) => calculator.SetFunction(name, value);

        private void PrintCommandsHelp()
        {
            _output.WriteLine("Список доступных комманд: ");
            foreach (var command in Commands)
            {
                _output.WriteLine(command.Key);
            }
        }

        private void InitializeCommand()
        {
            Commands.Clear();
            Commands.Add("var", CalcAddIdentifyer);
            Commands.Add("print", PrintResult);
            Commands.Add("let", CalcSetVariable);
            Commands.Add("fn", AddFunction);
            Commands.Add("printvars", PrintVariables);
            Commands.Add("printfns", PrintFunctions);
        }
    }
}
