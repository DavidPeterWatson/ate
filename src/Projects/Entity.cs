using System.Collections.Generic;
using System.Linq;
using ate.Definitions;
using ate.Extensions;

namespace ate.Projects
{
    public class Entity : ate.Definitions.Entity
    {

        public Module Module { get; set; }
        public PropertyGroup KeyPropertyGroup { get; set; }
        public Property PrimaryKey { get; set; }

        public List<Property> Children { get; set; }

        public new List<PropertyGroup> PropertyGroups { get; set; } = new List<PropertyGroup>();

        public new List<Property> NameProperties { get; set; } = new List<Property>();

        public new List<Command> Commands { get; set; } = new List<Command>();

        public Entity()
        {

        }

        public Entity(ate.Definitions.Entity sourceEntity)
        {
            Import(sourceEntity);


        }

        public void Import(ate.Definitions.Entity sourceEntity)
        {

            this.Map(sourceEntity);

            if (sourceEntity.PropertyGroups != null)
            {
                foreach (var basePropertyGroup in sourceEntity.PropertyGroups)
                {
                    PropertyGroups.Add(new PropertyGroup(basePropertyGroup));
                }
            }
        }

        /// <summary>
        /// Singular Display Name. If left blank will use reverse camel of Name
        /// </summary>
        /// <returns></returns>
        public Entity(string display, string pluralDisplay, string guid, string featureName, string featureGuid, string description, Property primaryKey, string name, string plural, Entity superType, Entity baseType)
        {
            this.Display = display;
            this.PluralDisplay = pluralDisplay;
            this.Guid = guid;
            this.FeatureName = featureName;
            this.FeatureGuid = featureGuid;
            this.Description = description;
            this.PrimaryKey = primaryKey;
            this.Name = name;
            this.Plural = plural;
            this.SuperType = superType;
            this.BaseType = baseType;
        }

        public string FullName
        {
            get
            {
                if (Module != null)
                {
                    return Module.FullName + "." + Name;
                }
                else
                {
                    return Name;
                }
            }
        }

        public App App
        {
            get
            {
                return Module.App;
            }
        }

        public string LowerCaseName
        {
            get
            {
                return Name.ToLower();
            }
        }

        public List<Property> Properties
        {
            get
            {
                var _Properties = new List<Property>();
                foreach (var PropertyGroup in PropertyGroups)
                {
                    _Properties.AddRange(PropertyGroup.Properties);
                }
                return _Properties;
            }
        }

        public PropertyGroup AddPropertyGroup(string DisplayName, string Guid = "")
        {
            var PropertyGroup = new PropertyGroup(DisplayName, Guid, this);
            if (PropertyGroups == null)
            {
                PropertyGroups = new List<PropertyGroup>();
            }
            PropertyGroups.Add(PropertyGroup);
            return PropertyGroup;
        }

        public List<Property> ParentProperties
        {
            get
            {
                var _ParentProperties = new List<Property>();
                foreach (var PropertyGroup in PropertyGroups)
                {
                    _ParentProperties.AddRange(PropertyGroup.ParentProperties);
                }
                return _ParentProperties;
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

        public List<PropertyGroup> VisiblePropertyGroups
        {
            get
            {
                var Query =
                    from FindPropertyGroup in PropertyGroups
                    where FindPropertyGroup.IsVisible == true
                    select FindPropertyGroup;

                return Query.ToList();
            }
        }

        public void Build()
        {

            foreach (var PropertyGroup in PropertyGroups)
            {
                PropertyGroup.Entity = this;
                PropertyGroup.Build();
            }

            BuildKeyPropertyGroup();
            BuildPrimaryKey();
            BuildNameProperties();

            foreach (var Command in Commands)
            {
                Command.Entity = this;
                Command.Build();
            }
        }

        public void BuildNameProperties()
        {
            if (NameProperties == null)
            {
                NameProperties = new List<Property>();
            }

            if (NameProperties.Count == 0)
            {
                var NameQuery =
                from FindProperty in Properties
                where FindProperty.Name == "Name"
                select FindProperty;

                if (NameQuery.Any())
                {
                    if (NameProperties == null)
                    {
                        NameProperties = new List<Property>();
                    }
                    NameProperties.Add(NameQuery.First());
                }

                if (NameProperties.Count == 0)
                {
                    NameProperties.Add(PrimaryKey);
                }
            }
            else
            {
                foreach (var NameProperty in NameProperties)
                {
                    Property EffectiveNameProperty;

                    if (NameProperty.PropertyGroup == null)
                    {
                        EffectiveNameProperty = FindProperty(NameProperty.Name);
                    }
                    else
                    {
                        EffectiveNameProperty = NameProperty;
                    }

                    if (EffectiveNameProperty != null)
                    {
                        if (NameProperties == null)
                        {
                            NameProperties = new List<Property>();
                        }
                        if (!NameProperties.Contains(EffectiveNameProperty))
                        {
                            NameProperties.Add(EffectiveNameProperty);
                        }
                    }
                }
            }
        }

        public void BuildKeyPropertyGroup()
        {
            if (KeyPropertyGroup == null)
            {
                var KeyQuery = from FindPropertyGroup in PropertyGroups
                               where FindPropertyGroup.Name == "Keys"
                               select FindPropertyGroup;

                KeyPropertyGroup = KeyQuery.FirstOrDefault();
                if (KeyPropertyGroup == null)
                {
                    KeyPropertyGroup = new PropertyGroup("Keys", "", this);
                    KeyPropertyGroup.Name = "Keys";
                    KeyPropertyGroup.IsVisible = false;
                }
            }
        }

        public void BuildPrimaryKey()
        {
            if (PrimaryKey == null)
            {
                var PrimarykeyQuery = from FindProperty in Properties
                                      where FindProperty.IsPrimaryKey == true
                                      select FindProperty;

                PrimaryKey = PrimarykeyQuery.FirstOrDefault();

                if (PrimaryKey == null)
                {
                    PrimaryKey = new Property("Id", Guid, DataType.Integer, DataTypeFormat.Integer);
                    PrimaryKey.IsVisible = false;
                    PrimaryKey.PropertyGroup = KeyPropertyGroup;
                    KeyPropertyGroup.Properties.Add(PrimaryKey);
                }

            }
            else
            {
                if (PrimaryKey.PropertyGroup != KeyPropertyGroup)
                {
                    PrimaryKey.PropertyGroup = KeyPropertyGroup;
                }
                if (!PrimaryKey.PropertyGroup.Properties.Contains(PrimaryKey))
                {
                    KeyPropertyGroup.Properties.Add(PrimaryKey);
                }
            }
        }

        public void PostBuild()
        {
            foreach (var PropertyGroup in PropertyGroups)
            {
                PropertyGroup.PostBuild();
            }

            foreach (var Command in Commands)
            {
                Command.PostBuild();
            }
        }

        public Property FindChild(Property ParentProperty)
        {
            if (Children == null)
            {
                return null;
            }
            //Search this module
            var ChildQuery =
                from FindChild in Children
                where FindChild == ParentProperty
                select FindChild;

            return ChildQuery.FirstOrDefault();

        }

        public Property FindOrCreateChild(Property ParentProperty)
        {
            var Child = FindChild(ParentProperty);
            if (Child == null)
            {
                if (Children == null)
                {
                    Children = new List<Property>();
                }
                Children.Add(ParentProperty);
            }
            return Child;
        }

        public Property FindProperty(string PropertyName)
        {
            var PropertyQuery = from FindProperty in Properties
                                where FindProperty.Name == PropertyName
                                select FindProperty;

            return PropertyQuery.FirstOrDefault();
        }
    }
}