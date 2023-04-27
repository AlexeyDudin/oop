using Lab4_1.Interfaces;

namespace Lab4_1.Domain
{
    public class CLineSegment : IShape
    {
        private CPoint _startPoint;
        private CPoint _endPoint;

        public double GetArea()
        {
            throw new NotImplementedException();
        }

        public uint GetOutlineColor()
        {
            throw new NotImplementedException();
        }

        public double GetPerimeter()
        {
            throw new NotImplementedException();
        }

        public CPoint GetStartPoint() => _startPoint;
        public CPoint GetEndPoint() => _endPoint;
    }
}
