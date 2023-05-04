using Lab4_2.Interfaces;
using Lab4_2.Logic;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

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

            var lineColors = ColorControl.GetColorFromUInt(lineColor);
            element.Stroke = new SolidColorBrush(System.Windows.Media.Color.FromRgb(lineColors[0], lineColors[1], lineColors[2]));

            Canvas.SetLeft(element, center.x - radius / 2);
            Canvas.SetTop(element, center.y - radius / 2);
            canvas.Children.Add(element);
        }

        //Убрать сделать вызовом двух методов
        public void DrawCircle(CCircle circle)
        {
            var element = new System.Windows.Shapes.Ellipse();
            element.Height = circle.GetRadius();
            element.Width = circle.GetRadius();

            var lineColors = ColorControl.GetColorFromUInt(circle.GetOutlineColor());
            element.Stroke = new SolidColorBrush(System.Windows.Media.Color.FromRgb(lineColors[0], lineColors[1], lineColors[2]));

            var fillColors = ColorControl.GetColorFromUInt(circle.GetFillColor());
            element.Fill = new SolidColorBrush(System.Windows.Media.Color.FromRgb(fillColors[0], fillColors[1], fillColors[2]));

            Canvas.SetLeft(element, circle.GetCenter().x - circle.GetRadius() / 2);
            Canvas.SetTop(element, circle.GetCenter().y - circle.GetRadius() / 2);
            canvas.Children.Add(element);
        }

        public void DrawLine(CPoint from, CPoint to, uint color)
        {
            var element = new System.Windows.Shapes.Line();
            element.X1 = from.x;
            element.Y1 = from.y;
            element.X2 = to.x;
            element.Y2 = to.y;

            var lineColors = ColorControl.GetColorFromUInt(color);
            element.Stroke = new SolidColorBrush(System.Windows.Media.Color.FromRgb(lineColors[0], lineColors[1], lineColors[2]));

            canvas.Children.Add(element);
        }

        public void DrawLineSegment(CLineSegment line)
        {
            var element = new System.Windows.Shapes.Line();
            element.X1 = line.GetStartPoint().x;
            element.Y1 = line.GetStartPoint().y;
            element.X2 = line.GetEndPoint().x;
            element.Y2 = line.GetEndPoint().y;

            var lineColors = ColorControl.GetColorFromUInt(line.GetOutlineColor());
            element.Stroke = new SolidColorBrush(System.Windows.Media.Color.FromRgb(lineColors[0], lineColors[1], lineColors[2]));

            canvas.Children.Add(element);
        }

        public void DrawPoint(CPoint point)
        {
            var element = new System.Windows.Shapes.Ellipse();
            element.Height = 1;
            element.Width = 1;

            element.Stroke = Brushes.Black;

            Canvas.SetLeft(element, point.x);
            Canvas.SetTop(element, point.y);
            canvas.Children.Add(element);
        }

        public void DrawRectangle(CRectangle rect)
        {
            var element = new System.Windows.Shapes.Rectangle();
            element.Width = rect.GetWidth();
            element.Height = rect.GetHeight();

            var lineColors = ColorControl.GetColorFromUInt(rect.GetOutlineColor());
            element.Stroke = new SolidColorBrush(System.Windows.Media.Color.FromRgb(lineColors[0], lineColors[1], lineColors[2]));

            var fillColors = ColorControl.GetColorFromUInt(rect.GetFillColor());
            element.Fill = new SolidColorBrush(System.Windows.Media.Color.FromRgb(fillColors[0], fillColors[1], fillColors[2]));

            Canvas.SetLeft(element, rect.GetTopLeftPoint().x);
            Canvas.SetTop(element, rect.GetTopLeftPoint().y);
            canvas.Children.Add(element);
        }

        public void DrawTriangle(CTriangle triangle)
        {
            var element = new System.Windows.Shapes.Polygon();

            var lineColors = ColorControl.GetColorFromUInt(triangle.GetOutlineColor());
            element.Stroke = new SolidColorBrush(System.Windows.Media.Color.FromRgb(lineColors[0], lineColors[1], lineColors[2]));

            var fillColors = ColorControl.GetColorFromUInt(triangle.GetFillColor());
            element.Fill = new SolidColorBrush(System.Windows.Media.Color.FromRgb(fillColors[0], fillColors[1], fillColors[2]));

            var pointCollection = new PointCollection();
            pointCollection.Add(triangle.GetVertex1().ConvertToWindowsPoint());
            pointCollection.Add(triangle.GetVertex2().ConvertToWindowsPoint());
            pointCollection.Add(triangle.GetVertex3().ConvertToWindowsPoint());

            element.Points = pointCollection;

            canvas.Children.Add(element);
        }

        public void FillCircle(CPoint center, double radius, uint fillColor)
        {
            var element = new System.Windows.Shapes.Ellipse();
            element.Height = radius;
            element.Width = radius;

            var fillColors = ColorControl.GetColorFromUInt(fillColor);
            element.Fill = new SolidColorBrush(System.Windows.Media.Color.FromRgb(fillColors[0], fillColors[1], fillColors[2]));

            Canvas.SetLeft(element, center.x - radius / 2);
            Canvas.SetTop(element, center.y - radius / 2);

            canvas.Children.Add(element);
        }

        public void FillPolygon(List<CPoint> points, uint fillColor)
        {
            var element = new System.Windows.Shapes.Polygon();

            var fillColors = ColorControl.GetColorFromUInt(fillColor);
            element.Fill = new SolidColorBrush(System.Windows.Media.Color.FromRgb(fillColors[0], fillColors[1], fillColors[2]));

            var pointCollection = new PointCollection();
            foreach(var point in points) 
            {
                pointCollection.Add(point.ConvertToWindowsPoint());
            }

            element.Points = pointCollection;

            canvas.Children.Add(element);
        }
    }
}
