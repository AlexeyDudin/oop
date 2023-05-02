using Lab4_2.Interfaces;
using Lab4_2.Logic;
using System;
using System.Windows;
using System.Windows.Media;

namespace Lab4_2.Domain
{
    public class CCircle : DrawingVisual, ISolidShape
    {
        private CPoint _center = new CPoint();
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
            canvas.DrawCircle(this);
        }

        public void Parse(string[] splitParams)
        {
            if (splitParams == null)
                throw new ArgumentNullException("Поступившие параметры являются null");
            if (splitParams.Length != 6)
                throw new ArgumentOutOfRangeException("Не верное количество входных параметров");
            if (splitParams[0] != "circle")
                throw new ArgumentException($"В объект CCircle подан не корректный параметр инициализации {string.Join(" ", splitParams)}");
            double parseResult;

            if (double.TryParse(splitParams[1].Replace('.', ','), out parseResult))
                _center.x = parseResult;
            else
                throw new ArgumentException($"Невозможно преобразовать параметр {splitParams[1]} в тип double");
            if (double.TryParse(splitParams[2].Replace('.', ','), out parseResult))
                _center.y = parseResult;
            else
                throw new ArgumentException($"Невозможно преобразовать параметр {splitParams[2]} в тип double");

            if (double.TryParse(splitParams[3].Replace('.', ','), out parseResult))
                _radius = parseResult;
            else
                throw new ArgumentException($"Невозможно преобразовать параметр {splitParams[3]} в тип double");
            
            _outlineColor = Convert.ToUInt32(splitParams[4], 16);
            _fillColor = Convert.ToUInt32(splitParams[5], 16);
        }
    }
}
