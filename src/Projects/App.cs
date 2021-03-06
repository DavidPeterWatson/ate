using System.Collections.Generic;
using System.IO;
using System.Linq;
using ate.Conversion;
using ate.Definitions;
using ate.Extensions;

namespace ate.Projects
{
    public class App : ate.Definitions.App
    {

        public Project Project { get; set; }
        public string FileName { get; set; }
        public new List<Module> Modules { get; set; }
        public new List<Feature> Features { get; set; }
        //public string SourceFilePath { get; set; }

        public string FullName
        {
            get
            {
                if ((NamePrefix ?? "") == "")
                {
                    return Name;
                }
                else
                {
                    return NamePrefix + "." + Name;
                }
            }
        }

        public string name
        {
            get
            {
                return Name.ToLower();
            }
        }

        public string NAME
        {
            get
            {
                return Name.ToUpper();
            }
        }

        public string naMe
        {
            get
            {
                return Name.ToCamelCase();
            }
        }

        public string na_me
        {
            get
            {
                return Name.ToUnderscoreCase();
            }
        }

        public string hyphenname
        {
            get
            {
                return Name.ToHyphenCase();
            }
        }

        public List<Entity> Entities
        {
            get
            {
                var Entities = new List<Entity>();
                if (Modules != null)
                {
                    foreach (var Module in Modules)
                    {
                        Entities.AddRange(Module.Entities);
                    }
                }
                return Entities;
            }
        }

        public void Build()
        {

            //ToDo Find Referenced Applications
            //LoadReferences();
            Load();

            if (Modules != null)
            {
                foreach (var Module in Modules)
                {
                    Module.App = this;
                    Module.Build();
                }
            }

            if (Features != null)
            {
                foreach (var Feature in Features)
                {
                    Feature.App = this;
                    Feature.Build();
                }
            }

            PostBuild();

        }

        // public void LoadReferences()
        // {
        //     if (Modules != null)
        //     {
        //         foreach (var Module in Modules ?? Enumerable.Empty<Module>())
        //         {

        //             Module.Load();

        //         }
        //     }
        // }

        /// <summary>
        /// Imports a reference to a file
        /// </summary>
        public void Load()
        {
            if ((FileName ?? "") != "" && (Name ?? "") == "")
            {
                IConverter IImporter = Converter.Find("yaml");
                FileName = Path.GetFullPath(Path.Combine(Path.GetDirectoryName(Project.FilePath), FileName));

                var Results = IImporter.Import<ate.Definitions.App>(new string[] { FileName });
                Import(Results.Result);

            }
        }

        public void Import(ate.Definitions.App sourceApp)
        {
            this.Map(sourceApp);
            if (sourceApp.Modules != null)
            {
                foreach (var sourceModule in sourceApp.Modules)
                {
                    if (Modules == null) { Modules = new List<Module>(); }
                    Modules.Add(new Module(sourceModule));
                }
            }
        }

        private void PostBuild()
        {
            if (Modules != null)
            {
                foreach (var Module in Modules)
                {
                    Module.PostBuild();
                }
            }
        }

        public Feature FindFeature(string FeatureName)
        {
            var FeatureQuery =
                from FindFeature in Features
                where FindFeature.Name == FeatureName
                select FindFeature;

            return FeatureQuery.FirstOrDefault();

        }
    }
}