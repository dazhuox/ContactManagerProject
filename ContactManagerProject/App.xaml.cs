using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace ContactManagerProject
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        //Gives me a place to store teh connection once I have it
        public SqlConnection connection { get; set; }

        public App()
        {
            var ConString = ConfigurationManager.ConnectionStrings["ContactDatabase"].ConnectionString;
            connection = new SqlConnection(ConString);

            connection.Open();

            Contact contact = new Contact();
        } 

    }
}
