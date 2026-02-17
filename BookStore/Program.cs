using System;

namespace BookStoreApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            // TODO:
            // 1. Read initial input
            // Format: BookID Title Price Stock
            try{
                Console.WriteLine("Enter Book Details:");
                Book book = new Book();
                string s=Console.ReadLine();
                string[] details=s.Split(" ");
                if(details.Length>4){
                    Console.WriteLine("Invalid Input");
                    return;
                }
                book.Id=details[0];
                book.Title=details[1];
                // book.Author=details[2];
                book.Price=Convert.ToInt32(details[2]);
                book.Stock=Convert.ToInt32(details[3]);

                BookUtility utility = new BookUtility(book);
                while (true)
                {
                    // TODO:
                    Console.WriteLine("Display menu:");
                    Console.WriteLine("1 -> Display book details");
                    Console.WriteLine("2 -> Update book price");
                    Console.WriteLine("3 -> Update book stock");
                    Console.WriteLine("4 -> Exit");
                    Console.WriteLine("Enter Choice");
                    int choice = 0; // TODO: Read user choice
                    choice=int.Parse(Console.ReadLine());

                    switch (choice)
                    {
                        case 1:
                            utility.GetBookDetails();
                            break;
                        case 2:
                            // TODO:
                            // Read new price
                            // Call UpdateBookPrice()
                            Console.WriteLine("Enter new price");
                            int newPrice=int.Parse(Console.ReadLine());
                            utility.UpdateBookPrice(newPrice);
                            break;

                        case 3:
                            // TODO:
                            // Read new stock
                            // Call UpdateBookStock()
                            Console.WriteLine("Enter new stock");
                            int newStock=int.Parse(Console.ReadLine());
                            utility.UpdateBookStock(newStock);
                            break;

                        case 4:
                            Console.WriteLine("Thank You");
                            Environment.Exit(0);
                            return;

                        default:
                            // TODO: Handle invalid choice
                            Console.WriteLine("Invalid choice");
                            break;
                    }
                }
            }
            catch(Exception ex){
                Console.WriteLine(ex.Message);
            }
        }
        
    }
}
