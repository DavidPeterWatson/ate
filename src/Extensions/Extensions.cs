using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace ate.Extensions
{
    public static class IOExtensions
    {

        public static void Replace<T>(this List<T> List, T Replace, T With)
        {
            List.Insert(List.IndexOf(Replace), With);
            List.Remove(Replace);
        }

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


        public static bool ContainsTags(this string Value, Dictionary<string, string> Tags, out KeyValuePair<string, string> Tag)
        {
            foreach (var Pair in Tags)
            {
                if (Value.Contains(Pair.Key) && Value.Contains(Pair.Value) && Value.IndexOf(Pair.Key) < Value.IndexOf(Pair.Value))
                {
                    Tag = Pair;
                    return true;
                }
            }
            Tag = new KeyValuePair<string, string>("", "");
            return false;
        }

        public static bool StartsWithTags(this string Value, Dictionary<string, string> Tags, out KeyValuePair<string, string> Tag)
        {
            foreach (var Pair in Tags)
            {
                if (Value.StartsWith(Pair.Key) && Value.Contains(Pair.Value))
                {
                    Tag = Pair;
                    return true;
                }
            }
            Tag = new KeyValuePair<string, string>("", "");
            return false;
        }

        public static string CodeName(this string Value)
        {
            return Value.Replace(" ", "").Replace("-", "");
        }

        public static bool Implements<I>(this Type source) where I : class
        {
            return typeof(I).IsAssignableFrom(source);
        }

        public static string GetResourceString(this object Object, string ResourceName)
        {
            using (StreamReader reader = new StreamReader(GetResourceStream(Object, ResourceName), Encoding.UTF8))
            {
                return reader.ReadToEnd();
            }
        }

        public static Stream GetResourceStream(this object Object, string ResourceName)
        {

            try
            {
                var Stream = Object.GetType().GetTypeInfo().Assembly.GetManifestResourceStream(ResourceName);
                if (Stream == null)
                {
                    var ResourceNames = Object.GetType().GetTypeInfo().Assembly.GetManifestResourceNames();
                    foreach (var Name in ResourceNames)
                    {
                        Console.WriteLine(Name);
                    }
                }
                return Stream;

            }
            catch (Exception Exception)
            {
                throw Exception;
            }

        }

    }

}