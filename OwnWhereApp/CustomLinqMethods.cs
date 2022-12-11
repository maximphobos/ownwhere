namespace OwnWhereApp
{
    public static class CustomLinqMethods
    {
        public static IEnumerable<TSource> MyWhere<TSource>(
            this IEnumerable<TSource> enumerable, 
            Predicate<TSource> compareMethod)
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
