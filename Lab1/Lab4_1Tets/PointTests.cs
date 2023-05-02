using Lab4_2.Domain;

namespace Lab4_1Tets
{
    public class Tests
    {
        [Test]
        public void CPoint_Initialization_Test_Ok()
        {
            // Arrange
            double x = 1.0;
            double y = 2.0;

            // Act
            var point = new CPoint(x, y);

            // Assert
            Assert.AreEqual(x, point.x);
            Assert.AreEqual(y, point.y);
        }

        [Test]
        public void CPoint_Parse_Test_Ok()
        {
            // Arrange
            string[] inputParams = new string[] { "point", "1.0", "2.0" };

            // Act
            var point = new CPoint();
            point.Parse(inputParams);

            // Assert
            Assert.AreEqual(1.0, point.x);
            Assert.AreEqual(2.0, point.y);
        }

        [Test]
        public void CPoint_ToString()
        {
            // Arrange
            string[] inputParams = new string[] { "point", "1.0", "2.0" };

            // Act
            var point = new CPoint();
            point.Parse(inputParams);
            var result = point.ToString();

            // Assert
            Assert.AreEqual("point 1 2", result);
        }

        [Test]
        public void CPoint_Parse_Test_Bad_NullParams()
        {
            // Act
            var point = new CPoint();

            // Assert
            Assert.Throws<ArgumentNullException>(() => point.Parse(null));
        }

        [Test]
        public void CPoint_Parse_Test_Bad_IncorrectCountParams()
        {
            //Arrange
            string[] inputParams = new string[] { "point", "1.0", "2.0", "2" };

            // Act
            var point = new CPoint();

            // Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => point.Parse(inputParams));
        }

        [Test]
        public void CPoint_Parse_Test_Bad_IncorrectNameParams()
        {
            //Arrange
            string[] inputParams = new string[] { "line", "1.0", "2.0" };

            // Act
            var point = new CPoint();

            // Assert
            Assert.Throws<ArgumentException>(() => point.Parse(inputParams));
        }

        [Test]
        public void CPoint_Parse_Test_Bad_IncorrectTypeParam()
        {
            //Arrange
            string[] inputParams = new string[] { "point", "1.0", "float" };

            // Act
            var point = new CPoint();

            // Assert
            Assert.Throws<ArgumentException>(() => point.Parse(inputParams));
        }

        [Test]
        public void CPoint_ConvertToWindowsPoint_Test_Ok()
        {
            // Arrange
            var point = new CPoint(1.0, 2.0);

            // Act
            var windowsPoint = point.ConvertToWindowsPoint();

            // Assert
            Assert.AreEqual(1.0, windowsPoint.X);
            Assert.AreEqual(2.0, windowsPoint.Y);
        }
    }
}