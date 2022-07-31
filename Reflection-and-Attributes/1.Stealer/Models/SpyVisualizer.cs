using System;
using System.Reflection;
using Stealer.Models.Contracts;


namespace Stealer.Models
{
    public class SpyVisualizer : IVisualizer
    {
        private const string DefaultClassMessage = "Class under investigation: {0}";

        public string VisualizeClass(Type type)
         =>  string.Format(DefaultClassMessage, type.Name);

        public string VisualizeFields(FieldInfo field, Type type)
        {
            object classInstance = Activator.CreateInstance(type, new object[] { });
            return $"{field.Name} = {field.GetValue(classInstance)}";
        }
    }
}

