//ʕignoreʔ
using System;
using System.Linq;
using System.Collections;
using ate.Extensions;
using ate.Projects;
using ate.Definitions;

 namespace N2dc6d3ff873d414ebf0ca84e8af566c9 { 
    public static class App 
    {

/*/home/david/Documents/repos/ate/templates/PlantUML*/

        public static String M303dabfe97b942f8b1c77615b65ddf25(this ate.Projects.App App)
        {
            return ((Func<String>)(() => App.Display))();
        }


/*/home/david/Documents/repos/ate/templates/PlantUML/ʕAppℴDisplayʔ.puml*/

        public static String M805ee7cac05844eea71a8ff4944d2a17(this ate.Projects.App App)
        {
            return ((Func<String>)(() => App.Name))();
        }


/*

*/
/*
' uncomment the line below if you're using computer with a retina display
' skinparam dpi 300
!define Table(name,desc) class name as "desc" << (T,#FFAAAA) >>
' we use bold for primary key
' green color for unique
' and underscore for not_null
!define primary_key(x) <b>x</b>
!define unique(x) <color:green>x</color>
!define not_null(x) <u>x</u>
' other tags available:
' <i></i>
' <back:COLOR></color>, where color is a color name or html color code
' (#FFAACC)
' see: http://plantuml.com/classes.html#More
hide methods
hide stereotypes

' entities
*/

        public static IEnumerable M6dbf5d9fa2d24a3496b9e6b51f11f338(this ate.Projects.App App)
        {
            return ((Func<IEnumerable>)(() => App.Entities))();
        }

    }

    public static class Property 
    {

/*
*/

        public static String Mc5153201cd034b12b61e1336f7d9c94b(this ate.Projects.Property ParentProperty)
        {
            return ((Func<String>)(() => ParentProperty.Entity.Name))();
        }


/**/

        public static String M960bcb8b2a084216a192c623c5f48b3d(this ate.Projects.Property Property)
        {
            return ((Func<String>)(() => Property.Name))();
        }


/**/

        public static Boolean M76f910c7e482449c803bb7bc0cd44194(this ate.Projects.Property Property)
        {
            return ((Func<Boolean>)(() => Property.DataType == DataType.DateTime))();
        }


/*
*/

        public static String M4f850097052c44119fdf52b04324ff14(this ate.Projects.Property ParentProperty)
        {
            return ((Func<String>)(() => ParentProperty.Parent.Name))();
        }


/**/

        public static Boolean Mc5f578e784e749b7854188ca826030df(this ate.Projects.Property Property)
        {
            return ((Func<Boolean>)(() => Property.DataType == DataType.String))();
        }


/**/

        public static Boolean Md15898afbdc94a19839e2f65a74972e7(this ate.Projects.Property Property)
        {
            return ((Func<Boolean>)(() => Property.IsPrimaryKey))();
        }


/**/

        public static String M119f89766134441981f33e6eda8f7d9b(this ate.Projects.Property Property)
        {
            return ((Func<String>)(() => Property.DataType.ToString()))();
        }


/**/

        public static String M5eb9e814f604429e95435f10a15b9441(this ate.Projects.Property Property)
        {
            return ((Func<String>)(() => Property.MaxLength.ToString()))();
        }

    }

    public static class Entity 
    {

/*
*/

        public static IEnumerable Mbe860a9b4d664d7b8d5a2b4afa172041(this ate.Projects.Entity Entity)
        {
            return ((Func<IEnumerable>)(() => Entity.ParentProperties))();
        }


/*
' uncomment the line below if you're using computer with a retina display
' skinparam dpi 300
!define Table(name,desc) class name as "desc" << (T,#FFAAAA) >>
' we use bold for primary key
' green color for unique
' and underscore for not_null
!define primary_key(x) <b>x</b>
!define unique(x) <color:green>x</color>
!define not_null(x) <u>x</u>
' other tags available:
' <i></i>
' <back:COLOR></color>, where color is a color name or html color code
' (#FFAACC)
' see: http://plantuml.com/classes.html#More
hide methods
hide stereotypes

' entities
*/

        public static String M73f85a787be14addbb7dcc2b5e0451ab(this ate.Projects.Entity Entity)
        {
            return ((Func<String>)(() => Entity.Description))();
        }


/*
' uncomment the line below if you're using computer with a retina display
' skinparam dpi 300
!define Table(name,desc) class name as "desc" << (T,#FFAAAA) >>
' we use bold for primary key
' green color for unique
' and underscore for not_null
!define primary_key(x) <b>x</b>
!define unique(x) <color:green>x</color>
!define not_null(x) <u>x</u>
' other tags available:
' <i></i>
' <back:COLOR></color>, where color is a color name or html color code
' (#FFAACC)
' see: http://plantuml.com/classes.html#More
hide methods
hide stereotypes

' entities
*/

        public static String Mb3836892280642d7ba55db3d15393f2e(this ate.Projects.Entity Entity)
        {
            return ((Func<String>)(() => Entity.Name))();
        }


/*)") {
    */

        public static IEnumerable M28dc99877b124235a6ab076ddb0466d2(this ate.Projects.Entity Entity)
        {
            return ((Func<IEnumerable>)(() => Entity.Properties))();
        }

    }

}