// Goal.cs - Base abstract class for all goal types
public abstract class Goal
{
    private int _points; //points awarded for completing this goal
    private string _description; //detailed description of the goal
    private string _name; //short name/title of the goal
    protected bool _isComplete; //completion status accessible to derived classes

    public int Points
    {
        get { return _points; } //return the points value
        protected set { _points = value; } //allow derived classes to modify points
    }

    public string Description
    {
        get { return _description; } //return the description
        protected set { _description = value; } //allow derived classes to modify description
    }

    public string Name
    {
        get { return _name; } //return the name
        protected set { _name = value; } //allow derived classes to modify name
    }

    public Goal(int points, string description, string name)
    {
        _points = points; //set the points value
        _description = description; //set the description
        _name = name; //set the name
        _isComplete = false; //all goals start as incomplete
    }

    public abstract bool IsComplete(); //must be implemented by derived classes to check completion

    public virtual int RecordEvent()
    {
        return Points; //default behavior returns the goal's point value
    }

    public virtual string GetDisplayInfo()
    {
        string checkbox = IsComplete() ? "[X]" : "[ ]"; //show [X] for complete, [ ] for incomplete
        return $"{checkbox} {_name} ({_description})"; //format display string with checkbox
    }

    public override string ToString()
    {
        return $"{_name}: {_description}"; //basic goal information without status
    }

    public virtual string GetStringRepresentation()
    {
        return $"{GetType().Name}|{_name}|{_description}|{_points}|{_isComplete}"; //format for file storage
    }
}