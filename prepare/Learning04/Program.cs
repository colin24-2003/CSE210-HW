using System;

class Program
{
    static void Main(string[] args)
    {
        Assignments assignments = new Assignments("Colin", "Math"); // inserting values as parameters in the new object 
        MathAssignment mathAssignment1 = new MathAssignment("Colin", "Fractions", "Section 7.3", "8-19");
        WritingAssignment writingAssignment1 = new WritingAssignment("Colin", "English", "The Causes of World War II by");
        Console.WriteLine(assignments.GetSummary()); // object.doSomething with the command
        Console.WriteLine(mathAssignment1.GetHomeworkList());
        Console.WriteLine(writingAssignment1.GetWritingInformation());
    }
}