using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using ate.Extensions;

namespace ate.Templating
{
    internal class File
    {


        //public const string TemplateFileExtension = ".ate";

        //ToDo Move this to a config file in a project folder
        //public static List<string> AutoTemplateExtensions = new List<string> { "*.cs", "*.sln", "*.csproj", "*.html", "*.js", "*.ts", "*.json", "*.cshtml", "*.wsd", "*.puml", "*.project", "*.java" , "*.sql" , "*.yaml", "*.xml", "*.yml", "*.md", "*.txt", "*.name"};

        internal static void Compile(CompileContext CompileContext, FileInfo FileInfo)
        {

            var FileName = FileInfo.Name;


            if (FileName.StartsWithTags(Template.Tags, "inject ", out var Tag))
            {
                var InjectionName = FileName.Substring(Tag.Key.Length + 7);
                InjectionName = InjectionName.Substring(0, InjectionName.IndexOf(Tag.Value));
                var CodeSegment = CompileContext.Template.FindOrCreateCodeSegment(InjectionName);
                CodeSegment.Code = FileInfo.ReadAllText();
            }
            else if (FileName.ContainsTags(Template.Tags, "ignore"))
            {
                //Do nothing
            }
            else
            {
                var PreviousTopSegment = CompileContext.Stack.Peek();
                Text.Compile(CompileContext, FileName);

                var FileSegment = new FileSegment();
                FileSegment.SourceFile = FileInfo;
                var TopSegment = CompileContext.Stack.Peek();

                TopSegment.Segments.Add(FileSegment);
                FileSegment.Class = TopSegment.Class;

                if (FileName.ContainsTags(Template.Tags, "no overwrite"))
                {
                    FileSegment.OverWrite = false;
                }
                else
                {
                    FileSegment.OverWrite = true;
                }

                if (FileInfo.Name.FitsMasks(CompileContext.Template.CompileMasks.ToList()))
                {
                    CompileContext.Stack.Push(FileSegment);
                    Text.Compile(CompileContext, System.IO.File.ReadAllText(FileInfo.FullName));
                }

                while (CompileContext.Stack.Peek() != PreviousTopSegment)
                {
                    CompileContext.Stack.Pop();
                }
            }

        }

    }

}