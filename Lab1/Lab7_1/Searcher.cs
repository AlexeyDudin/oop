namespace Lab7_1
{
    public static class Searcher
    {
        public static bool FindMax<T>(List<T> list, ref T result, Func<T, T, bool> less) where T : class
        {
            if (list.Count == 0)
                return false;
            result = list[0];
            for (int i = 1; i < list.Count; i++)
            {
                if (!less(list[i], result))
                    result = list[i];
            }
            return true;
        }
    }
}
