using System.Collections.Generic;
using System.Linq;
using ate.Definitions;
using ate.Extensions;

namespace ate.Projects
{
    public class PropertyGroup : ate.Definitions.PropertyGroup
    {

        public Entity Entity;

        public Feature Feature;
        public new List<Property> Properties { get; set; } = new List<Property>();

        public PropertyGroup(ate.Definitions.PropertyGroup basePropertyGroup)
        {
            Import(basePropertyGroup);


        }

        public void Import(ate.Definitions.PropertyGroup sourcePropertyGroup)
        {

            this.Map(sourcePropertyGroup);

            if (sourcePropertyGroup.Properties != null)
            {
                foreach (var baseProperty in sourcePropertyGroup.Properties)
                {
                    Properties.Add(new Property(baseProperty));
                }
            }
        }

        public PropertyGroup(string DisplayName, string Guid, Entity Entity)
        {
            if (Guid == "")
            {
                Guid = System.Guid.NewGuid().ToString();
            }
            this.DisplayName = DisplayName;
            this.Guid = Guid;
            this.Entity = Entity;

            this.Name = this.DisplayName.CodeName();
            if (!Entity.PropertyGroups.Contains(this))
            {
                Entity.PropertyGroups.Add(this);
            }
        }

        public string LowerCaseName
        {
            get
            {
                return Name.ToLower();
            }
        }

        public App App
        {
            get
            {
                return Entity.App;
            }
        }

        public List<Property> VisibleProperties
        {
            get
            {
                var Query =
                    from FindProperty in Properties
                    where FindProperty.IsVisible == true
                    select FindProperty;

                return Query.ToList();
            }
        }

        public List<Property> NonKeyProperties
        {
            get
            {
                var Query =
                    from FindProperty in Properties
                    where FindProperty.IsPrimaryKey == false && FindProperty.IsForeignKey == false
                    select FindProperty;
                return Query.ToList();
            }
        }

        public List<Property> ParentProperties
        {
            get
            {
                var ParentProperyQuery =
                from Property FindParentProperty in Properties
                where FindParentProperty.DataType == DataType.Parent
                select FindParentProperty;

                return ParentProperyQuery.ToList();
            }
        }

        public void Build()
        {

            foreach (var Property in Properties)
            {
                Property.PropertyGroup = this;
                Property.Build();
            }

        }

        public void PostBuild()
        {

            foreach (var Property in Properties)
            {
                Property.PostBuild();
            }
            if (Feature?.Guid != null)
            {
                Feature = App.FindFeature(FeatureName);
            }
        }

        public Property AddProperty(string DisplayName, string Guid = "", DataType DataType = DataType.String, DataTypeFormat DataTypeFormat = DataTypeFormat.String)
        {
            var Property = new Property(DisplayName, Guid, DataType, DataTypeFormat);
            Properties.Add(Property);
            Property.PropertyGroup = this;
            return Property;

        }

        public Property AddEnumProperty(string DisplayName, string Guid = "", DataTypeFormat DataTypeFormat = DataTypeFormat.String)
        {
            var Property = new Property(DisplayName, Guid, DataType.Enum, DataTypeFormat);
            Properties.Add(Property);
            Property.PropertyGroup = this;
            return Property;

        }

        public Property AddParentProperty(string DisplayName, Entity ParentObject, string Guid = "", DataTypeFormat DataTypeFormat = DataTypeFormat.String)
        {
            var Property = new Property(DisplayName, Guid, DataType.Parent, DataTypeFormat);
            Properties.Add(Property);
            Property.PropertyGroup = this;
            // Property.ParentReference = ParentObject.ObjectReference;
            return Property;

        }


    }

}