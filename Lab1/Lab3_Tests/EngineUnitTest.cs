using Lab3_1;

namespace Lab3_1_Tests
{
    public class EngineUnitTest
    {
        [Test]
        public void Positive_TurnOnDefaultCar()
        {
            var car = new Car();
            Assert.IsTrue(car.TurnOnEngine());
        }

        [Test]
        public void Positive_TurnOffDefaultCar()
        {
            var car = new Car();
            Assert.IsTrue(car.TurnOffEngine());
        }

        [Test]
        public void Positive_TurnOffCar_AfterSetGear()
        {
            var car = new Car();
            car.TurnOnEngine();
            car.SetGear((int)GearSelector.FIRST);
            car.SetGear((int)GearSelector.NEUTRAL);
            Assert.IsTrue(car.TurnOnEngine());
        }

        [Test]
        public void Positive_TurnOffCar_AfterSetSpeed()
        {
            var car = new Car();
            car.TurnOnEngine();
            car.SetGear((int)GearSelector.REVERSE);
            car.SetSpeed(15);
            car.SetGear((int)GearSelector.NEUTRAL);
            car.SetSpeed(0);
            Assert.IsTrue(car.TurnOnEngine());
        }

        [Test]
        public void Negative_TurnOffCar_IfRunForward()
        {
            var car = new Car();
            car.TurnOnEngine();
            car.SetGear((int)GearSelector.FIRST);
            car.SetSpeed(15);
            Assert.IsFalse(car.TurnOffEngine());
        }

        [Test]
        public void Negative_TurnOffCar_IfRunBackward()
        {
            var car = new Car();
            car.TurnOnEngine();
            car.SetGear((int)GearSelector.REVERSE);
            car.SetSpeed(15);
            Assert.IsFalse(car.TurnOffEngine());
        }

        [Test]
        public void Negative_TurnOffCar_IfSetGearBackward()
        {
            var car = new Car();
            car.TurnOnEngine();
            car.SetGear((int)GearSelector.REVERSE);
            Assert.IsFalse(car.TurnOffEngine());
        }

        [Test]
        public void Negative_TurnOffCar_IfSetGearForward()
        {
            var car = new Car();
            car.TurnOnEngine();
            car.SetGear((int)GearSelector.FIRST);
            Assert.IsFalse(car.TurnOffEngine());
        }
    }
}
