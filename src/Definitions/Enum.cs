using System.Dynamic;
using ate.Extensions;

namespace ate.Definitions
{
    public class Enum
    {

        public string Id { get; set; }
        public string DisplayName { get; set; }
        public string Name { get; set; }
        public string Guid { get; set; } = "";

        public Enum()
        {

        }

        public Enum(string Id, string DisplayName, string Name = "")
        {
            this.Id = Id;
            this.DisplayName = DisplayName;
            this.Name = Name;
            if (Name == "")
            {
                Name = DisplayName.CodeName();
            }

        }

        public void Autofill()
        {
            if (string.IsNullOrEmpty(Guid))
            {
                Guid = System.Guid.NewGuid().ToString();
            }
            Guid = Guid.ToLower();
        }

    }

}