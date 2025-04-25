using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("What is your grade percentage?: ");
        string grade = Console.ReadLine();
        int userGrade = int.Parse(grade);
        char letterGrade = 'F';
        if (userGrade >= 90)
        {
            letterGrade = 'A';
            
        }
        else if (userGrade >= 80 && userGrade < 90)
        {
            letterGrade = 'B';
        }
        else if (userGrade >= 70 && userGrade < 80)
        {
            letterGrade = 'C';
        }
        else if (userGrade >= 60 && userGrade < 70)
        {
            letterGrade = 'D';
        }
        else if (userGrade < 60)
        {
            letterGrade = 'F';
        }
        else
        {
            Console.WriteLine("Please enter a valid percentage?: ");
        }
        if (letterGrade == 'A' || letterGrade == 'B' || letterGrade == 'C')
        {
          Console.WriteLine($"You passed! Your grade is {letterGrade}");  
        }
        else if (letterGrade == 'D' || letterGrade == 'F')
        {
            Console.WriteLine($"You didn't pass! Your grade is {letterGrade}");
        }
        
    }
}

/* 
Grading scale

A >= 90
B >= 80
C >= 70
D >= 60
F < 60

passing grade >= 70

output: is the users letter grade along with a message if they passed or not
input: the user needs to input their grade percentage

user_grade = int(input("Enter grade percentage: " ))

if user_grade >= 90:
    letter_grade = "A"
elif user_grade >= 80 and user_grade < 90:
    letter_grade = "B"
elif user_grade >= 70 and user_grade < 80:
    letter_grade = "C"
elif user_grade >= 60 and user_grade < 70:
    letter_grade = "D"
elif user_grade < 60:
    letter_grade = "F"
else:
    print("Please enter a valid grade percentage")
print(f"Your grade is {letter_grade}")

*/