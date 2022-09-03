namespace Composite.Models.Interfaces
{
    public interface IGiftOperations
    {
        void Add(GiftBase gift);
        bool Remove(GiftBase gift);

    }
}

