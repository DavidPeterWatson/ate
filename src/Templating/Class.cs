using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
//using System.Reflection;

namespace ate.Templating
{
    public class Class
    {
        public Type BaseType { get; set; }

        public ConcurrentDictionary<string, Method> Methods { get; set; } = new ConcurrentDictionary<string, Method>();
        //public List<ISegment> MethodSegments { get; set; } = new List<ISegment>();
        public Type CompiledType;

        public string CompiledCode()
        {
            string Code = "\n    public static class " + BaseType.Name + " \n    {";

            foreach (var Method in Methods.Values)
            {
                Code += Method.CompiledCode();
            }

            Code += "\n    }\n";

            return Code;
        }


        public Method FindOrCreateMethod(string MethodCode, string ClassAlias, Type ReturnType, string Source)
        {
            var Method = Methods.GetOrAdd(MethodCode, MethodFactory);
            Method.ReturnType = ReturnType;
            Method.ClassAlias = ClassAlias;
            Method.Sources.GetOrAdd(Source, Source);
            return Method;
        }

        private Method MethodFactory(string MethodCode)
        {

            var Method = new Method();
            Method.Class = this;
            Method.MethodCode = MethodCode;
            Method.MethodName = "M" + Guid.NewGuid().ToString().Replace("-", "");
            return Method;
        }

        // public object SideCast(object Object)
        // {
        //     return JsonConvert.DeserializeObject(JsonConvert.SerializeObject(Object), CompiledType);
        // }

    }

}