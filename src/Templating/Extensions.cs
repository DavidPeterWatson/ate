using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace ate.Templating
{
    public static class Extensions
    {
        public static bool Contains(this string[] Values, string Find)
        {
            foreach (var value in Values)
            {
                if (value == Find)
                {
                    return true;
                }
            }
            return false;
        }

        public static bool ContainsTags(this string Value, Dictionary<string, string> Tags, string Contents)
        {
            foreach (var Pair in Tags)
            {
                if (Value.Contains(Pair.Key))
                {
                    string SubValue = Value.Substring(Value.IndexOf(Pair.Key) + Pair.Key.Length);

                    if (SubValue.Contains(Pair.Value))// && SubValue.IndexOf(Pair.Key) < SubValue.IndexOf(Pair.Value))
                    {
                        var Test = SubValue.Substring(0, SubValue.IndexOf(Pair.Value));
                        if (Test == Contents)
                        {
                            return true;
                        }
                    }
                }
            }
            Contents = "";
            return false;
        }

        public static bool ContainsTags(this string Value, Dictionary<string, string> Tags, string Contents, out KeyValuePair<string, string> Tag)
        {
            foreach (var Pair in Tags)
            {
                if (Value.Contains(Pair.Key))
                {
                    string SubValue = Value.Substring(Value.IndexOf(Pair.Key) + Pair.Key.Length);

                    if (SubValue.Contains(Pair.Value) && Value.IndexOf(Pair.Key) < SubValue.IndexOf(Pair.Value))
                    {

                        var Test = SubValue.Substring(0, SubValue.IndexOf(Pair.Value));
                        if (Test == Contents)
                        {
                            Tag = Pair;
                            return true;
                        }
                    }
                }
            }
            Tag = new KeyValuePair<string, string>("", "");
            Contents = "";
            return false;
        }

        public static int IndexOfTags(this string Value, Dictionary<string, string> Tags, out KeyValuePair<string, string> Tag)
        {
            foreach (var Pair in Tags)
            {
                if (Value.Contains(Pair.Key))
                {
                    Tag = Pair;
                    return Value.IndexOf(Pair.Key);
                }
            }
            Tag = new KeyValuePair<string, string>("", "");
            return -1;
        }

        public static bool StartsWithTags(this string Value, Dictionary<string, string> Tags, string Contents)
        {
            foreach (var Pair in Tags)
            {
                if (Value.StartsWith(Pair.Key))
                {
                    string SubValue = Value.Substring(Pair.Key.Length);

                    if (SubValue.Contains(Pair.Value))
                    {
                        var Test = SubValue.Substring(0, SubValue.IndexOf(Pair.Value));

                        if (Test.StartsWith(Contents))
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        public static bool StartsWithTags(this string Value, Dictionary<string, string> Tags, string Contents, out KeyValuePair<string, string> Tag)
        {
            try
            {
                foreach (var Pair in Tags)
                {

                    if (Value.StartsWith(Pair.Key))
                    {
                        string SubValue = Value.Substring(Pair.Key.Length);

                        if (SubValue.Contains(Pair.Value))
                        {
                            var Test = SubValue.Substring(0, SubValue.IndexOf(Pair.Value));

                            if (Test.StartsWith(Contents))
                            {
                                Tag = Pair;
                                return true;
                            }
                        }
                    }
                }
                Tag = new KeyValuePair<string, string>("", "");
                return false;
            }
            catch (Exception Exception)
            {
                Console.WriteLine(Value);
                Console.WriteLine(Contents);
                throw Exception;
            }
        }

        public static bool FitsMask(this string fileName, string fileMask)
        {
            Regex mask = new Regex(fileMask.Replace(".", "[.]").Replace("*", ".*").Replace("?", "."));
            return mask.IsMatch(fileName);
        }
    }
}