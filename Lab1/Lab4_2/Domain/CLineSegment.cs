using Lab4_2.Interfaces;
using Lab4_2.Logic;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Lab4_2.Domain
{
    public class CLineSegment : DrawingVisual, IShape
    {
        private CPoint _startPoint = new CPoint();
        private CPoint _endPoint = new CPoint();
        private uint _outlineColor;

        public double GetArea() => 0;

        public uint GetOutlineColor() => _outlineColor;

        public double GetPerimeter() => Mathematics.PifagorLenght(_startPoint, _endPoint);

        public CPoint GetStartPoint() => _startPoint;
        public CPoint GetEndPoint() => _endPoint;

        public void Draw(ICanvas canvas)
        {
            canvas.DrawLineSegment(this);
        }

        public void Parse(string[] splitParams)
        {
            if (splitParams == null)
                throw new ArgumentNullException("Поступившие параметры являются null");
            if (splitParams.Length != 6)
                throw new ArgumentOutOfRangeException("Не верное количество входных параметров");
            if (splitParams[0] != "line")
                throw new ArgumentException($"В объект CRectangle подан не корректный параметр инициализации {string.Join(" ", splitParams)}");
            double parseResult;

            if (double.TryParse(splitParams[1].Replace('.', ','), out parseResult))
                _startPoint.x = parseResult;
            else
                throw new ArgumentException($"Невозможно преобразовать параметр {splitParams[1]} в тип double");
            if (double.TryParse(splitParams[2].Replace('.', ','), out parseResult))
                _startPoint.y = parseResult;
            else
                throw new ArgumentException($"Невозможно преобразовать параметр {splitParams[2]} в тип double");

            if (double.TryParse(splitParams[3].Replace('.', ','), out parseResult))
                _endPoint.x = parseResult;
            else
                throw new ArgumentException($"Невозможно преобразовать параметр {splitParams[3]} в тип double");
            if (double.TryParse(splitParams[4].Replace('.', ','), out parseResult))
                _endPoint.y = parseResult;
            else
                throw new ArgumentException($"Невозможно преобразовать параметр {splitParams[4]} в тип double");

            _outlineColor = Convert.ToUInt32(splitParams[5], 16);
        }
    }
}
