using System;
using System.Diagnostics.CodeAnalysis;

namespace Web.Helpers
{
    /// <summary>
    /// Helper for throwing exceptions.
    /// </summary>
    public class ThrowHelper
    {
        /// <summary>
        /// Throw <see cref="ArgumentNullException"/> if <paramref name="value"/> is null.
        /// </summary>
        /// <param name="value">Value to check on null.</param>
        /// <param name="name">Name of <paramref name="value"/> parameter.</param>
        public static void ThrowIfIsNull([NotNull] object? value, string? name = null)
        {
            if (value is not null)
            {
                return;
            }

            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException();
            }

            throw new ArgumentNullException(name);
        }

        /// <summary>
        /// Throw <see cref="ArgumentException"/> if <paramref name="value"/> is null or white space.
        /// </summary>
        /// <param name="value">Value to check on null or white space.</param>
        /// <param name="name">Name of <paramref name="value"/> parameter.</param>
        public static void ThrowIfIsNullOrWhiteSpace([NotNull] string? value, string? name = null)
        {
            if (!string.IsNullOrWhiteSpace(value))
            {
                return;
            }

            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Value cannot be empty");
            }

            throw new ArgumentException($"'{name}' cannot be empty", name);
        }
    }
}