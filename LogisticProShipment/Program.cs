using System;
namespace LogisticStore{
    class Program{
        public static void Main(string[] args){
            try{
                Console.WriteLine("Welcome");
                ShipmentDetails s=new ShipmentDetails();
                Console.WriteLine("Enter Shipment Code:");
                s.ShipmentCode=Console.ReadLine();
                if(!s.ValidateShipmentCode()){
                    Console.WriteLine("Invalid shipment code");
                    return;
                }
                Console.WriteLine("Enter Mode");
                s.TransportMode=Console.ReadLine();
                Console.WriteLine("Enter Weight");
                s.Weight=double.Parse(Console.ReadLine());
                Console.WriteLine("Enter StorageType");
                s.StorageType=int.Parse(Console.ReadLine());
                Console.WriteLine($"The total shipping cost is {s.CalculateTotalCost():F2}");
            }
            catch(Exception ex){
                Console.WriteLine(ex.Message);
            }
        }
    }
}