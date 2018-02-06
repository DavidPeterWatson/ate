using System;
using System.Linq;
using System.Collections;
using ate.Extensions;
using ate.Projects;
using ate.Definitions;

 namespace Nf74f4e2a80574996925c7583c7ea1ab2 { 
    public static class Entity 
    {

/**/

        public static IEnumerable Mbba6f90633bb46bb9cbd3f23223d879d(this ate.Projects.Entity Entity)
        {
            return ((Func<IEnumerable>)(() => Entity.Properties))();
        }


/*/home/david/Documents/repos/ate/templates/CSharpPocoMulti/ʕAppℴDisplayʔ Models/ʕfor each Entity in AppℴEntitiesʔʕEntityℴNameʔ.cs*/
/* App.Entities*/

        public static String M06b1076d9c9b4e31bd928a17458df255(this ate.Projects.Entity Entity)
        {
            return ((Func<String>)(() => Entity.Name))();
        }


/*/home/david/Documents/repos/ate/templates/CSharpPocoMulti/ʕAppℴDisplayʔ Models/ʕfor each Entity in AppℴEntitiesʔʕEntityℴNameʔ.cs*/

        public static String Mf8ace5757d514b3db86127a508841396(this ate.Projects.Entity Entity)
        {
            return ((Func<String>)(() => Entity.App.FullName))();
        }

    }

    public static class App 
    {

/*/home/david/Documents/repos/ate/templates/CSharpPocoMulti/test.txt*/
/*/home/david/Documents/repos/ate/templates/CSharpPocoMulti*/

        public static String Mf71277812bb6486f935eaffc51e0ae75(this ate.Projects.App App)
        {
            return ((Func<String>)(() => App.Display))();
        }


/**/

        public static IEnumerable M0f89b229e17242f090ca8e13cf63f474(this ate.Projects.App App)
        {
            return ((Func<IEnumerable>)(() => App.Entities))();
        }

    }

    public static class Property 
    {

/* Entity.Properties*/

        public static String Mf6933d3bd6fd4aa9bf570ac00a2df993(this ate.Projects.Property Property)
        {
            return ((Func<String>)(() => Property.Name))();
        }


/* Entity.Properties*/

        public static String Ma6cde6c932544da1a8b159248eea7d80(this ate.Projects.Property Property)
        {
            return ((Func<String>)(() => Property.CSharp()))();
        }

    }

}