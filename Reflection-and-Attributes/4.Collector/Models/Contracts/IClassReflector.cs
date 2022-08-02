using System;
using System.Reflection;

namespace Stealer.Models.Contracts
{
    internal interface IClassReflector
    {
        Type GetClassType(string className);
        FieldInfo[] ExtractPublicFields(Type type);
        FieldInfo[] ExtractAllFields(Type type);
        MethodInfo[] ExtractPrivateMethods(Type type);
        MethodInfo[] ExtractPublicMethods(Type type);
        MethodInfo[] ExtractAllMethods(Type type);
    }
}