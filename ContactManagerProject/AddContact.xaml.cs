using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace ContactManagerProject
{
    /// <summary>
    /// Interaction logic for AddContact.xaml
    /// </summary>
    public partial class AddContact : Window
    {
        public AddContact()
        {
            InitializeComponent();

            contact = new Contact("First Name" , "Middle Name", "Last Name", "Salutation");

            phone = new Phone("Phone Number");

            contact.Phones.Add(phone);

            DataContext = this.contact;

        }

        internal AddContact(Contact selectedContact)
        {
            contact = selectedContact;

            InitializeComponent();

            DataContext = this.contact;

        }

        internal Contact contact { get; set; }

        internal Phone phone { get; set; }

        internal Email email { get; set; }  

        private void AddAddressButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void UpdateCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void DeleteContact_Click(object sender, RoutedEventArgs e)
        {
            DB.DB.DeleteContac(contact);
            this.Close();
        }

        private void Company_update_TextChanged(object sender, TextChangedEventArgs e)
        {

        }


    }
}
