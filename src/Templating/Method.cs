using System;
using System.Linq;
using System.Reflection;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace ate.Templating
{
    public class Method
    {
        public string MethodName { get; set; }
        public string MethodCode { get; set; }
        public MethodInfo MethodInfo { get; set; }
        public Type ReturnType { get; set; }
        public Class Class { get; set; }

        public string ClassAlias { get; set; } = "";

        public ConcurrentDictionary<string, string> Sources { get; set; } = new ConcurrentDictionary<string, string>();


        public string CompiledCode()
        {
            if (ClassAlias == null || ClassAlias == "")
            {
                ClassAlias = Class.BaseType.Name;
            }
            if (MethodCode != "")
            {
                string code = "\n\n";
                foreach (string source in Sources.Values.ToList())
                {
                    code += "/*" + source.Replace("*", "").Replace("\\", "") + "*/\n";
                }

                code += "\n        public static " + ReturnType.Name + " " + MethodName + "(this " + Class.BaseType.FullName + " " + ClassAlias + ")\n        {\n            return ((Func<" + ReturnType.Name + ">)(() => " + MethodCode + "))();\n        }\n";

                return code;
            }
            else
            {
                return "";
            }
        }

        public bool CheckMethodInfo()
        {
            if (MethodInfo == null && MethodCode != "")
            {
                MethodInfo = Class.CompiledType.GetMethods().Where(
(FindMethod) => FindMethod.Name == MethodName || FindMethod.Name == "get_" + MethodName
).FirstOrDefault();
            }
            return MethodInfo != null;
        }

    }

}