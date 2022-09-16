namespace MySimpleDI.Models.Container.Interfaces
{
    public interface IContainer
    {
        Tdependency GetImplementation<Tdependency>();

        TInstance Resolve<TInstance>();
    }
}

