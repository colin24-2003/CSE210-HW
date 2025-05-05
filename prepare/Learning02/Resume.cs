using System.Threading.Tasks.Dataflow;

public class Resume{
    public string _name;

    public List<Job> _jobs = new List<Job>();

    public void Display(){
        Console.WriteLine($"Name: {_name}");
        Console.WriteLine("Jobs: ");

        foreach (Job job in _jobs) // a for loop for each job in jobs
        // Job being the datatype job acting as i (for i in range) and _jobs being the list
        {
            job.Display(); // this is object.do something
        }
    }

    
}