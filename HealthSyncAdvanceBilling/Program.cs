using System;
namespace HealthSync{
    class Program
    {
        static void Main(string[] args)
        {
            InHouse inHouse = new InHouse { Id = "DR2001", Stipend = 10000, Allowance = 2000, Bonus = 1000 };
            if (!inHouse.ValidateConsultantId())
            {
                Console.WriteLine("Invalid doctor id");
                return;
            }
            inHouse.CalculateGrossPayout();
            inHouse.PrintFinalPayout();
            Console.WriteLine();
            Visiting visiting = new Visiting { Id = "DR8005", ConsultationCount = 10, RatePerVisit = 600 };
            if (!visiting.ValidateConsultantId())
            {
                Console.WriteLine("Invalid doctor id");
                return;
            }
            visiting.CalculateGrossPayout();
            visiting.PrintFinalPayout();
            Console.WriteLine();
            InHouse invalid = new InHouse { Id = "MD1001", Stipend = 5000, Allowance = 500, Bonus = 500 };
            if (!invalid.ValidateConsultantId())
            {
                Console.WriteLine("Invalid doctor id");
                return;
            }
        }
    }
}
