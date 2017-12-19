using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;


using ExtendedXmlSerialization;
using ate.Extensions;
using ate.Conversion;


namespace of.Xml
{
    public class XmlConverter : IConverter
    {
        public string Name => "xml";

        public List<string> Extensions => new List<string> { "xml" };

        public ExportResults<T> Export<T>(T Object, string[] Parameters)
        {
            try
            {
                var Destination = Parameters[0];

                string DirectoryName;
                string FileName;


                if (Destination.EndsWith(".xml"))
                {
                    DirectoryName = Path.GetDirectoryName(Destination);
                    FileName = Path.Combine(DirectoryName, Path.GetFileNameWithoutExtension(Destination) + ".xml");
                }
                else
                {
                    DirectoryName = Destination;
                    FileName = Path.Combine(DirectoryName, Object.ToString().CodeName() + ".xml");
                }

                if (!Directory.Exists(DirectoryName))
                {
                    Directory.CreateDirectory(DirectoryName);
                }

                var ExtendedXmlSerializer = new ExtendedXmlSerializer();
                var xml = ExtendedXmlSerializer.Serialize(Object);

                File.WriteAllText(FileName, xml);

                return new ExportResults<T>(Object, FileName);

            }
            catch (Exception Exception)
            {
                throw Exception;
            }
        }

        public ImportResults<T> Import<T>(string[] Parameters)
        {
            string ImportFile = "";

            var Source = Parameters[0];
            if (File.Exists(Source))
            {
                ImportFile = Source;
            }
            // else if (Directory.Exists(Source))
            // {
            //     var DirectoryInfo = new DirectoryInfo(Source);
            //     foreach (var FileInfo in DirectoryInfo.EnumerateFiles())
            //     {
            //         if (FileInfo.Extension == ".xml")
            //         {
            //             ImportFiles.Add(FileInfo.FullName);
            //         }
            //     }
            // }


            var ExtendedXmlSerializer = new ExtendedXmlSerializer();
            string ImportXml = File.ReadAllText(ImportFile);

            var ImportResults = new ImportResults<T>();

            ImportResults.Result = ExtendedXmlSerializer.Deserialize<T>(ImportXml);

            return ImportResults;

        }
    }
}