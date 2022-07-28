using System.Text;
using Logger.IO.Interfaces;

namespace Logger.IO
{
    public class FileWriter : IFileWriter
    {
        public FileWriter(string filepath)
        {
            this.FilePath = filepath;
        }

        public string FilePath { get; private set; }

        public void WriteToFile(string content, string fileName)
        {
            string ouputPath = Path.Combine(this.FilePath, fileName);
            File.WriteAllText(ouputPath, content, Encoding.UTF8);
        }
    }
}

