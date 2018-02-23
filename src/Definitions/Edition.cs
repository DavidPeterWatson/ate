using System;
using System.Collections.Generic;
using ate.Extensions;


namespace ate.Definitions
{
    public class Edition
    {
        public string DisplayName { get; set; } = "";
        public string Guid { get; set; } = "";
        public string Name { get; set; } = "";
        public List<Feature> Features { get; set; }

        public void Autofill()
        {
            if (Guid == null || Guid == "")
            {
                Guid = System.Guid.NewGuid().ToString();
            }
            Guid = Guid.ToLower();
        }

    }
}