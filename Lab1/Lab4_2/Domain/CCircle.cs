using Lab4_2.Interfaces;
using Lab4_2.Logic;
using System;
using System.Windows;
using System.Windows.Media;

namespace Lab4_2.Domain
{
    public class CCircle : DrawingVisual, ISolidShape
    {
        private CPoint _center;
        private double _radius;
        private uint _outlineColor;
        private uint _fillColor;

        public CCircle()
        {
        }

        public CCircle(string[] splitParams)
        {
            
        }

        public double GetArea() => Math.PI * Math.Pow(_radius, 2);

        public uint GetFillColor() => _fillColor;

        public uint GetOutlineColor() => _outlineColor;

        public double GetPerimeter() => 2 * Math.PI + _radius;
        public CPoint GetCenter() => _center;
        public double GetRadius() => _radius;

        public void Draw(ICanvas canvas)
        {
            using (var drawingContext = RenderOpen())
            {
                var outlineColors = ColorControl.GetColorFromUInt(_outlineColor);
                var fillColors = ColorControl.GetColorFromUInt(_fillColor);

                var pen = new Pen(new SolidColorBrush(Color.FromRgb(outlineColors[0], outlineColors[1], outlineColors[2])), 1);
                var fillColor = new SolidColorBrush(Color.FromRgb(fillColors[0], fillColors[1], fillColors[2]));

                drawingContext.DrawEllipse(fillColor, pen, _center.ConvertToWindowsPoint(), _radius, _radius);
            }
        }
    }
}
