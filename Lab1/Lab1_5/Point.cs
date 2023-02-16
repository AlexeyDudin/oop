namespace Lab1_5
{
    public class Point
    {
        public Point()
        {
        }

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }
    
        public int X { get; set; }
        public int Y { get; set; }


        public Point Left
        {
            get => new Point(X - 1, Y);
        }

        public Point Rigth
        {
            get => new Point(X + 1, Y);
        }
        public Point Up 
        {
            get => new Point(X, Y - 1);
        }

        public Point Down
        {
            get => new Point(X, Y + 1);
        }
    }
}
