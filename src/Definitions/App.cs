using System;
using System.Collections.Generic;
using ate.Extensions;
using System.Linq;

namespace ate.Definitions
{
    public class App
    {
        public string Display { get; set; } = "";
        public string Guid { get; set; } = "";
        public string NamePrefix { get; set; }
        public string Name { get; set; } = "";
        public string Version { get; set; }
        public string ImageKey { get; set; }
        public string Description { get; set; }
        public string Company { get; set; }


        public List<Feature> Features { get; set; }
        public List<Edition> Editions { get; set; }
        public List<Module> Modules { get; set; }



        public App()
        {

        }

        public App(string Display, string Guid = "", string Name = "")
        {
            if (Guid == "")
            {
                Guid = System.Guid.NewGuid().ToString();
            }
            this.Display = Display;
            this.Guid = Guid;
            this.Name = Name;

        }

        // public Module AddModule(string DisplayName, string Guid = "")
        // {
        //     var Module = new Module(DisplayName, Guid, this);
        //     Modules.Add(Module);
        //     return Module;

        // }

        public void Autofill()
        {
            if (Guid == null || Guid == "")
            {
                Guid = System.Guid.NewGuid().ToString();
            }
            Guid = Guid.ToLower();
            if (Name == null || Name == "")
            {
                Name = Display.CodeName();
            }
            foreach (var Module in Modules ?? Enumerable.Empty<Module>())
            {
                Module.Autofill();
            }
            // foreach (var Feature in Features ?? Enumerable.Empty<Feature>())
            // {
            //     Feature.Autofill();
            // }
            // foreach (var Edition in Editions ?? Enumerable.Empty<Edition>())
            // {
            //     Edition.Autofill();
            // }

        }






        // public Feature FindFeature(FeatureReference FeatureReference)
        // {

        //     var FeatureQuery =
        //         from FindFeature in Features
        //         where FindFeature.Name == FeatureReference.Name ||
        //         FindFeature.Guid == FeatureReference.Guid
        //         select FindFeature;

        //     return FeatureQuery.FirstOrDefault();

        // }

    }

}