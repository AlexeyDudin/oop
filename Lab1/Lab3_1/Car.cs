using Lab3_1.Interfaces;

namespace Lab3_1
{
    public class Car: ICar
    {
        public bool EngineStart { get; set; } = false;
        public List<Gear> AvailableGears { get; set; }
        public Gear SelectGear { get; set; } = null;


        public Car()
        {
            AvailableGears = new List<Gear>
            {
                new Gear() { Value = GearSelector.REVERSE, MinSpeed = 0, MaxSpeed = 20 },
                new Gear() { Value = GearSelector.NEUTRAL, MinSpeed = Int32.MinValue, MaxSpeed = Int32.MaxValue },
                new Gear() { Value = GearSelector.FIRST, MinSpeed = 0, MaxSpeed = 30 },
                new Gear() { Value = GearSelector.SECOND, MinSpeed = 20, MaxSpeed = 50 },
                new Gear() { Value = GearSelector.THIRD, MinSpeed = 30, MaxSpeed = 60 },
                new Gear() { Value = GearSelector.FOURTH, MinSpeed = 40, MaxSpeed = 90 },
                new Gear() { Value = GearSelector.FIFTH, MinSpeed = 50, MaxSpeed = 150 }
            };
            SelectGear = AvailableGears.Where(g => g.Value == GearSelector.NEUTRAL).Single();
        }

        public int CurrentSpeed { get; set; } = 0;
        public Direction Direction { get; set; } = Direction.Neutral;//TODO: опечатка - Fix

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

        public bool SetGear(GearSelector gear)
        {
            var gearToSelect = AvailableGears.Where(g => g.Value == gear).SingleOrDefault();
            if (gearToSelect == null)
                return false;
            if (CanSetGear(gearToSelect))
            {
                SelectGear = gearToSelect;
                return true;
            }
            return false;
        }

        public bool SetGear(int gear)
        {
            var gearToSelect = AvailableGears.Where(g => g.Value == (GearSelector)gear).SingleOrDefault();
            if (gearToSelect == null)
                return false;
            if (CanSetGear(gearToSelect))
            {
                SelectGear = gearToSelect;
                return true;
            }
            return false;
        }

        public bool SetSpeed(int speed)
        {
            if (SelectGear.Value == (int)GearSelector.NEUTRAL)
            {
                if (speed < CurrentSpeed)
                {
                    CurrentSpeed = speed;
                    FixDirection(speed);
                    return true;
                }
                else
                    return false;
            }
            if (speed != 0 && SelectGear.Value == (int)GearSelector.NEUTRAL)
                return false;
            if (speed >= SelectGear.MinSpeed && speed <= SelectGear.MaxSpeed)
            {
                FixDirection(speed);
                CurrentSpeed = speed;
                return true;
            }
            return false;
        }

        public bool IsTurnedOn()
        {
            return this.EngineStart;
        }

        public Direction GetDirection()
        {
            return this.Direction;
        }

        public int GetSpeed()
        {
            return CurrentSpeed;
        }

        public Gear GetGear()
        {
            return SelectGear;
        }


        private bool SpeedInGearSpeedRange(Gear gear) // TODO: поправить порядок: переменные, конструктор, методы (public, protected, private) - Fix
        {
            return (CurrentSpeed >= gear.MinSpeed && CurrentSpeed <= gear.MaxSpeed);
        }
        private bool GearInDirection(Gear gear)
        {
            if (gear.Value == GearSelector.NEUTRAL)//TODO: use GearSelector - Fix
                return true;
            if ((gear.Value != GearSelector.REVERSE && (Direction == Direction.Drive || Direction == Direction.Neutral)) ||
                (gear.Value == GearSelector.REVERSE && (Direction == Direction.Reverse || Direction == Direction.Neutral)))
                return true;
            return false;
        }
        private bool CanSetGear(Gear gear)
        {
            //TODO: расписать булеву логику и сократить ее 
            if (gear.Value == GearSelector.REVERSE && EngineStart)
            {
                if ((CurrentSpeed == 0) && SelectGear.Value == 0)
                    return true;
                return false;
            }
            if (Direction == Direction.Reverse && gear.Value != 0)
            {
                return false;
            }
            if (!EngineStart && gear.Value != GearSelector.NEUTRAL)
                return false;
            if (!EngineStart && gear.Value == GearSelector.NEUTRAL)
                return true;
            return (EngineStart && SpeedInGearSpeedRange(gear) && GearInDirection(gear));
        }
        private void FixDirection(int speed)
        {
            if (speed == 0)
                Direction = Direction.Neutral;
            else if (SelectGear.Value > 0)
                Direction = Direction.Drive;
            else
                Direction = Direction.Reverse;
        }
    }
}
