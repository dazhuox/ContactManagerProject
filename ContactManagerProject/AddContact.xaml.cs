using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace ContactManagerProject
{
    /// <summary>
    /// Interaction logic for AddContact.xaml
    /// </summary>
    public partial class AddContact : Window
    {
        public DataSet SingleContact { get; set; }

        public AddContact(int? contactID = null)
        {
            InitializeComponent();

            if (contactID != null)
            {
                int IntID = (int)contactID;

                SingleContact = Contact.Find(IntID);
            }
        }

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
    }
}
