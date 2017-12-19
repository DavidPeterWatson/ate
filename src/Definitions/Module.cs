using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

using ate.Extensions;

namespace ate.Definitions
{
    public class Module
    {
        public string FileName { get; set; }
        public string DisplayName { get; set; }
        public string Guid { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool? IsDisplayed { get; set; }
        public string FeatureName { get; set; }
        public string FeatureGuid { get; set; }
        public List<Entity> Entities { get; set; }


        public Module() : base()
        {

        }

        public Module(string DisplayName, string Guid)
        {
            if (Guid == "")
            {
                Guid = System.Guid.NewGuid().ToString();
            }
            this.DisplayName = DisplayName;
            this.Guid = Guid;
        }

        public Module(string DisplayName, string Guid, string Name = "") : this(DisplayName, Guid)
        {

            this.Name = Name;

        }


        public Entity AddObject(string SingularDisplayName, string Guid = "")
        {

            var Object = new Entity(SingularDisplayName, Guid, this);
            Entities.Add(Object);
            return Object;

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

            foreach (var Object in Entities)
            {
                Object.Autofill();
            }
        }


    }

}