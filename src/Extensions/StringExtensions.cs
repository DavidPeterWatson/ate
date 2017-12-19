namespace ate.Extensions
{
    public static class StringExtensions
    {

        public static string ToCamelCase(this string Value)
        {
            var Result = "";
            var RemainingString = Value;

            while (RemainingString.Length > 1 && RemainingString[0].IsUpper() && RemainingString[1].IsUpper())
            {
                Result += RemainingString[0].ToLower();
                RemainingString = RemainingString.Substring(1);
            }
            if (Result == "")
            {
                Result += RemainingString[0].ToLower();
                RemainingString = RemainingString.Substring(1);
            }
            Result += RemainingString;
            return Result;
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