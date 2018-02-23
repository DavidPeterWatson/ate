using System;
using System.IO;
using ate.Conversion;
using ate.Extensions;

namespace ate.Projects
{
    public class Project
    {
        public string Name { get; set; } = "";
        public string Description { get; set; }
        public string Template { get; set; }
        public string Destination { get; set; } = "";
        public App App { get; set; }
        public string FilePath { get; set; }


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
        public string name
        {
            get
            {
                return Name.ToLower();
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

        public static Project Open(string fileName)
        {

            IConverter IImporter = Converter.Find("yaml");

            var Results = IImporter.Import<Project>(new string[] { fileName });

            Results.Result.FilePath = Results.FilePath;

            return Results.Result;
        }

        public static void Build(string fileName)
        {
            //Import Apps
            var project = Open(fileName);
            project.Build();

        }

        public void Build()
        {
            //Import Apps
            //Build Apps
            var templateFolder = Path.GetFullPath(Path.Combine(Path.GetDirectoryName(FilePath), Template));
            ate.Templating.Template template = ate.Templating.Template.Compile(templateFolder, typeof(App));
            Destination = Path.GetFullPath(Path.Combine(Path.GetDirectoryName(FilePath), Destination));

            App.Project = this;
            App.Build();
            template.Render(App, Destination);

        }

    }
}