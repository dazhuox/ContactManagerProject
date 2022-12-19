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
        public int id { get; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Salutation { get; set; }
        public DateTime CreateDateTime { get; set; }
        public DateTime UpdateDateTime { get; set; }

        public static DataTable All()
        {
            using (SqlConnection connection = ((App)Application.Current).connection)
            {
                SqlCommand command = new SqlCommand("SELECT * FROM Contact;", connection);

                SqlDataAdapter adapter = new SqlDataAdapter(command);

                DataTable dataTable = new DataTable("Contacts");

                adapter.Fill(dataTable);

                adapter.Update(dataTable);

                return dataTable;

            }

        }


        public Contact() 
        {
        }

    }
}
