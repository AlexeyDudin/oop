namespace Lab7_1
{
    public class SportsMan
    {
        public uint Weight { get; set; } = 0;
        public string Name { get; set; } = "";
        public uint Length { get; set; } = 0;

        public static implicit operator string(SportsMan sportman)
        {
            return sportman.ToString();
        }

        public override string ToString()
        {
            return $"{this.Name}: Рост: {this.Length}; Вес: {this.Weight}";
        }
    }
}
