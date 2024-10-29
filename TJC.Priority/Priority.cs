namespace TJC.Priority;

public class Priority : IComparable, IComparable<Priority>, IEquatable<Priority>
{
    #region Fields

    private readonly Guid _id;

    private readonly List<Priority> _allPriorities = [];

    #endregion

    #region Constructors

    public Priority(int value = 0)
    {
        _id = Guid.NewGuid();
        _allPriorities.Add(this);
        Value = value;
    }

    #endregion

    #region Properties

    public double Value { get; private set; }

    #endregion

    #region Methods

    #region Prioritize

    public Priority Then(Priority nextPriority)
    {
        ArgumentNullException.ThrowIfNull(nextPriority);

        nextPriority.Value = Value + 1;
        AddPriorities(nextPriority._allPriorities);
        ReorderPriorities();
        return nextPriority;
    }

    public void Before(Priority otherPriority)
    {
        ArgumentNullException.ThrowIfNull(otherPriority);

        Value = otherPriority.Value - 0.5;
        AddPriorities(otherPriority._allPriorities);
        ReorderPriorities();
    }

    public void After(Priority otherPriority)
    {
        ArgumentNullException.ThrowIfNull(otherPriority);

        Value = otherPriority.Value + 0.5;
        AddPriorities(otherPriority._allPriorities);
        ReorderPriorities();
    }

    public static void Reset(List<Priority> priorities)
    {
        foreach (var priority in priorities)
            priority.Value = 0;
        foreach (var priority in priorities)
            priority._allPriorities.Clear();
    }

    public void Remove(Priority? priority = null)
    {
        _allPriorities.Remove(priority ?? this);
        ReorderPriorities();
    }

    private void AddPriorities(List<Priority> priorities)
    {
        _allPriorities.AddRange(priorities);
        var distinctPriorities = _allPriorities.DistinctBy(x => x._id).ToList();
        _allPriorities.Clear();
        _allPriorities.AddRange(distinctPriorities);
    }

    private void ReorderPriorities()
    {
        _allPriorities.Sort((p1, p2) => p1.Value.CompareTo(p2.Value));
        for (var i = 0; i < _allPriorities.Count; i++)
            _allPriorities[i].Value = i + 1;

        foreach (var priority in _allPriorities.Where(priority => priority._id != _id))
        {
            priority._allPriorities.Clear();
            priority._allPriorities.AddRange(_allPriorities);
        }
    }

    #endregion

    #region Print

    internal static string GetPrioritiesToString(Priority priority) =>
        GetPrioritiesToString(priority._allPriorities);

    internal static string GetPrioritiesToString(List<Priority> priorities)
    {
        var result = string.Empty;
        foreach (var priority in priorities.OrderBy(p => p.Value))
            result += $"Priority [{priority._id}]: {priority.Value}";
        return result;
    }

    #endregion

    #endregion

    #region IComparable & IComparable<Priority>

    public int CompareTo(object? obj)
    {
        return obj switch
        {
            null => 1,
            Priority otherPriority => CompareTo(otherPriority),
            _ => throw new ArgumentException("Object is not a Priority"),
        };
    }

    public int CompareTo(Priority? other) => other is null ? 1 : Value.CompareTo(other.Value);

    #endregion

    #region IEquatable<Priority>

    public override bool Equals(object? obj) =>
        obj is Priority otherPriority && Equals(otherPriority);

    public bool Equals(Priority? other) => Value.Equals(other?.Value);

    public override int GetHashCode() => HashCode.Combine(_id);

    #endregion

    #region Operators

    public static bool operator <(Priority left, Priority right)
    {
        ArgumentNullException.ThrowIfNull(left);
        ArgumentNullException.ThrowIfNull(right);

        return left.CompareTo(right) < 0;
    }

    public static bool operator >(Priority left, Priority right)
    {
        ArgumentNullException.ThrowIfNull(left);
        ArgumentNullException.ThrowIfNull(right);

        return left.CompareTo(right) > 0;
    }

    public static bool operator <=(Priority left, Priority right)
    {
        ArgumentNullException.ThrowIfNull(left);
        ArgumentNullException.ThrowIfNull(right);

        return left.CompareTo(right) <= 0;
    }

    public static bool operator >=(Priority left, Priority right)
    {
        ArgumentNullException.ThrowIfNull(left);
        ArgumentNullException.ThrowIfNull(right);

        return left.CompareTo(right) >= 0;
    }

    public static bool operator ==(Priority? left, Priority? right)
    {
        if (ReferenceEquals(left, right))
            return true;
        if (left is null || right is null)
            return false;
        return left.CompareTo(right) == 0;
    }

    public static bool operator !=(Priority left, Priority right) => !(left == right);

    #endregion
}
