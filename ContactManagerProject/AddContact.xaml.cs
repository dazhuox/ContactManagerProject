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

            DataContext = this.contact;

        }

        internal AddContact(Contact selectedContact)
        {
            contact = selectedContact;

            InitializeComponent();

            DataContext = this.contact;

        }

        internal Contact contact { get; }

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

        private void Company_update_TextChanged(object sender, TextChangedEventArgs e)
        {

        }


    }
}
