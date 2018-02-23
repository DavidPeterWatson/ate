using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace ate.Templating
{
    public class FileSegment : ISegment
    {
        public Class Class { get; set; }
        public string ClassAlias { get; set; }
        public bool OverWrite { get; set; } = true;

        public FileInfo SourceFile { get; set; }
        public List<ISegment> Segments { get; set; } = new List<ISegment>();
        public ISegment ParentSegment { get; set; }

        public string Source
        {
            get
            {
                return SourceFile.FullName;
            }
        }

        public void Render(RenderContext RenderContext)
        {
            var FileName = RenderContext.CurrentText;
            RenderContext.CurrentText = "";
            var FilePath = Path.Combine(RenderContext.CurrentDirectory, FileName);


            //if the file exists 
            //then if overwrite is true then delete and recreate otherwise leave the existing file
            if (System.IO.File.Exists(FilePath))
            {
                bool OverWriteThisFile = true;

                foreach (string line in System.IO.File.ReadLines(FilePath).Take(3))
                {
                    if (line != null && line.Contains("ʕno overwriteʔ"))
                    {
                        OverWriteThisFile = false;
                    }
                }

                if (OverWrite && OverWriteThisFile)
                {
                    System.IO.File.Delete(FilePath);
                }
                else
                {
                    return;
                }
            }


            //If the contents is templated then create a new file otherwise just copy the source file
            if (Segments.Count > 0)
            {
                if (FilePath.EndsWith(".of"))
                {
                    FilePath = FilePath.Substring(0, FilePath.Length - 3);
                }
                RenderContext.CurrentFile = "";
                foreach (var Segment in Segments)
                {
                    Segment.Render(RenderContext);
                }
                System.IO.File.WriteAllText(FilePath, RenderContext.CurrentText);
                RenderContext.CurrentText = "";
            }
            else
            {
                System.IO.File.Copy(SourceFile.FullName, FilePath, true);
            }

        }

        public string CompiledCode()
        {
            return "";
        }

    }

}