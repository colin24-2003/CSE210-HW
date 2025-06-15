using System;

class Program
{
    static void Main(string[] args)
    {
        Menu();
    }
    static void Menu()
    {
        bool isRunning = true;

        while (isRunning)
        {
            Console.Write($@" Menu Options:
        1. Start Breathing Activity
        2. Start Reflecting Activity
        3. Start Listing Activity
        4. Quit
 Select a choice from the menu: ");


        string userInput1 = Console.ReadLine();
        int userChoice1 = int.Parse(userInput1);


            if (userChoice1 == 1)
            {
                string description = @"This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.";
                Console.WriteLine($"{description} \n");
                Console.Write("How long, in seconds, would you like for your session?: ");
                int duration = int.Parse(Console.ReadLine());
                Breathing breathing1 = new Breathing(duration, description, "Breathing Activity");
                Console.WriteLine("\nGet ready... \n");
                Activity.SpinnerAnimation(3);
                breathing1.RunBreathingExercise(duration, 1000);
                Console.WriteLine("Well done");
                Activity.SpinnerAnimation(3);
                Console.WriteLine($"You have completed another {duration} seconds of the Breathing Activity! ");

            }
            else if (userChoice1 == 2)
            {

                string description = @"This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.";
                Console.WriteLine($"{description} \n");
                Console.Write("How long, in seconds, would you like for your session?: ");
                int duration = int.Parse(Console.ReadLine());
                Reflecting reflecting = new Reflecting(duration, description, "Reflecting Activity");
                Console.WriteLine("\nGet ready... \n");
                Activity.SpinnerAnimation(3);
                reflecting.GetRandomPrompt();
                Console.WriteLine("When you have something in mind please press enter. ");
                Console.ReadLine();
                Console.WriteLine("Now ponder each of the following questions as they related to this experience. ");
                Console.Write("You may begin in: ");
                Activity.CountDown(1000);

                DateTime startTime = DateTime.Now;
                DateTime futureTime = startTime.AddSeconds(duration);
                while (DateTime.Now < futureTime)
                {
                    reflecting.GetRandomQuestion();
                    Activity.SpinnerAnimation(5);
                }
                Console.WriteLine("");
                Console.WriteLine("Well Done!! \n");
                Console.WriteLine($"You have completed another {duration} seconds of the Breathing Activity! ");
                Activity.SpinnerAnimation(3);


            }
            else if (userChoice1 == 3)
            {
                string name = "Listing Activity";
                string description = @"This activity will help you reflect on the good things in your life by having you list
                as many things as you can in a certain area.";
                Console.WriteLine($"Welcome to the {name}\n");
                Console.WriteLine($"{description}\n");
                Console.Write("How long, in seconds, would you like for your session?: ");
                int duration = int.Parse(Console.ReadLine());
                Listing listing = new Listing(duration, description, name);
                Console.WriteLine("\nGet ready... \n");
                Activity.SpinnerAnimation(3);
                listing.GetAndDisplayRandomPrompt();
                Console.WriteLine("");
                Console.WriteLine("Well done! ");
                Console.WriteLine($"You have completed another {duration} seconds of the {name}");
                Activity.SpinnerAnimation(3);
            }
            else if (userChoice1 == 4)
            {
                Console.WriteLine("Thanks for using the Mindfulness Program! ");
                isRunning = false;
            }
        }
        
    }
}