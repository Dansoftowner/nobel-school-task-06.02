using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nobel_díj_Console
{
    class NobelCandidate
    {

        public int Year { get; set; }
        public string Name { get; set; }
        public Elethossz LifePeriod { get; set; }
        public string CountryCode { get; set; }

        public NobelCandidate(int year, string name, Elethossz lifePeriod, string countryCode)
        {
            Year = year;
            Name = name;
            LifePeriod = lifePeriod;
            CountryCode = countryCode;
        }

        public NobelCandidate(string row) : this(row.Split(';'))
        {
        }

        private NobelCandidate(string[] data) : this(int.Parse(data[0]), data[1], new Elethossz(data[2]), data[3])
        {
        }



    }
}
