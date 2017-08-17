using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic;
using System.CodeDom;
using System.IO;
using System.CodeDom.Compiler;
using System.Reflection;
using Microsoft.CSharp;
using TES30.API;
namespace TES30
{
    class ScriptFile
    {
        private string code;
        Assembly asm;
        public CodePart Class { get; private set; }
        private const string Header = @"using TES30.API;";
        public ScriptFile(string Code)
        {
            code = Code;
            asm = BuildAssembly();
            Class = (CodePart)Activator.CreateInstance(FindDerivedTypes(asm, typeof(CodePart)).First());
        }
        public IEnumerable<Type> FindDerivedTypes(Assembly assembly, Type baseType)
        {
            return assembly.GetTypes().Where(t => baseType.IsAssignableFrom(t));
        }
        private Assembly BuildAssembly()
        {
            Microsoft.CSharp.CSharpCodeProvider provider =
               new CSharpCodeProvider();
            ICodeCompiler compiler = provider.CreateCompiler();
            CompilerParameters compilerparams = new CompilerParameters()
            {
                GenerateExecutable = false,
                GenerateInMemory = true
            };
            compilerparams.ReferencedAssemblies.Add("TES30-API.dll");
            CompilerResults results =
               compiler.CompileAssemblyFromSource(compilerparams, Header + code);
            if (results.Errors.HasErrors)
            {
                StringBuilder errors = new StringBuilder("Compiler Errors :\r\n");
                foreach (CompilerError error in results.Errors)
                {
                    errors.AppendFormat("Line {0},{1}\t: {2}\n",
                           error.Line, error.Column, error.ErrorText);
                }
                throw new Exception(errors.ToString());
            }
            else
            {
                return results.CompiledAssembly;
            }
        }
    }
}
