using System;
using System.Linq;
using System.Collections;
using ate.Extensions;
using ate.Projects;
using ate.Definitions;

 namespace Na8222da1b0b34ad6a3a25dd216b13c81 { 
    public static class App 
    {

/**/

        public static IEnumerable M21b99ac8b66c48ca8aa385ddcf08dfd9(this ate.Projects.App App)
        {
            return ((Func<IEnumerable>)(() => App.Entities))();
        }


/*/Users/David/Documents/repos/ate/templates/CSharpPocoMulti*/
/*/Users/David/Documents/repos/ate/templates/CSharpPocoMulti/test.txt*/
/*/Users/David/Documents/repos/ate/templates/CSharpPocoMulti/Readme.md*/

        public static String Mfde33ae6b7a846eead0da766973a26e8(this ate.Projects.App App)
        {
            return ((Func<String>)(() => App.Display))();
        }

    }

    public static class Property 
    {

/* Entity.Properties*/

        public static String Md85ab9d864db4bbf928af87ff0cdac3b(this ate.Projects.Property Property)
        {
            return ((Func<String>)(() => Property.CSharp()))();
        }


/* Entity.Properties*/

        public static String Me0d20a744ea44388af55549fd4db5dcb(this ate.Projects.Property Property)
        {
            return ((Func<String>)(() => Property.Name))();
        }

    }

    public static class Entity 
    {

/*/Users/David/Documents/repos/ate/templates/CSharpPocoMulti/ʕAppℴDisplayʔ Models/ʕfor each Entity in AppℴEntitiesʔʕEntityℴNameʔ.cs*/
/* App.Entities*/

        public static String Ma5759b040d114fdfb9e0c6f283b28b6e(this ate.Projects.Entity Entity)
        {
            return ((Func<String>)(() => Entity.Name))();
        }


/**/

        public static IEnumerable Ma68520c73e9a4d51924dc87c7890d186(this ate.Projects.Entity Entity)
        {
            return ((Func<IEnumerable>)(() => Entity.Properties))();
        }


/*/Users/David/Documents/repos/ate/templates/CSharpPocoMulti/ʕAppℴDisplayʔ Models/ʕfor each Entity in AppℴEntitiesʔʕEntityℴNameʔ.cs*/

        public static String Mb94a4fcdc33a4c8599414779092752a7(this ate.Projects.Entity Entity)
        {
            return ((Func<String>)(() => Entity.App.FullName))();
        }

    }

}