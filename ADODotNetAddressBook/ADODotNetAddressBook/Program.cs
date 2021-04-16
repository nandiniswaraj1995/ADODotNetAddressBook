using ADODotNetAddressBook.Model;
using System;

namespace ADODotNetAddressBook
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Wellcome to Address Book Program!");
            ContactModel m = new ContactModel();
            m.firstName = "oop";
            Console.WriteLine(m.firstName);
            Console.WriteLine(m.lastName);
        }
    }
}
