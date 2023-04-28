namespace Lab4_1.Domain
{
    public class CPoint
    {
        public double x { get; set; } = double.NaN;
        public double y { get; set; } = double.NaN;

        public CPoint()
        { }

        public CPoint(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        public CPoint(string[] splitParams)
        {
            for (int i = 0; i < splitParams.Length; i++)
            {
                if (splitParams[i] == "point")
                    continue;
                if (double.TryParse(splitParams[i], out var result))
                {
                    if (x is double.NaN)
                        this.x = result;
                    else if (y is double.NaN)
                        this.y = result;
                    else
                        throw new ArgumentException("Не верные параметры для объекта CPoint.\nПоддерживаемые параметры: point xCoord yCoord\nгде point - опционально, xCoord и yCoord - типа double");
                }
            }
        }
    }
}
