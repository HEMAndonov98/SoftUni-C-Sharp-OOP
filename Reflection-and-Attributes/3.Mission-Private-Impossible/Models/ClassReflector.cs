using System;
using System.Reflection;
using Stealer.Models.Contracts;

namespace Stealer.Models
{
    internal class ClassReflector : IClassReflector
    {

        public Type GetClassType(string className)
        {
            Type type = Type.GetType(className);
            if (type == null)
            {
                throw new ArgumentException("Invalid name given, did you put the correct namespace for the class you're looking for?");
            }
            return type;
        }

        public FieldInfo[] ExtractPublicFields(Type type)
            => type
                .GetFields
                (
                BindingFlags.Public |
                BindingFlags.Instance |
                BindingFlags.Static
                );
        public MethodInfo[] ExtractPrivateMethods(Type type)
            => type
                .GetMethods(
                BindingFlags.NonPublic |
                BindingFlags.Instance
                );
        public MethodInfo[] ExtractPublicMethods(Type type)
            => type
                .GetMethods(
                BindingFlags.Instance |
                BindingFlags.Public);
    }
}

