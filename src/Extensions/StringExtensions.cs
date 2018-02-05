using System.Linq;

namespace ate.Extensions
{
    public static class StringExtensions
    {

        public static string ToCamelCase(this string input)
        {
            var result = "";
            var remainingString = input;

            while (remainingString.Length > 1 && remainingString[0].IsUpper() && remainingString[1].IsUpper())
            {
                result += remainingString[0].ToLower();
                remainingString = remainingString.Substring(1);
            }
            if (result == "")
            {
                result += remainingString[0].ToLower();
                remainingString = remainingString.Substring(1);
            }
            result += remainingString;
            return result;
        }


        public static string ToPascalCase(this string input)
        {
            var result = input.ToCamelCase();

            return result[0].ToLower() + result.Substring(1);
        }


        public static string ToHyphenCase(this string input)
        {
            string result = string.Concat(input.Select((x, j) => j > 0 && char.IsUpper(x) ? "-" + x.ToString() : x.ToString()));
            return result.ToLower();
        }

        public static string ToUnderscoreCase(this string input)
        {
            string result = string.Concat(input.Select((x, j) => j > 0 && char.IsUpper(x) ? "_" + x.ToString() : x.ToString()));
            return result.ToLower();
        }

        public static bool IsUpper(this char Char)
        {
            var s = "" + Char;

            return s != s.ToLower() && s == s.ToUpper();
        }

        public static bool IsLower(this char Char)
        {
            var s = "" + Char;

            return s != s.ToLower() && s == s.ToUpper();
        }

        public static char ToLower(this char Char)
        {
            return Char.ToString().ToLower()[0];
        }

        public static char ToUpper(this char Char)
        {
            return Char.ToString().ToUpper()[0];
        }


    }
}