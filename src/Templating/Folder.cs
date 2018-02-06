using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;

namespace ate.Templating
{
    /// <summary>
    /// Renames a folder
    /// </summary>
    public static class Folder
    {

        //Processes Folder name and then sub folders and then sub files
        internal static FolderSegment Compile(CompileContext CompileContext, DirectoryInfo DirectoryInfo)
        {

            var PreviousTopSegment = CompileContext.Stack.Peek();
            
            Text.Compile(CompileContext, DirectoryInfo.Name);

            var FolderSegment = new FolderSegment();
            FolderSegment.SourceDirectory = DirectoryInfo;

            var TopSegment = CompileContext.Stack.Peek();
            TopSegment.Segments.Add(FolderSegment);
            FolderSegment.Class = TopSegment.Class;


            FolderSegment.OverWrite = false;

            // if (DirectoryInfo.Name.ContainsTags(Template.Tags, "overwrite false"))
            // {
            //     FolderSegment.OverWrite = false;
            // }
            // else
            // {
            //     FolderSegment.OverWrite = true;
            // }

            CompileContext.Stack.Push(FolderSegment);

//Check for ate ignore file
            foreach (var ChildFile in DirectoryInfo.GetFiles("*.ateignore"))
            {
                foreach (var line in System.IO.File.ReadLines(ChildFile.FullName))
                {
                    if (!line.StartsWith("#") && line != "")
                    {
                        CompileContext.Template.IgnoreMasks.Add(line);
                    }
                }
            }

            //var DirectoryInfo = new DirectoryInfo(Source);
            foreach (var ChildDirectory in DirectoryInfo.GetDirectories())
            {
                bool ignoreDirectory = false;
                foreach (var ignoreMask in CompileContext.Template.IgnoreMasks)
                {
                    if ((ChildDirectory.FullName + "/").FitsMask(ignoreMask))
                    {
                        ignoreDirectory = true;
                        break;
                    }
                }
                if (!ignoreDirectory)
                {
                    Compile(CompileContext, ChildDirectory);
                }
            }

            foreach (var ChildFile in DirectoryInfo.GetFiles())
            {
                bool ignoreFile = false;
                foreach (var ignoreMask in CompileContext.Template.IgnoreMasks)
                {
                    if (ChildFile.FullName.FitsMask(ignoreMask))
                    {
                        ignoreFile = true;
                        break;
                    }
                }
                if (!ignoreFile)
                {
                    File.Compile(CompileContext, ChildFile);
                }
            }

            while (CompileContext.Stack.Peek() != PreviousTopSegment)
            {
                CompileContext.Stack.Pop();
            }

            return FolderSegment;
        }


    }
}