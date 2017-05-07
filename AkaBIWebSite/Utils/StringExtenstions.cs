using System.Linq;

namespace AkaBIWebSite.Utils
{
    public static class StringExtenstions
    {
        public static string TruncateString(this string str, int maxLength)
        {
            if (string.IsNullOrEmpty(str))
                return str;

            return str.Length <= maxLength ? str : string.Format("{0}...", str.Substring(0, maxLength));
        }

        public static string FirstLetterToUpper(this string str)
        {
            if (string.IsNullOrEmpty(str))
                return str;

            return str.First().ToString().ToUpper() + str.Substring(1);
        }
    }
}