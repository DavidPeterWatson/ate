using System.Collections.Generic;
using System.IO;
using ate.Definitions;
using ate.Extensions;

namespace ate.Projects
{
    public class Module : ate.Definitions.Module
    {

        public App App { get; set; }
        new public List<Entity> Entities { get; set; }

        public Module(ate.Definitions.Module baseModule)
        {
            this.Import(baseModule);
        }

        public string FullName
        {
            get
            {
                if (App != null)
                {
                    if (Name == "")
                    {
                        return App.FullName;
                    }
                    else
                    {
                        return App.FullName + "." + Name;
                    }
                }
                else
                {
                    return Name;
                }
            }
        }

        public string LowerCaseName
        {
            get
            {
                return Name.ToLower();
            }
        }

        public void Build()
        {
            Load();

            if (Entities != null)
            {
                foreach (var Entity in Entities)
                {
                    Entity.Module = this;
                    Entity.Build();
                }
            }
        }

        //If Module has a filename specified then load that file into module
        public void Load()
        {
            if ((FileName ?? "") != "" && (Name ?? "") == "")
            {
                FileName = Path.GetFullPath(Path.Combine(Path.GetDirectoryName(App.FileName), FileName));
                var Results = ate.Conversion.Converter.Import<ate.Definitions.Module>(FileName);
                Import(Results.Result);
            }
        }

        public void Import(ate.Definitions.Module sourceModule)
        {

            this.Map(sourceModule);

            if (sourceModule.Entities != null)
            {
                foreach (var baseEntity in sourceModule.Entities)
                {
                    if (Entities == null) { Entities = new List<Entity>(); }

                    Entities.Add(new Entity(baseEntity));
                }
            }
        }

        public void PostBuild()
        {

            foreach (var Entity in Entities)
            {
                Entity.PostBuild();
            }

        }
    }
}