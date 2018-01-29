using System;
using ate.Definitions;

namespace ate.Extensions
{
    public static class JavaExtensions
    {

        public static string Java(this DataType DataType)
        {
            switch (DataType)
            {
                case DataType.None:
                    return "";

                case DataType.Boolean:
                    return "Bool";

                case DataType.Integer:
                    return "Int";

                case DataType.Parent:
                    return "Object";

                case DataType.Number:
                    return "Decimal";

                default:
                    return "String";
            }
        }


    }

}