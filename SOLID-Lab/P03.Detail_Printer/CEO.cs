using System;
using P03.DetailPrinter;

namespace P03.Detail_Printer
{
    public class CEO : Employee
    {
        public CEO(string name)
            :base(name)
        {
        }

        public bool IsBoss { get; set; }

        public override string ToString()
        {
            return base.ToString() + ": " + this.IsBoss;
        }
    }
}

