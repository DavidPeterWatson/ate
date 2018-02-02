using System;
using System.Collections.Generic;
using System.Collections;
using System.Reflection;
using System.IO;

using ate.Extensions;
using System.Linq;

namespace ate.Templating
{

    public enum SegmentType
    {
        None,
        Text,
        Enumerator,
        Folder,
        File,
        FileContents,

    }

    public class TextSegment : ISegment
    {
        //public Type Type { get; set; }

        public Class Class { get; set; }
        // public Class SubClass { get; set; }
        public string ClassAlias { get; set; }
        public ISegment ParentSegment { get; set; }
        public string StaticText { get; set; }
        public Method Method { get; set; }
        //public string MethodName { get; set; }
        //public string MethodCode { get; set; }
        //        public MethodInfo MethodInfo { get; set; }

        public TextSegment(ISegment parentSegment)
        {
            this.ParentSegment = parentSegment;
        }
        public string Source
        {
            get
            {
                var source = "";
                if (ParentSegment != null)
                {
                    source += ParentSegment.Source ;
                }
                if(Method?.MethodCode != null)
                {
                    source += " " + Method.MethodCode.Replace("*/", "");
                }
                return source;
            }
        }

        public List<ISegment> Segments { get; set; } = new List<ISegment>();


        public void Render(RenderContext RenderContext)
        {

            RenderContext.CurrentText += StaticText;

            if (Method != null)
            {
                Method.CheckMethodInfo();
                if (Method.MethodInfo != null)
                {
                    var TextResult = Method.MethodInfo.Invoke(RenderContext.CurrentObject, new object[] { RenderContext.CurrentObject });
                    if (TextResult != null)
                    {
                        RenderContext.CurrentText += TextResult.ToString();
                    }
                }
            }

            foreach (var Segment in Segments)
            {
                Segment.Render(RenderContext);
            }


        }


        // public string CompiledCode()
        // {
        //     if (MethodCode != "")
        //     {
        //         return "\n  public string " + MethodName + "\n{get\n  { \n   return ((Func<string>)(() => " + MethodCode + "))();\n  }\n} \n";
        //     }
        //     else
        //     {
        //         return "";
        //     }
        // }

    }

}