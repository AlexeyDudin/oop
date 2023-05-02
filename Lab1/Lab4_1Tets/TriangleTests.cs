using Lab4_2.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4_1Tets
{
    public class TriangleTests
    {
        [Test]
        public void GetArea_Triangle()
        {
            // Arrange
            var triangle = new CTriangle();
            triangle.Parse(new[] { "triangle", "0", "0", "0", "1", "1", "0", "000000", "FFFFFF" });

            // Act
            var area = triangle.GetArea();

            // Assert
            Assert.AreEqual(0.5, area);
        }

        [Test]
        public void GetPerimeter_Triangle()
        {
            // Arrange
            var triangle = new CTriangle();
            triangle.Parse(new[] { "triangle", "0", "0", "0", "1", "1", "0", "000000", "FFFFFF" });

            // Act
            var perimeter = triangle.GetPerimeter();

            // Assert
            Assert.AreEqual(3.4142135623730949, perimeter);
        }

        [Test]
        public void Parse_NullParams_ThrowsArgumentNullException()
        {
            // Arrange
            var triangle = new CTriangle();

            // Act and Assert
            Assert.Throws<ArgumentNullException>(() => triangle.Parse(null));
        }

        [Test]
        public void Parse_WrongParamsCount_ThrowsArgumentOutOfRangeException()
        {
            // Arrange
            var triangle = new CTriangle();

            // Act and Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => triangle.Parse(new[] { "triangle", "0", "0", "0", "1", "1", "0", "000000" }));
        }

        [Test]
        public void Parse_WrongObjectType_ThrowsArgumentException()
        {
            // Arrange
            var triangle = new CTriangle();

            // Act and Assert
            Assert.Throws<ArgumentException>(() => triangle.Parse(new[] { "rectangle", "0", "0", "0", "1", "1", "0", "000000", "FFFFFF" }));
        }

        [Test]
        public void ToString_Returns_ValidStringRepresentation()
        {
            // Arrange
            var triangle = new CTriangle();
            triangle.Parse(new[] { "triangle", "0", "0", "0", "1", "1", "0", "000000", "FFFFFF" });

            // Act
            var str = triangle.ToString();

            // Assert
            Assert.AreEqual("triangle 0 0 0 1 1 0 0 FFFFFF", str);
        }
    }
}
