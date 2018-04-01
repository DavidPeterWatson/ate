using System;
using System.Collections.Generic;
using System.Linq;
//using System.Reflection;

namespace ate.Templating
{
    public class IfSegment : ISegment
    {
        public Class Class { get; set; }
        public string ClassAlias { get; set; }
        public ISegment ParentSegment { get; set; }

        public string StaticText { get; set; }
        public Method Method { get; set; }
        ///public MethodInfo MethodInfo { get; set; }
        //public string MethodName { get; set; }
        //public string MethodCode { get; set; }
        public List<ISegment> Segments { get; set; } = new List<ISegment>();
        public ISegment ElseSegment { get; set; }

        public string Source
        {
            get
            {
                return StaticText;
            }
        }

        public void Render(RenderContext RenderContext)
        {

            RenderContext.CurrentText += StaticText;

            if (Method?.CheckMethodInfo() == true)
            {
                var BoolResult = Method.MethodInfo.Invoke(RenderContext.CurrentObject, new object[] { RenderContext.CurrentObject });
                if (BoolResult != null && BoolResult.Equals(true))
                {
                    foreach (var Segment in Segments)
                    {
                        Segment.Render(RenderContext);
                    }
                }
                else
                {
                    ElseSegment?.Render(RenderContext);
                }
            }
        }
    }
}