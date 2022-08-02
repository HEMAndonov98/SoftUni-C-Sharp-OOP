using System;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Stealer.Models.Contracts
{
    public class Spy : ISpy
    {
        private readonly IVisualizer visualizer;

        public Spy()
        {
            this.visualizer = new SpyVisualizer();
        }


        public string StealFieldInfo(string className,params string[] fieldNames)
        {
            Type classType = Type.GetType(className);
            FieldInfo[] fields = classType
                .GetFields
                (
                BindingFlags.Public |
                BindingFlags.NonPublic |
                BindingFlags.Static |
                BindingFlags.Instance
                );


            return this.visualizer.ShowData(classType, fields);
        }

        public string AnalyzeAccessModifiers(string className)
        {
            Type type = Type.GetType(className);
            FieldInfo[] fields = ExtractPublicFields(type);
            MethodInfo[] methodGetters = ExtractPrivateGetters(type);
            MethodInfo[] methodSetters = ExtractPublicSetters(type);

           return this.visualizer.VisualizeIncorrectModifiers(fields, methodGetters, methodSetters);
        }

        

        private FieldInfo[] ExtractPublicFields(Type type)
            =>  type
                .GetFields
                (
                BindingFlags.Public |
                BindingFlags.Instance |
                BindingFlags.Static
                );
        private MethodInfo[] ExtractPrivateGetters(Type type)
            => type
                .GetMethods(
                BindingFlags.NonPublic |
                BindingFlags.Instance
                )
                .Where(m => m.Name.StartsWith("get"))
                .ToArray();
        private MethodInfo[] ExtractPublicSetters(Type type)
            => type
                .GetMethods(
                BindingFlags.Instance |
                BindingFlags.Public)
                .Where(m => m.Name.StartsWith("set"))
                .ToArray();
    }
}

