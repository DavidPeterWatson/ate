using System;
using ate.Definitions;

namespace ate.Extensions
{
    public static class MSSQLExtensions
    {

        public static string MSSQL(this Property Property)
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

                case DataType.String:
                    return "varchar(" + Property.MaxLength + ")";

                default:
                    return "varchar";
            }

        }

    }

}