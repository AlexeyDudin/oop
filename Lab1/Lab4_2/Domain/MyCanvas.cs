using Lab4_2.Interfaces;
using System.Collections.Generic;
using System.Drawing;
using System.Windows;
using System.Windows.Controls;

namespace Lab4_2.Domain
{
    public class MyCanvas: ICanvas
    {
        private readonly Canvas canvas;
        public MyCanvas(Canvas canvas)
        {
            this.canvas = canvas;
        }

        public void DrawCircle(CPoint center, double radius, uint lineColor)
        {
            var element = new System.Windows.Shapes.Ellipse();
            element.Height = radius;
            element.Width = radius;
            
            canvas.Children.Add(element);
        }

        public void DrawLine(CPoint from, CPoint to, uint color)
        {
            throw new System.NotImplementedException();
        }

        public void FillCircle(CPoint center, double radius, uint fillColor)
        {
            throw new System.NotImplementedException();
        }

        public void FillPolygon(List<CPoint> points, uint fillColor)
        {
            throw new System.NotImplementedException();
        }
    }
}
