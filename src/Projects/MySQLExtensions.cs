using System;
using ate.Definitions;

namespace ate.Extensions
{
    public static class MySQLExtensions
    {

        public static string MySQL(this DataType DataType)
        {
            switch (DataType)
            {
                case DataType.None:
                    return "";

                case DataType.Boolean:
                    return "bit";

                case DataType.Integer:
                    return "int";

                case DataType.Parent:
                    return "";

                case DataType.Number:
                    return "decimal";

                default:
                    return "varchar";
            }
        }

        public static string MySQL(this Property Property)
        {
            switch (Property.DataType)
            {
                case DataType.None:
                    return "";

                case DataType.Boolean:
                    return "bit";

                case DataType.Integer:
                    return "int";

                case DataType.Parent:
                    return "";

                case DataType.Number:
                    return "decimal";

                default:
                    return "varchar(" + Property.MaxLength + ")";
            }
        }


    }

}