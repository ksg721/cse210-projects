using System;
using System.Xml.Serialization;

public class EternalGoal : Goal
{
    private int _timesCompleted;
    public EternalGoal(string name, string description, int points, int timesCompleted) : base(name, description, points)
    {
        _timesCompleted = timesCompleted;
    }

    public int GetTimesCompleted()
    {
        return _timesCompleted;
    }

    public void SetTimesCompleted(int timesCompleted)
    {
        _timesCompleted = timesCompleted;
    }

    public override int RecordEvent()
    {
        SetTimesCompleted(GetTimesCompleted() + 1);
        return GetPoints();
    }

    public override bool IsComplete()
    {
        return false;
    }

    public override string GetStatus()
    {
        return $"Completed {_timesCompleted} times";
    }

    public override string GetGoalData()
    {
        return $"{GetType().Name}|{GetName()}|{GetDescription()}|{GetPoints()}|{GetTimesCompleted()}";
    }
}