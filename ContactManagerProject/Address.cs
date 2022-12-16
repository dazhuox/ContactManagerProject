using System;
using System.Collections.Generic;
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

        public Address(int id)
        {
            //Run sql to select id (looking through the sql query for the id)

            SqlCommand findAddressID = new SqlCommand("SELECT * FROM ADDRESS WHERE ID = @id LIMIT 1 ;"
                , ((App)Application.Current).connection );

            findAddressID.Parameters.AddWithValue("@id", id);

            SqlDataReader reader =  findAddressID.ExecuteReader();

            if (reader.HasRows) {


            }
        }

    }
}
