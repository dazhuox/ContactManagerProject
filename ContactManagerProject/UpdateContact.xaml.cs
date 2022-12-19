using System.Data;
using System.Windows;

namespace ContactManagerProject
{
    /// <summary>
    /// Interaction logic for UpdateContact.xaml
    /// </summary>
    public partial class UpdateContact : Window
    {
        public DataView SingleContact { get; set; }
        public UpdateContact()
        {
            InitializeComponent();

            //SingleContact = Contact.Find(1).AsDataView();

        }
    }
}
