using System;
using System.Collections.Generic;
using ate.Extensions;

namespace ate.Definitions
{
    public class PropertyReference
    {
        public string Name { get; set; }
        public string Guid { get; set; }

        public PropertyReference()
        {

        }

        public PropertyReference(string Name, string Guid)
        {
            this.Name = Name;
            this.Guid = Guid;
        }

        // public Property Resolve()
        // {
        //     if (Object  == null)
        //     {
        //         var PropertyQuery =
        //         from FindProperty in Object.Properties
        //         where FindProperty.Guid == Guid || FindProperty.Name == Name
        //         select FindProperty;

        //         return PropertyQuery.FirstOrDefault();
        //     }
        //     else
        //     {
        //         return this;
        //     }
        // }
    }
}