using System;
namespace LogisticStore{
    public class Shipment{
        public string ShipmentCode{get;set;}
        public string TransportMode{get;set;}
        public double Weight{get;set;}
        public int StorageType{get;set;}
    }
    public class ShipmentDetails:Shipment{
        public bool ValidateShipmentCode(){
            if(ShipmentCode.Length==7 && ShipmentCode.Substring(0,3)=="GC#" && char.IsDigit(ShipmentCode[3])){
                return true;
            }
            return false;
        }
        public double CalculateTotalCost(){
            double rate=0;
            if(TransportMode=="Sea"){
                rate=15.00;
            }else if(TransportMode=="Air"){
                rate=50.00;
            }else if(TransportMode=="Land"){
                rate=25.00;
            }
            double total=(Weight*rate)+Math.Sqrt(StorageType);
            return total;
        }
    }
}