using System;
using Telephony.Models.Interfaces;

namespace Telephony.Models
{
    public class Stationaryphone : ICallable
    {
        public Stationaryphone()
        {
        }

        public string Call(string number)
        {
            return $"Dialing... {number}";
        }

    }
}

