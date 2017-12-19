using System.Collections.Generic;
using System.Dynamic;

namespace ate.Definitions
{
    public partial class Property
    {
        public List<Enum> Enums { get; set; }

        public Enum AddEnum(int Value, string DisplayName, string Name = "")
        {
            return AddEnum(Value.ToString(), DisplayName, Name);
        }

        public Enum AddEnum(string Value, string DisplayName, string Name = "")
        {
            var Enum = new Enum(Value, DisplayName, Name);
            if (Enums == null)
            {
                Enums = new List<Enum>();
            }
            Enums.Add(Enum);
            return Enum;
        }

        public void AutofillEnums()
        {
            if(Enums != null)
            {
                foreach (var Enum in Enums)
                {
                    Enum.Autofill();
                }
            }
        }
    }
}