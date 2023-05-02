using Lab4_2.Interfaces;
using Lab4_2.Logic;
using System;
using System.Windows.Media;

namespace Lab4_2.Domain
{
    public class CTriangle : DrawingVisual, ISolidShape
    {
        private CPoint _vertex1 = new CPoint();
        private CPoint _vertex2 = new CPoint();
        private CPoint _vertex3 = new CPoint();

        private uint _fillColor;
        private uint _outlineColor;

        public CTriangle()
        {
        }

        public CTriangle(string[] splitParams)
        {
            
        }

        public void Draw(ICanvas canvas)
        {
            canvas.DrawTriangle(this);
        }

        public double GetArea() => Math.Abs((_vertex2.x - _vertex1.x) * (_vertex3.y - _vertex1.y) - (_vertex3.x - _vertex1.x) * (_vertex2.y - _vertex1.y)) / 2;

        public uint GetFillColor() => _fillColor;

        public uint GetOutlineColor() => _outlineColor;

        public double GetPerimeter()
        {
            double firstLine = Mathematics.PifagorLenght(_vertex1, _vertex2);
            double secondLine = Mathematics.PifagorLenght(_vertex2, _vertex3);
            double thirdLine = Mathematics.PifagorLenght(_vertex3, _vertex1);
            return firstLine + secondLine + thirdLine;
        }

        public CPoint GetVertex1() => _vertex1;
        public CPoint GetVertex2() => _vertex2;
        public CPoint GetVertex3() => _vertex3;

        public void Parse(string[] splitParams)
        {
            if (splitParams == null)
                throw new ArgumentNullException("Поступившие параметры являются null");
            if (splitParams.Length != 9)
                throw new ArgumentOutOfRangeException("Не верное количество входных параметров");
            if (splitParams[0] != "triangle")
                throw new ArgumentException($"В объект CTriangle подан не корректный параметр инициализации {string.Join(" ", splitParams)}");
            double parseResult;

            if (double.TryParse(splitParams[1].Replace('.', ','), out parseResult))
                _vertex1.x = parseResult;
            else
                throw new ArgumentException($"Невозможно преобразовать параметр {splitParams[1]} в тип double");
            if (double.TryParse(splitParams[2].Replace('.', ','), out parseResult))
                _vertex1.y = parseResult;
            else
                throw new ArgumentException($"Невозможно преобразовать параметр {splitParams[2]} в тип double");

            if (double.TryParse(splitParams[3].Replace('.', ','), out parseResult))
                _vertex2.x = parseResult;
            else
                throw new ArgumentException($"Невозможно преобразовать параметр {splitParams[1]} в тип double");
            if (double.TryParse(splitParams[4].Replace('.', ','), out parseResult))
                _vertex2.y = parseResult;
            else
                throw new ArgumentException($"Невозможно преобразовать параметр {splitParams[2]} в тип double");
            
            if (double.TryParse(splitParams[5].Replace('.', ','), out parseResult))
                _vertex3.x = parseResult;
            else
                throw new ArgumentException($"Невозможно преобразовать параметр {splitParams[1]} в тип double");
            if (double.TryParse(splitParams[6].Replace('.', ','), out parseResult))
                _vertex3.y = parseResult;
            else
                throw new ArgumentException($"Невозможно преобразовать параметр {splitParams[2]} в тип double");

            _outlineColor = Convert.ToUInt32(splitParams[7], 16);
            _fillColor = Convert.ToUInt32(splitParams[8], 16);
        }
    }
}
