namespace Lab3_2
{
    public class Calculator
    {
        private Dictionary<string, double?> vars = new Dictionary<string, double?>();
        private Dictionary<string, Func<double>> functions = new Dictionary<string, Func<double>>();

        public void DeclareVariable(string name)
        {
            if (vars.ContainsKey(name))
                throw new ArgumentException($"Переменная с именем {name} ранее была объявлена");
            vars.Add(name, double.NaN);
        }

    }
}
