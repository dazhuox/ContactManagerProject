using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
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
        public DataView Contacts { get; set; }
        public MainWindow()
        {

            // This shows the window.
            InitializeComponent();

            Contacts = Contact.All().AsDataView();

            ContactList.ItemsSource = Contacts;

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
            AddContact addContact = new AddContact();

            addContact.ShowDialog();
        }

        private void ContactList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (ContactList.SelectedItem == null) return;
            DataRowView SelectedContact = ContactList.SelectedItem as DataRowView;
            int? contactID = SelectedContact.Row["ID"] as int?;

            AddContact addContact = new AddContact();
            addContact.ShowDialog();
        }

        private void ContactList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void btnExport_Click(object sender, RoutedEventArgs e)
        {
            //connection
            string connectionString = "Server=localhost;Database=dotNetProject;Trusted_Connection=True;";
            string queryString = "SELECT ID, ContactImage_ID, FirstName, MiddleName, LastName, Salutation, CreateDateTime, UpdateDateTime FROM CONTACT"; //add other tables

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                //load data
                DataTable dataTable = new DataTable();
                dataTable.Load(reader);

                //StringBuilder to get it all together(CSV)
                StringBuilder sb = new StringBuilder();

                //Add column names
                string[] columnNames = new String[] { "ID", "ContactImage_ID", "FirstName", "MiddleName", "LastName", "Salutation", "CreateDateTime", "UpdateDateTime" };
                sb.AppendLine(string.Join(",", columnNames));

                //Add Rows
                foreach (DataRow row in dataTable.Rows)
                {
                    string[] fields = row.ItemArray.Select(field => field.ToString()).ToArray();
                    sb.AppendLine(string.Join(",", fields));

                }

                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "CSV File|*.csv";
                saveFileDialog.Title = "Save CSV File";
                saveFileDialog.ShowDialog();

                // Write the CSV data to the selected file
                System.IO.File.WriteAllText(saveFileDialog.FileName, sb.ToString());

            }
        }
    }
}

