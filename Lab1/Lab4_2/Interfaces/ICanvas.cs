using Lab4_2.Domain;
using System;
using System.Collections.Generic;
using System.Windows.Documents;

namespace Lab4_2.Interfaces
{
    public interface ICanvas
    {
        void DrawLine(CPoint from, CPoint to, uint color);
        void FillPolygon(List<CPoint> points, uint fillColor);
        void DrawCircle(CPoint center, double radius, uint lineColor);
        void FillCircle(CPoint center, double radius, uint fillColor);
    }
}
