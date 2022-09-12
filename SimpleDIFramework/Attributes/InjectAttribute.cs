namespace SimpleDIFramework.Attributes
{
    [AttributeUsage(AttributeTargets.Constructor | AttributeTargets.Field)]

    public class InjectAttribute : Attribute
    {
        public InjectAttribute()
        {
        }
    }
}

