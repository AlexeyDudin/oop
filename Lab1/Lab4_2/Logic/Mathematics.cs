using Lab4_2.Domain;
using System;

namespace Lab4_2.Logic
{
    public static class Mathematics
    {
        public static double PifagorLenght(CPoint firstPoint, CPoint secondPoint)
        {
            //delta x1,x2; delta y1,y2

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
