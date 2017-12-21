using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Reflection;
using Microsoft.CSharp;
using System.CodeDom.Compiler;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using System.IO;
using Microsoft.CodeAnalysis.Emit;
using System.Linq;
//using System.Runtime.Loader;
using System.Collections;
using ate.Extensions;

namespace ate.Templating
{
    public class Template
    {

        public Type Type { get; set; }

        //ToDo Move this to a config file in a project folder
        internal static Dictionary<string, string> Tags = new Dictionary<string, string> {
                { "<#", "#>" },
                { "ʕ", "ʔ" }
            };

        private Assembly Assembly;

        public Segment BaseSegment { get; set; }

        public Stack<ISegment> Stack = new Stack<ISegment>();

        public ConcurrentDictionary<Type, Class> Classes = new ConcurrentDictionary<Type, Class>();

        public ConcurrentDictionary<string, CodeSegment> CodeSegments = new ConcurrentDictionary<string, CodeSegment>();

        public static Template Compile(string Source, Type Type)
        {

            var Template = new Template();
            Template.Type = Type;
            Template.Compile(Source);

            return Template;
        }

        private void Compile(string Source)
        {

            var CompileContext = new CompileContext();
            CompileContext.Template = this;

            BaseSegment = new Segment();
            BaseSegment.Class = FindOrCreateClass(Type);

            CompileContext.Stack.Push(BaseSegment);

            //Create a new in memory assembly with classes that inherit from Core Object Model Classes with added functions that contain code from templates
            //if source is a file then compile it straight
            //if, however, it is a folder then compile the folder and file names
            if (Directory.Exists(Source))
            {
                Folder.Compile(CompileContext, new DirectoryInfo(Source));
            }
            else if (System.IO.File.Exists(Source))
            {
                File.Compile(CompileContext, new FileInfo(Source));
            }
            else
            {
                Text.Compile(CompileContext, Source);
            }

            string TemplateCode = "using System;\nusing System.Linq;\nusing System.Collections;\nusing ate.Extensions;\nusing ate.Projects;\nusing ate.Definitions;\n\n namespace N" + Guid.NewGuid().ToString().CodeName() + " { ";

            List<SyntaxTree> SyntaxTrees = new List<SyntaxTree>();

            foreach (var CodeSegment in CodeSegments.Values)
            {
                SyntaxTrees.Add(CSharpSyntaxTree.ParseText(CodeSegment.Code));
            }

            foreach (var Class in Classes.Values)
            {
                TemplateCode += Class.CompiledCode();
            }

            TemplateCode += "\n}";

            var assemblyName = "A" + Guid.NewGuid().ToString().CodeName();
            SyntaxTrees.Add(CSharpSyntaxTree.ParseText(TemplateCode));

            List<MetadataReference> References = new List<MetadataReference>();

            References.Add(MetadataReference.CreateFromFile(typeof(Object).Assembly.Location));
            References.Add(MetadataReference.CreateFromFile(typeof(Enumerable).Assembly.Location));
            References.Add(MetadataReference.CreateFromFile(typeof(IEnumerable).Assembly.Location));

            var EntryAssembly = Assembly.GetEntryAssembly();

            foreach (var AssemblyName in EntryAssembly.GetReferencedAssemblies())
            {
                var ReferencedAssembly = Assembly.Load(AssemblyName.FullName);

                References.Add(MetadataReference.CreateFromFile(ReferencedAssembly.Location));
            }

            var ExecutingAssembly = Assembly.GetExecutingAssembly();

            foreach (var AssemblyName in ExecutingAssembly.GetReferencedAssemblies())
            {
                var ReferencedAssembly = Assembly.Load(AssemblyName.FullName);

                References.Add(MetadataReference.CreateFromFile(ReferencedAssembly.Location));
            }

            foreach (var AssemblyName in Type.Assembly.GetReferencedAssemblies())
            {
                var ReferencedAssembly = Assembly.Load(AssemblyName.FullName);

                References.Add(MetadataReference.CreateFromFile(ReferencedAssembly.Location));
            }

            References.Add(MetadataReference.CreateFromFile(Type.Assembly.Location));


            CSharpCompilation compilation = CSharpCompilation.Create(
                assemblyName,
                syntaxTrees: SyntaxTrees,
                references: References,
                options: new CSharpCompilationOptions(OutputKind.DynamicallyLinkedLibrary));


            using (var ms = new MemoryStream())
            {
                EmitResult result = compilation.Emit(ms);

                if (!result.Success)
                {
                    IEnumerable<Diagnostic> failures = result.Diagnostics.Where(diagnostic =>
                        diagnostic.IsWarningAsError ||
                        diagnostic.Severity == DiagnosticSeverity.Error);

                    foreach (Diagnostic diagnostic in failures)
                    {
                        try
                        {
                            Console.WriteLine("{0}: {1} at {2}\n{3}", diagnostic.Id, diagnostic.GetMessage(), diagnostic.Location.SourceSpan.Start, diagnostic.Location.SourceTree.ToString().Substring(diagnostic.Location.SourceSpan.Start, diagnostic.Location.SourceTree.ToString().IndexOf(Environment.NewLine, diagnostic.Location.SourceSpan.Start) - diagnostic.Location.SourceSpan.Start));
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("{0}: {1} at {2}\n{3}", diagnostic.Id, diagnostic.GetMessage(), diagnostic.Location.SourceSpan.Start, diagnostic.Location.SourceTree.ToString());

                        }
                    }
                    throw new Exception("Compile error");
                }
                else
                {
                    ms.Seek(0, SeekOrigin.Begin);
                    //Assembly = System.Reflection.Assembly.Load(ms.ToArray());
                    Assembly = System.Runtime.Loader.AssemblyLoadContext.Default.LoadFromStream(ms);
                }

            }


            foreach (var Class in Classes.Values)
            {
                Class.CompiledType = Assembly.GetExportedTypes().Where(
                    (FindType) => FindType.Name == Class.BaseType.Name
                    ).FirstOrDefault();

            }

            Console.WriteLine("Successfully compiled");
        }

        public Class FindOrCreateClass(Type Type)
        {
            return Classes.GetOrAdd(Type, ClassFactory);
        }

        private Class ClassFactory(Type Type)
        {
            var Class = new Class();
            Class.BaseType = Type;
            return Class;
        }

        public CodeSegment FindOrCreateCodeSegment(string Name)
        {
            return CodeSegments.GetOrAdd(Name, CodeSegmentFactory);
        }

        private CodeSegment CodeSegmentFactory(string Name)
        {
            var CodeSegment = new CodeSegment();
            CodeSegment.Name = Name;
            return CodeSegment;
        }

        public RenderContext Render(object Object, string Destination)
        {

            var RenderContext = new RenderContext();
            RenderContext.CurrentDirectory = Destination;
            RenderContext.CurrentObject = Object;

            BaseSegment.Render(RenderContext);
            Console.WriteLine("Successfully rendered");

            return RenderContext;

        }

    }

}