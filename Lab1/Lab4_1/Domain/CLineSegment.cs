using Lab4_1.Interfaces;
using Lab4_1.Logic;

namespace Lab4_1.Domain
{
    public class CLineSegment : IShape
    {
        private CPoint _startPoint;
        private CPoint _endPoint;
        private uint _outlineColor;

        public double GetArea() => 0;

        public uint GetOutlineColor() => _outlineColor;

        public double GetPerimeter() => Mathematics.PifagorLenght(_startPoint, _endPoint);

        public CPoint GetStartPoint() => _startPoint;
        public CPoint GetEndPoint() => _endPoint;
    }
}
