using System;
using System.Collections.Generic;
using System.Linq;

public abstract class Item
{
    public int Id { get; set; }
    public string Name { get; set; }
    public double Cost { get; set; }
}

public class Inventory<T> where T : Item
{
    private List<T> _items = new List<T>();
    private Dictionary<int, int> _stock = new Dictionary<int, int>();

    public void AddItem(T item, int quantity)
    {
        if (!_items.Any(i => i.Id == item.Id))
        {
            _items.Add(item);
        }

        if (_stock.ContainsKey(item.Id))
        {
            _stock[item.Id] += quantity;
        }
        else
        {
            _stock.Add(item.Id, quantity);
        }
    }

    public void RemoveStock(int id, int quantity)
    {
        if (_stock.ContainsKey(id))
        {
            _stock[id] -= quantity;

            if (_stock[id] <= 0)
            {
                _stock.Remove(id);
                _items.RemoveAll(i => i.Id == id);
            }
        }
        else
        {
            Console.WriteLine("Item not found in stock.");
        }
    }

    public double GetTotalInventoryValue()
    {
        return _items.Sum(item =>
            item.Cost * (_stock.ContainsKey(item.Id) ? _stock[item.Id] : 0)
        );
    }

    public List<T> GetTopStockItems(int n)
    {
        return _items
            .Where(i => _stock.ContainsKey(i.Id))
            .OrderByDescending(i => _stock[i.Id])
            .Take(n)
            .ToList();
    }
}

class Book : Item { }
class Toy : Item { }

public class Program
{
    public static void Main(string[] args)
    {
        Inventory<Book> bookInventory = new Inventory<Book>();

        // Add books
        bookInventory.AddItem(new Book { Id = 1, Name = "C# Basics", Cost = 500 }, 10);
        bookInventory.AddItem(new Book { Id = 2, Name = "LINQ Mastery", Cost = 700 }, 5);
        bookInventory.AddItem(new Book { Id = 3, Name = "OOP Concepts", Cost = 600 }, 8);

        Console.WriteLine("Initial Total Inventory Value: " + 
            bookInventory.GetTotalInventoryValue());

        Console.WriteLine();

        // Show top 2 stock items
        var topItems = bookInventory.GetTopStockItems(2);

        Console.WriteLine("Top 2 Items by Stock:");
        foreach (var item in topItems)
        {
            Console.WriteLine($"{item.Name}");
        }

        Console.WriteLine();

        // Remove stock
        bookInventory.RemoveStock(1, 10);

        Console.WriteLine("Total Inventory Value After Removing Stock: " + 
            bookInventory.GetTotalInventoryValue());
    }
}
