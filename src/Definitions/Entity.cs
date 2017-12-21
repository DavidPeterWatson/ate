using System;
using System.Collections.Generic;
using ate.Extensions;
using System.Dynamic;
using System.Linq;


namespace ate.Definitions
{
    public class Entity
    {
        public string Reference { get; set; }
        public string Display { get; set; }

        /// <summary>
        /// Plural Display Name.!-- If left blank will use reverse camel of Plural
        /// </summary>
        /// <returns></returns>
        public string PluralDisplay { get; set; }

        public string Guid { get; set; }
        public bool? IsVisible { get; set; }
        public string FeatureName { get; set; }
        public string FeatureGuid { get; set; }
        public string Description { get; set; }

        public List<Property> PrimaryKeys { get; set; }


        /// <summary>
        /// Singular Code Name
        /// </summary>
        /// <returns></returns>
        public string Name { get; set; }


        /// <summary>
        /// Plural Code Name.!-- If left blank will pluralise Name
        /// </summary>
        /// <returns></returns>
        public string Plural { get; set; }

        public Entity SuperType { get; set; }

        /// <summary>
        /// Inherits from Base Type
        /// </summary>
        /// <returns></returns>
        public Entity BaseType { get; set; }

        public virtual List<PropertyGroup> PropertyGroups { get; set; } = new List<PropertyGroup>();

        public List<Property> NameProperties { get; set; }

        public List<Command> Commands { get; set; } 



        public Entity()
        {

        }

        public Entity(string DisplayName, string Guid, Module Module)
        {
            if (Guid == "")
            {
                Guid = System.Guid.NewGuid().ToString();
            }
            this.Display = DisplayName;
            this.Guid = Guid;
            // this.Module = Module;
        }

        public Entity(string DisplayName, string Guid, Module Module, string Name, string PluralName) :
            this(DisplayName, Guid, Module)
        {
            this.Name = Name;
            this.Plural = PluralName;
        }



        public Command AddCommand(string DisplayName, string Guid = "", string Name = "", string Code = "")
        {
            var Command = new Command(DisplayName, Guid, Name, Code);
            if (Commands == null)
            {
                Commands = new List<Command>();
            }
            Commands.Add(Command);
            return Command;

        }


        public void Autofill()
        {
            if (string.IsNullOrEmpty(Guid))
            {
                Guid = System.Guid.NewGuid().ToString();
            }
            Guid = Guid.ToLower();

            if (string.IsNullOrEmpty(Name))
            {

                Name = Display.CodeName();

            }

            foreach (var PropertyGroup in PropertyGroups)
            {
                PropertyGroup.Autofill();
            }

        }




    }

}