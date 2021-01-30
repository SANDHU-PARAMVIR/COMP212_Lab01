using System;
using System.Text;

namespace Lab1
{
    static class ExtensionMethod
    {
        public static int CountWords(this StringBuilder sb)
        {
            // split the string from the string builder with some whitespace characters
            // and exclude any entries with empty string
            string[] splitted = sb.ToString().Split(
                new[] { ' ', '\n', '\r', '\t' },
                StringSplitOptions.RemoveEmptyEntries);

            return splitted.Length;
        }
    }
}
