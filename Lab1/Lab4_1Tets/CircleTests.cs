using Lab4_2.Domain;

namespace Lab4_1Tets
{
    public class CircleTests
    {
        [Test]
        public void CCircle_GetArea()
        {
            // Arrange
            CCircle circle = new CCircle();
            circle.Parse(new string[] { "circle", "0", "0", "5", "FFFFFF", "000000" });
            double expectedArea = Math.PI * 25;

            // Act
            double actualArea = circle.GetArea();

            // Assert
            Assert.AreEqual(expectedArea, actualArea, 0.001);
        }

        [Test]
        public void CCircle_GetPerimeter()
        {
            // Arrange
            CCircle circle = new CCircle();
            circle.Parse(new string[] { "circle", "0", "0", "5", "FFFFFF", "000000" });
            double expectedPerimeter = 2 * Math.PI * 5;

            // Act
            double actualPerimeter = circle.GetPerimeter();

            // Assert
            Assert.AreEqual(expectedPerimeter, actualPerimeter);
        }

        [Test]
        public void CCircle_GetFillColor()
        {
            // Arrange
            CCircle circle = new CCircle();
            circle.Parse(new string[] { "circle", "0", "0", "5", "FFFFFF", "000000" });
            uint expectedFillColor = 0x000000;

            // Act
            uint actualFillColor = circle.GetFillColor();

            // Assert
            Assert.AreEqual(expectedFillColor, actualFillColor);
        }

        [Test]
        public void CCircle_GetOutlineColor()
        {
            // Arrange
            CCircle circle = new CCircle();
            circle.Parse(new string[] { "circle", "0", "0", "5", "FFFFFF", "000000" });
            uint expectedOutlineColor = 0xFFFFFF;

            // Act
            uint actualOutlineColor = circle.GetOutlineColor();

            // Assert
            Assert.AreEqual(expectedOutlineColor, actualOutlineColor);
        }

        [Test]
        public void CCircle_ToString()
        {
            // Arrange
            CCircle circle = new CCircle();
            circle.Parse(new string[] { "circle", "0", "0", "5", "FFFFFF", "000000" });
            string expectedString = "circle 0 0 5 FFFFFF 0";

            // Act
            string actualString = circle.ToString();

            // Assert
            Assert.AreEqual(expectedString, actualString);
        }

        [Test]
        public void CCircle_Parce_Bad_NullValue()
        {
            CCircle circle = new CCircle();
            Assert.Throws<ArgumentNullException>(() => circle.Parse(null));
        }

        [Test]
        public void CCircle_Parce_Bad_IncorrectCountValues()
        {
            CCircle circle = new CCircle();
            Assert.Throws<ArgumentOutOfRangeException>(() => circle.Parse(new string[] { "circle", "0", "0", "5", "FFFFFF"}));
        }

        [Test]
        public void CCircle_Parce_Bad_IncorrectValue()
        {
            CCircle circle = new CCircle();
            Assert.Throws<ArgumentException>(() => circle.Parse(new string[] { "line", "0", "0", "5", "FFFFFF", "000000" }));
        }

        [Test]
        public void CCircle_Parce_Bad_IncorrectDoubleValue()
        {
            CCircle circle = new CCircle();
            Assert.Throws<ArgumentException>(() => circle.Parse(new string[] { "circle", "double", "0", "5", "FFFFFF", "000000" }));
        }
    }
}
