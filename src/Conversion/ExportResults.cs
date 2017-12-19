using System.Collections.Generic;

namespace ate.Conversion
{
    public class ExportResults<T>
    {
        public T Result { get; set; }
        public string FileName { get; set; }

        public ExportResults()
        {

        }

        public ExportResults(T result, string fileName)
        {
            this.Result = result;
            this.FileName = fileName;
        }
    }
}