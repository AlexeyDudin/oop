using System;

namespace Lab4Domain.Interfaces
{
    public interface IShape: IDrawObject
    {
        public double GetArea();
        public double GetPerimeter();
        public string ToString();
        public UInt32 GetOutlineColor();
    }
}
