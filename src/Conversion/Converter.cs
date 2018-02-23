using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using ate.Extensions;

namespace ate.Conversion
{

    public static class Converter
    {
        public static ConcurrentDictionary<string, IConverter> _Converters { get; set; }// = new ConcurrentDictionary<string, IConverter>();

        public static ImportResults<T> Import<T>(string ImportType, string[] ImportParams = null)
        {
            IConverter IImporter;

            if (ImportParams == null)
            {
                ImportParams = new string[] { };
            }

            if (File.Exists(ImportType))
            {
                var ImportList = ImportParams.ToList();
                ImportList.Insert(0, ImportType);
                ImportParams = ImportList.ToArray();
                IImporter = Converter.FindByExtension(Path.GetExtension(ImportType).Replace(".", ""));
            }
            else
            {
                IImporter = Converter.Find(ImportType);
            }


            var Results = IImporter.Import<T>(ImportParams);

            // foreach (var Result in Results.Results)
            // {
            //     Result.App.SourceFilePath = Result.FileName;
            // }

            return Results;
        }

        public static void Convert<T>(string ImporterName, string[] ImportParams, string ExporterName, string[] ExportParams)
        {

            var ImportResults = Import<T>(ImporterName, ImportParams);

            IConverter IExporter = Converter.Find(ExporterName);

            IExporter.Export(ImportResults.Result, ExportParams);

        }

        public static IConverter Find(string Name)
        {

            IConverter value;
            Converters.TryGetValue(Name, out value);
            return value;

        }

        public static IConverter FindByExtension(string Extension)
        {

            var ConverterQuery = from FindConverter in Converters
                                 where FindConverter.Value.Extensions.Contains(Extension)
                                 select FindConverter.Value;

            return ConverterQuery.FirstOrDefault();

        }


        public static ConcurrentDictionary<string, IConverter> Converters
        {
            get
            {
                if (_Converters == null)
                {

                    _Converters = new ConcurrentDictionary<string, IConverter>();

                    string filePath = new Uri(System.Reflection.Assembly.GetExecutingAssembly().CodeBase).LocalPath;
                    var Dir = Path.GetDirectoryName(filePath);

                    var DirectoryInfo = new System.IO.DirectoryInfo(Dir);

                    foreach (var FileInfo in DirectoryInfo.EnumerateFiles())
                    {

                        if (FileInfo.Extension == ".dll")
                        //if (FileInfo.Name.ToLower() == SourceType + ".dll")
                        {
                            try
                            {
                                //var Assembly = System.Reflection.Assembly.LoadFrom(FileInfo.FullName);
                                var Assembly = System.Runtime.Loader.AssemblyLoadContext.Default.LoadFromAssemblyPath(FileInfo.FullName);

                                var Types = Assembly.GetExportedTypes();

                                var TypeQuery =
                                from System.Type FindType in Types
                                where FindType.Implements<IConverter>()
                                select FindType;

                                var ConverterType = TypeQuery.FirstOrDefault();

                                if (ConverterType != null)
                                {
                                    //var ConverterInstance = Activator.CreateInstance(typeof(IConverter<T>)) as IConverter<T>;
                                    var ConverterInstance = Activator.CreateInstance(ConverterType) as IConverter;
                                    _Converters.TryAdd(ConverterInstance.Name, ConverterInstance);
                                }

                            }
                            catch (Exception)
                            { }
                        }
                    }

                }
                return _Converters;

            }
        }

        // public static IConverter ConverterFactory(string SourceType)
        // {
        //     string filePath = new Uri(System.Reflection.Assembly.GetExecutingAssembly().CodeBase).LocalPath;
        //     var Dir = Path.GetDirectoryName(filePath);

        //     var DirectoryInfo = new System.IO.DirectoryInfo(Dir);

        //     SourceType = SourceType.ToLower();

        //     foreach (var FileInfo in DirectoryInfo.EnumerateFiles())
        //     {

        //         if (FileInfo.Extension == ".dll")
        //         //if (FileInfo.Name.ToLower() == SourceType + ".dll")
        //         {
        //             try
        //             {
        //                 //var Assembly = System.Reflection.Assembly.LoadFrom(FileInfo.FullName);
        //                 var Assembly = System.Runtime.Loader.AssemblyLoadContext.Default.LoadFromAssemblyPath(FileInfo.FullName);

        //                 var Types = Assembly.GetExportedTypes();

        //                 var TypeQuery =
        //                 from System.Type FindType in Types
        //                 where FindType.Implements<IConverter>()
        //                 select FindType;

        //                 var ConverterType = TypeQuery.FirstOrDefault();


        //                 var ConverterInstance = Activator.CreateInstance(ConverterType);
        //                 return (IConverter)ConverterInstance;

        //             }
        //             catch (Exception)
        //             { }
        //         }
        //     }
        //     return null;
        // }


    }
}