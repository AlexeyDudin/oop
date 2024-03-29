﻿using Lab4_2.Domain;
using System;
using System.Collections.Generic;
using System.Windows.Documents;

//не правильное разделение по интерфейсам
//Разделить фигуры и холст
namespace Lab4_2.Interfaces
{
    public interface ICanvas
    {
        void DrawLine(CPoint from, CPoint to, uint color);
        void FillPolygon(List<CPoint> points, uint fillColor);
        void DrawCircle(CPoint center, double radius, uint lineColor);
        void FillCircle(CPoint center, double radius, uint fillColor);
        //Убрать остальные!
        void DrawPoint(CPoint point);
        void DrawLineSegment(CLineSegment line);
        void DrawCircle(CCircle circle);
        void DrawRectangle(CRectangle rect);
        void DrawTriangle(CTriangle triangle);
    }
}
