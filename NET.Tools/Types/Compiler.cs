using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.CodeDom.Compiler;
using Microsoft.CSharp;
using System.Reflection;
using System.Collections.Specialized;
using System.IO;
using Microsoft.JScript;
using Microsoft.VisualBasic;

namespace NET.Tools
{
    public static class Compiler
    {
        public static CompilerResults CompileFromCSharpSourceCode(String sourceCode, CompilerParameters cParams)
        {
            using (CodeDomProvider provider = new CSharpCodeProvider())
            {
                CompilerResults res = provider.CompileAssemblyFromSource(cParams, sourceCode);

                return res;
            }
        }

        public static CompilerResults CompileFromCSharpSourceFile(String sourceFile, CompilerParameters cParams)
        {
            using (CodeDomProvider provider = new CSharpCodeProvider())
            {
                CompilerResults res = provider.CompileAssemblyFromFile(cParams, sourceFile);

                return res;
            }
        }

        public static CompilerResults CompileFromCSharpSourceStream(Stream sourceStream, CompilerParameters cParams)
        {
            String tmpFile = Path.GetTempFileName();
            using (FileStream output = new FileStream(tmpFile, FileMode.Create))
            {
                byte[] buffer = new byte[sourceStream.Length];
                sourceStream.Seek(0, SeekOrigin.Begin);
                sourceStream.Read(buffer, 0, buffer.Length);
                output.Write(buffer, 0, buffer.Length);
            }

            using (CodeDomProvider provider = new CSharpCodeProvider())
            {
                CompilerResults res = provider.CompileAssemblyFromFile(cParams, tmpFile);

                File.Delete(tmpFile);

                return res;
            }
        }

        public static CompilerResults CompileFromJScriptSourceCode(String sourceCode, CompilerParameters cParams)
        {
            using (CodeDomProvider provider = new JScriptCodeProvider())
            {
                CompilerResults res = provider.CompileAssemblyFromSource(cParams, sourceCode);

                return res;
            }
        }

        public static CompilerResults CompileFromJScriptSourceFile(String sourceFile, CompilerParameters cParams)
        {
            using (CodeDomProvider provider = new JScriptCodeProvider())
            {
                CompilerResults res = provider.CompileAssemblyFromFile(cParams, sourceFile);

                return res;
            }
        }

        public static CompilerResults CompileFromJScriptSourceStream(Stream sourceStream, CompilerParameters cParams)
        {
            String tmpFile = Path.GetTempFileName();
            using (FileStream output = new FileStream(tmpFile, FileMode.Create))
            {
                byte[] buffer = new byte[sourceStream.Length];
                sourceStream.Seek(0, SeekOrigin.Begin);
                sourceStream.Read(buffer, 0, buffer.Length);
                output.Write(buffer, 0, buffer.Length);
            }

            using (CodeDomProvider provider = new JScriptCodeProvider())
            {
                CompilerResults res = provider.CompileAssemblyFromFile(cParams, tmpFile);

                File.Delete(tmpFile);

                return res;
            }
        }

        public static CompilerResults CompileFromVBSourceCode(String sourceCode, CompilerParameters cParams)
        {
            using (CodeDomProvider provider = new VBCodeProvider())
            {
                CompilerResults res = provider.CompileAssemblyFromSource(cParams, sourceCode);

                return res;
            }
        }

        public static CompilerResults CompileFromVBSourceFile(String sourceFile, CompilerParameters cParams)
        {
            using (CodeDomProvider provider = new VBCodeProvider())
            {
                CompilerResults res = provider.CompileAssemblyFromFile(cParams, sourceFile);

                return res;
            }
        }

        public static CompilerResults CompileFromVBSourceStream(Stream sourceStream, CompilerParameters cParams)
        {
            String tmpFile = Path.GetTempFileName();
            using (FileStream output = new FileStream(tmpFile, FileMode.Create))
            {
                byte[] buffer = new byte[sourceStream.Length];
                sourceStream.Seek(0, SeekOrigin.Begin);
                sourceStream.Read(buffer, 0, buffer.Length);
                output.Write(buffer, 0, buffer.Length);
            }

            using (CodeDomProvider provider = new VBCodeProvider())
            {
                CompilerResults res = provider.CompileAssemblyFromFile(cParams, tmpFile);

                File.Delete(tmpFile);

                return res;
            }
        }
    }
}
