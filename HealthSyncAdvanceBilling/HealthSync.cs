using System;
using System.Text.RegularExpressions;
namespace HealthSync
{
    abstract class Consultant
    {
        public double GrossPay { get; set; }
        public abstract void CalculateGrossPayout();
        public virtual double CalculateTDS()
        {
            if (GrossPay <= 5000)
                return 0.05;
            else
                return 0.15;
        }
        public void PrintFinalPayout()
        {
            double tdsRate = CalculateTDS();
            double taxAmount = GrossPay * tdsRate;
            double netPay = GrossPay - taxAmount;
            Console.WriteLine($"Gross: {GrossPay:F2} | TDS Applied: {tdsRate * 100}% | Net Payout: {netPay:F2}");
        }
    }
    class InHouse : Consultant
    {
        public string Id { get; set; }
        public int Stipend { get; set; }
        public double Allowance { get; set; }
        public double Bonus { get; set; }
        public bool ValidateConsultantId()
        {
            string pattern = @"^DR\d{4}$";
            if (!string.IsNullOrEmpty(Id) && Id.Length == 6 && Regex.IsMatch(Id, pattern))
                return true;
            return false;
        }
        public override void CalculateGrossPayout()
        {
            GrossPay = Stipend + Allowance + Bonus;
        }
    }
    class Visiting : Consultant
    {
        public string Id { get; set; }
        public int ConsultationCount { get; set; }
        public int RatePerVisit { get; set; }
        public bool ValidateConsultantId()
        {
            string pattern = @"^DR\d{4}$";
            if (!string.IsNullOrEmpty(Id) && Id.Length == 6 && Regex.IsMatch(Id, pattern))
                return true;
            return false;
        }
        public override void CalculateGrossPayout()
        {
            GrossPay = ConsultationCount * RatePerVisit;
        }
        public override double CalculateTDS()
        {
            return 0.10;
        }
    }
    
}
