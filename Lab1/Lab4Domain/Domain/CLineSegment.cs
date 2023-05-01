using Lab4Domain.Interfaces;
using Lab4Domain.Logic;
using Microsoft.Maui.Graphics;

namespace Lab4Domain.Domain
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

        public void Draw(ICanvas canvas, RectF dirtyRect)
        {
            canvas.StrokeColor = Color.FromUint(_outlineColor);
            canvas.DrawLine((float)_startPoint.x, (float)_startPoint.y, (float)_endPoint.x, (float)_endPoint.y);
        }
    }
}
