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
        public int id { get; }
        public int Number { get; set; }
        public DateTime CreateDateTime { get; set; }
        public DateTime UpdateDateTime { get; set; }

        public static DataTable FindForContact(int contactId)
        {
            //Run sql to select id (looking through the sql query for the id)
            using (SqlConnection connection = ((App)Application.Current).connection)
            {
                SqlCommand command = new SqlCommand("SELECT Phone.ID, Phone.Number, Type.Description " +
                    "FROM Phone " +
                    "JOIN Type ON Phone.Type = Type.Code  " +
                    "WHERE Phone.Contact_ID = @id ;", connection);

                command.Parameters.AddWithValue("@id", contactId);

                SqlDataAdapter adapter = new SqlDataAdapter(command);

                DataTable dataTable = new DataTable("Phones");

                adapter.Fill(dataTable);

                adapter.Update(dataTable);

                return dataTable;

            }


        }
    }
}
