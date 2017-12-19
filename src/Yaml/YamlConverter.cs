using System;
using System.Linq;
using System.Collections.Generic;

using ate.Conversion;
using YamlDotNet.Serialization;
using System.IO;

namespace of.Yaml
{
    public class YamlConverter : IConverter
    {
        public string Name => "yaml";

        public List<string> Extensions => new List<string> { "yaml", "yml" };

        public ExportResults<T> Export<T>(T Object, string[] Parameters)
        {
            // if (Parameters.Contains("-a"))
            // {
            //     App.Autofill();
            // }
            // else
            // {
            //     App.Build();
            // }


            var serializer = new SerializerBuilder().Build();
            var yaml = serializer.Serialize(Object);
            var Destination = Parameters[0];

            var DirectoryName = Path.GetDirectoryName(Destination);
            if (!Directory.Exists(DirectoryName))
            {
                Directory.CreateDirectory(DirectoryName);
            }

            var FileName = Path.Combine(DirectoryName, Path.GetFileNameWithoutExtension(Destination) + ".yaml");

            File.WriteAllText(FileName, yaml);

            return new ExportResults<T>(Object, FileName);

        }

        public ImportResults<T> Import<T>(string[] Parameters)
        {
            string ImportFile = "";
            var Source = Parameters[0];
            FileInfo fileInfo;

            if (File.Exists(Source))
            {
                ImportFile = Source;
                fileInfo = new FileInfo(Source);
            }
            else
            {
                throw new Exception("File not found: " + Source);
            }
            // else if (Directory.Exists(Source))
            // {
            //     var DirectoryInfo = new DirectoryInfo(Source);
            //     foreach (var FileInfo in DirectoryInfo.EnumerateFiles())
            //     {
            //         if (FileInfo.Extension == ".yaml")
            //         {
            //             ImportFiles.Add(FileInfo.FullName);
            //         }
            //     }
            // }

            var ImportResults = new ImportResults<T>();

            var Deserializer = new DeserializerBuilder().Build();

            ImportResults.Result = Deserializer.Deserialize<T>(File.ReadAllText(ImportFile));
            ImportResults.FilePath = fileInfo.FullName;

            return ImportResults;

        }
    }
}