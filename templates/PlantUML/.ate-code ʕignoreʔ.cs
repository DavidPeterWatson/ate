//ʕignoreʔ
using System;
using System.Linq;
using System.Collections;
using ate.Extensions;
using ate.Projects;
using ate.Definitions;

 namespace Ne1e21d8988ef4f90beef61c3124b6a0d { 
    public static class App 
    {

/*/home/david/Documents/repos/ate/templates/PlantUML/ʕAppℴDisplayʔ.puml*/

        public static String M8b246d62ff3e41ca8f3e07b86e07630e(this ate.Projects.App App)
        {
            return ((Func<String>)(() => App.Name))();
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
/*

*/

        public static IEnumerable Mcc9c0d2d890b4170ba4600152c697071(this ate.Projects.App App)
        {
            return ((Func<IEnumerable>)(() => App.Entities))();
        }


/*/home/david/Documents/repos/ate/templates/PlantUML*/

        public static String M73f832831bdf4471bc34e09c4d75d674(this ate.Projects.App App)
        {
            return ((Func<String>)(() => App.Display))();
        }

    }

    public static class Property 
    {

/*
*/

        public static String M34df343f12534738ada383f967fcccdf(this ate.Projects.Property ParentProperty)
        {
            return ((Func<String>)(() => ParentProperty.Entity.Name))();
        }


/**/

        public static Boolean Mda86e1e9b38843e58931f2d9d727d8c1(this ate.Projects.Property Property)
        {
            return ((Func<Boolean>)(() => Property.DataType == DataType.DateTime))();
        }


/**/

        public static String M45ed385ef3ba4887bbb7b846c83ccd25(this ate.Projects.Property Property)
        {
            return ((Func<String>)(() => Property.MaxLength.ToString()))();
        }


/**/

        public static String M80f08eec0df94174b5cf177c450fd006(this ate.Projects.Property Property)
        {
            return ((Func<String>)(() => Property.DataType.ToString()))();
        }


/**/

        public static Boolean Mbf8ef82f6e8e4b40bb1ea6beabcff368(this ate.Projects.Property Property)
        {
            return ((Func<Boolean>)(() => Property.IsPrimaryKey))();
        }


/**/

        public static String Mdc3a56a2880b4039a730f9237f52400a(this ate.Projects.Property Property)
        {
            return ((Func<String>)(() => Property.Name))();
        }


/*
*/

        public static String Mba068c859f4c46e3ac615e12147b99cc(this ate.Projects.Property ParentProperty)
        {
            return ((Func<String>)(() => ParentProperty.Parent.Name))();
        }


/**/

        public static Boolean M57fc4c15e9ca4d7c86a3d86155559c7e(this ate.Projects.Property Property)
        {
            return ((Func<Boolean>)(() => Property.DataType == DataType.String))();
        }

    }

    public static class Entity 
    {

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

        public static String M28f90dea55104653a9ffeadf2a6f21fd(this ate.Projects.Entity Entity)
        {
            return ((Func<String>)(() => Entity.Name))();
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

        public static String M21e12e260a11411fad8a3b49812f9781(this ate.Projects.Entity Entity)
        {
            return ((Func<String>)(() => Entity.Description))();
        }


/*)") {
    */

        public static IEnumerable M9057257f4d3f421aa13b364267c77f8b(this ate.Projects.Entity Entity)
        {
            return ((Func<IEnumerable>)(() => Entity.Properties))();
        }


/*
*/

        public static IEnumerable M0551d5a26ac844bd8c5faff0466e1e45(this ate.Projects.Entity Entity)
        {
            return ((Func<IEnumerable>)(() => Entity.ParentProperties))();
        }

    }

}