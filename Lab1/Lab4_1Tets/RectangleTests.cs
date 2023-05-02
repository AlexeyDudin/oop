
using Lab4_2.Domain;

namespace Lab4_1Tets
{
    public class RectangleTests
    {
        [Test]
        public void TestCRectangleConstructor()
        {
            // Arrange
            string[] parameters = { "rectangle", "0", "0", "5", "5", "000000", "FFFFFF" };

            // Act
            CRectangle rectangle = new CRectangle(parameters);

            // Assert
            Assert.IsNotNull(rectangle);
            Assert.AreEqual(rectangle.GetTopLeftPoint().x, 0);
            Assert.AreEqual(rectangle.GetTopLeftPoint().y, 0);
            Assert.AreEqual(rectangle.GetBottomRightPoint().x, 5);
            Assert.AreEqual(rectangle.GetBottomRightPoint().y, 5);
            Assert.AreEqual(rectangle.GetOutlineColor(), 0x000000);
            Assert.AreEqual(rectangle.GetFillColor(), 0xFFFFFF);
        }

        [Test]
        public void TestCRectangleGetArea()
        {
            // Arrange
            CRectangle rectangle = new CRectangle();
            rectangle.GetTopLeftPoint().x = 0;
            rectangle.GetTopLeftPoint().y = 0;
            rectangle.GetBottomRightPoint().x = 5;
            rectangle.GetBottomRightPoint().y = 5;

            // Act
            double area = rectangle.GetArea();

            // Assert
            Assert.AreEqual(area, 25);
        }

        [Test]
        public void TestCRectangleGetPerimeter()
        {
            // Arrange
            CRectangle rectangle = new CRectangle();
            rectangle.GetTopLeftPoint().x = 0;
            rectangle.GetTopLeftPoint().y = 0;
            rectangle.GetBottomRightPoint().x = 5;
            rectangle.GetBottomRightPoint().y = 5;

            // Act
            double perimeter = rectangle.GetPerimeter();

            // Assert
            Assert.AreEqual(perimeter, 20);
        }

        [Test]
        public void TestCRectangleParseWithNullParams()
        {
            // Arrange
            CRectangle rectangle = new CRectangle();

            // Act + Assert
            Assert.Throws<ArgumentNullException>(() => rectangle.Parse(null));
        }

        [Test]
        public void TestCRectangleParseWithIncorrectParamsLength()
        {
            // Arrange
            CRectangle rectangle = new CRectangle();
            string[] parameters = { "rectangle", "0", "0", "5", "5", "000000" };

            // Act + Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => rectangle.Parse(parameters));
        }

        [Test]
        public void TestCRectangleParseWithIncorrectFirstParam()
        {
            // Arrange
            CRectangle rectangle = new CRectangle();
            string[] parameters = { "circle", "0", "0", "5", "5", "000000", "FFFFFF" };

            // Act + Assert
            Assert.Throws<ArgumentException>(() => rectangle.Parse(parameters));
        }

        [Test]
        public void TestCRectangleToString()
        {
            // Arrange
            CRectangle rectangle = new CRectangle(new string[] { "rectangle", "0", "0", "5", "5", "000000", "FFFFFF" });

            // Act
            string result = rectangle.ToString();

            // Assert
            Assert.AreEqual(result, "rectangle 0 0 5 5 0 FFFFFF");
        }
    }
}