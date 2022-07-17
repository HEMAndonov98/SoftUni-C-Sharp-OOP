using System;
using System.Linq;
using Telephony.IO.Interfaces;
using Telephony.Models;

namespace Telephony.Core
{
    public class Engine : IEngine
    {
        private readonly IReader reader;
        private readonly IWriter writer;

        private Smartphone smartphone;
        private Stationaryphone stationaryphone;

        public Engine()
        {
            this.smartphone = new Smartphone();
            this.stationaryphone = new Stationaryphone();
        }

        public Engine(IReader reader, IWriter writer)
            :this()
        {
            this.reader = reader;
            this.writer = writer;
        }

        public void Run()
        {
            string[] phoneNumbers = reader.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            string[] websites = reader.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            CallNumbers(phoneNumbers);

            BrowseWebsites(websites);

        }

        private void BrowseWebsites(string[] websites)
        {
            foreach (var url in websites)
            {
                if (!ValidateURL(url))
                {
                    writer.WriteLine("Invalid URL!");
                }
                else
                {
                    writer.WriteLine(smartphone.Browse(url));
                }
            }
        }

        private void CallNumbers(string[] phoneNumbers)
        {
            foreach (var number in phoneNumbers)
            {
                if (!ValidateNumber(number))
                {
                    writer.WriteLine("Invalid number!");
                }
                else if (number.Length == 10)
                {
                    writer.WriteLine(smartphone.Call(number));
                }
                else if (number.Length == 7)
                {
                    writer.WriteLine(stationaryphone.Call(number));
                }
            }
        }

        private bool ValidateNumber(string number)
        {
            return number.All(c => Char.IsNumber(c));
        }

        private bool ValidateURL(string url)
        {
            return url.All(c => !Char.IsNumber(c));
        }
    }
}

