using System.Collections.Generic;
using System.Dynamic;


using ate.Extensions;

namespace ate.Definitions
{
    public partial class Property
    {
        public string ParentName { get; set; }

        /// <summary>
        /// Used to infer foreign keys from parent primary keys
        /// </summary>
        /// <returns></returns>
        public string Prefix { get; set; }





    }

}