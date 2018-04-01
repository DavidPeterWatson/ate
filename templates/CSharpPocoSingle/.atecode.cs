using System;
using System.Linq;
using System.Collections;
using ate.Extensions;
using ate.Projects;
using ate.Definitions;

 namespace N211a7aacc37241789be134a025a12f98 { 
    public static class App 
    {

/**/

        public static IEnumerable M2fa662781bb14b7e818588d70ce483d3(this ate.Projects.App App)
        {
            return ((Func<IEnumerable>)(() => App.Entities))();
        }


/*/Users/David/Documents/repos/ate/templates/CSharpPocoSingle*/

        public static String Mc21c65dfba934f9eb25a43b8b3b15f26(this ate.Projects.App App)
        {
            return ((Func<String>)(() => App.Display))();
        }


/*/Users/David/Documents/repos/ate/templates/CSharpPocoSingle/ʕAppℴDisplayʔ Models.cs*/

        public static String M7b774799d4064dcc9ee004a484d4c80e(this ate.Projects.App App)
        {
            return ((Func<String>)(() => App.FullName))();
        }

    }

    public static class Property 
    {

/* Entity.Properties*/

        public static String M76d693dd61c84ba2ac6558f819223c81(this ate.Projects.Property Property)
        {
            return ((Func<String>)(() => Property.Name))();
        }


/* Entity.Properties*/

        public static String Mcb04e16d570a4d458ff2fa701fc36210(this ate.Projects.Property Property)
        {
            return ((Func<String>)(() => Property.CSharp()))();
        }

    }

    public static class Entity 
    {

/* App.Entities*/

        public static String Md9df00386c3c48ceb85e24abb0b1263c(this ate.Projects.Entity Entity)
        {
            return ((Func<String>)(() => Entity.Name))();
        }


/**/

        public static IEnumerable Mbb4682f7ea9e4c048887fb7c4085c007(this ate.Projects.Entity Entity)
        {
            return ((Func<IEnumerable>)(() => Entity.Properties))();
        }

    }

}