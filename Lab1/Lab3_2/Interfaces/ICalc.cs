namespace Lab3_2.Interfaces
{
    public interface ICalc
    {
        public void DeclareVariable(string name);
        public void SetVariableValue(string name, double? value);
        public void SetVariableValue(string name, string value);
        public double? GetValue(string name);
        public void DeclareFunction(string name);
        public void SetFunction(string name, string value);
        public Dictionary<string, double?> GetAllVariables();
        public Dictionary<string, FunctionHelper> GetAllFunctions();
        public double? PrintFunctionResult(string name);
    }
}
