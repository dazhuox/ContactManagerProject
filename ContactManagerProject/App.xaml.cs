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
        public SqlConnection connection {
            get {
                var ConString = ConfigurationManager.ConnectionStrings["ContactDatabase"].ConnectionString;
                return new SqlConnection(ConString);
            }
        }

        public App()
        {

        } 

    }
}
