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
                if (string.IsNullOrWhiteSpace(readString))
                {
                    _output.WriteLine("Введена пустая строка!");
                    PrintCommandsHelp();
                    continue;
                }

                string[] splitStrings = readString.Split(' ', '=');

                if (!Commands.ContainsKey(splitStrings[0]))
                {
                    _output.WriteLine("Не известная комманда");
                    PrintCommandsHelp();
                    continue;
                }

                string firstParam = "";
                if (splitStrings.Length > 1)
                    firstParam = splitStrings[1];

                string secondParam = "";
                if (splitStrings.Length > 2)
                    secondParam = splitStrings[2];

                if (!CheckCommandParams(splitStrings[0], firstParam, secondParam))
                {
                    _output.WriteLine("Не корректные параметры команды");
                    PrintCommandsHelp();
                    continue;
                }   
                
                Commands[splitStrings[0]](firstParam, secondParam);
            } while (readString != "quit");
        }

        private bool CheckCommandParams(string command, string firstParam, string secondParam)
        {
            switch (command)
            {
                case "var":
                    return !string.IsNullOrWhiteSpace(firstParam);
                case "print":
                    return !string.IsNullOrWhiteSpace(firstParam);
                case "let":
                    return !string.IsNullOrWhiteSpace(firstParam) ;
                default:
                    return false;
            }
        }

        private void CalcAddIdentifyer(string name, string value = "") => calculator.DeclareVariable(name);
        private void CalcSetVariable(string name, string value) => calculator.SetVariableValue(name, value);
        private void PrintVariable(string name, string value = "")
        {
            var variableResult = calculator.GetValiableValue(name);
            if (variableResult == null || variableResult is double.NaN)
                _output.WriteLine("nan");
            else
                _output.WriteLine(variableResult.Value);
        }
        private void PrintVariables(string name = "", string value = "")
        {
            var allVariables = calculator.GetAllVariables();
            foreach( var variable in allVariables ) 
            {
                _output.Write($"{variable.Key}:{variable.Value}");
            }
        }

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
            Commands.Add("print", PrintVariable);
            Commands.Add("let", CalcSetVariable);
            Commands.Add("printvars", PrintVariables);
        }
    }
}
