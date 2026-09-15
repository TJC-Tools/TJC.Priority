namespace TJC.Priority.Tests;

[TestClass]
public class ComparisonTests
{
    [TestMethod]
    public void CompareTo_HandlesNullPriorityAndUnsupportedObject()
    {
        var priority = new Priority(2);

        Assert.AreEqual(1, priority.CompareTo((Priority?)null));
        Assert.AreEqual(1, priority.CompareTo((object?)null));
        Assert.ThrowsException<ArgumentException>(() => priority.CompareTo("priority"));
    }

    [TestMethod]
    public void EqualityAndComparisonOperators_ComparePriorityValues()
    {
        var first = new Priority(1);
        var equal = new Priority(1);
        var later = new Priority(2);

        Assert.IsTrue(first == equal);
        Assert.IsFalse(first != equal);
        Assert.IsTrue(first < later);
        Assert.IsTrue(later > first);
        Assert.IsTrue(first <= equal);
        Assert.IsTrue(later >= equal);
        Assert.IsFalse(first.Equals("priority"));
        Assert.IsFalse(((Priority?)null) == first);
        Assert.IsTrue(((Priority?)null) == null);
    }

    [TestMethod]
    public void ComparisonOperators_NullOperand_ThrowArgumentNullException()
    {
        var priority = new Priority();
        Priority? nullPriority = null;

        Assert.ThrowsException<ArgumentNullException>(() => _ = nullPriority! < priority);
        Assert.ThrowsException<ArgumentNullException>(() => _ = priority > nullPriority!);
        Assert.ThrowsException<ArgumentNullException>(() => _ = nullPriority! <= priority);
        Assert.ThrowsException<ArgumentNullException>(() => _ = priority >= nullPriority!);
    }

    [TestMethod]
    public void Reset_SetsValuesToZero()
    {
        var first = new Priority(3);
        var second = new Priority(5);

        Priority.Reset([first, second]);

        Assert.AreEqual(0, first.Value);
        Assert.AreEqual(0, second.Value);
    }
}
