using System;
using ate.Definitions;

namespace ate.Extensions
{
    public static class MySQLExtensions
    {

        public static string MySQL(this Property Property)
        {
            switch (Property.DataType)
            {
                case DataType.None:
                    return "";

                case DataType.Boolean:
                    return "bit";

                case DataType.Parent:
                    return "";

                case DataType.Integer:

                    switch (Property.DataTypeFormat)
                    {
                        case DataTypeFormat.Byte:
                            return "tinyint";

                        case DataTypeFormat.ShortInteger:
                            return "shortint";

                        case DataTypeFormat.Integer:
                            return "int";

                        case DataTypeFormat.LongInteger:
                            return "bigint";
                    }
                    return "int";

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
                            return "varchar(" + Property.MaxLength + ")";
                    }

                default:
                    return "";

            }

        }

    }

}