using Lab3_1.Interfaces;
using System;

namespace Lab3_1
{
    public class CommandHandler
    {
        private readonly ICar car = new Car();
        private Dictionary<string, Action<string[]>> CommandDictionary = new();
        private readonly TextWriter _output;
        private readonly TextReader _input;

        public CommandHandler(TextReader input, TextWriter output)
        {
            _output = output;
            _input = input;
            CommandDictionary.Add("Info", PrintCarInfo);
            CommandDictionary.Add("EngineOn", CarEngineOn);
            CommandDictionary.Add("EngineOff", CarEngineOff);
            CommandDictionary.Add("SetGear", CarSetGear);
            CommandDictionary.Add("SetSpeed", CarSetSpeed);
        }

        private void CarEngineOn(string[] splitValues = null) => _output.WriteLine(car.TurnOnEngine() ? "Engine is turn on" : "Can't turn on engine");

        private void CarEngineOff(string[] splitValues = null) => _output.WriteLine(car.TurnOffEngine() ? "Engine is turn off" : "Can't turn off engine");

        private void CarSetGear(string[] splitValues)
        {
            int userGearValue;
            if (splitValues.Length < 2 || !Int32.TryParse(splitValues[1], out userGearValue))//TODO: add check on int - fix
            {
                _output.WriteLine("Invalid command params.");
                _output.WriteLine("SetGear <Value> //Value = [-1..5]");
                return;
            }
            var setGear = car.SetGear(userGearValue);
            _output.WriteLine(setGear ? $"Gear is set to {splitValues[1]}" : $"Can't set gear to {splitValues[1]}");
        }

        private void CarSetSpeed(string[] splitValues)
        {
            int userSpeedValue;
            if (splitValues.Length < 2 || !Int32.TryParse(splitValues[1], out userSpeedValue))
            {
                _output.WriteLine("Invalid command params.");
                _output.WriteLine("SetSpeed <Value> //Value is integer higher zero");
                return;
            }
            var setSpeed = car.SetSpeed(userSpeedValue);
            _output.WriteLine(setSpeed ? $"Speed is set to {splitValues[1]}" : $"Can't set speed to {splitValues[1]}");
        }

        private void PrintCarInfo(string[] splitValues = null)
        {
            _output.WriteLine($"Engine is start: {car.IsTurnedOn()}");
            _output.WriteLine($"Car direction: {car.GetDirection()}");
            _output.WriteLine($"Gear value: {(GearSelector)car.GetGear().Value}");
            _output.WriteLine($"Speed: {car.GetSpeed()}");
        }

        public void Work()
        {
            string? readValue = null;
            do
            {
                _output.Write("Введите команду: ");
                readValue = _input.ReadLine();
                if (string.IsNullOrWhiteSpace(readValue))
                {
                    _output.WriteLine("Invalid command. Command is empty");
                    PrintHelp();
                    continue;
                }
                var splitValues = readValue.Split(' ');
                if (CommandDictionary.ContainsKey(splitValues[0]))
                    CommandDictionary[splitValues[0]](splitValues);
                else
                {
                    _output.WriteLine($"Invalid command {readValue}");
                    PrintHelp();
                }
            } while (readValue != "quit");
        }

        private void PrintHelp()
        {
            _output.WriteLine("Available command\'s:");
            _output.WriteLine("Info");
            _output.WriteLine("EngineOn");
            _output.WriteLine("EngineOff");
            _output.WriteLine("SetGear");
            _output.WriteLine("SetSpeed");
        }
    }
}
