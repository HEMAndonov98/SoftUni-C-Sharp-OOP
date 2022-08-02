using System;
using System.Reflection;

namespace Stealer.Models.Contracts
{
    internal interface IClassReflector
    {
        MethodInfo[] ExtractPrivateMethods(Type type);
        FieldInfo[] ExtractPublicFields(Type type);
        MethodInfo[] ExtractPublicMethods(Type type);
        Type GetClassType(string className);
    }
}