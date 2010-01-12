using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mono.Cecil;
using LinFu.AOP.Interfaces;
using LinFu.AOP.Cecil;

namespace CSLInjectionDemo
{
    class Program
    {
        static void Main(string[] args)
        {            
            var filename = @"..\..\..\ConsoleClient\bin\Debug\SampleDomain.dll";
            var assembly = AssemblyFactory.GetAssembly(filename);

            // Intercept all object instantiations in the target assembly
            assembly.InterceptNewInstances(ShouldInterceptNewOperator, ShouldInjectCurrentMethod);
            AssemblyFactory.SaveAssembly(assembly, filename);

            Console.WriteLine("{0} successfully modified.", filename);

            return;
        }

        private static bool ShouldInterceptNewOperator(MethodReference constructor, TypeReference declaringType, MethodReference hostMethod)
        {
            var result = !declaringType.IsValueType &&
                         hostMethod.HasThis;

            return result;
        }

        private static bool ShouldInjectCurrentMethod(MethodReference currentMethod)
        {
            return true;
        }
    }
}
