
namespace MySimpleDI.Models.Container
{
    using Interfaces;

    public class ServiceProvider : IContainer
    {
        private readonly IDictionary<Type, Type> _services;


        public ServiceProvider(IDictionary<Type, Type> services)
        {
            this._services = services;
        }


        public Tdependency GetImplementation<Tdependency>()
            => (Tdependency)this.GetImplementation(typeof(Tdependency));

        public object GetImplementation(Type dependencyType)
        {
            if (!this._services.ContainsKey(dependencyType))
            {
                throw new InvalidOperationException();
            }

            var implementation = this._services[dependencyType];


            return this.CreateInstance(implementation);
        }

        public TInstance Resolve<TInstance>()
            => (TInstance)this.CreateInstance(typeof(TInstance));

        private object CreateInstance(Type implementation)
        {

            if (implementation.IsAbstract | implementation.IsInterface)
            {
                throw new ArgumentException();
            }

            var constructor = implementation.GetConstructors().First();
            var parameters = constructor.GetParameters();
            var dependencies = new object[parameters.Length];
            var dependenciesIndex = 0;

            if (parameters.Any() == false)
            {
                return Activator.CreateInstance(implementation)!;
            }

            for (int i = 0; i < parameters.Length; i++)
            {
                var parameterType = parameters[i].ParameterType;

                if (parameterType.IsValueType || parameterType.Name == "String" || parameterType.IsArray)
                {
                    dependencies[dependenciesIndex++] = this.GetBaseType(parameterType);
                    continue;
                }
                var dependency = this.GetImplementation(parameterType);

                dependencies[dependenciesIndex++] = dependency;
            }

            return constructor.Invoke(dependencies);

        }

        private object GetBaseType(Type type)
        {
            if (type.IsValueType)
            {
                return Activator.CreateInstance(type)!;
            }
            else if (type == typeof(string))
            {
                return string.Empty;
            }
            else if (type.IsArray)
            {
                var array = Array.CreateInstance(type.GetElementType()!, 1);
            }
            throw new ArgumentException();
        }
    }
}

