namespace ate.Conversion
{
    public class Result<T>
    {
        public T Object { get; set; }
        public string FileName { get; set; }


        public Result()
        {

        }

        public Result(T Object, string FileName)
        {
            this.Object = Object;
            this.FileName = FileName;
        }
    }
}