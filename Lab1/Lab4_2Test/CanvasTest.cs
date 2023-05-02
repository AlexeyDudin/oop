using Lab4_2.Domain;
using NUnit.Framework;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Lab4_2Test
{
    [TestFixture]
    [Apartment(ApartmentState.STA)]
    public class Tests
    {
        [Test]
        public void DrawCircle_AddsCircleToCanvasChildren()
        {
            var canvas = new System.Windows.Controls.Canvas();
            var myCanvas = new MyCanvas(canvas);
            var center = new CPoint(10, 10);
            var radius = 5.0;
            uint lineColor = 0xFF0000;

            myCanvas.DrawCircle(center, radius, lineColor);

            Assert.That(canvas.Children.Count, Is.EqualTo(1));
            Assert.That(canvas.Children[0], Is.TypeOf(typeof(System.Windows.Shapes.Ellipse)));
        }

        [Test]
        public void DrawCircle_SetsEllipsePropertiesCorrectly()
        {
            var canvas = new System.Windows.Controls.Canvas();
            var myCanvas = new MyCanvas(canvas);
            var center = new CPoint(10, 10);
            var radius = 5.0;
            uint lineColor = 0xFF0000;

            myCanvas.DrawCircle(center, radius, lineColor);
            var ellipse = (System.Windows.Shapes.Ellipse)canvas.Children[0];

            Assert.That(ellipse.Height, Is.EqualTo(radius));
            Assert.That(ellipse.Width, Is.EqualTo(radius));

            var expectedColor = Color.FromRgb(255, 0, 0);
            var str1 = ellipse.Stroke.ToString();
            var str2 = expectedColor.ToString();
            Assert.That(str2, Is.EqualTo(str1));
        }

        [Test]
        public void DrawCircle_WithCCircle_AddsCircleToCanvasChildren()
        {
            var canvas = new System.Windows.Controls.Canvas();
            var myCanvas = new MyCanvas(canvas);
            var center = new CPoint(10, 10);
            var radius = 5.0;
            var outlineColor = 0xFF0000;
            var fillColor = 0x00FF00;
            var circle = new CCircle(new string[] { "circle", center.x.ToString(), center.y.ToString(), radius.ToString(), outlineColor.ToString("X"), fillColor.ToString("X") });


            myCanvas.DrawCircle(circle);

            Assert.That(canvas.Children.Count, Is.EqualTo(1));
            Assert.That(canvas.Children[0], Is.TypeOf(typeof(System.Windows.Shapes.Ellipse)));
        }

        [Test]
        public void DrawCircle_WithCCircle_SetsEllipsePropertiesCorrectly()
        {
            var canvas = new System.Windows.Controls.Canvas();
            var myCanvas = new MyCanvas(canvas);
            var center = new CPoint(10, 10);
            var radius = 5.0;
            var outlineColor = 0xFF0000;
            var fillColor = 0x00FF00;
            var circle = new CCircle(new string[] { "circle", center.x.ToString(), center.y.ToString(), radius.ToString(), outlineColor.ToString("X"), fillColor.ToString("X") });

            myCanvas.DrawCircle(circle);
            var ellipse = (System.Windows.Shapes.Ellipse)canvas.Children[0];

            Assert.That(ellipse.Height, Is.EqualTo(radius));
            Assert.That(ellipse.Width, Is.EqualTo(radius));

            var expectedOutlineColor = Color.FromRgb(255, 0, 0).ToString();
            var str = ellipse.Stroke.ToString();
            Assert.That(str, Is.EqualTo(expectedOutlineColor));

            var expectedFillColor = Color.FromRgb(0, 255, 0).ToString();
            Assert.That(ellipse.Fill.ToString(), Is.EqualTo(expectedFillColor));
        }

        [Test]
        public void DrawLine_AddsLineToCanvasChildren()
        {
            var canvas = new System.Windows.Controls.Canvas();
            var myCanvas = new MyCanvas(canvas);
            var from = new CPoint(10, 10);
            var to = new CPoint(20, 20);
            uint color = 0xFF0000;

            myCanvas.DrawLine(from, to, color);

            Assert.That(canvas.Children.Count, Is.EqualTo(1));
            Assert.That(canvas.Children[0], Is.TypeOf(typeof(System.Windows.Shapes.Line)));
        }

        [Test]
        public void DrawLineSegment_AddsLineToCanvasChildren()
        {
            var canvas = new System.Windows.Controls.Canvas();
            var myCanvas = new MyCanvas(canvas);
            var from = new CPoint(10, 10);
            var to = new CPoint(20, 20);
            uint color = 0xFF0000;

            CLineSegment line = new CLineSegment(from, to, color);
            myCanvas.DrawLineSegment(line);

            Assert.That(canvas.Children.Count, Is.EqualTo(1));
            Assert.That(canvas.Children[0], Is.TypeOf(typeof(System.Windows.Shapes.Line)));
            Assert.That(color.ToString("X"), Is.EqualTo(line.GetOutlineColor().ToString("X")));
        }

        [Test]
        public void DrawPoint_AddToCanvas()
        {
            CPoint point = new CPoint(1.1, 2.2);
            var canvas = new System.Windows.Controls.Canvas();
            var myCanvas = new MyCanvas(canvas);
            myCanvas.DrawPoint(point);
            Assert.That(canvas.Children.Count, Is.EqualTo(1));
            Assert.That(canvas.Children[0], Is.TypeOf(typeof(System.Windows.Shapes.Ellipse)));
        }

        [Test]
        public void DrawRectangle_AddToCanvas()
        {
            CRectangle rect = new CRectangle(new string[] { "rectangle", "1.1", "1.1", "2.2", "2.2", "0", "FFFFFF" });
            var canvas = new System.Windows.Controls.Canvas();
            var myCanvas = new MyCanvas(canvas);
            myCanvas.DrawRectangle(rect);
            Assert.That(canvas.Children.Count, Is.EqualTo(1));
            Assert.That(canvas.Children[0], Is.TypeOf(typeof(System.Windows.Shapes.Rectangle)));
            Assert.That("FFFFFF", Is.EqualTo(rect.GetFillColor().ToString("X")));
            Assert.That("0", Is.EqualTo(rect.GetOutlineColor().ToString("X")));
        }
    }
}