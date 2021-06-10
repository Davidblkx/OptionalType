using System.Threading.Tasks;

namespace System.Optional
{
    /// <summary>
    /// Base option type
    /// </summary>
    public readonly struct Option : IOption
    {
        // option value
        private readonly object? _value;

        // init option with a value
        private Option(object? value) : this() => _value = value;

        /// <summary>
        /// Check if has a valid value
        /// </summary>
        /// <returns></returns>
        public bool HasValue() => _value is not null;

        /// <summary>
        /// Check if has a value and returns it
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool TryGetValue(out object value)
        {
            value = null!;
            if (_value is null) return false;

            value = _value;
            return true;
        }

        public Option<T> ToType<T>() => Option<T>.Some(_value);

        /// <summary>
        /// Create an Option for a value
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static Option Some(object? value) => new(value);
        /// <summary>
        /// Creates an empty option
        /// </summary>
        /// <returns></returns>
        public static Option None() => new(null);

        /// <summary>
        /// Create an Option for a value
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static Option<T> Some<T>(T? value) => Option<T>.Some(value);
        /// <summary>
        /// Creates an empty option
        /// </summary>
        /// <returns></returns>
        public static Option<T> None<T>() => Option<T>.None();
    }
}
