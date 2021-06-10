namespace System.Optional
{
    public static class FunctionalExtensions
    {
        /// <summary>
        /// Allow to Map value to a different one
        /// </summary>
        public static Option<K> Map<T, K>(this Option<T> option, Func<T, K> some, Func<K> none)
        {
            if (option.TryGetValue(out var val))
                return Option.Some(some(val));
            return Option.Some(none());
        }

        /// <summary>
        /// Allow to Map value to a different one
        /// </summary>
        public static Option<K> MapSome<T, K>(this Option<T> option, Func<T, K> some)
        {
            if (option.TryGetValue(out var val))
                return Option.Some(some(val));
            return Option.None<K>();
        }

        /// <summary>
        /// Allow to Map value to a different one
        /// </summary>
        public static Option<K> MapNone<T, K>(this Option<T> option, Func<K> none)
        {
            if (option.TryGetValue(out var val))
                return Option.Some(val).ToType<K>();
            return Option.Some(none());
        }

        /// <summary>
        /// Merge to Options
        /// </summary>
        public static Option<Z> MergeOption<T, K, Z>(this Option<T> o1, Option<K> o2, Func<T, K, Z> some)
        {
            if (o1.TryGetValue(out var v1) && o2.TryGetValue(out var v2))
                return Option.Some(some(v1, v2));

            return Option.None<Z>();
        }

        /// <summary>
        /// Covert <paramref name="o2"/> to Option and merge it
        /// </summary>
        public static Option<Z> Merge<T, K, Z>(this Option<T> o1, K o2, Func<T, K, Z> some)
            => o1.MergeOption(Option.Some(o2), some);
    }
}
