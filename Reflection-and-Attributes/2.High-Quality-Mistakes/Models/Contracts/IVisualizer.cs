using System;
using System.Reflection;

namespace Stealer.Models.Contracts
{
    public interface IVisualizer
    {
        string VisualizeClass(Type type);
        string VisualizeFields(FieldInfo field, Type type);
        string ShowData(Type type, FieldInfo[] fields);
        string VisualizeIncorrectModifiers(FieldInfo[] fields, MethodInfo[] getters, MethodInfo[] setters);
    }
}

