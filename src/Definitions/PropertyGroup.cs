using System.Collections.Generic;
using ate.Extensions;

using System.Linq;

namespace ate.Definitions
{
    public class PropertyGroup
    {
        public string DisplayName { get; set; }
        public string Guid { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string FeatureName { get; set; }
        public bool IsVisible { get; set; } = true;

        public List<Property> Properties { get; set; } = new List<Property>();


        public PropertyGroup() : base()
        {

        }





        public void Autofill()
        {
            if (Guid == null || Guid == "")
            {
                Guid = System.Guid.NewGuid().ToString();
            }
            Guid = Guid.ToLower();

            if (Name == null || Name == "")
            {

                Name = DisplayName.CodeName();

            }

            foreach (var Property in Properties)
            {
                Property.Autofill();
            }
        }


    }

}