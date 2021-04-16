using ADODotNetAddressBook.Model;
using ADODotNetAddressBook.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace ADODotNetAddressBook
{
    class AddressBookService
    {
        ContactRepo contactRepo = new ContactRepo();
        BookRepo bookRepo = new BookRepo();

        public void contactDetails(BookModel bookModel)
        {
            if (!bookRepo.GetBookByName(bookModel.bookName,bookModel.bookType))
            {
                bookRepo.AddBook(bookModel);
            }

            ContactModel contactModel = new ContactModel();
            Console.WriteLine("Enter First Name:");
            contactModel.firstName = Console.ReadLine();
            Console.WriteLine("Enter Last Name");
            contactModel.lastName = Console.ReadLine();
            Console.WriteLine("Enter Address");
            contactModel.address = Console.ReadLine();
            Console.WriteLine("Enter City");
            contactModel.city = Console.ReadLine();
            Console.WriteLine("Enter State");
            contactModel.state = Console.ReadLine();
            Console.WriteLine("Enter zip");
            contactModel.zip = Console.ReadLine();
            Console.WriteLine("Enter Phone Number");
            contactModel.phoneNumber = Console.ReadLine();
            Console.WriteLine("Enter Email");
            contactModel.email = Console.ReadLine();

            if (contactRepo.AddContact(contactModel, bookModel))
                Console.WriteLine("Records added successfully");
        }

    }
}
