using Lab3_2.Interfaces;

namespace Lab3_2
{
    public class Calculator
    {
        private Dictionary<string, IVarOrFunc> varAndFuncs { get; set; }

        public Calculator() { }

        public void DeclareVariable(string name)
        {
            if (varAndFuncs.ContainsKey(name))
                throw new ArgumentException($"Переменная с именем {name} ранее была объявлена");
            varAndFuncs.Add(name, null);
        }

        public void SetVariableValue(string name, double value)
        {
        }

    }
}
