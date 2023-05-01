using Lab4Domain.Interfaces;
using Lab4Domain.Logic;
using System;

namespace Lab4Domain.Domain
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

        public void Draw(Canvas canvas)
        {
            canvas.FillColor = Color.FromUint(_fillColor);
            canvas.StrokeColor = Color.FromUint(_outlineColor);
            PathF path = new PathF();
            path.MoveTo((float)_vertex1.x, (float)_vertex1.y);
            path.LineTo((float)_vertex2.x, (float)_vertex2.y);
            path.LineTo((float)_vertex3.x, (float)_vertex3.y);
            path.Close();
            canvas.FillPath(path);
            //canvas.DrawLine((float)_vertex1.x, (float)_vertex1.y, (float)_vertex2.x, (float)_vertex2.y);
            //canvas.DrawLine((float)_vertex2.x, (float)_vertex2.y, (float)_vertex3.x, (float)_vertex3.y);
            //canvas.DrawLine((float)_vertex3.x, (float)_vertex3.y, (float)_vertex1.x, (float)_vertex1.y);
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
