using System;
using System.Collections.Generic;

namespace ate.Templating
{
    public class RenderContext
    {

        public object CurrentObject { get; set; }
        public string CurrentDirectory { get; set; }
        public string CurrentFile { get; set; }
        public string CurrentText { get; set; }

    }

    public class CompileContext
    {
        // public Class Class { get; set; }
        public Template Template { get; set; }
        //public Type Type { get; set; }
        public Stack<ISegment> Stack = new Stack<ISegment>();

        //public ISegment TopSegment { get; set; }

    }

}