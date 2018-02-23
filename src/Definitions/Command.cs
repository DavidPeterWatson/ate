using System;
using System.Collections.Generic;
using ate.Extensions;

namespace ate.Definitions
{
    public class Command
    {
        public string DisplayName { get; set; }
        public string Guid { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }

        public string FeatureName { get; set; }



        public Command()
        {

        }

        public Command(string DisplayName, string Guid, string Name, string Code)
        {
            this.DisplayName = DisplayName;
            this.Guid = Guid;
            this.Name = Name;
            this.Code = Code;

        }


    }

}