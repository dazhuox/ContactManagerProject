using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManagerProject
{
    internal class Address
    {
        public int id { get; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string AddressNumber { get; set; }

        public Address() 
        {
        }

    }
}
