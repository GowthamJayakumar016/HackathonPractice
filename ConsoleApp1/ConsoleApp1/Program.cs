using ConsoleApp1;
using System;

class Program
{
    static void Main()
    {
        AppDbContext context = new AppDbContext();

        //Student s1 = new Student();
        //s1.Name = "Dharun";
        //s1.Age = 21;
        //Student s2 = new Student();
        //s1.Name = "Aravind";
        //s1.Age = 20;
        Teacher t1 = new Teacher();
        t1.Name = "Arun";
        t1.Number = 50;
        //context.Students.Add(s1);
        //context.Students.Add(s2);
        context.Teachers.Add(t1);
        context.SaveChanges();

        Console.WriteLine("Student record inserted successfully macha 😄");

    }
}
