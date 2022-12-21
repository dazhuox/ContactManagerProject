using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ContactManagerProject
{
    internal class Address
    {
        public Address(int id, string country, string city, string street, string addressNumber)
        {
            this.id = id;
            Country = country;
            City = city;
            Street = street;
            AddressNumber = addressNumber;
        }

        public Address(int id, string country, string city, string street, string addressNumber, Contact contact, Type type)
        {
            this.id = id;
            Country = country;
            City = city;
            Street = street;
            AddressNumber = addressNumber;
            Contact = contact;
            Type = type;
        }

        public int id { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string AddressNumber { get; set; }
        public Contact Contact {
            get 
            {
                return DB.DB.GetContact(_contactID);
            }
            set
            {
                _contactID = value.id;
            }
        }
        public Type Type
        {
            get
            {

                return DB.DB.GetType(_type);
            }
            set
            {
                _type = value.Code;
            }
        }

        private int _contactID;
        private char _type;
    }
}
