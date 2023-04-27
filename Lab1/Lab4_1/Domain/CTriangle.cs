using Lab4_1.Interfaces;

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

        public double GetArea() => Math.Abs((_vertex2.x - _vertex1.x) * (_vertex3.y - _vertex1.y) - (_vertex3.x - _vertex1.x) * (_vertex2.y - _vertex1.y)) / 2;

        public uint GetFillColor() => _fillColor;

        public uint GetOutlineColor() => _outlineColor;

        public double GetPerimeter()
        {
            double firstLine = PifagorLenght(_vertex1, _vertex2);
            double secondLine = PifagorLenght(_vertex2, _vertex3);
            double thirdLine = PifagorLenght(_vertex3, _vertex1);
            return firstLine + secondLine + thirdLine;
        }

        public CPoint GetVertex1() => _vertex1;
        public CPoint GetVertex2() => _vertex2;
        public CPoint GetVertex3() => _vertex3;

        private double PifagorLenght(CPoint firstPoint, CPoint secondPoint)
        {
            CPoint correctedCoordinatesFirstPoint = firstPoint;
            CPoint correctedCoordinatesSecondPoint = secondPoint;

            //Сначала смещаем первую точку, если это необходимо
            if (correctedCoordinatesFirstPoint.x < 0) //по координате x
            {
                double offset = Math.Abs(correctedCoordinatesFirstPoint.x);
                correctedCoordinatesFirstPoint.x = 0;
                correctedCoordinatesSecondPoint.x += offset;
            }
            if (correctedCoordinatesFirstPoint.y < 0) //по координате y
            {
                double offset = Math.Abs(correctedCoordinatesFirstPoint.y);
                correctedCoordinatesFirstPoint.y = 0;
                correctedCoordinatesSecondPoint.y += offset;
            }

            //Затем смещаем вторую точку, если это необходимо
            if (correctedCoordinatesSecondPoint.x < 0) //по координате x
            {
                double offset = Math.Abs(correctedCoordinatesSecondPoint.x);
                correctedCoordinatesFirstPoint.x += offset;
                correctedCoordinatesSecondPoint.x += 0;
            }
            if (correctedCoordinatesSecondPoint.y < 0) //по координате y
            {
                double offset = Math.Abs(correctedCoordinatesSecondPoint.y);
                correctedCoordinatesFirstPoint.y += offset;
                correctedCoordinatesSecondPoint.y = 0;
            }

            double result = Math.Pow(correctedCoordinatesSecondPoint.x - correctedCoordinatesFirstPoint.x, 2);
            result += Math.Pow(correctedCoordinatesSecondPoint.y - correctedCoordinatesFirstPoint.y, 2);
            result = Math.Sqrt(result);
            return result;
        }
    }
}
