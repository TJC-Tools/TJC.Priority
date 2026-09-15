namespace TJC.Priority.Tests;


public class ComparisonTests
{
    [Fact]
    public void CompareTo_HandlesNullPriorityAndUnsupportedObject()
    {
        var priority = new Priority(2);

        Assert.Equal(1, priority.CompareTo((Priority?)null));
        Assert.Equal(1, priority.CompareTo((object?)null));
        Assert.Throws<ArgumentException>(() => priority.CompareTo("priority"));
    }

    [Fact]
    public void EqualityAndComparisonOperators_ComparePriorityValues()
    {
        var first = new Priority(1);
        var equal = new Priority(1);
        var later = new Priority(2);

        Assert.True(first == equal);
        Assert.False(first != equal);
        Assert.True(first < later);
        Assert.True(later > first);
        Assert.True(first <= equal);
        Assert.True(later >= equal);
        Assert.False(first.Equals("priority"));
        Assert.False(((Priority?)null) == first);
        Assert.True(((Priority?)null) == null);
    }

    [Fact]
    public void ComparisonOperators_NullOperand_ThrowArgumentNullException()
    {
        var priority = new Priority();
        Priority? nullPriority = null;

        Assert.Throws<ArgumentNullException>(() => _ = nullPriority! < priority);
        Assert.Throws<ArgumentNullException>(() => _ = priority > nullPriority!);
        Assert.Throws<ArgumentNullException>(() => _ = nullPriority! <= priority);
        Assert.Throws<ArgumentNullException>(() => _ = priority >= nullPriority!);
    }

    [Fact]
    public void Reset_SetsValuesToZero()
    {
        var first = new Priority(3);
        var second = new Priority(5);

        Priority.Reset([first, second]);

        Assert.Equal(0, first.Value);
        Assert.Equal(0, second.Value);
    }
}