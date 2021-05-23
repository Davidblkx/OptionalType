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
    }
}
