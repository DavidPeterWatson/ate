using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;

namespace ate.Templating
{
    /// <summary>
    /// Renames a folder
    /// </summary>
    public class FolderSegment : ISegment
    {
        public Class Class { get; set; }
        public string ClassAlias { get; set; }
        public bool OverWrite { get; set; } = true;
        public bool IsTopLevel { get; set; } = false;
        public ISegment ParentSegment { get; set; }

        public DirectoryInfo SourceDirectory { get; set; }
        public List<ISegment> Segments { get; set; } = new List<ISegment>();

        public string Source
        {
            get
            {
                return SourceDirectory.FullName;
            }
        }


        /// <summary>
        /// Creates a directory and renames it according to current Text of Context
        /// </summary>
        /// <param name="RenderContext"></param>
        /// <returns></returns>
        public void Render(RenderContext RenderContext)
        {

            var PreviousRenderObject = RenderContext.CurrentObject;
            var PreviousDirectory = RenderContext.CurrentDirectory;

            string NewDirectory;
            if (IsTopLevel)
            {
                NewDirectory = RenderContext.CurrentDirectory;
            }
            else
            {
                NewDirectory = Path.Combine(RenderContext.CurrentDirectory, RenderContext.CurrentText);
            }

            DirectoryInfo DirectoryInfo;

            if (!Directory.Exists(NewDirectory))
            {
                DirectoryInfo = Directory.CreateDirectory(NewDirectory);
            }
            else if (OverWrite)
            {
                Directory.Delete(NewDirectory, true);
                DirectoryInfo = Directory.CreateDirectory(NewDirectory);
            }
            else
            {
                DirectoryInfo = new DirectoryInfo(NewDirectory);
            }

            RenderContext.CurrentDirectory = DirectoryInfo.FullName;
            RenderContext.CurrentFile = "";
            RenderContext.CurrentText = "";

            foreach (var Segment in Segments)
            {
                Segment.Render(RenderContext);
            }

            RenderContext.CurrentObject = PreviousRenderObject;
            RenderContext.CurrentDirectory = PreviousDirectory;
        }

        public string CompiledCode()
        {
            return "";
        }
    }

}