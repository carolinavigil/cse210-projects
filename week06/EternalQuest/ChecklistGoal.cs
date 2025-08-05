public class ChecklistGoal : Goal
{
    private int _targetCount;
    private int _bonus;
    private int _currentCount = 0;

    public ChecklistGoal(string name, string description, int points, int targetCount, int bonus)
        : base(name, description, points)
    {
        _targetCount = targetCount;
        _bonus = bonus;
    }

    public override int RecordEvent()
    {
        _currentCount++;
        return _currentCount == _targetCount ? _points + _bonus : _points;
    }

    public override bool IsComplete() => _currentCount >= _targetCount;

    public override string GetDetailsString()
    {
        string status = IsComplete() ? "[X]" : "[ ]";
        return $"{status} {_name} ({_description}) -- Completed {_currentCount}/{_targetCount}";
    }

    public override string GetStringRepresentation()
    {
        return $"ChecklistGoal|{_name}|{_description}|{_points}|{_bonus}|{_targetCount}|{_currentCount}";
    }
}
