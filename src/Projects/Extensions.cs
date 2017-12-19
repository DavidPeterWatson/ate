using System;
using ate.Definitions;

namespace ate.Extensions
{
    public static class Extensions
    {

        public static string CSharp(this DataType DataType)
        {
            switch (DataType)
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

                default:
                    return "string";
            }
        }


    }

}