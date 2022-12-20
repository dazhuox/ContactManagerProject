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
                connection.Open();


                SqlCommand command = new SqlCommand("SELECT * FROM Contact;", connection);

                SqlDataAdapter adapter = new SqlDataAdapter(command);

                DataTable dataTable = new DataTable("Contacts");

                adapter.Fill(dataTable);

                adapter.Update(dataTable);

                return dataTable;

            }

        }

        public static DataSet Find(int id)
        {
            DataSet dataSet = new DataSet();

            DataTable dataTable = new DataTable("Contacts");

            dataSet.Tables.Add(dataTable);

            using (SqlConnection connection = ((App)Application.Current).connection)
            {
                connection.Open();

                SqlCommand command = new SqlCommand("SELECT TOP 1 Contact.*, ContactImage.Image FROM Contact " +
                    "LEFT JOIN ContactImage ON Contact.ContactImage_ID = ContactImage.ID " +
                    "WHERE Contact.ID = @id;", connection);

                SqlDataAdapter adapter = new SqlDataAdapter(command);

                command.Parameters.AddWithValue("@id", id);

                adapter.Fill(dataTable);
                adapter.Update(dataTable);
            }

            DataTable addressTable = Address.FindForContact(id);
            DataTable phoneTable = Phone.FindForContact(id);
            DataTable emailTable = Email.FindForContact(id);


            dataSet.Tables.Add(addressTable);
            dataSet.Tables.Add(phoneTable);
            dataSet.Tables.Add(emailTable);

            dataSet.Relations.Add("ContactAddress",
                addressTable.Columns["Contact_ID"],
                dataTable.Columns["ID"]);


            dataSet.Relations.Add("ContactPhone",
                phoneTable.Columns["Contact_ID"],
                dataTable.Columns["ID"]);

            dataSet.Relations.Add("ContactEmail",
                emailTable.Columns["Contact_ID"],
                dataTable.Columns["ID"]);


            return dataSet;
        }
    }
}
