// using System;
// using System.Collections.Generic;
// class MainClass{
//     public static bool Validate(string id){
//         for(int i=0;i<id.Length;i++){
//             if(!char.IsDigit(id[i])){
//                 return false;
//             }
//         }
//         return true;
//     }
//     public static void Main(string[] args){
//         string s=Console.ReadLine();
//         string[] arr=s.Split(",");
//         Dictionary<int,bool?> report=new Dictionary<int,bool?>();
//         for(int i=0;i<arr.Length;i++){
//             string[] arr2=arr[i].Split(":");
//             if(Validate(arr2[0])){
//                 int id=Convert.ToInt32(arr2[0]);
//                 if(arr2.Length<2){
//                     report.Add(id,null);
//                 }else{
//                     bool? status=null;
//                     if(arr2[1]=="Present") status=true;
//                     if(arr2[1]=="Absent") status =false;
//                     report.Add(id,status);
//                 }
//             }
//         }
//         int pcount=0;
//         int acount=0;
//         int nmark=0;
//         Console.WriteLine("Attendace report");
//         foreach(var i in report){
//             string mark="";

//             if(i.Value==true){
//                 mark="Present";
//                 pcount++;
//             }else if(i.Value==false){
//                 mark="Absent";
//                 acount++;
//             }else if(i.Value==null){
//                 mark="Not Marked";
//                 nmark++;
//             }
//             Console.WriteLine(i.Key+"->"+mark);
//         }
//         Console.WriteLine("Total Present:"+pcount);
//         Console.WriteLine("Total Absent:"+acount);
//         Console.WriteLine("Not Marked:"+nmark);
//     }
// }