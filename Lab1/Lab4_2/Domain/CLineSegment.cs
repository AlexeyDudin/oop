using Lab4_2.Interfaces;
using Lab4_2.Logic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Lab4_2.Domain
{
    public class CLineSegment : DrawingVisual, IShape
    {
        private CPoint _startPoint;
        private CPoint _endPoint;
        private uint _outlineColor;

        public double GetArea() => 0;

        public uint GetOutlineColor() => _outlineColor;

        public double GetPerimeter() => Mathematics.PifagorLenght(_startPoint, _endPoint);

        public CPoint GetStartPoint() => _startPoint;
        public CPoint GetEndPoint() => _endPoint;

        public void Draw(ICanvas canvas)
        {
            using (var drawingContext = RenderOpen())
            {
                var outlineColors = ColorControl.GetColorFromUInt(_outlineColor);
                var outlineColor = new SolidColorBrush(Color.FromRgb(outlineColors[0], outlineColors[1], outlineColors[2]));
                var pen = new Pen(outlineColor, 1);

                drawingContext.DrawLine(pen, _startPoint.ConvertToWindowsPoint(), _endPoint.ConvertToWindowsPoint());
            }
        }
    }
}
