using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PracticalTest
{
    class ContactManager
    {
        private Hashtable contacts;

        public ContactManager()
        {
            contacts = new Hashtable();
        }

        public void AddContact()
        {
            Console.Write("Enter name: ");
            string name = Console.ReadLine();

            if (contacts.ContainsKey(name))
            {
                Console.WriteLine("Contact with the same name already exists.");
                return;
            }

            Console.Write("Enter phone number: ");
            string phone = Console.ReadLine();

            Contact contact = new Contact(name, phone);
            contacts.Add(name, contact);

            Console.WriteLine("Contact added successfully!");
        }
        public void FindContactByName()
        {
            Console.Write("Enter name to find: ");
            string name = Console.ReadLine();

            if (contacts.ContainsKey(name))
            {
                Contact contact = (Contact)contacts[name];
                Console.WriteLine($"Phone number for {name}: {contact.Phone}");
            }
            else
            {
                Console.WriteLine("Not found.");
            }
        }

        public void DisplayContacts()
        {
            Console.WriteLine("\t\tAddress Book");

            foreach (DictionaryEntry entry in contacts)
            {
                Contact contact = (Contact)entry.Value;
                Console.WriteLine($"Name: {contact.Name}\t\t Phone: {contact.Phone}");
            }
        }
    }
}