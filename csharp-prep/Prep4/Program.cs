using System;
using System.Collections.Generic;
using System.Linq;
class Program
{
    static void Main(string[] args)
    {
        List<int> nums = new List<int>(); // this is the same as nums = []
        List<int> posNums = new List<int>();
        bool isRunning = true; // this assigns isRunning = true
        Console.WriteLine("Enter a list of numbers, type 0 when done" );
        while (isRunning){ // the start of a while loop. This code will repeat until isRunning is false
            Console.Write("Enter a number: ");
            string userInt = Console.ReadLine(); // puts the user input into the variable userInt
            int intInput = int.Parse(userInt); // this changes the data type into an int
            if (intInput > 0){
                posNums.Add(intInput);
            }
            nums.Add(intInput); // this is like the .append() method in python
            if (intInput == 0){
                isRunning = false; // if statement to turn isRunning into false to stop the while loop
            }
        } // all of these below are the equivelent to min() max() sum() len() sort()
        int maxNum = nums.Max();   
        int sum = nums.Sum();
        int length = nums.Count();
        double average = sum / length;
        int minNum = posNums.Min();
        nums.Sort(); // sorts the lsit in lowest to highest 
        
        Console.WriteLine($"Your sum is {sum} \n");
        Console.WriteLine($"Your average is {average} \n");
        Console.WriteLine($"Your sum is {maxNum} ");
        Console.WriteLine($"Your lowest positive number is {minNum} ");
        Console.WriteLine("Sorted list: " + string.Join(", ", nums));
    }
}
/*  Sample code written in python
nums = []
isRunning = True
print(("Enter a list of numbers, type 0 when done " ))
while isRunning:
    userInput = int(input("Enter a number: " ))
    nums.append(userInput)

    if userInput == 0:
        isRunning = False
        break
    else:
        isRunning = True
average = sum(nums) / len(nums)   
sum = sum(nums)
largest = max(nums)
print(f"This is the numbered list {nums}, the sum is {sum}, the largest number is {largest} the average is {average}")
*/ 

