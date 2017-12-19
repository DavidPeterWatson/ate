using System;
using System.Linq;
using System.Collections.Generic;

using ate.Definitions;
using ate.Extensions;

namespace ate.Projects
{
    public partial class Property : ate.Definitions.Property
    {
        public PropertyGroup PropertyGroup { get; set; }

        public Feature Feature { get; set; }

        public Property(ate.Definitions.Property sourceProperty)
        {
            Import(sourceProperty);
        }

        public void Import(ate.Definitions.Property sourceProperty)
        {

            this.Map(sourceProperty);

        }


        public Property(string DisplayName, string Guid, DataType DataType = DataType.String, DataTypeFormat DataTypeFormat = DataTypeFormat.String)
        {
            if (Guid == "")
            {
                Guid = System.Guid.NewGuid().ToString();
            }
            this.DisplayName = DisplayName;
            this.Guid = Guid;
            this.DataType = DataType;
            this.DataTypeFormat = DataTypeFormat;

            this.Name = this.DisplayName.CodeName();

        }

        public string LowerCaseName
        {
            get
            {
                return Name.ToLower();
            }
        }

        public Entity Entity
        {
            get
            {
                return PropertyGroup?.Entity;
            }
        }
        public App App
        {
            get
            {
                return Entity?.App;
            }
        }


        public bool IsLicensed
        {
            get
            {
                return Feature != null;
            }
        }

        // public bool IsPrimaryKey
        // {
        //     get
        //     {
        //         return Entity?.PrimaryKey == this;
        //     }
        // }

        public bool IsForeignKey
        {
            get
            {
                return ParentProperty?.ForeignKey == this;
            }
        }

        public void Build()
        {

        }

        public void PostBuild()
        {
            if (DataType == DataType.Parent)
            {
                BuildParent();
            }
            if (Feature?.Guid != null)
            {
                Feature = App.FindFeature(FeatureName);
            }
        }





        public Entity FindEntity(string EntityName)
        {
            //Search this module
            var ObjectQuery =
                from FindObject in PropertyGroup.Entity.Module.Entities
                where FindObject.Name == EntityName
                select FindObject;

            var FoundObject = ObjectQuery.FirstOrDefault();

            //If not found then search all modules
            if (FoundObject == null)
            {
                var AllObjectQuery =
                    from FindModule in PropertyGroup.Entity.Module.App.Modules
                    from FindObject in FindModule.Entities
                    where FindObject.Module.Name + "." + FindObject.Name == EntityName
                    select FindObject;

                return AllObjectQuery.FirstOrDefault();
            }
            else
            {
                return FoundObject;
            }
        }


    }

}