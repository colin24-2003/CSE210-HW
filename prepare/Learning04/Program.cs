using System;

class Program
{
    static void Main(string[] args)
    {
        Assignments a1 = new Assignments("Samuel Bennett", "Multiplication"); // inserting values as parameters in the new object 
        MathAssignment m1 = new MathAssignment("Roberto Rodriguez", "Fractions", "7.3", "8-19");
        WritingAssignment w1 = new WritingAssignment("Mary Waters", "European History", "The Causes of World War II");
        Console.WriteLine(a1.GetSummary()); // object.doSomething with the command
        Console.WriteLine(m1.GetHomeworkList());
        Console.WriteLine(w1.GetWritingInformation());
    }
}