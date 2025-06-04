public class WritingAssignment : Assignments
{
    private string _title;


    public WritingAssignment(string studentName, string topic, string title)
        : base(studentName, topic)
    {
        _title = title;
    }


   public string  GetWritingInformation()
    {
        return $"{StudentName} - {Topic}\n {_title} by {StudentName}";
    }

}