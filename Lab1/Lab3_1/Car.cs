namespace Lab3_1
{
    public class Car
    {
        public Car()
        {
            AvailableGears = new List<Gear>
            {
                new Gear() { Value = (int)GearSelector.REVERSE, MinSpeed = 0, MaxSpeed = 20 },
                new Gear() { Value = (int)GearSelector.NEUTRAL, MinSpeed = Int32.MinValue, MaxSpeed = Int32.MaxValue },
                new Gear() { Value = (int)GearSelector.FIRST, MinSpeed = 0, MaxSpeed = 30 },
                new Gear() { Value = (int)GearSelector.SECOND, MinSpeed = 20, MaxSpeed = 50 },
                new Gear() { Value = (int)GearSelector.THIRD, MinSpeed = 30, MaxSpeed = 60 },
                new Gear() { Value = (int)GearSelector.FOURTH, MinSpeed = 40, MaxSpeed = 90 },
                new Gear() { Value = (int)GearSelector.FIFTH, MinSpeed = 50, MaxSpeed = 150 }
            };
            SelectGear = AvailableGears.Where(g => g.Value == (int)GearSelector.NEUTRAL).Single();
        }

        public bool EngineStart { get; set; } = false;
        public List<Gear> AvailableGears { get; set; }
        public Gear SelectGear { get; set; } = null;

        public int CurrentSpeed { get; set; } = 0;
        public Direction Direction { get; set; } = Direction.Neitral;

        public bool TurnOnEngine()
        {
            if (SelectGear.Value == (int)GearSelector.NEUTRAL)
                EngineStart = true;
            return EngineStart;
        }

        public bool TurnOffEngine()
        {
            if (SelectGear.Value == 0 && CurrentSpeed == 0)
            {
                EngineStart = false;
                return true;
            }
            return false;
        }

        private bool SpeedInGearSpeedRange(Gear gear)
        {
            return (CurrentSpeed >= gear.MinSpeed && CurrentSpeed <= gear.MaxSpeed);
        }

        private bool GearInDirection(Gear gear)
        {
            if (gear.Value == 0)
                return true;
            if ((gear.Value > 0 && (Direction == Direction.Drive || Direction == Direction.Neitral)) ||
                (gear.Value < 0 && (Direction == Direction.Reverse || Direction == Direction.Neitral)))
                return true;
            return false;
        }

        private bool CanSetGear(Gear gear)
        {
            if (gear.Value == -1)
            {
                if ((CurrentSpeed == 0) && SelectGear.Value == 0)
                    return true;
                return false;
            }
            if (Direction == Direction.Reverse && gear.Value != 0)
            {
                return false;
            }
            if (!EngineStart && gear.Value != 0)
                return false;
            if (!EngineStart && gear.Value == 0)
                return true;
            return (EngineStart && SpeedInGearSpeedRange(gear) && GearInDirection(gear));
        }

        public bool SetGear(int gear)
        {
            var gearToSelect = AvailableGears.Where(g => g.Value == gear).Single();
            if (CanSetGear(gearToSelect))
            {
                SelectGear = gearToSelect;
                return true;
            }
            return false;
        }

        public bool SetSpeed(int speed)
        {
            if (speed != 0 && SelectGear.Value == (int)GearSelector.NEUTRAL)
                return false;
            if (speed >= SelectGear.MinSpeed && speed <= SelectGear.MaxSpeed)
            {
                if (speed == 0)
                    Direction = Direction.Neitral;
                else if (speed > 0)
                    Direction = Direction.Drive;
                else
                    Direction = Direction.Reverse;
                CurrentSpeed = speed;
                return true;
            }
            return false;
        }
    }
}
