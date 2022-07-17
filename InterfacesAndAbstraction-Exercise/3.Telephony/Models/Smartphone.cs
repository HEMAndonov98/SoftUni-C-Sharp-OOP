using System;
using Telephony.Models.Interfaces;

namespace Telephony.Models
{
    public class Smartphone : ICallable, IBrowsable
    {
        public Smartphone()
        {
        }

        public string Browse(string website)
        {
            return $"Browsing: {website}!";
        }

        public string Call(string number)
        {
            return $"Calling... {number}";
        }
    }
}

