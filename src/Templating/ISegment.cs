using System.Collections.Generic;

namespace ate.Templating
{
    public interface ISegment
    {

        ISegment ParentSegment { get; set; }
        List<ISegment> Segments { get; set; }

        //string CompiledCode();

        void Render(RenderContext RenderContext);

        Class Class { get; set; }
        //Method Method { get; set; }
        string ClassAlias { get; set; }

        string Source { get; }

    }

}