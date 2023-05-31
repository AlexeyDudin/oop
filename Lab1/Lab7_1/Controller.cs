using System.Xml.Linq;

namespace Lab7_1
{
    public class Controller
    {
        private readonly TextReader tr;
        private readonly TextWriter tw;
        public Controller(TextReader tr, TextWriter tw)
        {
            this.tr = tr;
            this.tw = tw;
        }

        public void Work()
        {
            List<SportsMan> sportsMens = GenerateSportmans();

            SportsMan result = new SportsMan();
            if (Searcher.FindMax(sportsMens, ref result, SportManHelper.LessByLength))
                tw.WriteLine($"Спортсмен с максимальным ростом: {result}");
            else
                tw.WriteLine($"Массив пустой!");
            if (Searcher.FindMax(sportsMens, ref result, SportManHelper.LessByWeight))
                tw.WriteLine($"Спортсмен с максимальным весом: {result}");
            else
                tw.WriteLine($"Массив пустой!");
            if (Searcher.FindMax(sportsMens, ref result, SportManHelper.LessByName))
                tw.WriteLine($"Спортсмен последний в алфавитном порядке: {result}");
            else
                tw.WriteLine($"Массив пустой!");
        }

        private List<SportsMan> GenerateSportmans()
        {
            return new List<SportsMan>()
            {
                new SportsMan() { Weight = 70, Length = 180, Name = "Sasha A."},
                new SportsMan() { Weight = 70, Length = 185, Name = "Sasha B."},
                new SportsMan() { Weight = 75, Length = 190, Name = "Misha"},
                new SportsMan() { Weight = 90, Length = 170, Name = "Alex"}
            };
        }

        
    }
}
