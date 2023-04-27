using Lab4_1.Interfaces;

namespace Lab4_1.Domain
{
    public class CRectangle : ISolidShape
    {
        private CPoint _topLeftPoint;
        private CPoint _bottomRightPoint;
        private UInt32 _outlineColor;
        private UInt32 _fillColor;
        public CRectangle()
        {
        }

        public double GetArea() => GetHeight() * GetWidth();

        public uint GetFillColor() => _fillColor;

        public uint GetOutlineColor() => _outlineColor;

        public double GetPerimeter() => GetWidth() * 2 + GetHeight() * 2;

        public CPoint GetTopLeftPoint() => _topLeftPoint;
        public CPoint GetBottomRightPoint() => _bottomRightPoint;
        public double GetWidth() => Math.Abs(_bottomRightPoint.x - _topLeftPoint.x);
        public double GetHeight() => Math.Abs(_bottomRightPoint.y - _topLeftPoint.y);
    }
}
