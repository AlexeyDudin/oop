using Lab4_2.Interfaces;
using Lab4_2.Logic;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Media;

namespace Lab4_2.Domain
{
    public class CRectangle : ISolidShape
    {
        private CPoint _topLeftPoint = new CPoint();
        private CPoint _bottomRightPoint = new CPoint();
        private uint _outlineColor;
        private uint _fillColor;
        public CRectangle()
        {
        }

        public CRectangle(string[] splitParams)
        { 
            Parse(splitParams);
        }

        public double GetArea() => GetHeight() * GetWidth();

        public uint GetFillColor() => _fillColor;

        public uint GetOutlineColor() => _outlineColor;

        public double GetPerimeter() => GetWidth() * 2 + GetHeight() * 2;

        public CPoint GetTopLeftPoint() => _topLeftPoint;
        public CPoint GetBottomRightPoint() => _bottomRightPoint;
        public double GetWidth() => Math.Abs(_bottomRightPoint.x - _topLeftPoint.x);
        public double GetHeight() => Math.Abs(_bottomRightPoint.y - _topLeftPoint.y);
        public void Parse(string[] splitParams)
        {
            if (splitParams == null)
                throw new ArgumentNullException("Поступившие параметры являются null");
            if (splitParams.Length != 7)
                throw new ArgumentOutOfRangeException("Не верное количество входных параметров");
            if (splitParams[0] != "rectangle")
                throw new ArgumentException($"В объект CRectangle подан не корректный параметр инициализации {string.Join(" ", splitParams)}");
            double parseResult;

            if (double.TryParse(splitParams[1].Replace('.', ','), out parseResult))
                _topLeftPoint.x = parseResult;
            else
                throw new ArgumentException($"Невозможно преобразовать параметр {splitParams[1]} в тип double");
            if (double.TryParse(splitParams[2].Replace('.', ','), out parseResult))
                _topLeftPoint.y = parseResult;
            else
                throw new ArgumentException($"Невозможно преобразовать параметр {splitParams[2]} в тип double");

            if (double.TryParse(splitParams[3].Replace('.', ','), out parseResult))
                _bottomRightPoint.x = _topLeftPoint.x + parseResult;
            else
                throw new ArgumentException($"Невозможно преобразовать параметр {splitParams[3]} в тип double");
            if (double.TryParse(splitParams[4].Replace('.', ','), out parseResult))
                _bottomRightPoint.y = _topLeftPoint.y + parseResult;
            else
                throw new ArgumentException($"Невозможно преобразовать параметр {splitParams[4]} в тип double");

            _outlineColor = Convert.ToUInt32(splitParams[5], 16);
            _fillColor = Convert.ToUInt32(splitParams[6], 16);
        }

        public override string ToString()
        {
            return $"rectangle {_topLeftPoint.x} {_topLeftPoint.y} {_bottomRightPoint.x - _topLeftPoint.x} {_bottomRightPoint.y - _topLeftPoint.y} {_outlineColor.ToString("X")} {_fillColor.ToString("X")}";
        }

        public void Draw(ICanvas canvas)
        {
            var point1 = new CPoint(_topLeftPoint.x, _topLeftPoint.y);
            var point2 = new CPoint(_bottomRightPoint.x, _topLeftPoint.y);
            var point3 = new CPoint(_bottomRightPoint.x, _bottomRightPoint.y);
            var point4 = new CPoint(_topLeftPoint.x, _bottomRightPoint.y);
            
            canvas.DrawLine(point1, point2, GetOutlineColor());
            canvas.DrawLine(point2, point3, GetOutlineColor());
            canvas.DrawLine(point3, point4, GetOutlineColor());
            canvas.DrawLine(point4, point1, GetOutlineColor());

            var pointList = new List<CPoint>()
            {
                point1,
                point2,
                point3,
                point4
            };
            canvas.FillPolygon(pointList, GetFillColor());
            //canvas.DrawRectangle(this);
        }
    }
}
