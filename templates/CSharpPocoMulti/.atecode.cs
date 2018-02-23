using System;
using System.Linq;
using System.Collections;
using ate.Extensions;
using ate.Projects;
using ate.Definitions;

 namespace N41013f2fdabc40ad988957169e7bdb6a { 
    public static class Entity 
    {

/*/home/david/Documents/repos/ate/templates/CSharpPocoMulti/ʕAppℴDisplayʔ Models/ʕfor each Entity in AppℴEntitiesʔʕEntityℴNameʔ.cs*/

        public static String M1b45c294ae284441b804f3e933af1bdb(this ate.Projects.Entity Entity)
        {
            return ((Func<String>)(() => Entity.App.FullName))();
        }


/*/home/david/Documents/repos/ate/templates/CSharpPocoMulti/ʕAppℴDisplayʔ Models/ʕfor each Entity in AppℴEntitiesʔʕEntityℴNameʔ.cs*/
/* App.Entities*/

        public static String M9a21d4e8807f4ff3b39678978571edcc(this ate.Projects.Entity Entity)
        {
            return ((Func<String>)(() => Entity.Name))();
        }


/**/

        public static IEnumerable Me301b331bd2b4322b58d7e7ef459b320(this ate.Projects.Entity Entity)
        {
            return ((Func<IEnumerable>)(() => Entity.Properties))();
        }

    }

    public static class App 
    {

/*/home/david/Documents/repos/ate/templates/CSharpPocoMulti*/
/*/home/david/Documents/repos/ate/templates/CSharpPocoMulti/test.txt*/

        public static String M1d5c952ed0c848c98e551ff1218e4c70(this ate.Projects.App App)
        {
            return ((Func<String>)(() => App.Display))();
        }


/**/

        public static IEnumerable M887536c6350c48769493fac859b02269(this ate.Projects.App App)
        {
            return ((Func<IEnumerable>)(() => App.Entities))();
        }

    }

    public static class Property 
    {

/* Entity.Properties*/

        public static String M4d1f0a3750ba4c47b62da5b7793afc50(this ate.Projects.Property Property)
        {
            return ((Func<String>)(() => Property.CSharp()))();
        }


/* Entity.Properties*/

        public static String Ma055b6d31f924d85b79ae75bef73b337(this ate.Projects.Property Property)
        {
            return ((Func<String>)(() => Property.Name))();
        }

    }

}