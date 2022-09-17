
namespace MySimpleDI.Models.Collection
{
    using System.Reflection;
    using Container.Interfaces;
    using MySimpleDI.Models.Container;

    public class ServiceCollection
    {
        //interface -> implementations
        private readonly IDictionary<Type, Type> _services;

        public ServiceCollection()
        {
            this._services = new Dictionary<Type, Type>();
        }

        public void Register<TInterface, TImplementation>()
            where TImplementation : TInterface
        {
            this.Register(typeof(TInterface), typeof(TImplementation));
        }

        public void Register(Type implementation)
        {
            this._services[implementation] = implementation!;
        }

        private void Register(Type interfaceType, Type implementationType)
        {
            this._services[interfaceType] = implementationType;
        }

        public void RegisterAll<TAssembly>()
            where TAssembly : class
            => this.RegisterAll(typeof(TAssembly));

        public void RegisterAll(Type assemblyType)
        {
            var allTypes = assemblyType
              .Assembly
              .GetTypes()
              .Where(t => t.IsClass && t.IsInterface == false);

            foreach (var type in allTypes)
            {
                var sameInterface = type
                    .GetInterfaces()
                    .FirstOrDefault(i => i.Name == $"I{type.Name}");

                if (sameInterface != null)
                {
                    this.Register(sameInterface, type);
                }

                if (type.IsAbstract == false && type.Name.Contains("Attribute") == false)
                {
                    this.Register(type);
                }
            }
        }
        public IContainer BuildServices()
            => new ServiceProvider(this._services);
    }
}

