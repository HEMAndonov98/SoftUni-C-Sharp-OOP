namespace SimpleDIFramework.Modules
{

    using Interfaces;
    using Attributes;

    public abstract class AbstractModule : IModule
    {
        private IDictionary<Type, Dictionary<string, Type>> _implementations;
        private IDictionary<Type, object> _instances;

        protected AbstractModule()
        {
            this._implementations = new Dictionary<Type, Dictionary<string, Type>>();
            this._instances = new Dictionary<Type, object>();
        }

        public abstract void Configure();

        protected void CreateMapping<TInterface, TImplementation>()
        {
            if (!this._implementations.ContainsKey(typeof(TInterface)))
            {
                this._implementations[typeof(TInterface)] = new Dictionary<string, Type>();
            }

            this._implementations[typeof(TInterface)][typeof(TImplementation).Name] = typeof(TImplementation);
        }

        public Type GetMapping(Type currentInterface, object attribute)
        {
            var currentImplementations = this._implementations[currentInterface];
            Type? implementation = null;

            if (attribute is InjectAttribute)
            {
                if (currentImplementations.Count == 1)
                {
                    implementation = currentImplementations.Values.First();
                }
                else
                {
                    throw new ArgumentException($"No available mapping for class: {currentInterface.FullName}");
                }
            }
            else if (attribute is NamedAttribute)
            {
                NamedAttribute? named = (NamedAttribute)attribute;

                string dependencyName = named.Name;
                implementation = currentImplementations[dependencyName];
            }
            return implementation!;
        }

        public void SetInstance(Type implementation, object instance)
        {
            if (!this._instances.ContainsKey(implementation))
            {
                this._instances[implementation] = instance;
            }
        }

        public object GetInstance(Type implementation)
        {

            this._instances.TryGetValue(implementation, out object? value);
            return value!;
        }
    }
}

