using Lab4_2.Interfaces;
using Lab4_2.Logic;
using System;
using System.Windows;
using System.Windows.Media;

namespace Lab4_2.Domain
{
    public class CPoint: ICanvasDrawable
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
            canvas.DrawPoint(this);
        }

        public System.Windows.Point ConvertToWindowsPoint()
        {
            return new System.Windows.Point(x, y);
        }

        public void Parse(string[] splitParams)
        {
            if (splitParams == null)
                throw new ArgumentNullException("Поступившие параметры являются null");
            if (splitParams.Length != 3)
                throw new ArgumentOutOfRangeException("Не верное количество входных параметров");
            if (splitParams[0] != "point")
                throw new ArgumentException($"В объект CPoint подан не корректный параметр инициализации {string.Join(" ", splitParams)}");

            double parseResult;
            if (double.TryParse(splitParams[1].Replace('.', ','), out parseResult))
                x = parseResult;
            else
                throw new ArgumentException($"Невозможно преобразовать параметр {splitParams[1]} в тип double");
            if (double.TryParse(splitParams[2].Replace('.', ','), out parseResult))
                y = parseResult;
            else
                throw new ArgumentException($"Невозможно преобразовать параметр {splitParams[1]} в тип double");
        }

        public override string ToString()
        {
            return $"point {x} {y}";
        }
    }
}
