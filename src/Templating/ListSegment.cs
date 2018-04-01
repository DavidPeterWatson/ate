using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
//using System.Reflection;

namespace ate.Templating
{
    public class ListSegment : ISegment
    {
        public string StaticText { get; set; }
        public Method Method { get; set; }
        public ISegment ParentSegment { get; set; }

        // public string MethodName { get; set; }
        // public string MethodCode { get; set; }
        // public MethodInfo MethodInfo { get; set; }

        public Class Class { get; set; }
        public string ClassAlias { get; set; }

        public Class ParentClass { get; set; }

        public List<ISegment> Segments { get; set; } = new List<ISegment>();

        public string Source
        {
            get
            {
                var source = "";
                if (ParentSegment != null)
                {
                    source += ParentSegment.Source;
                }
                if (Method?.MethodCode != null)
                {
                    source += " " + Method.MethodCode.Replace("*/", "");
                }
                return source;
            }
        }

        public void Render(RenderContext RenderContext)
        {
            var PreviousRenderObject = RenderContext.CurrentObject;

            RenderContext.CurrentText += StaticText;

            Method.CheckMethodInfo();

            var Children = (IEnumerable)(Method.MethodInfo.Invoke(RenderContext.CurrentObject, new object[] { RenderContext.CurrentObject }));
            if (Children != null)
            {
                foreach (var Child in Children)
                {
                    //var CastChild = Class.SideCast(Child);
                    //RenderContext.CurrentObject = CastChild;
                    RenderContext.CurrentObject = Child;
                    foreach (var Segment in Segments)
                    {
                        Segment.Render(RenderContext);
                    }
                }
                RenderContext.CurrentObject = PreviousRenderObject;
            }
        }

    }

}