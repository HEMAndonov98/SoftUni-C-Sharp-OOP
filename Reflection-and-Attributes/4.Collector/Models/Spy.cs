using System;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices.WindowsRuntime;

namespace Stealer.Models.Contracts
{
    public class Spy : ISpy
    {
        private readonly IVisualizer visualizer;
        private readonly IClassReflector classReflector;

        public Spy()
        {
            this.visualizer = new SpyVisualizer();
            this.classReflector = new ClassReflector();
        }


        public string StealFieldInfo(string className,params string[] fieldNames)
        {
            Type classType = this.classReflector.GetClassType(className);
            FieldInfo[] fields = this.classReflector.ExtractAllFields(classType);


            return this.visualizer.ShowData(classType, fields);
        }

        public string AnalyzeAccessModifiers(string className)
        {
            Type type = this.classReflector.GetClassType(className);

            FieldInfo[] fields = this.classReflector.ExtractPublicFields(type);

            MethodInfo[] methodGetters = this.classReflector.ExtractPrivateMethods(type)
                 .Where(m => m.Name.StartsWith("get"))
                .ToArray();

            MethodInfo[] methodSetters = this.classReflector.ExtractPublicMethods(type)
                .Where(m => m.Name.StartsWith("set"))
                .ToArray();

           return this.visualizer.VisualizeIncorrectModifiers(fields, methodGetters, methodSetters);
        }

        public string RevealPrivateMethods(string className)
        {
            Type type = this.classReflector.GetClassType(className);
            MethodInfo[] methodInfos = this.classReflector.ExtractPrivateMethods(type);

            return this.visualizer.ShowPrivateMethods(methodInfos, type);
        }

        public string CollectGettersAndSetters(string className)
        {
            Type type = this.classReflector.GetClassType(className);
            MethodInfo[] methods = this.classReflector.ExtractAllMethods(type);

            return this.visualizer.VisualizeMethodsInformation(methods);
        }
    }
}

