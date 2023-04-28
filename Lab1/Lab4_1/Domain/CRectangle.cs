using Lab4_1.Interfaces;

namespace Lab4_1.Domain
{
    public class CRectangle : ISolidShape
    {
        private CPoint _topLeftPoint = new CPoint();
        private CPoint _bottomRightPoint = new CPoint();
        private UInt32 _outlineColor;
        private UInt32 _fillColor;
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
    }
}
