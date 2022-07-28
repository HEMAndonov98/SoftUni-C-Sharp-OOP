using System.Text;
using Logger.IO.Interfaces;

namespace Logger.IO
{
    public class LogFile : ILogFile
    {
        private readonly StringBuilder contentSb;
        private readonly IFileWriter writer;

        public LogFile(IFileWriter fileWriter)
        {
            this.contentSb = new StringBuilder();
            this.writer = fileWriter;
        }

        public int Size => this.Content.Length;

        // This represents temporary file content if its not saved it will be lost at compile end
        public string Content => this.contentSb.ToString();


        public void Write(string content)
        {
            this.contentSb.AppendLine(content);
        }
        //This method allows us to save the temporary content to an actual file 
        public void SaveAs(string filename)
        {
            this.writer.WriteToFile(this.Content, filename);
        }
    }
}

