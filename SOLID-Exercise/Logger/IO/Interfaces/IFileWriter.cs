namespace Logger.IO.Interfaces
{
    public interface IFileWriter
    {
        string FilePath { get; }

        void WriteToFile(string content, string fileName);
    }
}

