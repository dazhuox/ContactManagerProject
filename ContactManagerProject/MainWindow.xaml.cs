using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ContactManagerProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //Gives me a place to store teh connection once I have it
        public SqlConnection connection { get; set; }



        public MainWindow()
        {
            
            var ConString = ConfigurationManager.ConnectionStrings["LabConnection"].ConnectionString;
            connection = new SqlConnection(ConString);

            // This shows the window.
            InitializeComponent();

        }
        

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {

        }

        private void AddContactDoubleClick(object sender, RoutedEventArgs e)
        {

        }
    }
}
