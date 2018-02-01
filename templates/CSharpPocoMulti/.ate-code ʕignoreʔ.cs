//ʕignoreʔ
using System;
using System.Linq;
using System.Collections;
using ate.Extensions;
using ate.Projects;
using ate.Definitions;

 namespace Ne9da862bd6ed4c80abd0215319444e5b { 
    public static class App 
    {

/**/

        public static IEnumerable M2a962840843e43e98b5c4fdd5c2ceba7(this ate.Projects.App App)
        {
            return ((Func<IEnumerable>)(() => App.Entities))();
        }


/*/home/david/Documents/repos/ate/templates/CSharpPocoMulti*/

        public static String M6650b896fa834c1baf4e9754c26dbc0c(this ate.Projects.App App)
        {
            return ((Func<String>)(() => App.Display))();
        }

    }

    public static class Property 
    {

/*
    {

        //*/

        public static String Mb4ef5161192e49249568c1c3d370dd9e(this ate.Projects.Property Property)
        {
            return ((Func<String>)(() => Property.CSharp()))();
        }


/*
    {

        //*/

        public static String M3a7df61cc80f4278b310774d3645a2e4(this ate.Projects.Property Property)
        {
            return ((Func<String>)(() => Property.Name))();
        }

    }

    public static class Entity 
    {

/*
    {

        //*/

        public static IEnumerable Mdeb8de99fbab4203a4b4ad90f6b7b37e(this ate.Projects.Entity Entity)
        {
            return ((Func<IEnumerable>)(() => Entity.Properties))();
        }


/**/
/*/home/david/Documents/repos/ate/templates/CSharpPocoMulti/ʕAppℴDisplayʔ Models/ʕfor each Entity in AppℴEntitiesʔʕEntityℴNameʔ.cs*/

        public static String Me2c0f2fd42324d1e9ad446e6d1b9bd95(this ate.Projects.Entity Entity)
        {
            return ((Func<String>)(() => Entity.Name))();
        }


/*/home/david/Documents/repos/ate/templates/CSharpPocoMulti/ʕAppℴDisplayʔ Models/ʕfor each Entity in AppℴEntitiesʔʕEntityℴNameʔ.cs*/

        public static String Mf4608ca2201a42a787f58f02c0a7204a(this ate.Projects.Entity Entity)
        {
            return ((Func<String>)(() => Entity.App.FullName))();
        }

    }

}