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

        internal void editContact(BookModel bookModel)
        {
            if (!bookRepo.GetBookByName(bookModel.bookName, bookModel.bookType))
            {
                Console.WriteLine("Book Name Not Exist");
            }
            else
            {
            ContactModel contactModel = new ContactModel();
                Console.WriteLine("which data you want to edit please enter your choice");
                Console.WriteLine("1.first Name");
                Console.WriteLine("2.last Name");
                Console.WriteLine("3.address");
                Console.WriteLine("4.city ");
                Console.WriteLine("5.state");
                Console.WriteLine("6.zip code");
                Console.WriteLine("7.phone number");
                Console.WriteLine("8.email");
                string choice = Console.ReadLine();
                Console.WriteLine("Enter first Name");
                contactModel.firstName = Console.ReadLine();
                switch(choice)
                {

                    case "1":
                        contactRepo.updateFirstName(contactModel.firstName);
                        break;
                    case "2":
                        contactRepo.updateLastName(contactModel.firstName);
                        break;
                    case "3":
                        contactRepo.updateAddress(contactModel.firstName);
                        break;
                    case "4":
                        contactRepo.updateCity(contactModel.firstName);
                        break;
                    case "5":
                        contactRepo.updateState(contactModel.firstName);
                        break;
                    case "6":
                        contactRepo.updateZip(contactModel.firstName);
                        break;
                    case "7":
                        contactRepo.updatePhoneNumber(contactModel.firstName);
                        break;
                    case "8":
                        contactRepo.updateEmail(contactModel.firstName);
                        break;
                    default:
                        Console.WriteLine("Invalid choice try again!"); 
                        break;

                }

                }

        }
    }
}
