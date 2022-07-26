using System;
using System.Collections.Generic;
using System.Text;

namespace P03.DetailPrinter
{
    public class Manager : Employee
    {
        //Encapsulated the class
        private IReadOnlyCollection<string> documents;

        public Manager(string name, ICollection<string> documents) : base(name)
        {
            this.documents = new List<string>(documents);
        }

        public IReadOnlyCollection<string> Documents { get { return this.documents; } }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine(this.Name);
            sb.AppendJoin(Environment.NewLine, this.Documents);
            return sb.ToString();
        }
    }
}
