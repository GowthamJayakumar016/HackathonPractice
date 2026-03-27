// See https://aka.ms/new-console-template for more information
using ConsoleApp2;
using System;

class Program
{
    static void Main()
    {
        AppDbContext context = new AppDbContext();
        Student s= new Student();
        s.Name = "akash";
        context.Students.Add(s);
        context.SaveChanges(); 
        Console.WriteLine("Student record inserted successfully macha 😄");
    }
}

