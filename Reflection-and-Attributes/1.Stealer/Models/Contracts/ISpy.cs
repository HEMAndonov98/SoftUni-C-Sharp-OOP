namespace Stealer.Models.Contracts
{
    public interface ISpy
    {
        void StealFieldInfo(string className, string[] fieldNames);
        string ShowData();
    }
}