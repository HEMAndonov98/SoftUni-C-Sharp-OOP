using System;
using System.Reflection;
using System.Text;
using Stealer.Models.Contracts;


namespace Stealer.Models
{
    internal class SpyVisualizer : IVisualizer
    {
        private const string DefaultClassMessage = "Class under investigation: {0}";

        private const string PublicFieldMessage = "{0} must be private!";

        private const string PrivateGetterMessage = "{0} have to be public!";

        private const string PublicSetterMessage = "{0} have to be private!";

        private const string PrivateMethodsClassMessage = "All Private Methods of Class: {0}";

        private const string BaseClassMessage = "Base Class: {0}";




        public string VisualizeClass(Type type)
         =>  string.Format(DefaultClassMessage, type.Name);


        public string VisualizeFields(FieldInfo field, Type type)
        {
            object classInstance = Activator.CreateInstance(type, new object[] { });
            return $"{field.Name} = {field.GetValue(classInstance)}";
        }


        public string ShowData(Type type, FieldInfo[] fields)
        {
            var sb = new StringBuilder();
            sb.AppendLine(this.VisualizeClass(type));

            foreach (var field in fields)
            {
                sb.AppendLine(this.VisualizeFields(field, type));
            }

            return sb.ToString().Trim();
        }


        public string VisualizeIncorrectModifiers(FieldInfo[] fields, MethodInfo[] getters, MethodInfo[] setters)
        {
            var sb = new StringBuilder();

            foreach (var field in fields)
            {
                sb.AppendLine(string.Format(PublicFieldMessage, field.Name));
            }
            foreach (var privateGetter in getters)
            {
                sb.AppendLine(string.Format(PrivateGetterMessage, privateGetter.Name));
            }
            foreach (var publicSetter in setters)
            {
                sb.AppendLine(string.Format(PublicSetterMessage, publicSetter.Name));
            }
            return sb.ToString().Trim();
        }

        public string ShowPrivateMethods(MethodInfo[] methodInfos, Type type)
        {
            var sb = new StringBuilder();
            sb.AppendLine(string.Format(PrivateMethodsClassMessage, type.Name));
            sb.AppendLine(string.Format(BaseClassMessage, type.BaseType.Name));

            foreach (var privateMethod in methodInfos)
            {
                sb.AppendLine(privateMethod.Name);
            }

            return sb.ToString().Trim();
        }
    }
}

