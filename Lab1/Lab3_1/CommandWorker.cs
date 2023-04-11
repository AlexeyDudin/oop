namespace Lab3_1
{
    public class CommandWorker
    {
        public Car car { get; set; } = new Car();
        public void Work(TextReader input, TextWriter output)
        {
            var readValue = input.ReadLine();
            if (string.IsNullOrWhiteSpace(readValue))
            {
                output.WriteLine("Invalid command. Command is empty");
                return;
            }
            var splitValues = readValue.Split(' ');
            switch (splitValues[0])
            {
                case "Info":
                    output.WriteLine($"Engine is start: {car.EngineStart}");
                    output.WriteLine($"Car direction: {car.Direction}");
                    output.WriteLine($"Gear value: {car.SelectGear.Value}");
                    output.WriteLine($"Speed: {car.CurrentSpeed}");
                    break;
                case "EngineOn":
                    var engineIsTurnedOn = car.TurnOnEngine();
                    output.WriteLine(engineIsTurnedOn ? "Engine is turn on" : "Can't turn on engine");
                    break;
                case "EngineOff":
                    var engineIsTurnedOff = car.TurnOffEngine();
                    output.WriteLine(engineIsTurnedOff ? "Engine is turn off" : "Can't turn off engine");
                    break;
                case "SetGear":
                    if (splitValues.Length < 1)
                    {
                        output.WriteLine("Invalid command params.");
                        return;
                    }
                    var setGear = car.SetGear(Int32.Parse(splitValues[1]));
                    output.WriteLine(setGear? $"Gear is set to {splitValues[1]}" : $"Can't set gear to {splitValues[1]}");
                    break;
                case "SetSpeed":
                    if (splitValues.Length < 1)
                    {
                        output.WriteLine("Invalid command params.");
                        return;
                    }
                    var setSpeed = car.SetSpeed(Int32.Parse(splitValues[1]));
                    output.WriteLine(setSpeed? $"Speed is set to {splitValues[1]}" : $"Can't set speed to {splitValues[1]}");
                    break;
                default:
                    output.WriteLine($"Invalid command {readValue}");
                    break;
            }
        }
    }
}
