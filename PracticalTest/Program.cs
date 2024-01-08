using System;
using System.Collections;
using PracticalTest;


class Program
{
    static void Main()
    {
        ContactManager contactManager = new ContactManager();

        while (true)
        {
            Console.WriteLine("\nContact Manager Menu:");
            Console.WriteLine("1. Add new contact");
            Console.WriteLine("2. Find a contact by name");
            Console.WriteLine("3. Display contacts");
            Console.WriteLine("4. Exit");

            try
            {
                Console.Write("Enter your choice: ");
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        contactManager.AddContact();
                        break;
                    case 2:
                        contactManager.FindContactByName();
                        break;
                    case 3:
                        contactManager.DisplayContacts();
                        break;
                    case 4:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}
