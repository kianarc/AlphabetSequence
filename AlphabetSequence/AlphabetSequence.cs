using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlphabetSequence
{
    public static class AlphabetSequence
    {
        /// <summary>
        /// Gets the next alphabetical sequence (e.g., "AAA" -> "AAB", "AAZ" -> "ABA")
        /// </summary>
        /// <param name="current">Current alphabetical string</param>
        /// <returns>Next alphabetical sequence</returns>
        public static string GetNext(string current)
        {
            if (string.IsNullOrEmpty(current))
                throw new ArgumentException("Input cannot be null or empty");

            if (!IsValidAlphabetString(current))
                throw new ArgumentException("Input must contain only uppercase letters A-Z");

            char[] chars = current.ToCharArray();
            int length = chars.Length;

            // Start from the rightmost character
            for (int i = length - 1; i >= 0; i--)
            {
                if (chars[i] < 'Z')
                {
                    chars[i]++;
                    return new string(chars);
                }
                else
                {
                    chars[i] = 'A'; // Reset to 'A' and carry over
                }
            }

            // If we reach here, all characters were 'Z', so we need to add a new character
            return new string('A', length + 1);
        }

        /// <summary>
        /// Gets the previous alphabetical sequence (e.g., "AAB" -> "AAA", "ABA" -> "AAZ")
        /// </summary>
        /// <param name="current">Current alphabetical string</param>
        /// <returns>Previous alphabetical sequence</returns>
        public static string GetPrevious(string current)
        {
            if (string.IsNullOrEmpty(current))
                throw new ArgumentException("Input cannot be null or empty");

            if (!IsValidAlphabetString(current))
                throw new ArgumentException("Input must contain only uppercase letters A-Z");

            // Special case: if all characters are 'A', we need to go to previous length
            if (current.All(c => c == 'A'))
            {
                if (current.Length == 1)
                    throw new ArgumentException("Cannot get previous of 'A'");

                return new string('Z', current.Length - 1);
            }

            char[] chars = current.ToCharArray();
            int length = chars.Length;

            // Start from the rightmost character
            for (int i = length - 1; i >= 0; i--)
            {
                if (chars[i] > 'A')
                {
                    chars[i]--;
                    return new string(chars);
                }
                else
                {
                    chars[i] = 'Z'; // Reset to 'Z' and borrow from left
                }
            }

            // This should never be reached due to the check above
            throw new InvalidOperationException("Unexpected state in GetPrevious");
        }

        /// <summary>
        /// Gets the minimum alphabetical sequence between two sequences
        /// </summary>
        /// <param name="first">First alphabetical string</param>
        /// <param name="second">Second alphabetical string</param>
        /// <returns>The minimum (lexicographically smaller) sequence</returns>
        public static string GetMinimum(string first, string second)
        {
            if (string.IsNullOrEmpty(first) || string.IsNullOrEmpty(second))
                throw new ArgumentException("Inputs cannot be null or empty");

            if (!IsValidAlphabetString(first) || !IsValidAlphabetString(second))
                throw new ArgumentException("Inputs must contain only uppercase letters A-Z");

            return string.Compare(first, second, StringComparison.Ordinal) <= 0 ? first : second;
        }

        /// <summary>
        /// Gets the maximum alphabetical sequence between two sequences
        /// </summary>
        /// <param name="first">First alphabetical string</param>
        /// <param name="second">Second alphabetical string</param>
        /// <returns>The maximum (lexicographically larger) sequence</returns>
        public static string GetMaximum(string first, string second)
        {
            if (string.IsNullOrEmpty(first) || string.IsNullOrEmpty(second))
                throw new ArgumentException("Inputs cannot be null or empty");

            if (!IsValidAlphabetString(first) || !IsValidAlphabetString(second))
                throw new ArgumentException("Inputs must contain only uppercase letters A-Z");

            return string.Compare(first, second, StringComparison.Ordinal) >= 0 ? first : second;
        }

        /// <summary>
        /// Generates the first sequence of a given length (e.g., length 3 -> "AAA")
        /// </summary>
        /// <param name="length">Length of the sequence</param>
        /// <returns>First sequence of specified length</returns>
        public static string GetFirst(int length)
        {
            if (length <= 0)
                throw new ArgumentException("Length must be greater than 0");

            return new string('A', length);
        }

        /// <summary>
        /// Generates the last sequence of a given length (e.g., length 3 -> "ZZZ")
        /// </summary>
        /// <param name="length">Length of the sequence</param>
        /// <returns>Last sequence of specified length</returns>
        public static string GetLast(int length)
        {
            if (length <= 0)
                throw new ArgumentException("Length must be greater than 0");

            return new string('Z', length);
        }

        /// <summary>
        /// Validates if a string contains only uppercase letters A-Z
        /// </summary>
        /// <param name="input">String to validate</param>
        /// <returns>True if valid, false otherwise</returns>
        private static bool IsValidAlphabetString(string input)
        {
            return input.All(c => c >= 'A' && c <= 'Z');
        }

        /// <summary>
        /// Converts a number to alphabetical sequence (0->A, 1->B, ..., 25->Z, 26->AA, etc.)
        /// </summary>
        /// <param name="number">Number to convert (0-based)</param>
        /// <returns>Alphabetical sequence</returns>
        public static string ToSequence(long number)
        {
            if (number < 0)
                throw new ArgumentException("Number must be non-negative");

            if (number < 26)
                return ((char)('A' + number)).ToString();

            StringBuilder result = new StringBuilder();
            while (number >= 0)
            {
                result.Insert(0, (char)('A' + (number % 26)));
                number = number / 26 - 1;
                if (number < 0) break;
            }

            return result.ToString();
        }

        /// <summary>
        /// Converts an alphabetical sequence to its numeric equivalent
        /// </summary>
        /// <param name="sequence">Alphabetical sequence</param>
        /// <returns>Numeric equivalent (0-based)</returns>
        public static long ToNumber(string sequence)
        {
            if (string.IsNullOrEmpty(sequence))
                throw new ArgumentException("Sequence cannot be null or empty");

            if (!IsValidAlphabetString(sequence))
                throw new ArgumentException("Sequence must contain only uppercase letters A-Z");

            long result = 0;
            for (int i = 0; i < sequence.Length; i++)
            {
                result = result * 26 + (sequence[i] - 'A' + 1);
            }
            return result - 1;
        }
    }
}
