using Lab4Domain.Interfaces;
using Microsoft.Maui.Graphics;
using System;

namespace Lab4Domain.Domain
{
    public class CCircle : ISolidShape
    {
        private CPoint _center;
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

        public void Draw(ICanvas canvas, RectF dirtyRect)
        {
            canvas.DrawCircle((float)_center.x, (float)_center.y, (float)_radius);
        }
    }
}
