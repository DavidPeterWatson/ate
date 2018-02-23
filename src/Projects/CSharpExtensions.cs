using System;
using ate.Definitions;

namespace ate.Extensions
{
    public static class CSharpExtensions
    {

        public static string CSharp(this Property Property)
        {
            switch (Property.DataType)
            {
                case DataType.None:
                    return "";

                case DataType.Boolean:
                    return "bool";

                case DataType.Integer:
                    return "int";

                case DataType.Parent:
                    return "object";

                case DataType.Number:
                    return "decimal";

                case DataType.DateTime:
                    return "DateTime";

                default:
                    return "string";
            }
        }

    }

}