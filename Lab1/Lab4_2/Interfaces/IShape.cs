using System;

namespace Lab4_2.Interfaces
{
    public interface IShape: ICanvasDrawable
    {
        public double GetArea();
        public double GetPerimeter();
        public string ToString();
        public UInt32 GetOutlineColor();
    }
}
