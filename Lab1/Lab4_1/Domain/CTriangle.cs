using Lab4_1.Interfaces;
using Lab4_1.Logic;

namespace Lab4_1.Domain
{
    public class CTriangle : ISolidShape
    {
        private CPoint _vertex1;
        private CPoint _vertex2;
        private CPoint _vertex3;

        private uint _fillColor;
        private uint _outlineColor;

        public CTriangle()
        {
        }

        public CTriangle(string[] splitParams)
        {
            
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

        
    }
}
