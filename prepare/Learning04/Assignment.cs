public class Assignments
{
    private string _studentName;
    private string _topic;

    public Assignments(string studentName, string topic) // constructor assigning values 
    {
        _studentName = studentName;
        _topic = topic;
    }

    public string StudentName
    {
        get { return _studentName; }
    }

    public string Topic
    {
        get { return _topic; }
    }

    

    public string GetSummary()
    {
        return $"{_studentName} - {_topic}";
    }
    
}