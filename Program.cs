using System;
using System.Collections.Generic;

public class CrudOperations<T> where T : class
{
    private List<T> dataList;

    public CrudOperations()
    {
        dataList = new List<T>();
    }

    // Create
    public void AddItem(T item)
    {
        dataList.Add(item);
        Console.WriteLine("Item added successfully.");
    }

    // Read
    public void DisplayItems()
    {
        Console.WriteLine($"List of {typeof(T).Name}s:");
        foreach (var item in dataList)
        {
            Console.WriteLine(item);
        }
    }

    // Update
    public void UpdateItem(int index, T newItem)
    {
        if (index >= 0 && index < dataList.Count)
        {
            dataList[index] = newItem;
            Console.WriteLine("Item updated successfully.");
        }
        else
        {
            Console.WriteLine("Invalid index. Update failed.");
        }
    }

    // Delete
    public void RemoveItem(int index)
    {
        if ((index-1) >= 0 && (index-1) < dataList.Count)
        {
            dataList.RemoveAt(index-1);
            Console.WriteLine("Item removed successfully.");
        }
        else
        {
            Console.WriteLine("Invalid index. Removal failed.");
        }
    }
}

class Program
{
    static void Main()
    {
        // CRUD for Customer
        CrudOperations<Customer> customerCrud = new CrudOperations<Customer>();
        customerCrud.AddItem(new Customer { Id = 1, Name = "John Doe", Email = "john@example.com" });
        customerCrud.AddItem(new Customer { Id = 2, Name = "Jane Doe", Email = "jane@example.com" });
        customerCrud.DisplayItems();
        customerCrud.UpdateItem(0, new Customer { Id = 1, Name = "Updated John Doe", Email = "updatedjohn@example.com" });
        customerCrud.DisplayItems();
        customerCrud.RemoveItem(1);
        customerCrud.DisplayItems();

        // CRUD for Student
        CrudOperations<Student> studentCrud = new CrudOperations<Student>();
        studentCrud.AddItem(new Student { Id = 101, Name = "Alice", Grade = "A", Email = "alice@example.com" });
        studentCrud.AddItem(new Student { Id = 102, Name = "Bob", Grade = "B", Email = "bob@example.com" });
        studentCrud.DisplayItems();

        // CRUD for Product
        CrudOperations<Product> productCrud = new CrudOperations<Product>();
        productCrud.AddItem(new Product { Id = 1, Name = "Laptop", Price = 999.99 });
        productCrud.AddItem(new Product { Id = 2, Name = "Phone", Price = 499.99 });
        productCrud.DisplayItems();
    }
}

public class Customer
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }

    public override string ToString()
    {
        return $"Customer ID: {Id}, Name: {Name}, Email: {Email}";
    }
}

public class Student
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Grade { get; set; }
    public string Email { get; set; }

    public override string ToString()
    {
        return $"Student ID: {Id}, Name: {Name}, Grade: {Grade}, Email: {Email}";
    }
}

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public double Price { get; set; }

    public override string ToString()
    {
        return $"Product ID: {Id}, Name: {Name}, Price: ${Price}";
    }
}
