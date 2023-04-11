using Lab3_1;

namespace Lab3_1_Tests
{
    public class SpeedUnitTest
    {
        [Test]
        public void Negative_SpeedTest_NoAccelerationInNeutralGear_Reverse()
        {
            var car = new Car();
            car.TurnOnEngine();
            car.SetGear(-1);
            car.SetSpeed(15);
            car.SetGear(0);
            Assert.IsFalse(car.SetSpeed(20));
        }

        [Test]
        public void Negative_SpeedTest_NoAccelerationInNeutralGear_Forward()
        {
            var car = new Car();
            car.TurnOnEngine();
            car.SetGear(1);
            car.SetSpeed(15);
            car.SetGear(0);
            Assert.IsFalse(car.SetSpeed(20));
        }

        [Test]
        public void Positive_SpeedTest_BrakingInNeutralGear_Reverse()
        {
            var car = new Car();
            car.TurnOnEngine();
            car.SetGear(-1);
            car.SetSpeed(15);
            car.SetGear(0);
            Assert.IsTrue(car.SetSpeed(10));
        }

        [Test]
        public void Positive_SpeedTest_BrakingInNeutralGear_Forward()
        {
            var car = new Car();
            car.TurnOnEngine();
            car.SetGear(1);
            car.SetSpeed(15);
            car.SetGear(0);
            Assert.IsTrue(car.SetSpeed(10));
        }

        [Test]
        public void Positive_SpeedTest_NeutralGear_SetSpeedIs0()
        {
            var newSpeed = 0;
            var car = new Car();
            car.TurnOnEngine();
            Assert.IsTrue(car.SetSpeed(newSpeed));
        }

        [Test]
        public void Negative_SpeedTest_NeutralGear_SetSpeedIs1()
        {
            var newSpeed = 1;
            var car = new Car();
            car.TurnOnEngine();
            Assert.IsFalse(car.SetSpeed(newSpeed));
        }

        [Test]
        public void Negative_SpeedTest_NeutralGear_SetSpeedIsMinus1()
        {
            var newSpeed = -1;
            var car = new Car();
            car.TurnOnEngine();
            Assert.IsFalse(car.SetSpeed(newSpeed));
        }

        [Test]
        public void Positive_SpeedTest_ReverseGear_SetSpeedIs0()
        {
            var newSpeed = 0;
            var car = new Car();
            car.TurnOnEngine();
            car.SetGear(-1);
            Assert.IsTrue(car.SetSpeed(newSpeed));
        }

        [Test]
        public void Positive_SpeedTest_ReverseGear_SetSpeedIs20()
        {
            var newSpeed = 20;
            var car = new Car();
            car.TurnOnEngine();
            car.SetGear(-1);
            Assert.IsTrue(car.SetSpeed(newSpeed));
        }

        [Test]
        public void Negative_SpeedTest_ReverseGear_SetSpeedIs21()
        {
            var newSpeed = 21;
            var car = new Car();
            car.TurnOnEngine();
            car.SetGear(-1);
            Assert.IsFalse(car.SetSpeed(newSpeed));
        }

        [Test]
        public void Positive_SpeedTest_FirstGear_SetSpeedIs0()
        {
            var newSpeed = 0;
            var car = new Car();
            car.TurnOnEngine();
            car.SetGear(1);
            Assert.IsTrue(car.SetSpeed(newSpeed));
        }

        [Test]
        public void Positive_SpeedTest_FirstGear_SetSpeedIs30()
        {
            var newSpeed = 30;
            var car = new Car();
            car.TurnOnEngine();
            car.SetGear(1);
            Assert.IsTrue(car.SetSpeed(newSpeed));
        }

        [Test]
        public void Negative_SpeedTest_FirstGear_SetSpeedIs31()
        {
            var newSpeed = 31;
            var car = new Car();
            car.TurnOnEngine();
            car.SetGear(1);
            Assert.IsFalse(car.SetSpeed(newSpeed));
        }

        [Test]
        public void Positive_SpeedTest_SecondGear_SetSpeedIs20()
        {
            var newSpeed = 20;
            var car = new Car();
            car.TurnOnEngine();
            car.SetGear(1);
            car.SetSpeed(20);
            car.SetGear(2);
            Assert.IsTrue(car.SetSpeed(newSpeed));
        }

        [Test]
        public void Positive_SpeedTest_SecondGear_SetSpeedIs50()
        {
            var newSpeed = 50;
            var car = new Car();
            car.TurnOnEngine();
            car.SetGear(1);
            car.SetSpeed(20);
            car.SetGear(2);
            Assert.IsTrue(car.SetSpeed(newSpeed));
        }

        [Test]
        public void Negative_SpeedTest_SecondGear_SetSpeedIs19()
        {
            var newSpeed = 19;
            var car = new Car();
            car.TurnOnEngine();
            car.SetGear(1);
            car.SetSpeed(20);
            car.SetGear(2);
            Assert.IsFalse(car.SetSpeed(newSpeed));
        }

        [Test]
        public void Negative_SpeedTest_SecondGear_SetSpeedIs51()
        {
            var newSpeed = 51;
            var car = new Car();
            car.TurnOnEngine();
            car.SetGear(1);
            car.SetSpeed(20);
            car.SetGear(2);
            Assert.IsFalse(car.SetSpeed(newSpeed));
        }

        [Test]
        public void Positive_SpeedTest_ThirdGear_SetSpeedIs30()
        {
            var newSpeed = 30;
            var car = new Car();
            car.TurnOnEngine();
            car.SetGear(1);
            car.SetSpeed(30);
            car.SetGear(3);
            Assert.IsTrue(car.SetSpeed(newSpeed));
        }

        [Test]
        public void Positive_SpeedTest_ThirdGear_SetSpeedIs60()
        {
            var newSpeed = 60;
            var car = new Car();
            car.TurnOnEngine();
            car.SetGear(1);
            car.SetSpeed(30);
            car.SetGear(3);
            Assert.IsTrue(car.SetSpeed(newSpeed));
        }

        [Test]
        public void Negative_SpeedTest_ThirdGear_SetSpeedIs29()
        {
            var newSpeed = 29;
            var car = new Car();
            car.TurnOnEngine();
            car.SetGear(1);
            car.SetSpeed(30);
            car.SetGear(3);
            Assert.IsFalse(car.SetSpeed(newSpeed));
        }

        [Test]
        public void Negative_SpeedTest_ThirdGear_SetSpeedIs61()
        {
            var newSpeed = 61;
            var car = new Car();
            car.TurnOnEngine();
            car.SetGear(1);
            car.SetSpeed(20);
            car.SetGear(2);
            Assert.IsFalse(car.SetSpeed(newSpeed));
        }

    }
}
