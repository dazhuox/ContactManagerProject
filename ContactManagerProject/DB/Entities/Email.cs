using System.Data.SqlClient;
using System.Data;
using System.Windows;

namespace ContactManagerProject
{
    internal class Email
    {
        public int id { get; }
        public string EmailAddress { get; set; }


        public static DataTable FindForContact(int contactId)
        {
            //Run sql to select id (looking through the sql query for the id)
            using (SqlConnection connection = ((App)Application.Current).connection)
            {
                SqlCommand command = new SqlCommand("SELECT Email.Contact_ID, Email.ID, Email.EmailAddress, " +
                    "Type.Description FROM Email " +
                    "JOIN Type ON Email.Type = Type.Code " +
                    "WHERE Email.Contact_ID = @id ;", connection);

                command.Parameters.AddWithValue("@id", contactId);

                SqlDataAdapter adapter = new SqlDataAdapter(command);

                DataTable dataTable = new DataTable("Emails");

                adapter.Fill(dataTable);

                adapter.Update(dataTable);

                return dataTable;

            }


        }
    }
}
