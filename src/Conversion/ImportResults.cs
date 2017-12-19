using System.Collections.Generic;

namespace ate.Conversion
{
    public class ImportResults<T>
    {
        public T Result { get; set; }
        public string FilePath { get; set; }

        public ImportResults()
        {

        }

        public ImportResults(T Result)
        {
            this.Result = Result;
        }
    }
}