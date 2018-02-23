using System;
using System.Collections.Generic;
using ate.Extensions;

namespace ate.Definitions
{
    public class Feature
    {
        public string Name { get; set; } = "";
        public string DisplayName { get; set; } = "";
        public string Guid { get; set; } = "";

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