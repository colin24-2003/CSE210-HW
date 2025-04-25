using System;

class Program
{
    static void Main(string[] args)
    {
        // A program to computer the area of a circle 

        // Get radius from user
        Console.Write("Enter the radius of the circle: ");
        // readLine is  getting input from user
        string userInput = Console.ReadLine();
        // Parse is typecasting from string into double 
        double radius = double.Parse(userInput);
        //calculating area
        double area = Math.PI * radius * radius;
        /* int x = 3;
         string s = "Goodbye";
         float f = 3.14F;
         double d = 5.21;
         long n = 25; */
        // Below is c# version of an F-string
        // "" is string '' is 1 char
        Console.WriteLine($"Area of the circle: {Math.Round(area, 2)}");
    }
}