using System;

class Program
{
    static void Main(string[] args)
    {
        Job job1 = new Job(); // this is = to (datatype variable = )
        // job1 is an object from the Job class
        job1._jobTitle = "Software Engineer";
        job1._company = "Microsoft";
        job1._startYer = 2019;
        job1._endYear = 2022;

        Job job2 = new Job();
        job2._jobTitle = "Manager";
        job2._company = "Apple";
        job2._startYer = 2022;
        job2._endYear = 2023;


        // job1.Display(); | this is (object.do something)
        Resume myResume = new Resume();
        myResume._name = "Allison Rose";

        myResume._jobs.Add(job1);
        myResume._jobs.Add(job2);

        myResume.Display();
        
    }
    
}