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



            //var DirectoryInfo = new DirectoryInfo(Source);
            foreach (var ChildDirectory in DirectoryInfo.GetDirectories())
            {
                bool ignoreDirectory = false;
                string fullname = ChildDirectory.FullName.Replace("\\", "/");
                foreach (var ignoreMask in CompileContext.Template.IgnoreMasks)
                {
                    if ((fullname + "/").FitsMask(ignoreMask))
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
                string fullname = ChildFile.FullName.Replace("\\", "/");
                foreach (var ignoreMask in CompileContext.Template.IgnoreMasks)
                {
                    if (fullname.FitsMask(ignoreMask))
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