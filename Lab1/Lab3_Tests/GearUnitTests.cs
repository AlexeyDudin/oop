using Lab3_1;

namespace Lab3_1_Tests
{
    public class GearUnitTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Positive_GearTest_SetNeutralGear_InStopEngine()
        {
            var car = new Car();
            Assert.IsTrue(car.SetGear((int)GearSelector.NEUTRAL));
        }

        [Test]
        public void Positive_GearTest_SetNeutralGear_NoSpeed()
        {
            var car = new Car();
            car.TurnOnEngine();
            car.SetGear((int)GearSelector.NEUTRAL);
            var result = car.SelectGear;
            Assert.That(result.Value, Is.EqualTo((int)GearSelector.NEUTRAL));
        }

        [Test]
        public void Positive_GearTest_SetSelfGear_GearForward()
        {
            var selfGear = (int)GearSelector.FIRST;
            var car = new Car();
            car.TurnOnEngine();
            car.SetGear(selfGear);
            car.SetSpeed(25);
            car.SetGear(selfGear);
            var result = car.SelectGear;
            Assert.That(result.Value, Is.EqualTo(selfGear));
        }

        [Test]
        public void Negative_GearTest_SetSelfGear_GearBackward()
        {
            const int selfGear = (int)GearSelector.REVERSE;
            var car = new Car();
            car.TurnOnEngine();
            car.SetGear(selfGear);
            car.SetSpeed(15);
            Assert.IsFalse(car.SetGear((int)GearSelector.REVERSE));
        }

        [Test]
        public void Positive_GearTest_ReverseGear_SpeedIs0()
        {
            const int carSpeed = 0;
            var car = new Car();
            car.TurnOnEngine();
            car.SetSpeed(carSpeed);
            Assert.IsTrue(car.SetGear((int)GearSelector.FIRST));
        }

        [Test]
        public void Positive_GearTest_FirstGear_SpeedIs0()
        {
            const int carSpeed = 0;
            var car = new Car();
            car.TurnOnEngine();
            car.SetSpeed(carSpeed);
            Assert.IsTrue(car.SetGear((int)GearSelector.FIRST));
        }

        [Test]
        public void Positive_GearTest_FirstGear_SwitchInSpeedIs30()
        {
            const int carSpeed = 20;
            var car = new Car();
            car.TurnOnEngine();
            car.SetGear(1);
            car.SetSpeed(carSpeed);
            car.SetGear(2);
            car.SetSpeed(30);
            Assert.IsTrue(car.SetGear((int)GearSelector.FIRST));
        }

        [Test]
        public void Positive_GearTest_SecondGear_SwitchInSpeedIs20()
        {
            const int carSpeed = 20;
            var car = new Car();
            car.TurnOnEngine();
            car.SetGear(1);
            car.SetSpeed(carSpeed);
            Assert.IsTrue(car.SetGear((int)GearSelector.SECOND));
        }

        [Test]
        public void Positive_GearTest_SecondGear_SwitchInSpeedIs50()
        {
            const int carSpeed = 50;
            var car = new Car();
            car.TurnOnEngine();
            car.SetGear(1);
            car.SetSpeed(30);
            car.SetGear(3);
            car.SetSpeed(50);
            Assert.IsTrue(car.SetGear((int)GearSelector.SECOND));
        }

        [Test]
        public void Positive_GearTest_ThirdGear_SwitchInSpeedIs30()
        {
            const int carSpeed = 30;
            var car = new Car();
            car.TurnOnEngine();
            car.SetGear(1);
            car.SetSpeed(carSpeed);
            Assert.IsTrue(car.SetGear((int)GearSelector.THIRD));
        }

        [Test]
        public void Positive_GearTest_ThirdGear_SwitchInSpeedIs60()
        {
            const int carSpeed = 60;
            var car = new Car();
            car.TurnOnEngine();
            car.SetGear(1);
            car.SetSpeed(30);
            car.SetGear(3);
            car.SetSpeed(50);
            car.SetGear(4);
            car.SetSpeed(carSpeed);
            Assert.IsTrue(car.SetGear((int)GearSelector.THIRD));
        }

        [Test]
        public void Positive_GearTest_FourthGear_SwitchInSpeedIs40()
        {
            const int carSpeed = 40;
            var car = new Car();
            car.TurnOnEngine();
            car.SetGear(1);
            car.SetSpeed(30);
            car.SetGear(2);
            car.SetSpeed(carSpeed);
            Assert.IsTrue(car.SetGear((int)GearSelector.FOURTH));
        }

        [Test]
        public void Positive_GearTest_FourthGear_SwitchInSpeedIs90()
        {
            const int carSpeed = 90;
            var car = new Car();
            car.TurnOnEngine();
            car.SetGear(1);
            car.SetSpeed(30);
            car.SetGear(3);
            car.SetSpeed(50);
            car.SetGear(5);
            car.SetSpeed(carSpeed);
            Assert.IsTrue(car.SetGear((int)GearSelector.FOURTH));
        }

        [Test]
        public void Positive_GearTest_FifthGear_SwitchInSpeedIs50()
        {
            const int carSpeed = 50;
            var car = new Car();
            car.TurnOnEngine();
            car.SetGear(1);
            car.SetSpeed(30);
            car.SetGear(2);
            car.SetSpeed(carSpeed);
            Assert.IsTrue(car.SetGear((int)GearSelector.FIFTH));
        }

        [Test]
        public void Positive_GearTest_FifthGear_SwitchInSpeedIs150()
        {
            const int carSpeed = 150;
            var car = new Car();
            car.TurnOnEngine();
            car.SetGear(1);
            car.SetSpeed(30);
            car.SetGear(3);
            car.SetSpeed(50);
            car.SetGear(5);
            car.SetSpeed(carSpeed);
            Assert.IsTrue(car.SetGear((int)GearSelector.FIFTH));
        }
        // NEGATIVE

        [Test]
        public void Negative_GearTest_FirstGear_SpeedIs31()
        {
            const int carSpeed = 31;
            var car = new Car();
            car.TurnOnEngine();
            car.SetGear(1);
            car.SetSpeed(20);
            car.SetGear(2);
            car.SetSpeed(carSpeed);
            Assert.IsFalse(car.SetGear((int)GearSelector.FIRST));
        }

        [Test]
        public void Negative_GearTest_SecondGear_SwitchInSpeedIs19()
        {
            const int carSpeed = 19;
            var car = new Car();
            car.TurnOnEngine();
            car.SetGear(1);
            car.SetSpeed(carSpeed);
            Assert.IsFalse(car.SetGear((int)GearSelector.SECOND));
        }

        [Test]
        public void Negative_GearTest_SecondGear_SwitchInSpeedIs51()
        {
            const int carSpeed = 51;
            var car = new Car();
            car.TurnOnEngine();
            car.SetGear(1);
            car.SetSpeed(30);
            car.SetGear(3);
            car.SetSpeed(carSpeed);
            Assert.IsFalse(car.SetGear((int)GearSelector.SECOND));
        }

        [Test]
        public void Negative_GearTest_ThirdGear_SwitchInSpeedIs29()
        {
            const int carSpeed = 29;
            var car = new Car();
            car.TurnOnEngine();
            car.SetGear(1);
            car.SetSpeed(carSpeed);
            Assert.IsFalse(car.SetGear((int)GearSelector.THIRD));
        }

        [Test]
        public void Negative_GearTest_ThirdGear_SwitchInSpeedIs61()
        {
            const int carSpeed = 61;
            var car = new Car();
            car.TurnOnEngine();
            car.SetGear(1);
            car.SetSpeed(30);
            car.SetGear(3);
            car.SetSpeed(50);
            car.SetGear(4);
            car.SetSpeed(carSpeed);
            Assert.IsFalse(car.SetGear((int)GearSelector.THIRD));
        }

        [Test]
        public void Negative_GearTest_FourthGear_SwitchInSpeedIs39()
        {
            const int carSpeed = 39;
            var car = new Car();
            car.TurnOnEngine();
            car.SetGear(1);
            car.SetSpeed(30);
            car.SetGear(2);
            car.SetSpeed(carSpeed);
            Assert.IsFalse(car.SetGear((int)GearSelector.FOURTH));
        }

        [Test]
        public void Negative_GearTest_FourthGear_SwitchInSpeedIs91()
        {
            const int carSpeed = 91;
            var car = new Car();
            car.TurnOnEngine();
            car.SetGear(1);
            car.SetSpeed(30);
            car.SetGear(3);
            car.SetSpeed(50);
            car.SetGear(5);
            car.SetSpeed(carSpeed);
            Assert.IsFalse(car.SetGear((int)GearSelector.FOURTH));
        }

        [Test]
        public void Negative_GearTest_FifthGear_SwitchInSpeedIs49()
        {
            const int carSpeed = 49;
            var car = new Car();
            car.TurnOnEngine();
            car.SetGear(1);
            car.SetSpeed(30);
            car.SetGear(2);
            car.SetSpeed(carSpeed);
            Assert.IsFalse(car.SetGear((int)GearSelector.FIFTH));
        }
    }
}
