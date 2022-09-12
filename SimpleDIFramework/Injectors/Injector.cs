
namespace SimpleDIFramework.Injectors
{
    using System.Reflection;
    using Modules.Interfaces;
    using SimpleDIFramework.Attributes;

    public class Injector 
    {
        private IModule _module;

        public Injector(IModule module)
        {
            this._module = module;
        }

        public static Injector CreateInjector(IModule module)
        {
            module.Configure();
            return new Injector(module);
        }

        private bool CheckForFieldInjection<TClass>()
        {
            return typeof(TClass)
                .GetFields((BindingFlags) 62)
                .Any(f => f.GetCustomAttributes(typeof(InjectAttribute), true).Any());
        }

        private bool CheckForConstructorInjections<TClass>()
        {
            return typeof(TClass)
                .GetConstructors()
                .Any(c => c.GetCustomAttributes(typeof(InjectAttribute), true).Any());
        }

        private TClass CreateConstructorInjection<TClass>()
        {
            if (typeof(TClass) == null)
            {
                return default(TClass)!;
            }

            var constructors = typeof(TClass).GetConstructors();

            foreach (var constructor in constructors)
            {
                if (!this.CheckForConstructorInjections<TClass>())
                {
                    continue;
                }

                var inject = (InjectAttribute)constructor
                    .GetCustomAttributes(typeof(InjectAttribute), true)
                    .FirstOrDefault()!;

                var parameterTypes = constructor.GetParameters();
                var constructorParams = new object[parameterTypes.Length];

                var i = 0;

                foreach (var parameterType in parameterTypes)
                {
                    var named = parameterType.ParameterType.GetCustomAttribute(typeof(NamedAttribute));
                    Type? dependancy = null;

                    if (named == null)
                    {
                        dependancy = this._module.GetMapping(parameterType.ParameterType, inject);
                    }
                    else
                    {
                        dependancy = this._module.GetMapping(parameterType.ParameterType, named);
                    }

                    if (parameterType.ParameterType.IsAssignableFrom(dependancy))
                    {
                        object instance = this._module.GetInstance(dependancy);
                        if (instance != null)
                        {
                            constructorParams[i++] = instance;
                        }
                        else
                        {
                            instance = Activator.CreateInstance(dependancy)!;
                            constructorParams[i++] = instance;
                            this._module.SetInstance(parameterType.ParameterType, instance);
                        }
                    }
                }
                    return (TClass)Activator.CreateInstance(typeof(TClass), constructorParams)!;
            }
            return default(TClass)!;
        }

        private TClass CreateFieldInjection<TClass>()
        {
            var desiredClass = typeof(TClass);
            var desiredInstance = this._module.GetInstance(desiredClass);

            if (desiredInstance == null)
            {
                desiredInstance = Activator.CreateInstance(desiredClass);
                this._module.SetInstance(desiredClass, desiredInstance!);
            }

            var fields = desiredClass.GetFields((BindingFlags)62);

            foreach (var field in fields)
            {
                if (field.GetCustomAttributes(typeof(InjectAttribute), true).Any())
                {
                    var injection = (InjectAttribute)field
                        .GetCustomAttributes(typeof(InjectAttribute), true)
                        .FirstOrDefault()!;

                    Type? dependency = null;

                    var named = field.GetCustomAttributes(typeof(NamedAttribute), true);
                    var type = field.FieldType;

                    if (named == null)
                    {
                        dependency = this._module.GetMapping(type, injection);
                    }
                    else
                    {
                        dependency = this._module.GetMapping(type, named);
                    }

                    if (type.IsAssignableFrom(dependency))
                    {
                        object instance = this._module.GetInstance(dependency);
                        if (instance == null)
                        {
                            instance = Activator.CreateInstance(dependency)!;
                            this._module.SetInstance(desiredClass, instance);
                        }
                    }
                }
            }
                return (TClass)desiredInstance!;
        }
    }
}

