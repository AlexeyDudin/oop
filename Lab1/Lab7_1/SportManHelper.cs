namespace Lab7_1
{
    public static class SportManHelper
    {
        private static void CheckOnNull(SportsMan man1, SportsMan man2) 
        {
            if (man1 == null || man2 == null)
                throw new Exception("Невозможно сравнить спортсменов! Оба объекта являются null");
            if (man1 == null)
                throw new Exception("Невозможно сравнить спортсменов! Первый спортсмен равен null");
            if (man2 == null)
                throw new Exception("Невозможно сравнить спортсменов! Второй спортсмен равен null");
        }
        public static bool LessByWeight(SportsMan man1, SportsMan man2)
        {
            CheckOnNull(man1, man2);
            return man1.Weight < man2.Weight;
        }

        public static bool LessByLength(SportsMan man1, SportsMan man2)
        {
            CheckOnNull(man1, man2);
            return man1.Length < man2.Length;
        }
        public static bool LessByName(SportsMan man1, SportsMan man2)
        {
            CheckOnNull(man1, man2);
            int minLenght = man1.Name.Length < man2.Name.Length ? man1.Name.Length : man2.Name.Length;
            for (int i = 0; i < minLenght; i++)
            {
                if (man1.Name[i] != man2.Name[i])
                    return man1.Name[i] < man2.Name[i];
            }
            return man1.Name.Length == minLenght;
        }
    }
}
