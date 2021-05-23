namespace System.Optional
{
    public static class ValueExtensions
    {
        /// <summary>
        /// Return current value or fails
        /// </summary>
        public static T ValueOrFail<T>(this Option<T> option)
        {
            if (option.TryGetValue(out var val)) return val;
            throw new NullReferenceException("Value is null");
        }

        /// <summary>
        /// Return current value, or <paramref name="orValue"/> if null
        /// </summary>
        public static T ValueOr<T>(this Option<T> option, T orValue)
        {
            if (option.TryGetValue(out var val)) return val;
            return orValue;
        }


        /// <summary>
        /// Control flow depending if a value is found
        /// </summary>
        public static void Match<T>(this Option<T> option, Action<T> some, Action none)
        {
            if (option.TryGetValue(out var val)) some(val);
            else none();
        }

        /// <summary>
        /// Control flow depending if a value is found
        /// </summary>
        public static T Match<T>(this Option<T> option, Func<T, T> some, Func<T> none)
        {
            if (option.TryGetValue(out var val)) return some(val);
            else return none();
        }

        public static void MatchSome<T>(this Option<T> option, Action<T> some) => option.Match(some, () => { });
        public static void MatchNone<T>(this Option<T> option, Action none) => option.Match(_ => { }, none);
    }
}
