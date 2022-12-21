using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ContactManagerProject
{
    internal class Contact
    {
        public Contact()
        {
        }

        public Contact(string firstName, string middleName, string lastName, string salutation)
        {
            FirstName = firstName;
            MiddleName = middleName;
            LastName = lastName;
            Salutation = salutation;
        }

        public Contact(int id, string firstName, string middleName, string lastName, string salutation, DateTime createDateTime, DateTime updateDateTime)
        {
            this.id = id;
            FirstName = firstName;
            MiddleName = middleName;
            LastName = lastName;
            Salutation = salutation;
            CreateDateTime = createDateTime;
            UpdateDateTime = updateDateTime;
        }

        public int id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Salutation { get; set; }
        public DateTime CreateDateTime { get; set; }
        public DateTime UpdateDateTime { get; set; }
        public List<Address> Addresses { get; set; }
        public List<Email> Emails { get; set; }
        public List<Phone> Phones { get; set; }
    }
}
