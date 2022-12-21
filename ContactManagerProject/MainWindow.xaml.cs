using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
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
        internal List<Contact> Contacts { get; set; }
        public MainWindow()
        {

            // This shows the window.
            InitializeComponent();

            Contacts = DB.DB.GetContacts();

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
            Contact SelectedContact = ContactList.SelectedItem as Contact;

            AddContact addContact = new AddContact(SelectedContact);
            addContact.ShowDialog();
        }

        private void ContactList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void btnExport_Click(object sender, RoutedEventArgs e)
        {
            //connection
            string connectionString = "Server=localhost;Database=dotNetProject;Trusted_Connection=True;";
            string queryStringContact = "SELECT ID, ContactImage_ID, FirstName, MiddleName, LastName, Salutation, CreateDateTime, UpdateDateTime FROM CONTACT";
            string queryStringAddress = "SELECT ID, Contact_ID, Type, Country, City, Street, AddressNumber FROM ADDRESS";
            string queryStringEmail = "SELECT ID, Contact_ID, Type, EmailAddress FROM EMAIL";
            string queryStringPhone = "SELECT ID, Contact_ID, Type, Number, CreateDateTime, UpdateDateTime FROM PHONE";
            string queryStringType = "SELECT Code, Description FROM TYPE";



            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                //everything is for the 5 tables
                SqlCommand commandContact = new SqlCommand(queryStringContact, connection);
                SqlCommand commandAddress = new SqlCommand(queryStringAddress, connection);
                SqlCommand commandEmail = new SqlCommand(queryStringEmail, connection);
                SqlCommand commandPhone = new SqlCommand(queryStringPhone, connection);
                SqlCommand commandType = new SqlCommand(queryStringType, connection);

                connection.Open();

                SqlDataReader Contact = commandContact.ExecuteReader();
                //SqlDataReader ReaderAddress = commandAddress.ExecuteReader();
                //SqlDataReader readerEmail = commandEmail.ExecuteReader();
                //SqlDataReader readerPhone = commandPhone.ExecuteReader();
                //SqlDataReader readerType = commandType.ExecuteReader();

                //load data
                DataTable dataTableContact = new DataTable();
                DataTable dataTableAddress = new DataTable();
                DataTable dataTableEmail = new DataTable();
                DataTable dataTablePhone = new DataTable();
                DataTable dataTableType = new DataTable();

                dataTableContact.Load(Contact);
                dataTableAddress.Load(Contact);
                dataTableEmail.Load(Contact);
                dataTablePhone.Load(Contact);
                dataTableType.Load(Contact);

                //StringBuilder to get it all together(CSV)
                StringBuilder sb = new StringBuilder();

                //Add column names (contact)
                string[] columnNames = new String[] { "ID", "ContactImage_ID", "FirstName", "MiddleName", "LastName", "Salutation", "CreateDateTime", "UpdateDateTime" };
                sb.AppendLine(string.Join(",", columnNames));

                //Add Rows
                foreach (DataRow row in dataTableContact.Rows)
                {
                    string[] fields = row.ItemArray.Select(field => field.ToString()).ToArray();
                    sb.AppendLine(string.Join(",", fields));

                }

                //Add column names (address)
                columnNames = new String[] { "ID", "Contact_ID", "Type", "Country", "City", "Street", "AddressNumber" };
                sb.AppendLine(string.Join(",", columnNames));

                //Add Rows
                foreach (DataRow row in dataTableContact.Rows)
                {
                    string[] fields = row.ItemArray.Select(field => field.ToString()).ToArray();
                    sb.AppendLine(string.Join(",", fields));

                }

                //Add column names (Email)
                columnNames = new String[] { "ID", "Contact_ID", "Type", "EmailAddress" };
                sb.AppendLine(string.Join(",", columnNames));

                //Add Rows
                foreach (DataRow row in dataTableContact.Rows)
                {
                    string[] fields = row.ItemArray.Select(field => field.ToString()).ToArray();
                    sb.AppendLine(string.Join(",", fields));

                }

                //Add column names (Phone)
                columnNames = new String[] { "SELECT ID", "Contact_ID", "Type", "Number", "CreateDateTime", "UpdateDateTime" };
                sb.AppendLine(string.Join(",", columnNames));

                //Add Rows
                foreach (DataRow row in dataTableContact.Rows)
                {
                    string[] fields = row.ItemArray.Select(field => field.ToString()).ToArray();
                    sb.AppendLine(string.Join(",", fields));

                }

                //Add column names (Type)
                columnNames = new String[] { "SELECT Code", "Description" };
                sb.AppendLine(string.Join(",", columnNames));

                //Add Rows
                foreach (DataRow row in dataTableContact.Rows)
                {
                    string[] fields = row.ItemArray.Select(field => field.ToString()).ToArray();
                    sb.AppendLine(string.Join(",", fields));
                }

                foreach (DataRow row in dataTableAddress.Rows)
                {
                    string[] fields = row.ItemArray.Select(field => field.ToString()).ToArray();
                    sb.AppendLine(string.Join(",", fields));
                }

                foreach (DataRow row in dataTableEmail.Rows)
                {
                    string[] fields = row.ItemArray.Select(field => field.ToString()).ToArray();
                    sb.AppendLine(string.Join(",", fields));
                }

                foreach (DataRow row in dataTablePhone.Rows)
                {
                    string[] fields = row.ItemArray.Select(field => field.ToString()).ToArray();
                    sb.AppendLine(string.Join(",", fields));
                }

                foreach (DataRow row in dataTableType.Rows)
                {
                    string[] fields = row.ItemArray.Select(field => field.ToString()).ToArray();
                    sb.AppendLine(string.Join(",", fields));
                }



                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*";
                saveFileDialog.FilterIndex = 1;

                if (saveFileDialog.ShowDialog() == true)
                {
                    string filePath = saveFileDialog.FileName;
                    File.WriteAllText(filePath, sb.ToString());
                    Console.WriteLine("Data exported successfully!");
                }



                connection.Close();

            }
        }
    }
}

