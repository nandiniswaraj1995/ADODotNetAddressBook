using ADODotNetAddressBook.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace ADODotNetAddressBook.Repository
{
    class ContactRepo
    {
        public static string connectionString = @"Data Source=(localdb)\MSSQLLocalDB; Initial Catalog=addressServiceDB;Integrated Security=True";
        public bool AddContact(ContactModel model, BookModel bookModel)
        {
            SqlConnection connection = new SqlConnection(connectionString);
           

            try
            {
                using (connection)
                {
                    SqlCommand command = new SqlCommand("sp_AddContact", connection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@first_name", model.firstName);
                    command.Parameters.AddWithValue("@last_name", model.lastName);
                    command.Parameters.AddWithValue("@address", model.address);
                    command.Parameters.AddWithValue("@city", model.city);
                    command.Parameters.AddWithValue("@state", model.state);
                    command.Parameters.AddWithValue("@zip", model.zip);
                    command.Parameters.AddWithValue("@phone_number", model.phoneNumber);
                    command.Parameters.AddWithValue("@email", model.email);
                    command.Parameters.AddWithValue("@book_name", bookModel.bookName);
                    command.Parameters.AddWithValue("@book_type", bookModel.bookType);


                    connection.Open();
                    var result = command.ExecuteNonQuery();
                    connection.Close();
                    if (result != 0)
                    {
                        return true;
                    }

                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            finally
            {
                connection.Close();
            }
            return false;
        }



    }
}
