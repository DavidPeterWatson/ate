using System;
using ate.Definitions;

namespace ate.Extensions
{
    public static class JavascriptExtensions
    {

        public static string Javascript(this Property Property)
        {
            switch (Property.DataType)
            {
                case DataType.None:
                    return "";

                case DataType.Boolean:
                    return "boolean";

                case DataType.Integer:
                    return "number";

                case DataType.Parent:
                    return "object";

                case DataType.Number:
                    return "number";

                default:
                    return "string";
            }
        }

    }

}