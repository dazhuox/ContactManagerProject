using System.Data.SqlClient;
using System.Data;
using System.Windows;

namespace ContactManagerProject
{
    internal class Email
    {
        public Email(int id, string emailAddress)
        {
            this.id = id;
            EmailAddress = emailAddress;
        }

        public Email(int id, string emailAddress, Contact contact, Type type)
        {
            this.id = id;
            EmailAddress = emailAddress;
            Contact = contact;
            Type = type;
        }

        public int id { get; set; }
        public string EmailAddress { get; set; }
        public Contact Contact
        {
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
