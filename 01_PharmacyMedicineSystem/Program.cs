using System;
using Domain;
using Services;
using Exceptions;
namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            ManagementService service = new ManagementService();

            while (true)
            {
                Console.WriteLine("1 → Display all medicines");
                Console.WriteLine("2 → Update medicine price");
                Console.WriteLine("3 → Add medicine");
                Console.WriteLine("4 → Exit");

                int choice = int.Parse(Console.ReadLine());

                try
                {
                    switch (choice)
                    {
                        case 1:
                            foreach (var entity in service.GetAll())
                            {
                                Medicine med = entity as Medicine;
                                Console.WriteLine($"Details: {med.Id} {med.Name} {med.Price} {med.ExpiryYear}");
                            }
                            break;

                        case 2:
                            Console.WriteLine("Enter Medicine Id:");
                            string id = Console.ReadLine();

                            Console.WriteLine("Enter New Price:");
                            int price = int.Parse(Console.ReadLine());

                            service.UpdateEntity(id, price);
                            Console.WriteLine("Price Updated Successfully");
                            break;

                        case 3:
                            Console.WriteLine("Enter MedicineID Name Price ExpiryYear:");
                            string[] input = Console.ReadLine().Split(' ');

                            Medicine medicine = new Medicine
                            {
                                Id = input[0],
                                Name = input[1],
                                Price = int.Parse(input[2]),
                                ExpiryYear = int.Parse(input[3])
                            };

                            service.AddEntity(medicine.ExpiryYear, medicine);
                            Console.WriteLine("Medicine Added Successfully");
                            break;

                        case 4:
                            Console.WriteLine("Thank You");
                            return;

                        default:
                            Console.WriteLine("Invalid Choice");
                            break;
                    }
                }
                catch (CustomBaseException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
