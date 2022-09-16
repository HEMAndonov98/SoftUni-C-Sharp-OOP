
namespace MySimpleDI.Models.Collection
{

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
            this._services[typeof(TInterface)] = typeof(TImplementation);
        }

        public void Register(Type implementation)
        {
            this._services[implementation] = implementation!;
        }

        public IContainer BuildServices()
            => new ServiceProvider(this._services);
    }
}

