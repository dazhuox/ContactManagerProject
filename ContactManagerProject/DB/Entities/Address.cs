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
        public int id { get; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string AddressNumber { get; set; }

        public static DataTable FindForContact(int contactId)
        {
            //Run sql to select id (looking through the sql query for the id)
            using (SqlConnection connection = ((App)Application.Current).connection)
            {
                SqlCommand findAddressID = new SqlCommand("SELECT Address.Contact_ID, Address.ID, Address.Country, Address.City, Address.Street, Address.AddressNumber, Type.Description " +
                    "FROM Address" +
                    " JOIN Type ON Address.Type = Type.Code " +
                    "WHERE Address.Contact_ID = @id;", connection);

                findAddressID.Parameters.AddWithValue("@id", contactId);

                SqlDataAdapter adapter = new SqlDataAdapter(findAddressID);

                DataTable dataTable = new DataTable("Addresses");

                adapter.Fill(dataTable);

                adapter.Update(dataTable);

                return dataTable;

            }


        }

    }
}
