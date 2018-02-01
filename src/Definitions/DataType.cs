namespace ate.Definitions
{
    public enum DataType : byte
    {
        None = 0,
        Boolean = 1,
        String = 2,
        Integer = 3,//byte, int16, int32, long
        Number = 4,//float, decimal, double
        Guid = 5,
        Parent = 6,//reference to a parent object
        Data = 7, //Byte array
        Enum = 8,//
        DateTime = 9,
        TimeSpan = 10,
    }

    public enum DataTypeFormat : byte
    {
        None = 0,
        String = 1,
        Guid = 2,
        Password = 3,
        Char = 4,
        Json = 5,
        Xml = 6,
        Byte = 10,
        ShortInteger = 11,
        Integer = 12,
        LongInteger = 13,
        Number = 20,//Decimal
        Float = 21,//32 bit
        Double = 22, //64 bit
        Percentage = 21,
        Currency = 30,
        AccountingCurrency = 31,
        ShortDate = 40,
        MediumDate = 41,
        LongDate = 42,
        ShortDateTime = 50,
        MediumDateTime = 51,
        LongDateTime = 52,
        ShortTime = 60,
        MediumTime = 61,
        YesNo = 70,
        AutoTimeSpan = 80,
        Milliseconds = 81,
        Seconds = 82,
        Minutes = 83,
        Hours = 84,
        Days = 85,
        Weeks = 86,
        Months = 87,
        Years = 88,

    }
}