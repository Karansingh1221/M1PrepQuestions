using System;
using System.Text.RegularExpressions;
namespace HealthSync{
    abstract class Consultant{
        public abstract void CalculateGrossPayout();
    }
    class InHouse:Consultant{
        public string Id{get;set;}
        public int Stipend{get;set;}
        public double Allowance{get;set;}
        public double Bonus{get;set;}

        public bool ValidateConsultantId(){
            string pattern=@"^DR\d+$";
            if(Id.Length==6 && Regex.IsMatch(Id,pattern)){
                return true;
            }
            return false;
        }
        public override void CalculateGrossPayout(){

        }
    }
    class Visiting:Consultant{
        public int ConsultantCount{get;set;}
        public int Rate{get;set;}
        public override void CalculateGrossPayout(){
            
        }
    }
}