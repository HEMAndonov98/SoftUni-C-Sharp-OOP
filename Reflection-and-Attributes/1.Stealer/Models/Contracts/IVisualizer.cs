using System;
using System.Reflection;

namespace Stealer.Models.Contracts
{
    public interface IVisualizer
    {
        string VisualizeClass(Type type);
        string VisualizeFields(FieldInfo field, Type type);
    }
}

