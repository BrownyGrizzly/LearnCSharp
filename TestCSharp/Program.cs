using System;
using System.Collections.Generic;

class Program
{
    static List<Student> students = new List<Student>();
    static User currentUser;

    static void Main()
    {
        // Initialize some sample data
        students.Add(new Student(1, "John Doe", "john@example.com", "123 Main St", "555-1234"));
        students.Add(new Student(2, "Jane Smith", "jane@example.com", "456 Oak St", "555-5678"));

        // Initialize a sample user
        User sampleUser = new User("admin", "password");

        // Login
        Console.WriteLine("Login to the system");
        Console.Write("Username: ");
        string username = Console.ReadLine();
        Console.Write("Password: ");
        string password = Console.ReadLine();

        if (Login(username, password, sampleUser))
        {
            Console.WriteLine($"Login successful. Welcome, {username}!");

            // Display menu
            while (true)
            {
                Console.WriteLine("\nMenu:");
                Console.WriteLine("1. View all students");
                Console.WriteLine("2. Update student information");
                Console.WriteLine("3. Delete student");
                Console.WriteLine("4. Logout");
                Console.Write("Enter your choice: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        ViewAllStudents();
                        break;
                    case "2":
                        UpdateStudentInformation();
                        break;
                    case "3":
                        DeleteStudent();
                        break;
                    case "4":
                        Logout();
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Try again.");
                        break;
                }
            }
        }
        else
        {
            Console.WriteLine("Login failed. Exiting program.");
        }
    }

    static bool Login(string username, string password, User user)
    {
        if (user != null && username == user.Username && password == user.Password)
        {
            currentUser = user;
            return true;
        }
        return false;
    }

    static void ViewAllStudents()
    {
        Console.WriteLine("\nStudent Information:");
        foreach (var student in students)
        {
            Console.WriteLine(student.ToString());
        }
    }

    static void UpdateStudentInformation()
    {
        Console.Write("Enter student ID to update: ");
        int studentId = int.Parse(Console.ReadLine());

        Student studentToUpdate = students.Find(s => s.StudentId == studentId);

        if (studentToUpdate != null)
        {
            Console.Write("Enter new student name: ");
            string newName = Console.ReadLine();
            Console.Write("Enter new student email: ");
            string newEmail = Console.ReadLine();
            Console.Write("Enter new student address: ");
            string newAddress = Console.ReadLine();
            Console.Write("Enter new student phone: ");
            string newPhone = Console.ReadLine();

            // Update student information
            studentToUpdate.StudentName = newName;
            studentToUpdate.StudentEmail = newEmail;
            studentToUpdate.StudentAddress = newAddress;
            studentToUpdate.StudentPhone = newPhone;

            Console.WriteLine("Student information updated successfully.");
        }
        else
        {
            Console.WriteLine($"Student with ID {studentId} not found.");
        }
    }

    static void DeleteStudent()
    {
        Console.Write("Enter student ID to delete: ");
        int studentId = int.Parse(Console.ReadLine());

        Student studentToDelete = students.Find(s => s.StudentId == studentId);

        if (studentToDelete != null)
        {
            // Delete student from the list
            students.Remove(studentToDelete);
            Console.WriteLine("Student deleted successfully.");
        }
        else
        {
            Console.WriteLine($"Student with ID {studentId} not found.");
        }
    }

    static void Logout()
    {
        currentUser = null;
        Console.WriteLine("Logout successful. Exiting program.");
        Environment.Exit(0);
    }
}

class Student
{
    public int StudentId { get; set; }
    public string StudentName { get; set; }
    public string StudentEmail { get; set; }
    public string StudentAddress { get; set; }
    public string StudentPhone { get; set; }

    public Student(int id, string name, string email, string address, string phone)
    {
        StudentId = id;
        StudentName = name;
        StudentEmail = email;
        StudentAddress = address;
        StudentPhone = phone;
    }

    public override string ToString()
    {
        return $"ID: {StudentId}, Name: {StudentName}, Email: {StudentEmail}, Address: {StudentAddress}, Phone: {StudentPhone}";
    }
}

class User
{
    public string Username { get; set; }
    public string Password { get; set; }

    public User(string username, string password)
    {
        Username = username;
        Password = password;
    }
}
