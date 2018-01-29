using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using ate.Extensions;

namespace ate.Templating
{
    internal static class Text
    {

        /// <summary>
        /// Adds text and enum segments to Context
        /// </summary>
        /// <param name="CompileContext"></param>
        /// <param name="SourceText"></param>
        internal static void Compile(CompileContext CompileContext, string SourceText)
        {

            var bits = SourceText.Split(Template.Tags.Values.ToArray(), StringSplitOptions.None);
            foreach (var bit in bits)
            {

                string StaticText;
                string Code;
                //string Name;
                var TopSegment = CompileContext.Stack.Peek();

                int Opening = bit.IndexOfTags(Template.Tags, out var Tag);
                if (Opening > -1)
                {
                    StaticText = bit.Substring(0, Opening);
                    Code = bit.Substring(Opening + Tag.Key.Length);
                    Code = Code.Trim();
                    if (Code.IndexOf(Tag.Key) >= 0)
                    {
                        throw new Exception("template syntax error in " + SourceText + " at position " + SourceText.IndexOf(bit) + ": " + bit);
                    }
                    //Name = "M" + Guid.NewGuid().ToString().Replace("-", "");
                }
                else
                {
                    StaticText = bit;
                    Code = "";
                    //Name = "";
                }

                StaticText = StaticText.Replace("App_FullCodeName", "App.FullCodeName");
                Code = Code.Replace("_", ".");
                Code = Code.Replace("ʢ", "(");
                Code = Code.Replace("ʡ", ")");
                Code = Code.Replace("ℴ", ".");


                if (Code.Length > 9 && Code.Substring(0, 9) == "for each ")
                {

                    var ListSegment = new ListSegment();
                    //ListSegment.MethodName = Name;
                    ListSegment.StaticText = StaticText;

                    Code = Code.Substring(9);
                    var Alias = "";
                    var SubTypeName = "";
                    var AsIndex = Code.IndexOf(" as ");
                    if (AsIndex >= 0)
                    {
                        SubTypeName = Code.Substring(0, AsIndex);
                        Alias = Code.Substring(AsIndex + 4, Code.IndexOf(" in ", AsIndex) - AsIndex - 4);
                    }
                    else
                    {
                        SubTypeName = Code.Substring(0, Code.IndexOf(" in "));
                        Alias = SubTypeName;
                    }
                    Code = Code.Substring(Code.IndexOf(" in ") + 4);

                    // Code = Code.Substring(9);
                    // var SubTypeName = Code.Substring(0, Code.IndexOf(" in "));
                    // Code = Code.Substring(Code.IndexOf("in") + 3);
                    ListSegment.ParentClass = TopSegment.Class;
                    var Type = ListSegment.ParentClass.BaseType.Assembly.ExportedTypes.Where(
                        (FindType) => FindType.Name == SubTypeName
                        ).FirstOrDefault();
                    if (Type == null)
                    {
                        throw new System.Exception("Type not found for " + SubTypeName);
                    }
                    ListSegment.Class = CompileContext.Template.FindOrCreateClass(Type);

                    //ListSegment.ParentClass.MethodSegments.Add(ListSegment);
                    ListSegment.Method = ListSegment.ParentClass.FindOrCreateMethod(Code, TopSegment.ClassAlias, typeof(System.Collections.IEnumerable));
                    ListSegment.ClassAlias = Alias;
                    TopSegment.Segments.Add(ListSegment);
                    CompileContext.Stack.Push(ListSegment);

                }
                else if (Code.Length >= 3 && Code.Substring(0, 3) == "if ")
                {

                    var IfSegment = new IfSegment();

                    IfSegment.StaticText = StaticText;
                    Code = Code.Substring(3);
                    IfSegment.Class = TopSegment.Class;
                    IfSegment.Method = IfSegment.Class.FindOrCreateMethod(Code, TopSegment.ClassAlias, typeof(bool));

                    TopSegment.Segments.Add(IfSegment);
                    CompileContext.Stack.Push(IfSegment);

                }
                else if (Code.Length >= 8 && Code.Substring(0, 8) == "else if ")
                {
                    var TextSegment = new TextSegment();
                    TextSegment.StaticText = StaticText;
                    TopSegment.Segments.Add(TextSegment);

                    var ElseIfSegment = new IfSegment();

                    ElseIfSegment.StaticText = "";
                    Code = Code.Substring(8);
                    ElseIfSegment.Class = TopSegment.Class;
                    ElseIfSegment.Method = ElseIfSegment.Class.FindOrCreateMethod(Code, TopSegment.ClassAlias, typeof(bool));

                    //TopSegment.Segments.Add(ElseIfSegment);
                    ((IfSegment)TopSegment).ElseSegment = ElseIfSegment;
                    CompileContext.Stack.Push(ElseIfSegment);

                }
                else if (Code == "else")
                {
                    var TextSegment = new TextSegment();
                    TextSegment.StaticText = StaticText;
                    TopSegment.Segments.Add(TextSegment);


                    var ElseSegment = new TextSegment();

                    ElseSegment.StaticText = "";

                    ElseSegment.Class = TopSegment.Class;

                    //TopSegment.Segments.Add(ElseSegment);
                    ((IfSegment)TopSegment).ElseSegment = ElseSegment;
                    CompileContext.Stack.Push(ElseSegment);


                }
                else if (Code.Length >= 9 && Code.Substring(0, 9) == "overwrite")
                {

                    Code = "";

                }
                else if (Code.Length > 7 && Code.Substring(0, 7) == "inject ")
                {

                    var InjectionName = Code.Substring(7);
                    var NamePosition = InjectionName.IndexOf(" ");
                    var InjectionCode = InjectionName.Substring(NamePosition);
                    InjectionName = InjectionName.Substring(0, NamePosition);
                    var CodeSegment = CompileContext.Template.FindOrCreateCodeSegment(InjectionName);
                    CodeSegment.Code = InjectionCode;

                }
                else
                {
                    if (Code.Length >= 4 && Code.Substring(0, 4) == "next")
                    {
                        CompileContext.Stack.Pop();
                        //TopSegment = CompileContext.Stack.Peek();
                        //ToDo Check that next type matches current for each 
                        // if (!ListSegement.GetType().IsAssignableFrom(typeof(ListSegement)))
                        // {
                        //     throw new Exception("for each  doesn't match with code grouping");
                        // }
                        Code = "";

                    }
                    else if (Code.Length >= 6 && Code.Substring(0, 6) == "end if")
                    {
                        var IfSegment = CompileContext.Stack.Pop();

                        var TopPeek = CompileContext.Stack.Peek();

                        while (TopPeek.GetType() == typeof(IfSegment) && ((IfSegment)TopPeek).ElseSegment == IfSegment)
                        {
                            IfSegment = CompileContext.Stack.Pop();
                            TopPeek = CompileContext.Stack.Peek();
                        }
                        //TopSegment = CompileContext.Stack.Peek();
                        // if (!IfSegement.GetType().IsAssignableFrom(typeof(IfSegment)))
                        // {
                        //     throw new Exception("end if doesn't match with code grouping");
                        // }

                        Code = "";

                    }

                    var TextSegment = new TextSegment();

                    TextSegment.StaticText = StaticText;

                    TopSegment.Segments.Add(TextSegment);
                    TextSegment.Class = TopSegment.Class;
                    if (Code != "")
                    {
                        TextSegment.Method = TextSegment.Class.FindOrCreateMethod(Code, TopSegment.ClassAlias, typeof(string));
                    }

                }

            }

        }

    }

}