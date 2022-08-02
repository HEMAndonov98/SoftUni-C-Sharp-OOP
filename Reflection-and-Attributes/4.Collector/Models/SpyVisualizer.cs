using System;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices.WindowsRuntime;
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

        private const string MethodReturnTypeMessage = "{0} will return {1}"; // {0} -> Method name, {1} -> return type

        private const string MethodBackingFieldTypeMessage = "{0} will set field of {1}"; // {0} -> Method name, {1} -> field type




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


        public string VisualizeMethodsInformation(MethodInfo[] methodInfos)
        {
            var sb = new StringBuilder();

            foreach (var methodGetter in methodInfos.Where(m => m.Name.Contains("get")))
            {
                sb.AppendLine(string.Format(MethodReturnTypeMessage, methodGetter.Name, methodGetter.ReturnType));
            }

            foreach (var methodSetter in methodInfos.Where(m => m.Name.Contains("set")))
            {
                sb.AppendLine(string.Format(MethodBackingFieldTypeMessage, methodSetter.Name, methodSetter.GetParameters().First().ParameterType));
            }



            return sb.ToString().Trim(); ;
        }
    }
}

