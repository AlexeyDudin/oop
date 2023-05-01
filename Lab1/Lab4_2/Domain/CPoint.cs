using Lab4_2.Interfaces;
using Lab4_2.Logic;
using System;
using System.Windows;
using System.Windows.Media;

namespace Lab4_2.Domain
{
    public class CPoint: DrawingVisual, ICanvasDrawable
    {
        public double x { get; set; } = double.NaN;
        public double y { get; set; } = double.NaN;

        public CPoint()
        { }

        public CPoint(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        public CPoint(string[] splitParams)
        {
            for (int i = 0; i < splitParams.Length; i++)
            {
                if (splitParams[i] == "point")
                    continue;
                if (double.TryParse(splitParams[i], out var result))
                {
                    if (x is double.NaN)
                        this.x = result;
                    else if (y is double.NaN)
                        this.y = result;
                    else
                        throw new ArgumentException("Не верные параметры для объекта CPoint.\nПоддерживаемые параметры: point xCoord yCoord\nгде point - опционально, xCoord и yCoord - типа double");
                }
            }
        }

        public void Draw(ICanvas canvas)
        {
            using (var drawingContext = RenderOpen())
            {
                var pen = new Pen(Brushes.Black, 1);
                drawingContext.DrawLine(pen, ConvertToWindowsPoint(), ConvertToWindowsPoint());
            }
        }

        public System.Windows.Point ConvertToWindowsPoint()
        {
            return new System.Windows.Point(x, y);
        }
    }
}
