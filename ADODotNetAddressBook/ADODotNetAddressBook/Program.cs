using ADODotNetAddressBook.Model;
using ADODotNetAddressBook.Repository;
using System;

namespace ADODotNetAddressBook
{
    class Program
    {
        static void Main(string[] args)
        {
            AddressBookService addressBookService = new AddressBookService();
            BookModel bookModel = new BookModel();
            Console.WriteLine("Wellcome to Address Book Program!");
            Console.WriteLine("Enter your choice");
            string choice = "";
            while(choice != "2")
            {
                Console.WriteLine("1.Add Person");
                Console.WriteLine("2.close Application");
                choice = Console.ReadLine();
                switch(choice)
                {
                    case "1": Console.WriteLine("Enter Book Name in which you want to  add contact");
                        bookModel.bookName = Console.ReadLine();
                        Console.WriteLine("Enter Book Type");
                        bookModel.bookType = Console.ReadLine();
                        addressBookService.contactDetails(bookModel);
                        break;
                    case "2": choice = "2";
                        break;
                    default: Console.WriteLine("Invalid choice try again!");
                        break;

                }
            }
        }
    }
}
