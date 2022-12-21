using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Net;
using System.Security.Policy;

namespace ContactManagerProject.DB
{
    internal class DB
    {
        //GetContacts - show just a few details
        public static List<Contact> GetContacts()
        {
            using (SqlConnection connection = ((App)Application.Current).connection)
            {
                connection.Open();

                SqlCommand command = new SqlCommand("SELECT Contact.*, ContactImage.Image FROM Contact " +
                    "LEFT JOIN ContactImage ON Contact.ContactImage_ID = ContactImage.ID;", connection);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    List<Contact> contacts = new List<Contact>();
                    while (reader.Read())
                    {
                        contacts.Add(new Contact((int)reader["ID"], (string)reader["FirstName"],
                        (string)reader["MiddleName"], (string)reader["LastName"], (string)reader["Salutation"],
                        (DateTime)reader["CreateDateTime"], (DateTime)reader["UpdateDateTime"]));
                    }
                    // Call Close when done reading.
                    reader.Close();

                    return contacts;
                }
            }
        }

        //Get Contact - show more details for an ID
        public static Contact GetContact(int contactID)
        {
            List<Address> addresses = GetAddressesForContact(contactID);
            List<Phone> phones = GetPhonesForContact(contactID);
            List<Email> emails = GetEmailsForContact(contactID);

            using (SqlConnection connection = ((App)Application.Current).connection)
            {
                connection.Open();

                SqlCommand command = new SqlCommand("SELECT TOP 1 Contact.*, ContactImage.Image FROM Contact " +
                    "LEFT JOIN ContactImage ON Contact.ContactImage_ID = ContactImage.ID " +
                    "WHERE Contact.ID = @id;", connection);

                command.Parameters.AddWithValue("@id", contactID);

                using(SqlDataReader reader = command.ExecuteReader())
                {
                    reader.Read();

                    Contact contact = new Contact((int)reader["ID"], (string)reader["FirstName"],
                        (string)reader["MiddleName"], (string)reader["LastName"], (string)reader["Salutation"],
                        (DateTime)reader["CreateDateTime"], (DateTime)reader["UpdateDateTime"]);

                    // Call Close when done reading.
                    reader.Close();

                    contact.Addresses = addresses; 
                    contact.Phones = phones;
                    contact.Emails = emails;

                    return contact;
                }
            }
        }



        //GetAddress - shows an address for address ID

        public static Address GetAddress(int addressID)
        {
            using (SqlConnection connection = ((App)Application.Current).connection)
            {
                connection.Open();

                SqlCommand command = new SqlCommand("SELECT Address.Contact_ID, Address.ID, Address.Country, Address.City," +
                    " Address.Street, Address.AddressNumber, Type.Description " +
                    "FROM Address" +
                    " JOIN Type ON Address.Type = Type.Code " +
                    "WHERE Address.ID = @id;", connection);

                command.Parameters.AddWithValue("@id", addressID);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    reader.Read();

                    Address address = new Address((int)reader["ID"], (string)reader["Country"], (string)reader["City"],
                        (string)reader["Street"], (string)reader["Addressnumber"]);

                    reader.Close();

                    return address;
                }

            }
        }

        //GetAddressForContact - Get all addresses for a contact ID (limited detail)

        public static List<Address> GetAddressesForContact(int contactID)
        {

            using (SqlConnection connection = ((App)Application.Current).connection)
            {
                connection.Open();

                SqlCommand command = new SqlCommand("SELECT Address.Contact_ID, Address.ID, Address.Country, Address.City," +
                    " Address.Street, Address.AddressNumber, Type.Description " +
                    "FROM Address" +
                    " JOIN Type ON Address.Type = Type.Code " +
                    "WHERE Address.Contact_ID = @id;", connection);

                command.Parameters.AddWithValue("@id", contactID);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    List<Address> addresses = new List<Address>();
                    while (reader.Read())
                    {
                        addresses.Add(new Address((int)reader["ID"], (string)reader["Country"], (string)reader["City"],
                        (string)reader["Street"], (string)reader["Addressnumber"]));
                    }

                    reader.Close();

                    return addresses;
                }

            }
        }

        //Get Phones
        public static Phone GetPhone(int phoneID)
        {
            using (SqlConnection connection = ((App)Application.Current).connection)
            {
                SqlCommand command = new SqlCommand("SELECT Phone.Contact_ID, Phone.ID, Phone.Number, Type.Description " +
                    "FROM Phone " +
                    "JOIN Type ON Phone.Type = Type.Code  " +
                    "WHERE Phone.ID = @id ;", connection);

                command.Parameters.AddWithValue("@id", phoneID);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    reader.Read();

                    Phone phone = new Phone((int)reader["ID"], (string)reader["Number"],
                        (DateTime)reader["CreateDateTime"], (DateTime)reader["UpdateDateTime"]);

                    reader.Close();

                    return phone;
                }

            }
        }
        //Get all phones for a contactID
        public static List<Phone> GetPhonesForContact(int contactID)
        {
            using (SqlConnection connection = ((App)Application.Current).connection)
            {
                SqlCommand command = new SqlCommand("SELECT Phone.Contact_ID, Phone.ID, Phone.Number, Type.Description " +
                    "FROM Phone " +
                    "JOIN Type ON Phone.Type = Type.Code  " +
                    "WHERE Phone.Contact_ID = @id ;", connection); 

                command.Parameters.AddWithValue("@id", contactID);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    reader.Read();

                    List<Phone> phones = new List<Phone>();
                    while (reader.Read())
                    {
                        phones.Add(new Phone((int)reader["ID"], (string)reader["Number"],
                        (DateTime)reader["CreateDateTime"], (DateTime)reader["UpdateDateTime"]));
                    }

                    reader.Close();

                    return phones;
                }
            }
        }


        // GET email
        public static Email GetEmail(int emailID)
        {
            using (SqlConnection connection = ((App)Application.Current).connection)
            {
                SqlCommand command = new SqlCommand("SELECT Email.Contact_ID, Email.ID, Email.EmailAddress, " +
                    "Type.Description FROM Email " +
                    "JOIN Type ON Email.Type = Type.Code " +
                    "WHERE Email.ID = @id ;", connection);

                command.Parameters.AddWithValue("@id", emailID);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    reader.Read();

                    Email email = new Email((int)reader["ID"], (string)reader["EmailAddress"]);

                    reader.Close();

                    return email;
                }
            }
        }

        //Get emails for a contactID
        public static List<Email> GetEmailsForContact(int contactID)
        {
            using (SqlConnection connection = ((App)Application.Current).connection)
            {
                SqlCommand command = new SqlCommand("SELECT Email.Contact_ID, Email.ID, Email.EmailAddress, " +
                    "Type.Description FROM Email " +
                    "JOIN Type ON Email.Type = Type.Code " +
                    "WHERE Email.Contact_ID = @id ;", connection);

                command.Parameters.AddWithValue("@id", contactID);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    reader.Read();

                    List<Email> emails = new List<Email>();
                    while (reader.Read())
                    {
                        emails.Add(new Email((int)reader["ID"], (string)reader["EmailAddress"]));
                    }

                    reader.Close();

                    return emails;
                }
            }
        }

        //Get Type
        public static Type GetType(char code)
        {
            using (SqlConnection connection = ((App)Application.Current).connection)
            {
                SqlCommand command = new SqlCommand("SELECT * FROM Type " +
                    "WHERE Type.Code = @code ;", connection);

                command.Parameters.AddWithValue("@code", code);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    reader.Read();

                    Type type = new Type((char)reader["Code"], (string)reader["Description"]);

                    reader.Close();

                    return type;
                }

            }
        }

        //------------------------------------------------(ADDING)--------------------------------------------------------------


        //add contact
        public static void AddContact(Contact contact)
        {
            using (SqlConnection connection = ((App)Application.Current).connection)
            {
                connection.Open();

                SqlCommand command = new SqlCommand(
                    "INSERT INTO Contact (FirstName, MiddleName, LastName, Salutation) " +
                    "OUTPUT inserted.ID " +
                    "VALUES (@FirstName, @MiddleName, @LastName, @Salutation);"
                    , connection);


                command.Parameters.AddWithValue("@FirstName", contact.FirstName);
                command.Parameters.AddWithValue("@MiddleName", contact.MiddleName);
                command.Parameters.AddWithValue("@LastName", contact.LastName);
                command.Parameters.AddWithValue("@Salutation", contact.Salutation);

                contact.id = (int)command.ExecuteScalar();
                
            }
        }

        //add Address
        public static void AddAddress(Address address)
        {
            using (SqlConnection connection = ((App)Application.Current).connection)
            {
                connection.Open();

                SqlCommand command = new SqlCommand(
                    "INSERT INTO Address (Contact_ID, Country, City, Street, AddressNumber, Type) " +
                    "OUTPUT inserted.ID " +
                    "VALUES (@Contact_ID, @Country, @City, @Street, @AddressNumber, @Type);"
                    , connection);


                command.Parameters.AddWithValue("@Contact_ID", address.Contact.id);
                command.Parameters.AddWithValue("@Country", address.Country);
                command.Parameters.AddWithValue("@City", address.City);
                command.Parameters.AddWithValue("@Street", address.Street);
                command.Parameters.AddWithValue("@AddressNumber", address.AddressNumber);
                command.Parameters.AddWithValue("@Type", address.Type);

                address.id = (int)command.ExecuteScalar();
            }
        }

        //add Phone 
        public static void AddPhone(Phone phone) 
        {
            using (SqlConnection connection = ((App)Application.Current).connection)
            {
                connection.Open();

                SqlCommand command = new SqlCommand(
                    "INSERT INTO Phone (Contact_ID ,Type, Number) " +
                    "OUTPUT inserted.ID " +
                    "VALUES (@Contact_ID, @Type, @Number );"
                    , connection);


                command.Parameters.AddWithValue("@Contact_ID", phone.Contact.id);
                command.Parameters.AddWithValue("@Type", phone.Type);
                command.Parameters.AddWithValue("@Number", phone.Number);

                phone.id = (int)command.ExecuteScalar();
            }
        }

        //addEmail
        public static void AddEmail(Email email)
        {
            using (SqlConnection connection = ((App)Application.Current).connection)
            {
                connection.Open();

                SqlCommand command = new SqlCommand(
                    "INSERT INTO Phone (Contact_ID ,Type, EmailAddress) " +
                    "OUTPUT inserted.ID " +
                    "VALUES (@Contact_ID, @Type, @EmailAddress );"
                    , connection);


                command.Parameters.AddWithValue("@Contact_ID", email.Contact.id);
                command.Parameters.AddWithValue("@Type", email.Type);
                command.Parameters.AddWithValue("@EmailAddress", email.EmailAddress);

                email.id = (int)command.ExecuteScalar();
            }
        }
        //---------------------------------------------------------(UPDATE DATA)--------------------------------------------------------------------------

        //UPDATE Contact
        public static void UpdateContact(Contact contact)
        {
            using (SqlConnection connection = ((App)Application.Current).connection)
            {
                connection.Open();

                SqlCommand command = new SqlCommand(
                    "UPDATE Contact SET (" +
                    "FirstName = @FirstName, MiddleName = @MiddleName, LastName = @LastName, Salutation = @Salutation) " +
                    "WHERE ID = @id ;"
                    , connection);


                command.Parameters.AddWithValue("@FirstName", contact.FirstName);
                command.Parameters.AddWithValue("@MiddleName", contact.MiddleName);
                command.Parameters.AddWithValue("@LastName", contact.LastName);
                command.Parameters.AddWithValue("@Salutation", contact.Salutation);
                command.Parameters.AddWithValue("@id", contact.id);

                command.ExecuteNonQuery();

            }
        }

        //UPDATE Address
        public static void UpdateAddress(Address address, Contact contact)
        {
            using (SqlConnection connection = ((App)Application.Current).connection)
            {
                connection.Open();

                SqlCommand command = new SqlCommand(
                    "UPDATE Address SET (" +
                    "Contact_ID = @Contact_ID, Country = @Country , City = @City, Street = @Street, AddressNumber = @AddressNumber, Type = @Type) " +
                    "WHERE ID = @id ;"
                    , connection);


                command.Parameters.AddWithValue("@Contact_ID", contact.id);
                command.Parameters.AddWithValue("@Country", address.Country);
                command.Parameters.AddWithValue("@City", address.City);
                command.Parameters.AddWithValue("@Street", address.Street);
                command.Parameters.AddWithValue("@AddressNumber", address.AddressNumber);
                command.Parameters.AddWithValue("@Type", address.Type);
                command.Parameters.AddWithValue("@id", address.id);

                command.ExecuteNonQuery();
            }
        }

        //UPDATE Phone
        public static void UpdatePhone(Phone phone, Contact contact)
        {
            using (SqlConnection connection = ((App)Application.Current).connection)
            {
                connection.Open();

                SqlCommand command = new SqlCommand(
                    "UPDATE Phone SET (" +
                    "Contact_ID = @Contact_ID ,Type = @Type, Number = @Number) " +
                    "WHERE ID = @id ;"
                    , connection);


                command.Parameters.AddWithValue("@Contact_ID", contact.id);
                command.Parameters.AddWithValue("@Type", phone.Type);
                command.Parameters.AddWithValue("@Number", phone.Number);
                command.Parameters.AddWithValue("@id", phone.id);

                command.ExecuteNonQuery();
            }
        }

        //UPDATE Email
        public static void UpdateEmail(Email email, Contact contact)
        {
            using (SqlConnection connection = ((App)Application.Current).connection)
            {
                connection.Open();

                SqlCommand command = new SqlCommand(
                    "UPDATE Email SET (" +
                    "Contact_ID = @Contact_ID ,Type = @Type, EmailAddress = @EmailAddress) " +
                    "WHERE ID = @id ;"
                    , connection);


                command.Parameters.AddWithValue("@Contact_ID", contact.id);
                command.Parameters.AddWithValue("@Type", email.Type);
                command.Parameters.AddWithValue("@EmailAddress", email.EmailAddress);
                command.Parameters.AddWithValue("@id", email.id);

                command.ExecuteNonQuery();
            }
        }
        //-----------------------------------------------------------(DELETE DATA)-------------------------------------------------------------------------

        //Delete Contact
        public static void DeleteContac(Contact contact)
        {
            using (SqlConnection connection = ((App)Application.Current).connection)
            {
                connection.Open();

                SqlCommand command = new SqlCommand(
                    "DELETE FROM Contact WHERE ID = @id ;"
                    , connection);

                command.Parameters.AddWithValue("@id", contact.id);

                command.ExecuteNonQuery();

            }
        }

        //Delete Address
        public static void DeleteAddress(Address address)
        {
            using (SqlConnection connection = ((App)Application.Current).connection)
            {
                connection.Open();

                SqlCommand command = new SqlCommand(
                    "DELETE FROM Address WHERE ID = @id ;"
                    , connection);

                command.Parameters.AddWithValue("@id", address.id);

                command.ExecuteNonQuery();

            }
        }

        //Delete Phone
        public static void DeletePhonec(Phone phone)
        {
            using (SqlConnection connection = ((App)Application.Current).connection)
            {
                connection.Open();

                SqlCommand command = new SqlCommand(
                    "DELETE FROM Phone WHERE ID = @id ;"
                    , connection);

                command.Parameters.AddWithValue("@id", phone.id);

                command.ExecuteNonQuery();

            }
        }

        //Delete Email
        public static void DeleteEmail(Email email)
        {
            using (SqlConnection connection = ((App)Application.Current).connection)
            {
                connection.Open();

                SqlCommand command = new SqlCommand(
                    "DELETE FROM Email WHERE ID = @id ;"
                    , connection);

                command.Parameters.AddWithValue("@id", email.id);

                command.ExecuteNonQuery();

            }
        }
    }
}
