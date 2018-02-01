using System;
using System.Linq;

namespace ate.Projects
{
    public partial class Property : ate.Definitions.Property
    {

        public Entity Parent { get; set; }



        public Entity Child
        {
            get
            {
                return Entity;
            }
        }

        public Property ForeignKey { get; set; }

        public string PluralDisplayName { get; set; }


        public string PluralName { get; set; }

        public void BuildParent()
        {

            if (Parent == null)
            {
                Parent = FindEntity(ParentName);
                if(Parent == null)
                {
                    throw new Exception("Parent called '" + ParentName + "' for property " + Name + " of " + Entity.Name + " not found");
                }
                Parent.FindOrCreateChild(this);

            }

            if (PluralDisplayName == null || PluralDisplayName == "")
            {
                PluralDisplayName = (Prefix + " " + Child.PluralDisplay).Trim();
            }
            if (PluralName == null || PluralName == "")
            {
                PluralName = Prefix + Child.Plural;
            }

            if (Display == null || Display == "")
            {
                Display = (Prefix + " " + Parent.Display).Trim();
            }
            if (Name == null || Name == "")
            {
                Name = Prefix + Parent.Name;
            }

            if ((ForeignKeyName ?? "") != "")
            {
                ForeignKey = Entity.Properties.FirstOrDefault(findProperty => findProperty.Name == ForeignKeyName);
            }

            if (ForeignKey == null)
            {
                ForeignKey = new Property(Prefix + " " + Parent.Display + " " + Parent.PrimaryKey.Display, null, Parent.PrimaryKey.DataType, Parent.PrimaryKey.DataTypeFormat);

                ForeignKey.Name = Prefix + Parent.Name + Parent.PrimaryKey.Name;

                ForeignKey.IsVisible = false;

                ForeignKey.PropertyGroup = Entity.KeyPropertyGroup;
                Entity.KeyPropertyGroup.Properties.Add(ForeignKey);
                ForeignKey.ParentProperty = this;

            }

        }

    }
}