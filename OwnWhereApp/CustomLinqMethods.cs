namespace OwnWhereApp
{
    public static class CustomLinqMethods
    {
        public static IEnumerable<TSource> MyWhere<TSource>(
            this IEnumerable<TSource> enumerable,
            Func<TSource, bool> compareMethod)
        {
            foreach (TSource item in enumerable)
            {
                if (compareMethod(item))
                {
                    yield return item;
                }
            }
        }
    }
}
