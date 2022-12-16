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

        public Contact() 
        {
            //Create a SqlConnection to the Northwind database.
            using (SqlConnection connection = ((App)Application.Current).connection)
            {
                //Create a SqlDataAdapter for the Suppliers table.
                SqlDataAdapter adapter = new SqlDataAdapter();

                // A table mapping names the DataTable.
                adapter.TableMappings.Add("Table", "Contact");

                // Open the connection.
                Console.WriteLine("The SqlConnection is open.");

                // Create a SqlCommand to retrieve Suppliers data.
                SqlCommand command = new SqlCommand("SELECT * FROM Contact;", connection);
                command.CommandType = CommandType.Text;

                // Set the SqlDataAdapter's SelectCommand.
                adapter.SelectCommand = command;

                // Fill the DataSet.
                DataSet dataSet = new DataSet("Contact");
                adapter.Fill(dataSet);

                // Create a second Adapter and Command to get
                // the Products table, a child table of Suppliers.
                SqlDataAdapter addressAdapter = new SqlDataAdapter();
                addressAdapter.TableMappings.Add("Table", "Address");

                SqlCommand addressCommand = new SqlCommand("SELECT * FROM Address;", connection);
                addressAdapter.SelectCommand = addressCommand;

                // Fill the DataSet.
                addressAdapter.Fill(dataSet);

                // Close the connection.
                connection.Close();
                Console.WriteLine("The SqlConnection is closed.");

                // Create a DataRelation to link the two tables
                // based on the SupplierID.
                DataColumn parentColumn =
                    dataSet.Tables["Address"].Columns["Contact_ID"];
                DataColumn childColumn =
                    dataSet.Tables["Contact"].Columns["ID"];
                DataRelation relation =
                    new DataRelation("Address_Contact",
                    parentColumn, childColumn);
                dataSet.Relations.Add(relation);
                Console.WriteLine(
                    "The {0} DataRelation has been created.",
                    relation.RelationName);
            }
        }

    }
}
