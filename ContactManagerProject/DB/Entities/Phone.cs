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
    internal class Phone
    {
        public Phone(int id, string number, DateTime createDateTime, DateTime updateDateTime)
        {
            this.id = id;
            Number = number;
            CreateDateTime = createDateTime;
            UpdateDateTime = updateDateTime;
        }

        public Phone(int id, string number, DateTime createDateTime, DateTime updateDateTime, Contact contact, Type type)
        {
            this.id = id;
            Number = number;
            CreateDateTime = createDateTime;
            UpdateDateTime = updateDateTime;
            Contact = contact;
            Type = type;
        }

        public Phone(string number)
        {
            Number = number;
        }

        public int id { get; set; }
        public string Number { get; set; }
        public DateTime CreateDateTime { get; set; }
        public DateTime UpdateDateTime { get; set; }
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
