﻿using System;
using System.Collections.Generic;
using ate.Extensions;

namespace ate
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {

                if (args.Length == 0 || args[0] == "-h")
                {
                    Console.WriteLine("ate -i ImportType ImportParameters -e ExportType Export Parameters");
                    return;
                }
                else if (args[0] == "-v")
                {
                    Console.WriteLine("ate version " + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString());
                    return;
                }
                else if (args[0] == "-l")
                {
                    foreach (var Converter in ate.Conversion.Converter.Converters)
                    {
                        Console.WriteLine(Converter);
                    }
                    return;
                }
                else if (args[0] == "-i")
                {

                    string ImportType = args[1];
                    var ImportParameters = new List<string>();

                    var index = 2;
                    while (args[index] != "-e" && index < args.Length)
                    {
                        ImportParameters.Add(args[index]);
                        index += 1;
                    }
                    index += 1;

                    string ExportType = args[index];
                    var ExportParameters = new List<string>();

                    for (var i = index + 1; i < args.Length; i++)
                    {
                        ExportParameters.Add(args[i]);
                    }

                    ate.Conversion.Converter.Convert<ate.Definitions.App>(ImportType, ImportParameters.ToArray(), ExportType, ExportParameters.ToArray());
                }
                else if (args[0] == "-t")
                {
                    //Pass arguments to templating engine
                    ate.Projects.Project.Build(args[1]);
                }

            }
            catch (Exception Exception)
            {
                Console.WriteLine(Exception.FullMessage());
            }
        }


    }
}