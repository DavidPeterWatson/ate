using System;
using System.Collections.Generic;

namespace ate.Templating
{
    public class Segment : ISegment
    {
        public Class Class { get; set; }
        public string ClassAlias { get; set; }
        public ISegment ParentSegment { get; set; }

        public List<ISegment> Segments { get; set; } = new List<ISegment>();

        public string Source
        {
            get
            {
                return ClassAlias;
            }
        }

        public string CompiledCode()
        {
            return "";
        }

        public void Render(RenderContext RenderContext)
        {
            foreach (var Segment in Segments)
            {
                Segment.Render(RenderContext);
            }

        }

    }

}