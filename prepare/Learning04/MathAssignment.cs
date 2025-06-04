public class MathAssignment : Assignments
{
    private string _textbookSection;
    private string _problems;

    public MathAssignment(string studentName, string topic, string textbookSection, string problems)
        : base(studentName, topic)
    {
        _textbookSection = textbookSection;
        _problems = problems;
    }

    // Use the public properties StudentName and Topic from the base class
    public string GetHomeworkList()
    {
        return $"{StudentName} - {Topic}\n { _textbookSection} Problems: {_problems}";  // Access via properties, NOT private fields
    }
}
