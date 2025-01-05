using System.Globalization;

namespace BachLib.Extensions
{
	public static class StringExtensions
	{
		public static string ToTitleCase(this string? input)
		{
			return string.IsNullOrEmpty(input)
				? string.Empty
				: CultureInfo.CurrentCulture.TextInfo.ToTitleCase(input.ToLower());
		}

		public static string ToLowerTrim(this string? input)
		{
			return string.IsNullOrEmpty(input)
				? string.Empty
				: input.ToLower().Trim();
		}

		/**
		 * <summary>Compares two strings for equality, ignoring case and leading/trailing whitespace.</summary>
		 * <param name="input">The first string to compare.</param>
		 * <param name="other">The second string to compare.</param>
		 * <returns>True if the strings are equal, ignoring case and leading/trailing whitespace; otherwise, false.</returns>
		 */
		public static bool LooseEquals(this string? input, string? other)
		{
			return string.Equals(input.ToLowerTrim(), other.ToLowerTrim(), StringComparison.CurrentCultureIgnoreCase);
		}
	}
}