using System;

public class ChecklistGoal : Goal
{
    private int _target;
    private int _current;
    private int _bonus;

    public ChecklistGoal(string name, string description, int points, int target, int current, int bonus) : base(name, description, points)
    {
        _target = target;
        _current = current;
        _bonus = bonus;
    }

    public int GetTarget()
    {
        return _target;
    }

    public int GetCurrent()
    {
        return _current;
    }

    public void SetCurrent(int current)
    {
        _current = current;
    }

    public int GetBonus()
    {
        return _bonus;
    }

    public override int RecordEvent()
    {
        if (_current < _target)
        {
            SetCurrent(GetCurrent() + 1);
            if (_current == _target)
            {
                return GetPoints() + _bonus;
            }
            return GetPoints();
        }
        return 0;
    }

    public override bool IsComplete()
    {
        return _current >= _target;
    }

    public override string GetStatus()
    {
        return $"({_current}/{_target})";
    }

    public override string GetGoalData()
    {
        return $"{GetType().Name}|{GetName()}|{GetDescription()}|{GetPoints()}|{GetTarget()}|{GetCurrent()}|{GetBonus()}";
    }
}