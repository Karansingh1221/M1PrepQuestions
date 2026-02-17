using System;
using System.Collections.Generic;
class Student{
    public int Id{get;set;}
    public int Age{get;set;}
    public string Name{get;set;}
    public override string ToString(){
        return Id+" "+Age+" "+Name;
    }
    
}
var dict=_carItems.OrederByDescending(x=>x.Id);
foreach(var i in dict){
    Console.WriteLine(i.Key+" "+i.Value);
}
class Program{
    public static void Main(string[] args){
        List<Student> l=new List<Student>();
        int n=int.Parse(Console.ReadLine());
        for(int i=0;i<n;i++){
            string s=Console.ReadLine();
            string[] arr=s.Split(" ");
            Student std=new Student();
            std.Id=Convert.ToInt32(arr[0]);
            std.Age=Convert.ToInt32(arr[1]);
            std.Name=arr[2];
            l.Add(std);
        }

        // List<int> ids=new List<int>{1,2,4};
        // Student newstudent=new Student{Id=1,Age=22,Name="Karan"};
        // ids.Id.Contains(newstudent.Id);
        // if(ids.Contains(newstudent.Id)){
        //     Console.WriteLine()
        // }
        // bool flag=false;
        // foreach(var i in l){
        //     if(newstudent.Name==i.Name){
        //         // newstudent.Id++;
        //         flag=true;
        //     }
        // }
        // Console.WriteLine(newstudent.Id);
        // for(int i=0;i<l.Count;i++){
        //     Console.WriteLine(l[i]);
        // }     
        Dictionary<int,Student> d
        // var i=d.Value.FirstOrDefault(x=>x.Name==name);
        if(i!=null){
            Console.WriteLine(i.Name);
        }        
    }
}