using ADODotNetAddressBook.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace ADODotNetAddressBook.Repository
{
    class BookRepo
    {
        public static string connectionString = @"Data Source=(localdb)\MSSQLLocalDB; Initial Catalog=addressServiceDB;Integrated Security=True";

        public bool GetBookByName(string bookName,string bookType)
        {
            SqlConnection connection = new SqlConnection(connectionString);

            try
            {
                BookModel model = new BookModel();
                using (connection)
                {
                    string query = @"Select * from book;";
                    SqlCommand cmd = new SqlCommand(query, connection);
                    connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            model.bookName = dr.GetString(0);
                            model.bookType = dr.GetString(1);

                            if (model.bookName == bookName && model.bookType == bookType)
                            {
                                return true;
                            }
                            /*  else if (model.bookName == bookModel.bookName && model.bookType != bookModel.bookType)
                              {
                                  Console.WriteLine("bookType Mismatch!");
                              }*/
                        }
                    }
                }
            }
            catch (Exception e)
            {
                System.Console.WriteLine(e.Message);
            }
            return false;
        }


        public bool AddBook(BookModel model)
        {
            SqlConnection connection = new SqlConnection(connectionString);

            try
            {
                using (connection)
                {
                    SqlCommand command = new SqlCommand("sp_AddBook", connection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@book_name", model.bookName);
                    command.Parameters.AddWithValue("@book_type", model.bookType);
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
