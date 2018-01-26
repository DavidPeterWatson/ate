using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using ate.Extensions;

namespace ate.Definitions
{

    public partial class Property
    {

        public string DisplayName { get; set; }
        public string Guid { get; set; }
        public DataType DataType { get; set; } = DataType.None;
        public DataTypeFormat DataTypeFormat { get; set; } = DataTypeFormat.String;
        public int MaxLength { get; set; }
        public bool IsSequence { get; set; } = false;
        public bool IsVisible { get; set; } = true;
        public string Name { get; set; }
        public string Description { get; set; }
        public string FeatureName { get; set; }
        public bool IsReadOnly { get; set; }
        public object DefaultValue { get; set; }
        public bool Searchable { get; set; }
        public bool IsPrimaryKey { get; set; }
        public bool IsRequired { get; set; }
        public bool IsIndexed { get; set; }

        public Property() : base()
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

            AutofillEnums();
        }




    }

}