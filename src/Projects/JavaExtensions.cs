using System;
using ate.Definitions;

namespace ate.Extensions
{
    public static class JavaExtensions
    {

        public static string Java(this Property Property)
        {
            switch (Property.DataType)
            {
                case DataType.None:
                    return "void";

                case DataType.Boolean:
                    return "boolean";

                case DataType.Parent:
                    return "Object";

                case DataType.Integer:

                    switch (Property.DataTypeFormat)
                    {
                        case DataTypeFormat.Byte:
                            return "Byte";

                        case DataTypeFormat.ShortInteger:
                            return "Short";

                        case DataTypeFormat.Integer:
                            return "Integer";

                        case DataTypeFormat.LongInteger:
                            return "Long";
                    }
                    return "Integer";

                case DataType.Number:
                    switch (Property.DataTypeFormat)
                    {
                        case DataTypeFormat.Float:
                            return "float";

                        case DataTypeFormat.Double:
                            return "double";
                    }
                    return "double";

                case DataType.DateTime:
                    return "DateTime";

                case DataType.String:

                    switch (Property.DataTypeFormat)
                    {
                        case DataTypeFormat.Char:
                            return "char";

                        default:
                            return "String";
                    }

                default:
                    return "";

            }
        }

    }

}