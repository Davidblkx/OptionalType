namespace System.Optional
{
    /// <summary>
    /// Base typed optional
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public readonly struct Option<T> : IOption
    {
        // option value
        private readonly object? _value;

        // init option with a value
        private Option(object? value)
        {
            _value = value;
        }

        /// <summary>
        /// Check if has a valid value
        /// </summary>
        /// <returns></returns>
        public bool HasValue() => _value is T;

        /// <summary>
        /// Check if has a value and returns it
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool TryGetValue(out T value)
        {
            value = default!;
            if (_value is T val)
            {
                value = val;
                return true;
            }

            return false;
        }

        /// <summary>
        /// Cast value
        /// </summary>
        /// <typeparam name="K"></typeparam>
        /// <returns></returns>
        public Option<K> ToType<K>() => new(_value);

        /// <summary>
        /// Returns a untyped Option
        /// </summary>
        /// <returns></returns>
        public Option ToObject() => Option.Some(_value);

        /// <summary>
        /// Create an Option for a value
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static Option<T> Some(object? value) => new(value);
        /// <summary>
        /// Creates an empty option
        /// </summary>
        /// <returns></returns>
        public static Option<T> None() => new(null);
    }
}
