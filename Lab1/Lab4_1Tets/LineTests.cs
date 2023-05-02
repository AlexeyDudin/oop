using Lab4_2.Domain;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4_1Tets
{
    public class LineTests
    {
        [Test]
        public void TestGetArea()
        {
            var startPoint = new CPoint(0, 0);
            var endPoint = new CPoint(3, 4);

            var lineSegment = new CLineSegment(startPoint, endPoint, 0);
            var area = lineSegment.GetArea();
            Assert.AreEqual(0, area);
        }

        [Test]
        public void TestGetPerimeter()
        {
            var startPoint = new CPoint(0, 0);
            var endPoint = new CPoint(3, 4);
            var lineSegment = new CLineSegment (startPoint, endPoint, 0);
            var perimeter = lineSegment.GetPerimeter();
            Assert.AreEqual(5, perimeter);
        }

        [Test]
        public void TestGetOutlineColor()
        {
            var startPoint = new CPoint(0, 0);
            var endPoint = new CPoint(3, 4);

            var lineSegment = new CLineSegment(startPoint, endPoint, 0xFF0000);
            var outlineColor = lineSegment.GetOutlineColor();
            Assert.AreEqual((uint)0xFF0000, outlineColor);
        }

        [Test]
        public void TestGetStartPoint()
        {
            var startPoint = new CPoint(1, 2);
            var endPoint = new CPoint(3, 4);
            var lineSegment = new CLineSegment(startPoint, endPoint, 0);
            var start = lineSegment.GetStartPoint();
            Assert.AreEqual(startPoint, start);
        }

        [Test]
        public void TestGetEndPoint()
        {
            var startPoint = new CPoint(1, 2);
            var endPoint = new CPoint(3, 4);
            var lineSegment = new CLineSegment (startPoint, endPoint ,0);
            var end = lineSegment.GetEndPoint();
            Assert.AreEqual(endPoint, end);
        }

        [Test]
        public void TestParse_Ok()
        {
            var lineSegment = new CLineSegment();
            lineSegment.Parse(new string[] { "line", "1.0", "2.0", "3.0", "4.0", "FF0000" });
            Assert.AreEqual(1.0, lineSegment.GetStartPoint().x);
            Assert.AreEqual(2.0, lineSegment.GetStartPoint().y);
            Assert.AreEqual(3.0, lineSegment.GetEndPoint().x);
            Assert.AreEqual(4.0, lineSegment.GetEndPoint().y);
            Assert.AreEqual((uint)0xFF0000, lineSegment.GetOutlineColor());
        }

        [Test]
        public void TestToString()
        {
            var lineSegment = new CLineSegment();
            lineSegment.Parse(new string[] { "line", "1.0", "2.0", "3.0", "4.0", "FF0000" });
            var result = lineSegment.ToString();
            Assert.AreEqual("line 1 2 3 4 FF0000", result);
        }

        [Test]
        public void TestParse_Bad_NullArgument()
        {
            var lineSegment = new CLineSegment();
            Assert.Throws<ArgumentNullException>(() => lineSegment.Parse(null));
        }

        [Test]
        public void TestParse_Bad_WrongNumberOfParameters()
        {
            var lineSegment = new CLineSegment();
            Assert.Throws<ArgumentOutOfRangeException>(() => lineSegment.Parse(new string[] { "line", "1.0", "2.0", "3.0" }));
        }

        [Test]
        public void TestParse_Bad_InvalidObjectType()
        {
            var lineSegment = new CLineSegment();
            Assert.Throws<ArgumentException>(() => lineSegment.Parse(new string[] { "rect", "1.0", "2.0", "3.0", "4.0", "FF0000" }));
        }

        [Test]
        public void TestParse_Bad_InvalidParameter()
        {
            var lineSegment = new CLineSegment();
            Assert.Throws<ArgumentException>(() => lineSegment.Parse(new string[] { "line", "float", "2.0", "3.0", "4.0", "FF0000" }));
        }
    }
}
